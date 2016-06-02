/**
 * Copyright (c) 2007-2014, Kaazing Corporation. All rights reserved.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Kaazing.AMQP.Demo
{
    partial class AMQPDemoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AMQPDemoForm));
            this.LocationLabel = new System.Windows.Forms.Label();
            this.LocationText = new System.Windows.Forms.TextBox();
            this.Output = new System.Windows.Forms.TextBox();
            this.ClearLogButton = new System.Windows.Forms.Button();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.DisconnectButton = new System.Windows.Forms.Button();
            this.MessageLabel = new System.Windows.Forms.Label();
            this.MessageText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SubscribeButton = new System.Windows.Forms.Button();
            this.SendButton = new System.Windows.Forms.Button();
            this.UnsubscribeButton = new System.Windows.Forms.Button();
            this.Title = new System.Windows.Forms.Label();
            this.Subtitle = new System.Windows.Forms.Label();
            this.HintLabel1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ExchangeLabel = new System.Windows.Forms.Label();
            this.VirtualHostText = new System.Windows.Forms.TextBox();
            this.ExchangeText = new System.Windows.Forms.TextBox();
            this.ConnectionStatusLabel = new System.Windows.Forms.Label();
            this.ConnectionStatusValueLabel = new System.Windows.Forms.Label();
            this.TransactionLabel1 = new System.Windows.Forms.Label();
            this.TransactionMessageLabel = new System.Windows.Forms.Label();
            this.TransactionMessageText = new System.Windows.Forms.TextBox();
            this.SelectButton = new System.Windows.Forms.Button();
            this.PublishTransactionButton = new System.Windows.Forms.Button();
            this.RollbackButton = new System.Windows.Forms.Button();
            this.CommitButton = new System.Windows.Forms.Button();
            this.LogMessagesLabel = new System.Windows.Forms.Label();
            this.TransactionExchangeText = new System.Windows.Forms.TextBox();
            this.TransactionExchangeLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.UserIdText = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // LocationLabel
            // 
            this.LocationLabel.AutoSize = true;
            this.LocationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LocationLabel.Location = new System.Drawing.Point(16, 88);
            this.LocationLabel.Name = "LocationLabel";
            this.LocationLabel.Size = new System.Drawing.Size(75, 17);
            this.LocationLabel.TabIndex = 0;
            this.LocationLabel.Text = "Location:";
            // 
            // LocationText
            // 
            this.LocationText.Location = new System.Drawing.Point(116, 88);
            this.LocationText.Name = "LocationText";
            this.LocationText.Size = new System.Drawing.Size(197, 20);
            this.LocationText.TabIndex = 1;
            this.LocationText.Text = "wss://sandbox.kaazing.net/amqp091";
            this.LocationText.TextChanged += new System.EventHandler(this.LocationText_TextChanged);
            // 
            // Output
            // 
            this.Output.Location = new System.Drawing.Point(20, 331);
            this.Output.Multiline = true;
            this.Output.Name = "Output";
            this.Output.Size = new System.Drawing.Size(726, 230);
            this.Output.TabIndex = 6;
            // 
            // ClearLogButton
            // 
            this.ClearLogButton.Location = new System.Drawing.Point(646, 566);
            this.ClearLogButton.Name = "ClearLogButton";
            this.ClearLogButton.Size = new System.Drawing.Size(99, 33);
            this.ClearLogButton.TabIndex = 7;
            this.ClearLogButton.Text = "Clear Log";
            this.ClearLogButton.UseVisualStyleBackColor = true;
            this.ClearLogButton.Click += new System.EventHandler(this.ClearLogButton_Click);
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(19, 224);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(85, 28);
            this.ConnectButton.TabIndex = 8;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // DisconnectButton
            // 
            this.DisconnectButton.Enabled = false;
            this.DisconnectButton.Location = new System.Drawing.Point(116, 225);
            this.DisconnectButton.Name = "DisconnectButton";
            this.DisconnectButton.Size = new System.Drawing.Size(85, 28);
            this.DisconnectButton.TabIndex = 9;
            this.DisconnectButton.Text = "Disconnect";
            this.DisconnectButton.UseVisualStyleBackColor = true;
            this.DisconnectButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // MessageLabel
            // 
            this.MessageLabel.AutoSize = true;
            this.MessageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MessageLabel.Location = new System.Drawing.Point(395, 107);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(77, 17);
            this.MessageLabel.TabIndex = 10;
            this.MessageLabel.Text = "Message:";
            // 
            // MessageText
            // 
            this.MessageText.Location = new System.Drawing.Point(485, 107);
            this.MessageText.Name = "MessageText";
            this.MessageText.Size = new System.Drawing.Size(197, 20);
            this.MessageText.TabIndex = 11;
            this.MessageText.Text = "Demo message";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(449, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 12;
            // 
            // SubscribeButton
            // 
            this.SubscribeButton.Enabled = false;
            this.SubscribeButton.Location = new System.Drawing.Point(392, 130);
            this.SubscribeButton.Name = "SubscribeButton";
            this.SubscribeButton.Size = new System.Drawing.Size(85, 28);
            this.SubscribeButton.TabIndex = 14;
            this.SubscribeButton.Text = "Publish";
            this.SubscribeButton.UseVisualStyleBackColor = true;
            this.SubscribeButton.Click += new System.EventHandler(this.Publish_Click);
            // 
            // SendButton
            // 
            this.SendButton.Enabled = false;
            this.SendButton.Location = new System.Drawing.Point(493, 130);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(85, 28);
            this.SendButton.TabIndex = 15;
            this.SendButton.Text = "Flow On";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.Flow_On_Click);
            // 
            // UnsubscribeButton
            // 
            this.UnsubscribeButton.Enabled = false;
            this.UnsubscribeButton.Location = new System.Drawing.Point(596, 130);
            this.UnsubscribeButton.Name = "UnsubscribeButton";
            this.UnsubscribeButton.Size = new System.Drawing.Size(85, 28);
            this.UnsubscribeButton.TabIndex = 16;
            this.UnsubscribeButton.Text = "Flow Off";
            this.UnsubscribeButton.UseVisualStyleBackColor = true;
            this.UnsubscribeButton.Click += new System.EventHandler(this.Flow_Off_Click);
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(41, 8);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(371, 26);
            this.Title.TabIndex = 18;
            this.Title.Text = "AMQP .Net  Framework Client Demo";
            // 
            // Subtitle
            // 
            this.Subtitle.AutoSize = true;
            this.Subtitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Subtitle.Location = new System.Drawing.Point(14, 35);
            this.Subtitle.Name = "Subtitle";
            this.Subtitle.Size = new System.Drawing.Size(652, 17);
            this.Subtitle.TabIndex = 19;
            this.Subtitle.Text = "This is a demo of a AMQP .Net Framework client application that communicates with" +
    " a message broker";
            // 
            // HintLabel1
            // 
            this.HintLabel1.AutoSize = true;
            this.HintLabel1.Location = new System.Drawing.Point(18, 351);
            this.HintLabel1.Name = "HintLabel1";
            this.HintLabel1.Size = new System.Drawing.Size(0, 13);
            this.HintLabel1.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(635, 17);
            this.label3.TabIndex = 24;
            this.label3.Text = "via WebSocket to subscribe to destinations, send and receive messages, and proces" +
    "s transactions.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(449, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 17);
            this.label4.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 17);
            this.label2.TabIndex = 27;
            this.label2.Text = "Virtual Host:";
            // 
            // ExchangeLabel
            // 
            this.ExchangeLabel.AutoSize = true;
            this.ExchangeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExchangeLabel.Location = new System.Drawing.Point(395, 81);
            this.ExchangeLabel.Name = "ExchangeLabel";
            this.ExchangeLabel.Size = new System.Drawing.Size(83, 17);
            this.ExchangeLabel.TabIndex = 28;
            this.ExchangeLabel.Text = "Exchange:";
            // 
            // VirtualHostText
            // 
            this.VirtualHostText.Location = new System.Drawing.Point(116, 114);
            this.VirtualHostText.Name = "VirtualHostText";
            this.VirtualHostText.Size = new System.Drawing.Size(197, 20);
            this.VirtualHostText.TabIndex = 29;
            this.VirtualHostText.Text = "/";
            this.VirtualHostText.TextChanged += new System.EventHandler(this.VirtualHostText_TextChanged);
            // 
            // ExchangeText
            // 
            this.ExchangeText.Location = new System.Drawing.Point(485, 82);
            this.ExchangeText.Name = "ExchangeText";
            this.ExchangeText.Size = new System.Drawing.Size(197, 20);
            this.ExchangeText.TabIndex = 30;
            this.ExchangeText.Text = "demo_exchange";
            this.ExchangeText.TextChanged += new System.EventHandler(this.ExchangeText_TextChanged);
            // 
            // ConnectionStatusLabel
            // 
            this.ConnectionStatusLabel.AutoSize = true;
            this.ConnectionStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectionStatusLabel.Location = new System.Drawing.Point(16, 193);
            this.ConnectionStatusLabel.Name = "ConnectionStatusLabel";
            this.ConnectionStatusLabel.Size = new System.Drawing.Size(59, 17);
            this.ConnectionStatusLabel.TabIndex = 31;
            this.ConnectionStatusLabel.Text = "Status:";
            // 
            // ConnectionStatusValueLabel
            // 
            this.ConnectionStatusValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectionStatusValueLabel.Location = new System.Drawing.Point(116, 192);
            this.ConnectionStatusValueLabel.Name = "ConnectionStatusValueLabel";
            this.ConnectionStatusValueLabel.Size = new System.Drawing.Size(261, 20);
            this.ConnectionStatusValueLabel.TabIndex = 32;
            this.ConnectionStatusValueLabel.Text = "DISCONNECTED";
            // 
            // TransactionLabel1
            // 
            this.TransactionLabel1.AutoSize = true;
            this.TransactionLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.TransactionLabel1.Location = new System.Drawing.Point(386, 182);
            this.TransactionLabel1.Name = "TransactionLabel1";
            this.TransactionLabel1.Size = new System.Drawing.Size(338, 17);
            this.TransactionLabel1.TabIndex = 33;
            this.TransactionLabel1.Text = "Select, send to, and commit or rollback a transaction";
            // 
            // TransactionMessageLabel
            // 
            this.TransactionMessageLabel.AutoSize = true;
            this.TransactionMessageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TransactionMessageLabel.Location = new System.Drawing.Point(394, 234);
            this.TransactionMessageLabel.Name = "TransactionMessageLabel";
            this.TransactionMessageLabel.Size = new System.Drawing.Size(77, 17);
            this.TransactionMessageLabel.TabIndex = 35;
            this.TransactionMessageLabel.Text = "Message:";
            // 
            // TransactionMessageText
            // 
            this.TransactionMessageText.Location = new System.Drawing.Point(484, 234);
            this.TransactionMessageText.Name = "TransactionMessageText";
            this.TransactionMessageText.Size = new System.Drawing.Size(197, 20);
            this.TransactionMessageText.TabIndex = 36;
            this.TransactionMessageText.Text = "Demo transaction message";
            // 
            // SelectButton
            // 
            this.SelectButton.Location = new System.Drawing.Point(392, 258);
            this.SelectButton.Name = "SelectButton";
            this.SelectButton.Size = new System.Drawing.Size(85, 28);
            this.SelectButton.TabIndex = 37;
            this.SelectButton.Text = "Select";
            this.SelectButton.UseVisualStyleBackColor = true;
            this.SelectButton.Click += new System.EventHandler(this.SelectTx_Click);
            // 
            // PublishTransactionButton
            // 
            this.PublishTransactionButton.Enabled = false;
            this.PublishTransactionButton.Location = new System.Drawing.Point(483, 258);
            this.PublishTransactionButton.Name = "PublishTransactionButton";
            this.PublishTransactionButton.Size = new System.Drawing.Size(85, 28);
            this.PublishTransactionButton.TabIndex = 38;
            this.PublishTransactionButton.Text = "Publish";
            this.PublishTransactionButton.UseVisualStyleBackColor = true;
            this.PublishTransactionButton.Click += new System.EventHandler(this.PublishTx_Click);
            // 
            // RollbackButton
            // 
            this.RollbackButton.Enabled = false;
            this.RollbackButton.Location = new System.Drawing.Point(664, 258);
            this.RollbackButton.Name = "RollbackButton";
            this.RollbackButton.Size = new System.Drawing.Size(85, 28);
            this.RollbackButton.TabIndex = 39;
            this.RollbackButton.Text = "Rollback";
            this.RollbackButton.UseVisualStyleBackColor = true;
            this.RollbackButton.Click += new System.EventHandler(this.RollbackTx_Click);
            // 
            // CommitButton
            // 
            this.CommitButton.Enabled = false;
            this.CommitButton.Location = new System.Drawing.Point(574, 258);
            this.CommitButton.Name = "CommitButton";
            this.CommitButton.Size = new System.Drawing.Size(85, 28);
            this.CommitButton.TabIndex = 40;
            this.CommitButton.Text = "Commit";
            this.CommitButton.UseVisualStyleBackColor = true;
            this.CommitButton.Click += new System.EventHandler(this.CommitTx_Click);
            // 
            // LogMessagesLabel
            // 
            this.LogMessagesLabel.AutoSize = true;
            this.LogMessagesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogMessagesLabel.Location = new System.Drawing.Point(17, 311);
            this.LogMessagesLabel.Name = "LogMessagesLabel";
            this.LogMessagesLabel.Size = new System.Drawing.Size(117, 17);
            this.LogMessagesLabel.TabIndex = 41;
            this.LogMessagesLabel.Text = "Log Messages:";
            // 
            // TransactionExchangeText
            // 
            this.TransactionExchangeText.Location = new System.Drawing.Point(484, 210);
            this.TransactionExchangeText.Name = "TransactionExchangeText";
            this.TransactionExchangeText.Size = new System.Drawing.Size(197, 20);
            this.TransactionExchangeText.TabIndex = 43;
            this.TransactionExchangeText.Text = "demo_txn_exchange";
            // 
            // TransactionExchangeLabel
            // 
            this.TransactionExchangeLabel.AutoSize = true;
            this.TransactionExchangeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TransactionExchangeLabel.Location = new System.Drawing.Point(394, 209);
            this.TransactionExchangeLabel.Name = "TransactionExchangeLabel";
            this.TransactionExchangeLabel.Size = new System.Drawing.Size(83, 17);
            this.TransactionExchangeLabel.TabIndex = 42;
            this.TransactionExchangeLabel.Text = "Exchange:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(11, 6);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 31);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 44;
            this.pictureBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 17);
            this.label5.TabIndex = 45;
            this.label5.Text = "User ID";
            // 
            // UserIdText
            // 
            this.UserIdText.Location = new System.Drawing.Point(116, 141);
            this.UserIdText.Name = "UserIdText";
            this.UserIdText.Size = new System.Drawing.Size(197, 20);
            this.UserIdText.TabIndex = 46;
            this.UserIdText.Text = "guest";
            this.UserIdText.TextChanged += new System.EventHandler(this.UserIdText_TextChanged);
            // 
            // AMQPDemoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(767, 621);
            this.Controls.Add(this.UserIdText);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.TransactionExchangeText);
            this.Controls.Add(this.TransactionExchangeLabel);
            this.Controls.Add(this.LogMessagesLabel);
            this.Controls.Add(this.CommitButton);
            this.Controls.Add(this.RollbackButton);
            this.Controls.Add(this.PublishTransactionButton);
            this.Controls.Add(this.SelectButton);
            this.Controls.Add(this.TransactionMessageText);
            this.Controls.Add(this.TransactionMessageLabel);
            this.Controls.Add(this.TransactionLabel1);
            this.Controls.Add(this.ConnectionStatusValueLabel);
            this.Controls.Add(this.ConnectionStatusLabel);
            this.Controls.Add(this.ExchangeText);
            this.Controls.Add(this.VirtualHostText);
            this.Controls.Add(this.ExchangeLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.HintLabel1);
            this.Controls.Add(this.Subtitle);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.UnsubscribeButton);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.SubscribeButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MessageText);
            this.Controls.Add(this.MessageLabel);
            this.Controls.Add(this.DisconnectButton);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.ClearLogButton);
            this.Controls.Add(this.Output);
            this.Controls.Add(this.LocationText);
            this.Controls.Add(this.LocationLabel);
            this.Name = "AMQPDemoForm";
            this.Text = "AMQP .Net Client Demo";
            this.Load += new System.EventHandler(this.AMQPDemoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LocationLabel;
        private System.Windows.Forms.TextBox LocationText;
        private System.Windows.Forms.TextBox Output;
        private System.Windows.Forms.Button ClearLogButton;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Button DisconnectButton;
        private System.Windows.Forms.Label MessageLabel;
        private System.Windows.Forms.TextBox MessageText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SubscribeButton;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.Button UnsubscribeButton;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label Subtitle;
        private System.Windows.Forms.Label HintLabel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Label label2;
        private Label ExchangeLabel;
        private TextBox VirtualHostText;
        private TextBox ExchangeText;
        private Label ConnectionStatusLabel;
        private Label ConnectionStatusValueLabel;
        private Label TransactionLabel1;
        private Label TransactionMessageLabel;
        private TextBox TransactionMessageText;
        private Button SelectButton;
        private Button PublishTransactionButton;
        private Button RollbackButton;
        private Button CommitButton;
        private Label LogMessagesLabel;
        private TextBox TransactionExchangeText;
        private Label TransactionExchangeLabel;

        private PictureBox pictureBox1;
        private Label label5;
        private TextBox UserIdText;
    }
    
}