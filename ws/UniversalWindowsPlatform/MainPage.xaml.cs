using Kaazing.HTML5;
using Kaazing.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace EchoDemo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public PasswordAuthentication Credentials;
        public System.Threading.AutoResetEvent userInputCompleted = new System.Threading.AutoResetEvent(false);

        private WebSocket ws;
        private WebSocketFactory factory;

        // Constructor
        public MainPage()
        {
            InitializeComponent();


            // setup ChallengeHandler
            factory = new WebSocketFactory();
            BasicChallengeHandler handler = BasicChallengeHandler.Create();
            handler.LoginHandler = new LoginHandlerDemo(this);
            factory.ChallengeHandler = handler;
        }

        private void connectButton_Click(object sender, RoutedEventArgs e)
        {
            if (ws == null || ws.ReadyState != WebSocket.OPEN)
            {
                connectButton.IsEnabled = false;
                this.url.IsEnabled = false;
                String url = this.url.Text;
                ws = factory.CreateWebSocket();
                ws.OpenEvent += ws_OpenEvent;
                ws.CloseEvent += ws_CloseEvent;
                ws.MessageEvent += ws_MessageEvent;
                ws.Connect(url);
                log("Connecting to " + url);
            }
        }

        private void disconnectButton_Click(object sender, RoutedEventArgs e)
        {
            if (ws != null && ws.ReadyState == WebSocket.OPEN)
            {
                log("CLOSE");
                ws.Close();
            }
        }

        private void sendButton_Click(object sender, RoutedEventArgs e)
        {
            if (ws != null && ws.ReadyState == WebSocket.OPEN)
            {
                log("SEND: " + this.sendText.Text, Colors.Green);
                string text = this.sendText.Text;
                if ("long".Equals(text))
                {
                    // send large data
                    StringBuilder message = new StringBuilder();
                    message.Append("1");
                    for (int i = 0; i < 20; i++)
                    {
                        String lastMessage = message.ToString();
                        message.Append(lastMessage);
                    }
                    text = message.ToString();

                }
                if ("utf-8".Equals(text))
                {
                    // send large data
                    text = "";
                    for (int i = 0; i < 1024; i++)
                    {
                        text += (char)i;
                    }

                }
                bool? sendBinary = this.binaryButton.IsChecked;
                if (sendBinary.HasValue && sendBinary.Value)
                {
                    ws.Send(ByteBuffer.Wrap(UTF8Encoding.UTF8.GetBytes(text)));
                }
                else
                {
                    ws.Send(text);
                }
            }
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            logList.Items.Clear();
        }

        void ws_MessageEvent(object sender, MessageEventArgs args)
        {
            if (args._buf.Remaining() > 1024)
            {
                switch (args.MessageType)
                {

                    case EventType.BINARY:
                        log("BINARY MESSAGE: Length = " + args.Data.Count, Colors.Blue);
                        break;
                    case EventType.TEXT:
                        log("TEXT MESSAGE: Length = " + args.Data.Count, Colors.Blue);
                        break;
                    case EventType.CLOSE:
                        log("CLOSE MESSAGE: Length = " + args.Data.Count);
                        break;
                }
            }
            else
            {
                switch (args.MessageType)
                {

                    case EventType.BINARY:
                        log("BINARY MESSAGE: " + BitConverter.ToString(args.Data.Array), Colors.Blue);
                        break;
                    case EventType.TEXT:
                        log("TEXT MESSAGE: " + Encoding.UTF8.GetString(args.Data.Array, args.Data.Offset, args.Data.Count), Colors.Blue);
                        break;
                    case EventType.CLOSE:
                        log("CLOSE MESSAGE: " + args.Data);
                        break;
                }

            }
        }

        void ws_OpenEvent(object sender, OpenEventArgs args)
        {
            var t = Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                log("CONNECTED");
                connectButton.IsEnabled = false;
                disconnectButton.IsEnabled = true;
                sendButton.IsEnabled = true;
            });
        }

        void ws_CloseEvent(object sender, CloseEventArgs args)
        {
            var t = Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
           {
               this.url.IsEnabled = true;
               log("CLOSED");
               connectButton.IsEnabled = true;
               disconnectButton.IsEnabled = false;
               sendButton.IsEnabled = false;
           });
        }

        private const int MAX_LOG_SIZE = 100;
        private void log(string message)
        {
            var t = Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                if (logList.Items.Count >= MAX_LOG_SIZE)
                {
                    logList.Items.Clear();
                }
                ListBoxItem item = new ListBoxItem();
                item.Content = message;
                logList.Items.Insert(0, item);

            });
        }

        private void log(string message, Color foreground)
        {
            var t = Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                if (logList.Items.Count >= MAX_LOG_SIZE)
                {
                    logList.Items.Clear();
                }
                ListBoxItem item = new ListBoxItem();
                item.Content = message;
                item.Foreground = new SolidColorBrush(foreground);
                logList.Items.Insert(0, item);

            });
        }
        
        //ChallengeHandler code

        public void AuthenticationHandler()
        {
            //popup login page
            var t = this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                if (loginPopup.Child == null)
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
                    LoginControl login = new LoginControl(this);
                    panel2.Children.Add(login);
                    panel1.Children.Add(panel2);
                    border.Child = panel1;

                    loginPopup.Child = border;
                }
                loginPopup.IsOpen = true;
            });
        }

        public void CloseLoginPage()
        {
            var t = this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                loginPopup.IsOpen = false;
            });
        }

        private void OnUrlTextChanged(object sender, TextChangedEventArgs e)
        {
            if (url.Text.Length == 0)
            {
                connectButton.IsEnabled = false;
            }
            else
            {
                connectButton.IsEnabled = true;
            }
        }
    }
}
