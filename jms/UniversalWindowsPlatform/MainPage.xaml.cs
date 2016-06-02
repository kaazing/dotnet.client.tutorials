using Kaazing.JMS;
using Kaazing.JMS.Stomp;
using Kaazing.Security;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace JmsDemo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private IConnection connection = null;
        private ISession session = null;
        private IMessageConsumer consumer = null;
        private IDictionary<String, List<IMessageConsumer>> consumers = null;
        private int lockUIControls = 0;
        private int messageReceived = 0;
        // username and password from Login Popup Page
        public PasswordAuthentication Credentials;
        BasicChallengeHandler basicHandler;
        public AutoResetEvent userInputCompleted = new AutoResetEvent(false);

        // Constructor
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;

            // Create handler for authentication
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
                ConnectButton.IsEnabled = false;
                string url = UrlBox.Text;
                UrlBox.IsEnabled = false;

                Task.Run(() =>
                {
                    var t = JMS_ConnectAsync(url);
                }, CancellationToken.None);
            }
        }

        private void DisconnectButton_Click(object sender, RoutedEventArgs e)
        {
            if (Interlocked.CompareExchange(ref lockUIControls, 1, 0) == 0)
            {
                Task.Run(() =>
                {
                    var t = JMS_CloseAsync();
                });
            }
        }

        private void ClearMsgButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Text = "";
        }

        private void SubButton_Click(object sender, RoutedEventArgs e)
        {
            if (Interlocked.CompareExchange(ref lockUIControls, 1, 0) == 0)
            {
                string dest = DestinationBox.Text;
                Task.Run(() =>
                {
                    var t = JMS_SubscribeAsync(dest);
                });
            }
        }

        private void UnsubscribeButton_Click(object sender, RoutedEventArgs e)
        {
            if (Interlocked.CompareExchange(ref lockUIControls, 1, 0) == 0)
            {
                string dest = DestinationBox.Text;
                Task.Run(() =>
                {
                    var t = JMS_UnsubscribeAsync(dest);
                });
            }
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            if (Interlocked.CompareExchange(ref lockUIControls, 1, 0) == 0)
            {
                string dest = DestinationBox.Text;
                string msg = MessageBox.Text;
                bool binaryMessage = BinaryCheckBox.IsChecked.HasValue && BinaryCheckBox.IsChecked.Value;
                bool showJMSHeaders = ShowJMSHeaders.IsChecked.HasValue && ShowJMSHeaders.IsChecked.Value;
                Task.Run(() =>
                {
                    var t = JMS_SendAsync(dest, msg, binaryMessage, showJMSHeaders);
                });
            }
        }

        private void ClosedHandler()
        {
            var t = this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                Log("CLOSED");
                messageReceived = 0;
                MessageCountText.Text = "Message Received: 0";
                ConnectButton.IsEnabled = true;
                DisconnectButton.IsEnabled = false;

                UrlBox.IsEnabled = true;
                // disable other buttons
                SendButton.IsEnabled = false;
                SubscribeButton.IsEnabled = false;
                UnsubscribeButton.IsEnabled = false;
            });
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

        private const int MAX_LOG_SIZE = 100;
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
            if (logList.Items.Count >= MAX_LOG_SIZE)
            {
                logList.Items.Clear();
            }
            ListBoxItem item = new ListBoxItem();
            item.Content = arg;
            logList.Items.Insert(0, item);
        }
        private async Task JMS_ConnectAsync(string url)
        {
            try
            {
                HandleLog("CONNECT:" + url);

                await Task.Run(() =>
                {
                    try
                    {
                        StompConnectionFactory connectionFactory = new StompConnectionFactory(new Uri(url));
                        ChallengeHandlers.Default = basicHandler;
                        connection = connectionFactory.CreateConnection("", "");
                        connection.ExceptionListener = new ExceptionHandler(this);
                        consumers = new Dictionary<String, List<IMessageConsumer>>();
                        session = connection.CreateSession(false, SessionConstants.AUTO_ACKNOWLEDGE);
                        connection.Start();
                        var t = this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                        {
                            Log("CONNECTED");
                            // Enable User Interface for Connected application
                            SubscribeButton.IsEnabled = true;
                            SendButton.IsEnabled = true;
                            DisconnectButton.IsEnabled = true;
                            ConnectButton.IsEnabled = false;
                        });
                    }
                    catch (Exception exc)
                    {                       
                        if (connection != null)
                        {
                            connection.Close();
                        }

                        var t = this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                        {
                            Log("CONNECTION FAILED: " + exc.Message);
                            UrlBox.IsEnabled = true;
                            ConnectButton.IsEnabled = true;
                        });
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

        private async Task JMS_CloseAsync()
        {
            try
            {
                HandleLog("CLOSING");

                if (connection != null)
                {
                    await Task.Run(() =>
                    {

                        // Close in a new thread to prevent blocking UI
                        try
                        {
                            connection.Close();
                        }
                        catch (Exception exc)
                        {
                            throw exc;
                        }
                        finally
                        {
                            connection = null;
                            ClosedHandler();
                        }
                    });
                }
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

        private async Task JMS_SubscribeAsync(string dest)
        {
            try
            {
                HandleLog("SUBSCRIBE:" + dest);
                if (consumers.ContainsKey(dest))
                {
                    HandleLog("Destion already Consumed:" + dest);
                }
                else
                {
                    IDestination destination;
                    if (dest.StartsWith("/topic/"))
                    {
                        destination = session.CreateTopic(dest);
                    }
                    else if (dest.StartsWith("/queue/"))
                    {
                        destination = session.CreateQueue(dest);
                    }
                    else
                    {
                        throw new ArgumentException("Destination must start with /topic/ or /queue/");
                    }
                    await Task.Run(() =>
                    { 
                        consumer = session.CreateConsumer(destination);
                        consumer.MessageListener = new MessageHandler(this);

                        List<IMessageConsumer> consumerList = new List<IMessageConsumer>();
                        consumerList.Add(consumer);

                        try
                        {
                            consumers.Add(dest, consumerList);
                            var t = this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                            {
                                SubscribeButton.IsEnabled = false;
                                UnsubscribeButton.IsEnabled = true;
                            });

                        }
                        catch (ArgumentException)
                        {

                            // we catch the ArgumentException here, because in Java the the VALUE
                            // is replaced, if a KEY already exists:
                            List<IMessageConsumer> oldValue = consumers[dest];
                            consumers.Remove(dest);
                            consumers.Add(dest, consumerList);
                        }
                    });
                }
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

        private async Task JMS_UnsubscribeAsync(string destinationName)
        {
            try
            {
                HandleLog("UNSUBSCRIBE:" + destinationName);
                await Task.Run(() =>
                {
                    List<IMessageConsumer> consumerList = consumers[destinationName];
                    int consumerlistSize = consumerList.Count;

                    if (consumerlistSize > 0)
                    {
                        IMessageConsumer consumer = (IMessageConsumer)consumerList[consumerlistSize - 1];
                        consumerList.RemoveAt(consumerlistSize - 1);
                        if (consumer != null)
                        {
                            consumer.Close();
                            consumers.Remove(destinationName);
                            var t = this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                            {
                                SubscribeButton.IsEnabled = true;
                                UnsubscribeButton.IsEnabled = false;
                            });

                        }
                        else
                        {
                            throw new ArgumentException("ERROR: Destination not found: " + destinationName);
                        }

                    }
                    else
                    {
                        throw new ArgumentException("ERROR: Destination not found: " + destinationName);
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


        private async Task JMS_SendAsync(string dest, string msg, bool binaryMessage, bool showJMSHeaders)
        {
            try
            {


                // Create a destination for the producer
                IDestination destination;
                if (dest.StartsWith("/topic/"))
                {
                    destination = session.CreateTopic(dest);
                }
                else if (dest.StartsWith("/queue/"))
                {
                    destination = session.CreateQueue(dest);
                }
                else
                {
                    throw new ArgumentException("Destination must start with /topic/ or /queue/");
                }

                // Create the message to send
                IMessage message;
                StringBuilder sb = new StringBuilder();
                if (binaryMessage)
                {
                    sb.AppendLine("SEND BYTE: " + BitConverter.ToString(Encoding.UTF8.GetBytes(msg)) + ": " + dest);
                    message = session.CreateBytesMessage();
                    ((IBytesMessage)message).WriteUTF(msg);
                }
                else
                {
                    sb.AppendLine("SEND TEXT: " + msg + ": " + dest);
                    message = session.CreateTextMessage(msg);
                }

                await Task.Run(() =>
                {
                    // Create the producer, send, and close
                    IMessageProducer producer = session.CreateProducer(destination);
                    try
                    {
                        producer.Send(message);
                        if (showJMSHeaders)
                        {
                            // show JMS message headers
                            if (message.JMSDeliveryMode == Kaazing.JMS.DeliveryModeConstants.NON_PERSISTENT)
                            {
                                sb.AppendLine("DeliveryMode: NON_PERSISTENT");
                            }
                            else if (message.JMSDeliveryMode == Kaazing.JMS.DeliveryModeConstants.PERSISTENT)
                            {
                                sb.AppendLine("DeliveryMode: PERSISTENT");
                            }
                            else
                            {
                                sb.AppendLine("DeliveryMode: UNKNOWN");
                            }
                            sb.AppendLine("JMSPriority: " + message.JMSPriority);
                            sb.AppendLine("JMSMessageID: " + message.JMSMessageID);
                            sb.AppendLine("JMSTimestamp: " + message.JMSTimestamp);
                            sb.AppendLine("JMSCorrelationID: " + message.JMSCorrelationID);
                            sb.AppendLine("JMSType: " + message.JMSType);
                            sb.AppendLine("JMSReplyTo: " + message.JMSReplyTo);
                        }
                        HandleLog(sb.ToString().TrimEnd('\n', '\r'), Colors.Green);
                    }
                    catch (Exception exception)
                    {
                        var t = this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                        {
                            Log("EXCEPTION: " + exception.Message);
                        });
                    }
                    finally
                    {
                        producer.Close();
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


        private void ClearOutput_Click(object sender, RoutedEventArgs e)
        {
            logList.Items.Clear();
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

        class MessageHandler : IMessageListener
        {
            MainPage page;

            internal MessageHandler(MainPage page)
            {
                this.page = page;
            }

            public void OnMessage(IMessage message)
            {
                var t = page.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    StringBuilder sb = new StringBuilder();
                    if (message is ITextMessage)
                    {
                        ITextMessage textMessage = (ITextMessage)message;
                        sb.AppendLine("RECV TEXT: " + textMessage.Text);
                    }
                    else if (message is IBytesMessage)
                    {
                        IBytesMessage msg = (IBytesMessage)message;
                        byte[] actual = new byte[(int)msg.BodyLength];
                        msg.ReadBytes(actual);
                        sb.AppendLine("RECV BYTE: " + BitConverter.ToString(actual));
                    }
                    else if (message is IMapMessage)
                    {
                        IMapMessage mapMessage = (IMapMessage)message;
                        IEnumerator<String> mapNames = mapMessage.MapNames;
                        while (mapNames.MoveNext())
                        {
                            String name = mapNames.Current;
                            Object obj = mapMessage.GetObject(name);
                            if (obj == null)
                            {
                                sb.AppendLine(name + ": null");
                            }
                            else if (obj.GetType().IsArray)
                            {
                                sb.AppendLine(name + ": " + BitConverter.ToString(obj as byte[]) + " (" + obj.GetType().Name + ")");
                            }
                            else
                            {
                                String type = obj.GetType().ToString();
                                sb.AppendLine(name + ": " + obj.ToString() + " (" + type + ")");
                            }
                        }
                        sb.AppendLine("RECV MAP:");
                    }
                    else
                    {
                        sb.AppendLine("UNKNOWN MESSAGE TYPE");
                    }
                    if (page.ShowJMSHeaders.IsChecked.HasValue && page.ShowJMSHeaders.IsChecked.Value)
                    {
                        // show JMS message headers
                        if (message.JMSDeliveryMode == Kaazing.JMS.DeliveryModeConstants.NON_PERSISTENT)
                        {
                            sb.AppendLine("DeliveryMode: NON_PERSISTENT");
                        }
                        else if (message.JMSDeliveryMode == Kaazing.JMS.DeliveryModeConstants.PERSISTENT)
                        {
                            sb.AppendLine("DeliveryMode: PERSISTENT");
                        }
                        else
                        {
                            sb.AppendLine("DeliveryMode: UNKNOWN");
                        }
                        sb.AppendLine("JMSPriority: " + message.JMSPriority);
                        sb.AppendLine("JMSMessageID: " + message.JMSMessageID);
                        sb.AppendLine("JMSTimestamp: " + message.JMSTimestamp);
                        sb.AppendLine("JMSCorrelationID: " + message.JMSCorrelationID);
                        sb.AppendLine("JMSType: " + message.JMSType);
                        sb.AppendLine("JMSReplyTo: " + message.JMSReplyTo);
                    }
                    page.Log(sb.ToString().TrimEnd('\n', '\r'), Colors.Blue);
                    page.MessageCountText.Text = string.Format("Message Received: {0}", ++page.messageReceived);
                });
            }
        }

        class ExceptionHandler : IExceptionListener
        {
            MainPage page;

            internal ExceptionHandler(MainPage page)
            {
                this.page = page;
            }

            public void OnException(JMSException exc)
            {
                if (exc is ConnectionDisconnectedException)
                {
                    page.ClosedHandler();
                }

                page.Log(exc.Message, Colors.Red);
            }
        }

        private void OnUrlTextChanged(object sender, TextChangedEventArgs e)
        {
            if (UrlBox.Text.Length == 0)
            {
                ConnectButton.IsEnabled = false;
            }
            else
            {
                ConnectButton.IsEnabled = true;
            }
        }
    }
}