/**
 * Copyright (c) 2007-2014, Kaazing Corporation. All rights reserved.
 */

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using Kaazing.HTML5;
using Kaazing.Security;
using Kaazing.AMQP;

namespace Kaazing.AMQP.Demo
{
    public partial class AMQPDemoForm : Form
    {
        private const int LOG_LIMIT = 50;

        private AmqpClient       client = null;
        private BasicChallengeHandler basicHandler;
        private AmqpChannel      publishChannel = null;
        private AmqpChannel      consumeChannel = null; 
        private AmqpChannel      txnPublishChannel = null;
        private AmqpChannel      txnConsumeChannel = null;
        private string           queueName = "queue" + new Random().Next();
        private string           txnQueueName = "txnqueue" + new Random().Next(); 
        private string           exchangeName = "demo_exchange";
        private string           txnExchangeName = "demo_txn_exchange";
        private string           routingKey = "broadcastkey";
        private bool             terminated = false;
        private Queue<String>    logLines = new Queue<String>();

        private delegate void InvokeDelegate();

        public AMQPDemoForm()
        {
            InitializeComponent();

            UpdateConnectionButtons(false);
            //setup ChallengeHandler to handler Basic/Application Basic authentications
            this.basicHandler = BasicChallengeHandler.Create();
            basicHandler.LoginHandler = new LoginHandlerDemo(this);
        } 

        private void AMQPDemoForm_Load(object sender, EventArgs e)
        {
        }

        /*
         *  Button click handler for connect button
         */
        private void ConnectButton_Click(object sender, EventArgs e)
        {
            ConnectButton.Enabled = false;
            client = new AmqpClient();
            client.ChallengeHandler = basicHandler;
            client.OpenEvent += new AmqpEventHandler(ConnectedHandler);
            client.CloseEvent += new AmqpEventHandler(CloseHandler);
            client.ErrorEvent += new AmqpEventHandler(ConnectionErrorHandler);
            ConnectionStatusValueLabel.Text = "CONNECTING";

            Log("\n");
            Log("CONNECTING: " + LocationText.Text + " " + UsernameText.Text);

            string virtualHost = VirtualHostText.Text;
            string locText = LocationText.Text;

            if ((locText == null) || (locText.Length == 0))
            {
                locText = "ws://localhost:8001/amqp";
            }

            try
            {
                client.Connect(locText, virtualHost, UsernameText.Text, PasswordText.Text);
            }
            catch (Exception ex)
            {
                Log("Exception: " + ex.Message);
            }
        }

        private void CreateChannel()
        {
            Log("OPEN: Publish Channel");
            publishChannel = client.OpenChannel();
            publishChannel.OpenEvent += PublishChannelOpenHandler;
            publishChannel.DeclareExchangeEvent += DeclareExchangeOkHandler;
            publishChannel.CloseEvent += PublishChannelCloseHandler;
            publishChannel.ErrorEvent += PublishChannelErrorHandler;

            Log("OPEN: Consume Channel");
            consumeChannel = client.OpenChannel();
            consumeChannel.OpenEvent += ConsumeChannelOpenHandler;
            consumeChannel.DeclareQueueEvent += DeclareQueueOkHandler;
            consumeChannel.BindQueueEvent += BindQueueOkHandler;
            consumeChannel.ConsumeEvent += BasicConsumeOkHandler;
            consumeChannel.MessageEvent += MessageHandler;
            consumeChannel.FlowEvent += FlowOkHandler;
            consumeChannel.CancelEvent += CancelOkBasicHandler;
            consumeChannel.CloseEvent += ChannelCloseHandler;

            txnPublishChannel = client.OpenChannel();
            txnPublishChannel.OpenEvent += TxnPublishChannelOpenHandler;
            txnPublishChannel.CommitTransactionEvent += CommitOkTxHandler;
            txnPublishChannel.RollbackTransactionEvent += RollbackOkTxHandler;
            txnPublishChannel.SelectTransactionEvent += SelectOkTxHandler;

            txnConsumeChannel = client.OpenChannel();
            txnConsumeChannel.OpenEvent += TxnConsumeChannelOpenHandler;
            txnConsumeChannel.MessageEvent += TxnMessageHandler;
        }

        /*
         *  Button click handler for disconnect button!
         */
        private void CloseButton_Click(object sender, EventArgs e)
        {
            Log("DISCONNECT");

            // close the connection...
            publishChannel.CloseChannel(0, "", 0, 0);
            consumeChannel.CloseChannel(0, "", 0, 0);
            txnPublishChannel.CloseChannel(0, "", 0, 0);
            txnConsumeChannel.CloseChannel(0, "", 0, 0); 
            Disconnect();
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
         *  Button click handler for Publish(non-txn) button
         */
        private void Publish_Click(object sender, EventArgs e)
        {
            if (MessageText.Text == null || MessageText.Text.Length == 0)
            {
                Log("Please enter valid text for AMQP message");
                return;
            }

            PublishBasic(MessageText.Text);
        }

        /*
        *  Button click handler for Flow On button!
        */
        private void Flow_On_Click(object sender, EventArgs e)
        {
            consumeChannel.FlowChannel(true);
        }

        /*
        *  Button click handler for Flow Off button!
        */
        private void Flow_Off_Click(object sender, EventArgs e)
        {
            consumeChannel.FlowChannel(false);
        }

        /*
         * Button click handler for Clear Log button!
         */
        private void ClearLogButton_Click(object sender, EventArgs e)
        {
            logLines.Clear();
            Output.Text = "";
        }

        /*
         * Button click handler for Select button!
         */
        private void SelectTx_Click(object sender, EventArgs e)
        {
            Log("TXN SELECT/START");
            txnPublishChannel.SelectTx();
        }

        /*
         * Button click handler for Publish(transactional) button!
         */
        private void PublishTx_Click(object sender, EventArgs e)
        {
            if (TransactionMessageText.Text == null || TransactionMessageText.Text.Length == 0)
            {
                Log("Please enter valid text for AMQP message");
                return;
            }

            TxPublishBasic(TransactionMessageText.Text);
        }

        /*
         * Button click handler for Commit transaction button!
         */
        private void CommitTx_Click(object sender, EventArgs e)
        {
            Log("TXN COMMIT");
            txnPublishChannel.CommitTx();
        }

        /*
         * Button click handler for Rollback transaction button!
         */
        private void RollbackTx_Click(object sender, EventArgs e)
        {
            Log("TXN ROLLBACK");
            txnPublishChannel.RollbackTx();
        }


        /*
         * All registered Event Handlers
         */
        private void CloseHandler(object sender, AmqpEventArgs e)
        {
            this.BeginInvoke((InvokeDelegate)(() =>
            {
                if (!terminated)
                {
                    Disconnect();
                }

                ConnectionStatusValueLabel.Text = "DISCONNECTED";
                terminated = false;
                UpdateConnectionButtons(false);
                Log("DISCONNECTED");

                ExchangeText.ReadOnly = false;
                TransactionExchangeText.ReadOnly = false;
            }));
        }

        private void ConnectedHandler(object sender, AmqpEventArgs e)
        {
            this.BeginInvoke((InvokeDelegate)(()  =>
            {
                Log("CONNECTED");
                ConnectionStatusValueLabel.Text = "CONNECTED";

                exchangeName = ExchangeText.Text;
                txnExchangeName = TransactionExchangeText.Text;

                CreateChannel();

                // Ready to process messages
                UpdateConnectionButtons(true);

                ExchangeText.ReadOnly = true;
                TransactionExchangeText.ReadOnly = true;
            }));
        }

        private void ConnectionErrorHandler(object sender, AmqpEventArgs e)
        {
            this.BeginInvoke((InvokeDelegate)(() =>
            {
                ConnectionStatusValueLabel.Text = "ERROR";
                Log("ERROR:" + e.Message);
            }));
        }

        /*
         * Publish Channel Handlers
         */
        private void PublishChannelOpenHandler(object sender, AmqpEventArgs e)
        {
            this.BeginInvoke((InvokeDelegate)(() =>
            {
                Log("OPENED: Publish Channel");

                publishChannel.DeclareExchange(exchangeName, "fanout", false, false, false, null);
            }));
        }

        private void PublishChannelErrorHandler(object sender, AmqpEventArgs e)
        {
            this.BeginInvoke((InvokeDelegate)(() =>
            {
                Log("ERROR: PUBLISH CHANNEL: " + e.Message);
            }));
        }

        private void PublishChannelCloseHandler(object sender, AmqpEventArgs e)
        {
            this.BeginInvoke((InvokeDelegate)(() =>
            {
                Log("CLOSED: PUBLISH CHANNEL");
            }));
        }

        /*
         * Txn Publish Channel Handler
         */
        private void TxnPublishChannelOpenHandler(object sender, AmqpEventArgs e)
        {
            this.BeginInvoke((InvokeDelegate)(() =>
            {
                txnPublishChannel.DeclareExchange(txnExchangeName, "fanout", false, false, false, null);
            }));
        }

        private void PublishBasic(string text)
        {
            ByteBuffer buffer = new ByteBuffer();
            buffer.PutString(text, System.Text.Encoding.UTF8);
            buffer.Flip();
            AmqpProperties amqpProperties = new AmqpProperties();
            amqpProperties.MessageId = "abcdxyz1234pqr";
            amqpProperties.CorrelationId = "23456";
            amqpProperties.UserId = UsernameText.Text;
            amqpProperties.ContentType = AmqpProperties.TEXT_PLAIN;
            amqpProperties.DeliveryMode = 1;
            amqpProperties.Priority = 6;
            amqpProperties.Timestamp = DateTime.Now.ToLocalTime();
            AmqpArguments customHeaders = new AmqpArguments();
            customHeaders.AddInteger("KZNG_AMQP_KEY1", 100);
            customHeaders.AddLongString("KZNG_AMQP_KEY2", "Custom Header Value");
            amqpProperties.Headers = customHeaders;
            publishChannel.PublishBasic(buffer, amqpProperties, exchangeName, routingKey, false, false);
            Log(amqpProperties.ToString());
            Log("Published Message Properties:");
            Log("MESSAGE PUBLISHED: " + text);
        }

        private void TxPublishBasic(string text)
        {
            ByteBuffer buffer = new ByteBuffer();
            buffer.PutString(text, System.Text.Encoding.UTF8);
            buffer.Flip();
            AmqpProperties amqpProperties = new AmqpProperties();
            txnPublishChannel.PublishBasic(buffer, amqpProperties, txnExchangeName, routingKey, false, false);
            Log("TXN MESSAGE PUBLISHED: " + text);
        }

        /*
         * Consume Channel Handlers
         */
        private void ConsumeChannelOpenHandler(object sender, AmqpEventArgs e)
        {
            this.BeginInvoke((InvokeDelegate)(() =>
            {
                Log("OPENED: Consume Channel");
  
                consumeChannel.DeclareQueue(queueName, false, false, false, false, false, null)
                              .BindQueue(queueName, exchangeName, routingKey, false, null)
                              .ConsumeBasic(queueName, routingKey, false, false, false, false, null);
            }));
        }

        /*
         * Txn Consume Channel Handlers
         */
        private void TxnConsumeChannelOpenHandler(object sender, AmqpEventArgs e)
        {
            this.BeginInvoke((InvokeDelegate)(() =>
            {
                txnConsumeChannel.DeclareQueue(txnQueueName, false, false, false, false, false, null)
                                 .BindQueue(txnQueueName, txnExchangeName, routingKey, false, null)
                                 .ConsumeBasic(txnQueueName, routingKey, false, false, false, false, null);
            }));
        }

        private void DeclareExchangeOkHandler(object sender, AmqpEventArgs e)
        {
            this.BeginInvoke((InvokeDelegate)(() =>
            {
                Log("EXCHANGE DECLARED: " + exchangeName);
            }));
        }

        private void DeclareQueueOkHandler(object sender, AmqpEventArgs e)
        {
            this.BeginInvoke((InvokeDelegate)(() =>
            {
                Log("QUEUE DECLARED: " + queueName);
            }));
        }

        private void BindQueueOkHandler(object sender, AmqpEventArgs e)
        {
            this.BeginInvoke((InvokeDelegate)(() =>
            {
                Log("QUEUE BOUND: " + exchangeName + "  -  " + queueName);
            }));
        }

        private void BasicConsumeOkHandler(object sender, AmqpEventArgs e)
        {
            this.BeginInvoke((InvokeDelegate)(() =>
            {
                Log("READY TO CONSUME FROM QUEUE: " + queueName);
            }));
        }

        private void ChannelErrorHandler(object sender, AmqpEventArgs e)
        {
            this.BeginInvoke((InvokeDelegate)(() =>
            {
                Log("ERROR: " + e.Message);
            }));
        }

        private void ChannelCloseHandler(object sender, AmqpEventArgs e)
        {
            this.BeginInvoke((InvokeDelegate)(() =>
            {
                Log("CHANNEL CLOSED");
            }));
        }

        private void CancelOkBasicHandler(object sender, AmqpEventArgs e)
        {
            this.BeginInvoke((InvokeDelegate)(() =>
            {
                Log("BASIC CANCELLED");
            }));
        }

        private void FlowOkHandler(object sender, AmqpEventArgs e)
        {
            this.BeginInvoke((InvokeDelegate)(() =>
            {
                Log("FLOW: " + (e.IsFlowActive ? "ON" : "OFF"));
            }));
        }

        private void CommitOkTxHandler(object sender, AmqpEventArgs e)
        {
            this.BeginInvoke((InvokeDelegate)(() =>
            {
                Log("TXN COMMITTED");
                UpdateTransactionButtons(false, true);
            }));
        }

        private void RollbackOkTxHandler(object sender, AmqpEventArgs e)
        {
            this.BeginInvoke((InvokeDelegate)(() =>
            {
                Log("TXN ROLLEDBACK");
                UpdateTransactionButtons(false, true);
            }));
        }

        private void SelectOkTxHandler(object sender, AmqpEventArgs e)
        {
            this.BeginInvoke((InvokeDelegate)(() =>
            {
                Log("TXN SELECTED/STARTED");
                UpdateTransactionButtons(true, true);
            }));
        }

        private void MessageHandler(object sender, AmqpEventArgs e)
        {
            this.BeginInvoke((InvokeDelegate)(() =>
            {
                ByteBuffer buf = e.Body;
                string message = buf.GetString(System.Text.Encoding.UTF8);
                Log(e.AmqpProperties.ToString());
                Log("Consumed Message Properties:");
                Log("MESSAGE CONSUMED: " + message);

                // Explicitly acknowledge the message as we are passing
                // 'false' as the value of the 'noAck' parameter in
                // the consumeChannel.ConsumeBasic() call.
                long dt = Convert.ToInt64(e.Arguments["deliveryTag"]);
                ((AmqpChannel)sender).AckBasic(dt, true);
            }));
        }

        private void TxnMessageHandler(object sender, AmqpEventArgs e)
        {
            this.BeginInvoke((InvokeDelegate)(() =>
            {
                ByteBuffer buf = e.Body;
                string message = buf.GetString(System.Text.Encoding.UTF8);
                Log("TXN MESSAGE CONSUMED: " + message);

                // Explicitly acknowledge the message as we are passing
                // 'false' as the value of the 'noAck' parameter in
                // the txnConsumeChannel.ConsumeBasic() call.
                long dt = Convert.ToInt64(e.Arguments["deliveryTag"]);
                ((AmqpChannel)sender).AckBasic(dt, true);
            }));
        }

        /*
         * All helper/convenience methods.
         */

        private void UpdateConnectionButtons(bool connected)
        {
            ConnectButton.Enabled = !connected;
            DisconnectButton.Enabled = connected;
            SubscribeButton.Enabled = connected;
            SendButton.Enabled = connected;
            UnsubscribeButton.Enabled = connected;

            UpdateTransactionButtons(false, connected);
        }

         private void UpdateTransactionButtons(bool transacted, bool connected)
         {
             if (connected)
             {
                 SelectButton.Enabled = !transacted;
                 CommitButton.Enabled = transacted;
                 PublishTransactionButton.Enabled = transacted;
                 RollbackButton.Enabled = transacted;
             }
             else
             {
                 SelectButton.Enabled = false;
                 CommitButton.Enabled = false;
                 PublishTransactionButton.Enabled = false;
                 RollbackButton.Enabled = false;
             }
         }

        /*
         * Console output 
         */
        private void Log(String arg)
        {
            logLines.Enqueue(arg);
            if (logLines.Count > LOG_LIMIT)
            {
                logLines.Dequeue();
            }
            String[] o = logLines.ToArray();

            Array.Reverse(o);

            Output.Text = String.Join("\r\n", o);
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
    }
}