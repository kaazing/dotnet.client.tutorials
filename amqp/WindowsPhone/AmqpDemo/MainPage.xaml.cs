/**
 * Copyright (c) 2007-2016, Kaazing Corporation. All rights reserved.
 */
using Kaazing.AMQP;
using Kaazing.HTML5;
using Kaazing.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace AmqpDemo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private const int LOG_LIMIT = 50;
        private const int MAX_LOG_SIZE = 100;

        private AmqpClient client = null;
        private AmqpChannel publishChannel = null;
        private AmqpChannel consumeChannel = null;
        private string queueName = "queue" + new Random().Next();
        private string exchangeName = "demo_exchange";
        private string routingKey = "broadcastkey";
        private int lockUIControls = 0;
        private int messageReceived = 0; 
        private bool terminated = false;
        private bool messageFlow = true;
        private Queue<String> logLines = new Queue<String>();

        private delegate void InvokeDelegate();
        public PasswordAuthentication Credentials;
        BasicChallengeHandler basicHandler;
        public AutoResetEvent userInputCompleted = new AutoResetEvent(false);

        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
            basicHandler = BasicChallengeHandler.Create();
            basicHandler.LoginHandler = new DemoLoginHandler(this);
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private void ConnButton_Click(object sender, RoutedEventArgs e)
        {
            if (Interlocked.CompareExchange(ref lockUIControls, 1, 0) == 0)
            {
                string url = UrlBox.Text;
                ConnectButton.IsEnabled = false;
                Task.Run(() =>
                {
                    var t = AMQP_ConnectAsync(url);
                }, CancellationToken.None);
            }
        }

        private void DisconnectButton_Click(object sender, RoutedEventArgs e)
        {
            if (Interlocked.CompareExchange(ref lockUIControls, 1, 0) == 0)
            {
                string url = UrlBox.Text;
                Task.Run(() =>
                {
                    var t = AMQP_CloseAsync(url);
                });
            }
        }

        private void ClearMsgButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Text = "";
        }

        private void FlowButton_Click(object sender, RoutedEventArgs e)
        {
            if (Interlocked.CompareExchange(ref lockUIControls, 1, 0) == 0)
            {
                string exchange = ExchangeBox.Text;
                Task.Run(() =>
                {
                    messageFlow = !messageFlow;
                    var t = AMQP_FlowAsync();
                });
            }
        }

        private void PublishButton_Click(object sender, RoutedEventArgs e)
        {
            if (Interlocked.CompareExchange(ref lockUIControls, 1, 0) == 0)
            {
                string exchange = ExchangeBox.Text;
                string msg = MessageBox.Text;

                Task.Run(() =>
                {
                    var t = AMQP_PublishAsync(exchange, msg);
                });
            }
        }

        private void LogSizeToggle_Click(object sender, RoutedEventArgs e)
        {
            if (this.ControlGrid.Visibility == Visibility.Collapsed)
            {
                ControlGrid.Visibility = Visibility.Visible;
                LogPanel.Height = 240;
                logList.Height = 220;
            }
            else
            {
                ControlGrid.Visibility = Visibility.Collapsed;
                LogPanel.Height = 240 + 290;
                logList.Height = 220 + 290;
            }
        }

        private void ClearOutput_Click(object sender, RoutedEventArgs e)
        {
            logList.Items.Clear();
        }

        private void HandleLog(String message)
        {
            var t = this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                Log(message);
            });
        }

        private void HandleLog(String message, Color foreground)
        {
            var t = this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                Log(message, foreground);
            });
        }

        private void Log(string arg, Color foreground)
        {
            if (logList.Items.Count >= MAX_LOG_SIZE)
            {
                logList.Items.Clear();
            }
            ListBoxItem item = new ListBoxItem();
            item.Content = arg;
            item.Foreground = new SolidColorBrush(foreground);
            logList.Items.Insert(0, item);
        }

        private void Log(string arg)
        {
            ListBoxItem item = new ListBoxItem();
            item.Content = arg;
            logList.Items.Insert(0, item);
        }

        private async Task AMQP_ConnectAsync(string url)
        {
            try
            {
                await Task.Run(() =>
                {
                    try
                    {                     
                        client = new AmqpClient(); 
                        client.ChallengeHandler = basicHandler;
                        client.OpenEvent += new AmqpEventHandler(ConnectedHandler);
                        client.CloseEvent += new AmqpEventHandler(CloseHandler);
                        client.ErrorEvent += new AmqpEventHandler(ConnectionErrorHandler);

                        string virtualHost = "/";

                        if ((url == null) || (url.Length == 0))
                        {
                            url = "wss://sandbox.kaazing.net/amqp091";
                        }

                        HandleLog("\n");
                        HandleLog("CONNECTING as 'guest' to: " + url);

                        try
                        {
                            client.Connect(url, virtualHost, "guest", "guest");
                        }
                        catch (Exception ex)
                        {
                            HandleLog("Exception: " + ex.Message);
                        }
                    }
                    catch (Exception exc)
                    {
                        if (client != null)
                        {
                            client.Disconnect();
                        }

                        HandleLog("CONNECTION FAILED: " + exc.Message);
                        UpdateUI(false);
                    }
                });
            }
            catch (Exception ex)
            {
                HandleLog(ex.Message, Colors.Red);
                UpdateUI(false);
            }
            finally
            {
                Interlocked.CompareExchange(ref lockUIControls, 0, 1);
            }
        }

        private async Task AMQP_CloseAsync(string url)
        {
            try
            {
                HandleLog("DISCONNECTING: " + url);

                await Task.Run(() =>
                {
                    try
                    {
                        terminated = true;
                        if (client != null)
                        {
                            client.Disconnect();
                        }

                        client = null;
                    }
                    catch (Exception exc)
                    {
                        HandleLog("Exception during DISCONNECT: " + exc.Message);
                        UpdateUI(false);
                    }
                });
            }
            catch (Exception ex)
            {
                HandleLog(ex.Message, Colors.Red);
                UpdateUI(false);
            }
            finally
            {
                Interlocked.CompareExchange(ref lockUIControls, 0, 1);
            }
        }

        private async Task AMQP_FlowAsync()
        {
            try
            {
                HandleLog("TURNING MESSAGE FLOW " + (messageFlow ? "ON" : "OFF"));

                await Task.Run(() =>
                {
                    try
                    {
                        consumeChannel.FlowChannel(messageFlow);
                    }
                    catch (Exception exc)
                    {
                        if (client != null)
                        {
                            client.Disconnect();
                        }

                        UpdateUI(false);
                    }
                });
            }
            catch (Exception ex)
            {
                HandleLog(ex.Message, Colors.Red);
            }
            finally
            {
                Interlocked.CompareExchange(ref lockUIControls, 0, 1);
            }
        }

        private async Task AMQP_PublishAsync(string exchange, string message)
        {
            try
            {
                await Task.Run(() =>
                {
                    try
                    {
                        if (message == null || message.Length == 0)
                        {
                            HandleLog("Please enter valid text for AMQP message");
                            return;
                        }

                        PublishBasic(message);
                    }
                    catch (Exception exc)
                    {
                        if (client != null)
                        {
                            client.Disconnect();
                        }
                        UpdateUI(false);
                    }
                });
            }
            catch (Exception ex)
            {
                HandleLog(ex.Message, Colors.Red);
            }
            finally
            {
                Interlocked.CompareExchange(ref lockUIControls, 0, 1);
            }
        }

        private void UpdateUI(bool connected)
        {
            var t = this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                ConnectButton.IsEnabled = !connected;
                DisconnectButton.IsEnabled = connected;
                FlowButton.IsEnabled = connected;
                PublishButton.IsEnabled = connected;

                UrlBox.IsReadOnly = connected;
                ExchangeBox.IsReadOnly = !connected;

                messageReceived = 0;
                MessageCountText.Text = "Message Received: 0";
            });
        }

        private void CreateChannel()
        {
            HandleLog("OPEN: Publish Channel");
            publishChannel = client.OpenChannel();
            publishChannel.OpenEvent += PublishChannelOpenHandler;
            publishChannel.DeclareExchangeEvent += DeclareExchangeOkHandler;
            publishChannel.CloseEvent += PublishChannelCloseHandler;
            publishChannel.ErrorEvent += PublishChannelErrorHandler;

            HandleLog("OPEN: Consume Channel");
            consumeChannel = client.OpenChannel();
            consumeChannel.OpenEvent += ConsumeChannelOpenHandler;
            consumeChannel.DeclareQueueEvent += DeclareQueueOkHandler;
            consumeChannel.BindQueueEvent += BindQueueOkHandler;
            consumeChannel.ConsumeEvent += BasicConsumeOkHandler;
            consumeChannel.MessageEvent += MessageHandler;
            consumeChannel.FlowEvent += FlowOkHandler;
            consumeChannel.CancelEvent += CancelOkBasicHandler;
            consumeChannel.CloseEvent += ChannelCloseHandler;
        }

        private void Disconnect()
        {
            terminated = true;
            if (client != null)
            {
                client.Disconnect();
            }

            client = null;
        }

        /*
         * All registered Event Handlers
         */
        private void CloseHandler(object sender, AmqpEventArgs e)
        {
            if (!terminated)
            {
                Disconnect();
            }

            terminated = false;
            HandleLog("DISCONNECTED");
            UpdateUI(false);
        }

        private void ConnectedHandler(object sender, AmqpEventArgs e)
        {
            var t = this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                HandleLog("CONNECTED");

                exchangeName = ExchangeBox.Text;

                CreateChannel();

                // Ready to process messages
                UpdateUI(true);
            });
        }

        private void ConnectionErrorHandler(object sender, AmqpEventArgs e)
        {
            HandleLog("ERROR:" + e.Message);
        }

        private void PublishChannelOpenHandler(object sender, AmqpEventArgs e)
        {
            HandleLog("OPENED: Publish Channel");

            publishChannel.DeclareExchange(exchangeName, "fanout", false, false, false, null);
        }

        private void PublishChannelErrorHandler(object sender, AmqpEventArgs e)
        {
            HandleLog("ERROR: PUBLISH CHANNEL: " + e.Message);
        }

        private void PublishChannelCloseHandler(object sender, AmqpEventArgs e)
        {
            HandleLog("CLOSED: PUBLISH CHANNEL");
        }

        private void PublishBasic(string text)
        {
            ByteBuffer buffer = new ByteBuffer();
            buffer.PutString(text, System.Text.Encoding.UTF8);
            buffer.Flip();
            AmqpProperties amqpProperties = new AmqpProperties();
            amqpProperties.MessageId = "abcdxyz1234pqr";
            amqpProperties.CorrelationId = "23456";
            amqpProperties.UserId = "guest";
            amqpProperties.ContentType = AmqpProperties.TEXT_PLAIN;
            amqpProperties.DeliveryMode = 1;
            amqpProperties.Priority = 6;
            amqpProperties.Timestamp = DateTime.Now.ToLocalTime();
            AmqpArguments customHeaders = new AmqpArguments();
            customHeaders.AddInteger("KZNG_AMQP_KEY1", 100);
            customHeaders.AddLongString("KZNG_AMQP_KEY2", "Custom Header Value");
            amqpProperties.Headers = customHeaders;
            publishChannel.PublishBasic(buffer, amqpProperties, exchangeName, routingKey, false, false);
            HandleLog("MESSAGE PUBLISHED: " + text);
        }

        private void ConsumeChannelOpenHandler(object sender, AmqpEventArgs e)
        {
            HandleLog("OPENED: Consume Channel");

            consumeChannel.DeclareQueue(queueName, false, false, false, false, false, null)
                            .BindQueue(queueName, exchangeName, routingKey, false, null)
                            .ConsumeBasic(queueName, routingKey, false, false, false, false, null);
        }

        private void DeclareExchangeOkHandler(object sender, AmqpEventArgs e)
        {
            HandleLog("EXCHANGE DECLARED: " + exchangeName);
        }

        private void DeclareQueueOkHandler(object sender, AmqpEventArgs e)
        {
            HandleLog("QUEUE DECLARED: " + queueName);
        }

        private void BindQueueOkHandler(object sender, AmqpEventArgs e)
        {
            HandleLog("QUEUE BOUND: " + exchangeName + "  -  " + queueName);
        }

        private void BasicConsumeOkHandler(object sender, AmqpEventArgs e)
        {
            HandleLog("READY TO CONSUME FROM QUEUE: " + queueName);
        }

        private void ChannelErrorHandler(object sender, AmqpEventArgs e)
        {
            HandleLog("ERROR: " + e.Message);
        }

        private void ChannelCloseHandler(object sender, AmqpEventArgs e)
        {
            HandleLog("CHANNEL CLOSED");
        }

        private void CancelOkBasicHandler(object sender, AmqpEventArgs e)
        {
            HandleLog("BASIC CANCELLED");
        }

        private void FlowOkHandler(object sender, AmqpEventArgs e)
        {
            HandleLog("MESSAGE FLOW: " + (e.IsFlowActive ? "ON" : "OFF"));

            var t = this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                string label = !messageFlow ? "Flow On" : "Flow Off";
                FlowButton.Content = label;
            });
        }

        private void MessageHandler(object sender, AmqpEventArgs e)
        {
            ByteBuffer buf = e.Body;
            string message = buf.GetString(System.Text.Encoding.UTF8);
            HandleLog("MESSAGE CONSUMED: " + message);

            messageReceived++;
            var t = this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                MessageCountText.Text = "Message Received: " + messageReceived;
            });

            // Explicitly acknowledge the message as we are passing
            // 'false' as the value of the 'noAck' parameter in
            // the consumeChannel.ConsumeBasic() call.
            long dt = Convert.ToInt64(e.Arguments["deliveryTag"]);
            ((AmqpChannel)sender).AckBasic(dt, true);
        }

        public void PopupLoginPage()
        {
            var t = this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                if (popup.Child == null)
                {
                    Border border = new Border();

                    StackPanel panel1 = new StackPanel();
                    panel1.Height = 600;
                    panel1.Width = 370;
                    panel1.Background = new SolidColorBrush(Colors.Black);
                    panel1.Opacity = 0.8;
                    StackPanel panel2 = new StackPanel();
                    panel2.Background = new SolidColorBrush(Colors.White);
                    panel2.Opacity = 100;
                    panel2.Margin = new Thickness(0, 50, 0, 0);
                    LogonControl login = new LogonControl();
                    login.parent = this;
                    panel2.Children.Add(login);
                    panel1.Children.Add(panel2);
                    border.Child = panel1;

                    popup.Child = border;
                }
                popup.IsOpen = true;
            });
        }

        public void CloseLoginPage()
        {
            var t = this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                popup.IsOpen = false;
            });
        }
    }
}

