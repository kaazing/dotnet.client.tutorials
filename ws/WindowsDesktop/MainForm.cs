/**
 * Copyright (c) 2007-2015, Kaazing Corporation. All rights reserved.
 */
using Kaazing.HTML5;
using Kaazing.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EchoDemo
{
    public partial class MainForm : Form
    {
        private WebSocket webSocket = null;
        private WebSocketFactory factory = new WebSocketFactory();

        public delegate void InvokeDelegate();

        /// <summary>
        /// .Net HTML5 Demo Form
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            string defaultLocation = "wss://sandbox.kaazing.net/echo";
            LocationText.Text = defaultLocation;
        }

        private void HTML5DemoForm_Load(object sender, EventArgs e)
        {
        }

        private void HandleLog(string message)
        {
            this.BeginInvoke((InvokeDelegate)(() =>
            {
                Log("LOG: " + message);
            }));
        }

        ///
        ///  Button click handlers
        ///
        private void ConnectButton_Click(object sender, EventArgs e)
        {
            // Immediately disable the connect button
            ConnectButton.Enabled = false;
            LocationText.Enabled = false;

            //setup ChallengeHandler to handler Basic/Application Basic authentications
            BasicChallengeHandler basicHandler = BasicChallengeHandler.Create();
            basicHandler.LoginHandler = new LoginHandlerDemo(this);

            factory.ChallengeHandler = basicHandler;
            webSocket = factory.CreateWebSocket();
            Log("CONNECT:" + LocationText.Text);

            webSocket.OpenEvent += new OpenEventHandler(OpenHandler);
            webSocket.CloseEvent += new CloseEventHandler(CloseHandler);
            webSocket.MessageEvent += new MessageEventHandler(MessageHandler);

            webSocket.Connect(LocationText.Text);
        }

        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            Log("DISCONNECT");
            webSocket.Close();
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            if (checkBox_Binary.Checked)
            {
                ByteBuffer buf = new ByteBuffer();
                buf.PutString(MessageText.Text, Encoding.UTF8);
                buf.Flip();
                Log("SEND BINARY:" + buf.GetHexDump());
                webSocket.Send(buf);
            }
            else
            {
                Log("SEND TEXT:" + MessageText.Text);
                webSocket.Send(MessageText.Text);
            }
        }

        ///
        /// Console output
        ///
        private const int LOG_LIMIT = 50;
        private Queue<string> logLines = new Queue<string>();
        private void Log(string arg)
        {
            logLines.Enqueue(arg);
            if (logLines.Count > LOG_LIMIT)
            {
                logLines.Dequeue();
            }
            string[] o = logLines.ToArray<string>();

            o = o.Reverse<string>().ToArray<string>();

            Output.Text = string.Join("\r\n", o);
        }

        private void ClearLogButton_Click(object sender, EventArgs e)
        {
            logLines.Clear();
            Output.Text = "";
        }


        /*
         * HTML5 Event Handlers
         */
        ///
        /// Handle server authentication challenge request,
        /// Popup a login window for username/password
        ///
        public PasswordAuthentication AuthenticationHandler()
        {
            PasswordAuthentication credentials = null;
            AutoResetEvent userInputCompleted = new AutoResetEvent(false);
            this.BeginInvoke((InvokeDelegate)(() =>
            {
                LoginDemoForm loginForm = new LoginDemoForm();
                if (loginForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    credentials = new PasswordAuthentication(loginForm.Username, loginForm.Password.ToCharArray());
                }
                userInputCompleted.Set();
            }));
            // wait user click 'OK' or 'Cancel' on login window
            userInputCompleted.WaitOne();
            return credentials;
        }

        ///
        /// HTML5 Event Handlers
        ///
        private void OpenHandler(object sender, OpenEventArgs args)
        {
            this.BeginInvoke((InvokeDelegate)(() =>
            {
                Log("CONNECTED");

                DisconnectButton.Enabled = true;
                SendButton.Enabled = true;
            }));
        }

        private void CloseHandler(object sender, CloseEventArgs args)
        {
            this.BeginInvoke((InvokeDelegate)(() =>
            {
                Log("DISCONNECTED");
                LocationText.Enabled = true;
                ConnectButton.Enabled = true;
                DisconnectButton.Enabled = false;
                SendButton.Enabled = false;
            }));
        }

        private void MessageHandler(object sender, MessageEventArgs args)
        {
            this.BeginInvoke((InvokeDelegate)(() =>
            {
                switch(args.MessageType) {
                    case EventType.BINARY:
                        Log("BINARY MESSAGE: "+  BitConverter.ToString(args.Data.Array));
                        break;
                    case EventType.TEXT:
                        Log("TEXT MESSAGE: " + Encoding.UTF8.GetString(args.Data.Array));
                        break;
                    case EventType.CLOSE:
                        Log("CLOSED");
                        break;

                }
                
            }));
        }



        private void LocationText_TextChanged(object sender, EventArgs e)
        {
            if (LocationText.Text.Length == 0)
            {
                ConnectButton.Enabled = false;
            }
            else
            {
                ConnectButton.Enabled = true;
            }
        }



        private void MainForm_Load(object sender, EventArgs e)
        {



        }

    }
}
