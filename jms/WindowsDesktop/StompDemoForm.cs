/**
 * Copyright (c) 2007-2015, Kaazing Corporation. All rights reserved.
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Resources;
using System.Windows.Forms;
using Kaazing.JMS;
using Kaazing.JMS.Stomp;
using Kaazing.Security;
using System.Threading;
using Kaazing.HTML5;
using System.Threading.Tasks;

namespace Kaazing.JMS.Demo
{
    /// <summary>
    /// Top level JMS Client Demo
    /// </summary>
    public partial class StompDemoForm : Form
    {
        private IConnection connection = null;
        private ISession session = null;
        private IMessageConsumer consumer = null;
        BasicChallengeHandler basicHandler;

        private delegate void InvokeDelegate();
        private delegate void InvokeDelegate1();

        /// <summary>
        /// JMS Demo Form constructor
        /// </summary>
        public StompDemoForm()
        {
            InitializeComponent();

            String defaultLocation = "wss://demos.kaazing.com/jms";
            LocationText.Text = defaultLocation;

            ResourceManager resourceManager = new ResourceManager("Kaazing.JMS.Demo.StompDemoForm", GetType().Assembly);
            this.Icon = (Icon)resourceManager.GetObject("Favicon.Ico");           

            //setup ChallengeHandler to handler Basic/Application Basic authentications
            basicHandler = BasicChallengeHandler.Create();
            basicHandler.LoginHandler = new LoginHandlerDemo(this);
            
        }

        private void StompDemoForm_Load(object sender, EventArgs e)
        {
        }

        private void HandleLog(String message)
        {
            this.BeginInvoke((InvokeDelegate)(() =>
            {
                Log("LOG: " + message);
            }));
        }

        ///
        /// Handle server authentication challenge request,
        /// Popup a login window for username/password
        ///
        public PasswordAuthentication AuthenticationHandler()
        {
            PasswordAuthentication credentials = null;
            LoginDemoForm loginForm = new LoginDemoForm();
            AutoResetEvent userInputCompleted = new AutoResetEvent(false);

            //
            //Popup login window on new Task. Note: please use Task to do parallel jobs
            //
            Task t = Task.Factory.StartNew(() =>
            {
                if (loginForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    credentials = new PasswordAuthentication(loginForm.Username, loginForm.Password.ToCharArray());
                }
                userInputCompleted.Set();
            });

            // wait user click 'OK' or 'Cancel' on login window
            userInputCompleted.WaitOne();
            return credentials;
        }

        /*
         *  Button click handlers
         */
        private void ConnectButton_Click(object sender, EventArgs e)
        {
            try
            {
                // try to establish the JMS connection
                this.JMS_Connect();                
            }
            catch (System.IO.FileLoadException)
            {
                MessageBox.Show("You need to upgrade your .NET Framework version. Check the Release Notes.");
            }
        }

        /*
         * "Delegate, invoked by the "click handler", which actually establishes the JMS connection.
         */
        private void JMS_Connect()
        {
            // Immediately disable the connect button
            ConnectButton.Enabled = false;
            LocationText.Enabled = false;
            Log("CONNECT:" + LocationText.Text);

            try
            {
                StompConnectionFactory connectionFactory = new StompConnectionFactory(new Uri(LocationText.Text));
                ChallengeHandlers.Default = basicHandler;   // set challenge handler

                connection = connectionFactory.CreateConnection("", "");
                Log("CONNECTED");

                connection.ExceptionListener = new ExceptionHandler(this);
                
                session = connection.CreateSession(false, SessionConstants.AUTO_ACKNOWLEDGE);

                connection.Start();

                // Enable User Interface for Connected application
                SubscribeButton.Enabled = true;
                SendButton.Enabled = true;

                DisconnectButton.Enabled = true;
            }
            catch (Exception exc)
            {
                if (connection != null)
                {
                    connection.Close();
                }

                Log("CONNECTION FAILED: " + exc.Message);
                LocationText.Enabled = true;
                ConnectButton.Enabled = true;
                
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Log("CLOSE");

            if (connection != null)
            {
                try
                {
                    connection.Close();
                }
                catch (Exception exc)
                {
                    Log("EXCEPTION: " + exc.Message);
                }
                finally
                {
                    connection = null;
                }
            }

            DisconnectedHandler();
        }

        private void DisconnectedHandler()
        {
            this.BeginInvoke((InvokeDelegate)(() =>
            {
                Log("DISCONNECTED");
                LocationText.Enabled = true;
                ConnectButton.Enabled = true;

                SendButton.Enabled = false;
                SubscribeButton.Enabled = false;

                DisconnectButton.Enabled = false;
            }));
        }


        private void SubscribeButton_Click(object sender, EventArgs e)
        {
           if (SubscribeButton.Text == "Subscribe")
            {
                if (Subscribe())
                {
                    SubscribeButton.Text = "Unsubscribe";
                    DestinationText.Enabled = false;
                }
            }
            else
            {
                Unsubscribe();
                SubscribeButton.Text = "Subscribe";
                DestinationText.Enabled = true;
            }

        }

        private bool Subscribe()
        {
            // TODO: Track consumers by topic, and durable subscribers by subscription name
            Log("SUBSCRIBE:" + DestinationText.Text);

            IDestination destination;
            if (DestinationText.Text.StartsWith("/topic/"))
            {
                destination = session.CreateTopic(DestinationText.Text);
            }
            else if (DestinationText.Text.StartsWith("/queue/"))
            {
                destination = session.CreateQueue(DestinationText.Text);
            }
            else
            {
                Log("Destination must start with /topic/ or /queue/");
                return false;
            }

            consumer = session.CreateConsumer(destination);
            consumer.MessageListener = new MessageHandler(this);
            return true;
        }

        private void Unsubscribe()
        {
            Log("UNSUBSCRIBE:" + DestinationText.Text);
       
            if (consumer != null)
            {
                consumer.Close();
            }

            consumer = null;
        }

        class MessageHandler : IMessageListener
        {
            StompDemoForm form;

            internal MessageHandler(StompDemoForm form)
            {
                this.form = form;
            }

            public void OnMessage(IMessage message)
            {
                form.BeginInvoke((InvokeDelegate)(() =>
                {
                    if (message is ITextMessage)
                    {
                        ITextMessage textMessage = (ITextMessage)message;
                        form.Log("RECEIVED ITextMessage: " + textMessage.Text);
                    }
                    else if (message is IBytesMessage)
                    {
                        IBytesMessage msg = (IBytesMessage)message;
                        byte[] actual = new byte[(int)msg.BodyLength];
                        msg.ReadBytes(actual);
                        form.Log("RECEIVED IBytesMessage: " + BitConverter.ToString(actual));

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
                                form.Log(name + ": null");
                            }
                            else if (obj.GetType().IsArray)
                            {
                                form.Log(name + ": " + BitConverter.ToString(obj as byte[]) + " (byte[])");
                            }
                            else
                            {
                                String type = obj.GetType().ToString();
                                form.Log(name + ": " + obj.ToString() + " ("+type+")");
                            }
                        }
                        form.Log("RECEIVED IMapMessage:");
                    }
                    else
                    {
                        form.Log("UNKNOWN MESSAGE TYPE");
                    }
                }));
            }
        }

        class ExceptionHandler : IExceptionListener
        {
            StompDemoForm form;

            internal ExceptionHandler(StompDemoForm form)
            {
                this.form = form;
            }

            public void OnException(JMSException exc)
            {
                form.BeginInvoke((InvokeDelegate)(() =>
                {
                    form.Log(exc.Message);
                }));
            }
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            // Create a destination for the producer
            IDestination destination;
            if (DestinationText.Text.StartsWith("/topic/"))
            {
                destination = session.CreateTopic(DestinationText.Text);
            }
            else if (DestinationText.Text.StartsWith("/queue/"))
            {
                destination = session.CreateQueue(DestinationText.Text);
            }
            else
            {
                Log("Destination must start with /topic/ or /queue/");
                return;
            }

            // Create the message to send
            IMessage message;
            if (BinaryCheckBox.Checked)
            {
                Log("SEND IBytesMessage:" + BitConverter.ToString(Encoding.UTF8.GetBytes(MessageText.Text)) + ": " + DestinationText.Text);
                message = session.CreateBytesMessage();
                ((IBytesMessage)message).WriteUTF(MessageText.Text);              
            }
            else
            {
                Log("SEND ITextMessage: " + MessageText.Text + ": " + DestinationText.Text);
                message = session.CreateTextMessage(MessageText.Text);
            }

            // Create the producer, send, and close
            IMessageProducer producer = session.CreateProducer(destination);
            producer.Send(message);
            producer.Close();
        }

        /*
         * Console output 
         */
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

        private void DestinationText_TextChanged(object sender, EventArgs e)
        {
            SubscribeButton.Enabled = DestinationText.TextLength > 0;
        }
    }
}
