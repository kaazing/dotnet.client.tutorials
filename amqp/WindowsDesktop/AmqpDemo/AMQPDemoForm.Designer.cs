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
            this.UsernameText = new System.Windows.Forms.TextBox();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.PasswordText = new System.Windows.Forms.TextBox();
            this.PasswordLabel = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // LocationLabel
            // 
            this.LocationLabel.AutoSize = true;
            this.LocationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LocationLabel.Location = new System.Drawing.Point(32, 169);
            this.LocationLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LocationLabel.Name = "LocationLabel";
            this.LocationLabel.Size = new System.Drawing.Size(134, 31);
            this.LocationLabel.TabIndex = 0;
            this.LocationLabel.Text = "Location:";
            // 
            // LocationText
            // 
            this.LocationText.Location = new System.Drawing.Point(232, 169);
            this.LocationText.Margin = new System.Windows.Forms.Padding(6);
            this.LocationText.Name = "LocationText";
            this.LocationText.Size = new System.Drawing.Size(390, 31);
            this.LocationText.TabIndex = 1;
            this.LocationText.Text = "ws://sandbox.kaazing.net/amqp091";
            // 
            // UsernameText
            // 
            this.UsernameText.Location = new System.Drawing.Point(232, 269);
            this.UsernameText.Margin = new System.Windows.Forms.Padding(6);
            this.UsernameText.Name = "UsernameText";
            this.UsernameText.Size = new System.Drawing.Size(390, 31);
            this.UsernameText.TabIndex = 3;
            this.UsernameText.Text = "guest";
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameLabel.Location = new System.Drawing.Point(32, 269);
            this.UsernameLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(156, 31);
            this.UsernameLabel.TabIndex = 2;
            this.UsernameLabel.Text = "Username:";
            // 
            // PasswordText
            // 
            this.PasswordText.Location = new System.Drawing.Point(232, 319);
            this.PasswordText.Margin = new System.Windows.Forms.Padding(6);
            this.PasswordText.Name = "PasswordText";
            this.PasswordText.Size = new System.Drawing.Size(390, 31);
            this.PasswordText.TabIndex = 5;
            this.PasswordText.Text = "guest";
            this.PasswordText.UseSystemPasswordChar = true;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordLabel.Location = new System.Drawing.Point(32, 323);
            this.PasswordLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(151, 31);
            this.PasswordLabel.TabIndex = 4;
            this.PasswordLabel.Text = "Password:";
            // 
            // Output
            // 
            this.Output.Location = new System.Drawing.Point(40, 636);
            this.Output.Margin = new System.Windows.Forms.Padding(6);
            this.Output.Multiline = true;
            this.Output.Name = "Output";
            this.Output.Size = new System.Drawing.Size(1448, 438);
            this.Output.TabIndex = 6;
            // 
            // ClearLogButton
            // 
            this.ClearLogButton.Location = new System.Drawing.Point(1292, 1089);
            this.ClearLogButton.Margin = new System.Windows.Forms.Padding(6);
            this.ClearLogButton.Name = "ClearLogButton";
            this.ClearLogButton.Size = new System.Drawing.Size(198, 64);
            this.ClearLogButton.TabIndex = 7;
            this.ClearLogButton.Text = "Clear Log";
            this.ClearLogButton.UseVisualStyleBackColor = true;
            this.ClearLogButton.Click += new System.EventHandler(this.ClearLogButton_Click);
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(38, 431);
            this.ConnectButton.Margin = new System.Windows.Forms.Padding(6);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(170, 53);
            this.ConnectButton.TabIndex = 8;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // DisconnectButton
            // 
            this.DisconnectButton.Enabled = false;
            this.DisconnectButton.Location = new System.Drawing.Point(232, 433);
            this.DisconnectButton.Margin = new System.Windows.Forms.Padding(6);
            this.DisconnectButton.Name = "DisconnectButton";
            this.DisconnectButton.Size = new System.Drawing.Size(170, 53);
            this.DisconnectButton.TabIndex = 9;
            this.DisconnectButton.Text = "Disconnect";
            this.DisconnectButton.UseVisualStyleBackColor = true;
            this.DisconnectButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // MessageLabel
            // 
            this.MessageLabel.AutoSize = true;
            this.MessageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MessageLabel.Location = new System.Drawing.Point(790, 205);
            this.MessageLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(140, 31);
            this.MessageLabel.TabIndex = 10;
            this.MessageLabel.Text = "Message:";
            // 
            // MessageText
            // 
            this.MessageText.Location = new System.Drawing.Point(970, 205);
            this.MessageText.Margin = new System.Windows.Forms.Padding(6);
            this.MessageText.Name = "MessageText";
            this.MessageText.Size = new System.Drawing.Size(390, 31);
            this.MessageText.TabIndex = 11;
            this.MessageText.Text = "Demo message";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(898, 169);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 31);
            this.label1.TabIndex = 12;
            // 
            // SubscribeButton
            // 
            this.SubscribeButton.Enabled = false;
            this.SubscribeButton.Location = new System.Drawing.Point(783, 250);
            this.SubscribeButton.Margin = new System.Windows.Forms.Padding(6);
            this.SubscribeButton.Name = "SubscribeButton";
            this.SubscribeButton.Size = new System.Drawing.Size(170, 53);
            this.SubscribeButton.TabIndex = 14;
            this.SubscribeButton.Text = "Publish";
            this.SubscribeButton.UseVisualStyleBackColor = true;
            this.SubscribeButton.Click += new System.EventHandler(this.Publish_Click);
            // 
            // SendButton
            // 
            this.SendButton.Enabled = false;
            this.SendButton.Location = new System.Drawing.Point(986, 250);
            this.SendButton.Margin = new System.Windows.Forms.Padding(6);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(170, 53);
            this.SendButton.TabIndex = 15;
            this.SendButton.Text = "Flow On";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.Flow_On_Click);
            // 
            // UnsubscribeButton
            // 
            this.UnsubscribeButton.Enabled = false;
            this.UnsubscribeButton.Location = new System.Drawing.Point(1192, 250);
            this.UnsubscribeButton.Margin = new System.Windows.Forms.Padding(6);
            this.UnsubscribeButton.Name = "UnsubscribeButton";
            this.UnsubscribeButton.Size = new System.Drawing.Size(170, 53);
            this.UnsubscribeButton.TabIndex = 16;
            this.UnsubscribeButton.Text = "Flow Off";
            this.UnsubscribeButton.UseVisualStyleBackColor = true;
            this.UnsubscribeButton.Click += new System.EventHandler(this.Flow_Off_Click);
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(82, 16);
            this.Title.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(724, 51);
            this.Title.TabIndex = 18;
            this.Title.Text = "AMQP .Net  Framework Client Demo";
            // 
            // Subtitle
            // 
            this.Subtitle.AutoSize = true;
            this.Subtitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Subtitle.Location = new System.Drawing.Point(28, 67);
            this.Subtitle.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Subtitle.Name = "Subtitle";
            this.Subtitle.Size = new System.Drawing.Size(1250, 31);
            this.Subtitle.TabIndex = 19;
            this.Subtitle.Text = "This is a demo of a AMQP .Net Framework client application that communicates with" +
    " a message broker";
            // 
            // HintLabel1
            // 
            this.HintLabel1.AutoSize = true;
            this.HintLabel1.Location = new System.Drawing.Point(36, 675);
            this.HintLabel1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.HintLabel1.Name = "HintLabel1";
            this.HintLabel1.Size = new System.Drawing.Size(0, 25);
            this.HintLabel1.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 100);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1210, 31);
            this.label3.TabIndex = 24;
            this.label3.Text = "via WebSocket to subscribe to destinations, send and receive messages, and proces" +
    "s transactions.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(898, 269);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 31);
            this.label4.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 217);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 31);
            this.label2.TabIndex = 27;
            this.label2.Text = "Virtual Host:";
            // 
            // ExchangeLabel
            // 
            this.ExchangeLabel.AutoSize = true;
            this.ExchangeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExchangeLabel.Location = new System.Drawing.Point(790, 156);
            this.ExchangeLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.ExchangeLabel.Name = "ExchangeLabel";
            this.ExchangeLabel.Size = new System.Drawing.Size(151, 31);
            this.ExchangeLabel.TabIndex = 28;
            this.ExchangeLabel.Text = "Exchange:";
            // 
            // VirtualHostText
            // 
            this.VirtualHostText.Location = new System.Drawing.Point(232, 219);
            this.VirtualHostText.Margin = new System.Windows.Forms.Padding(6);
            this.VirtualHostText.Name = "VirtualHostText";
            this.VirtualHostText.Size = new System.Drawing.Size(390, 31);
            this.VirtualHostText.TabIndex = 29;
            this.VirtualHostText.Text = "/";
            // 
            // ExchangeText
            // 
            this.ExchangeText.Location = new System.Drawing.Point(970, 158);
            this.ExchangeText.Margin = new System.Windows.Forms.Padding(6);
            this.ExchangeText.Name = "ExchangeText";
            this.ExchangeText.Size = new System.Drawing.Size(390, 31);
            this.ExchangeText.TabIndex = 30;
            this.ExchangeText.Text = "demo_exchange";
            // 
            // ConnectionStatusLabel
            // 
            this.ConnectionStatusLabel.AutoSize = true;
            this.ConnectionStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectionStatusLabel.Location = new System.Drawing.Point(32, 372);
            this.ConnectionStatusLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.ConnectionStatusLabel.Name = "ConnectionStatusLabel";
            this.ConnectionStatusLabel.Size = new System.Drawing.Size(107, 31);
            this.ConnectionStatusLabel.TabIndex = 31;
            this.ConnectionStatusLabel.Text = "Status:";
            // 
            // ConnectionStatusValueLabel
            // 
            this.ConnectionStatusValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectionStatusValueLabel.Location = new System.Drawing.Point(232, 369);
            this.ConnectionStatusValueLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.ConnectionStatusValueLabel.Name = "ConnectionStatusValueLabel";
            this.ConnectionStatusValueLabel.Size = new System.Drawing.Size(522, 39);
            this.ConnectionStatusValueLabel.TabIndex = 32;
            this.ConnectionStatusValueLabel.Text = "DISCONNECTED";
            // 
            // TransactionLabel1
            // 
            this.TransactionLabel1.AutoSize = true;
            this.TransactionLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.TransactionLabel1.Location = new System.Drawing.Point(772, 350);
            this.TransactionLabel1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.TransactionLabel1.Name = "TransactionLabel1";
            this.TransactionLabel1.Size = new System.Drawing.Size(643, 31);
            this.TransactionLabel1.TabIndex = 33;
            this.TransactionLabel1.Text = "Select, send to, and commit or rollback a transaction";
            // 
            // TransactionMessageLabel
            // 
            this.TransactionMessageLabel.AutoSize = true;
            this.TransactionMessageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TransactionMessageLabel.Location = new System.Drawing.Point(788, 450);
            this.TransactionMessageLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.TransactionMessageLabel.Name = "TransactionMessageLabel";
            this.TransactionMessageLabel.Size = new System.Drawing.Size(140, 31);
            this.TransactionMessageLabel.TabIndex = 35;
            this.TransactionMessageLabel.Text = "Message:";
            // 
            // TransactionMessageText
            // 
            this.TransactionMessageText.Location = new System.Drawing.Point(968, 450);
            this.TransactionMessageText.Margin = new System.Windows.Forms.Padding(6);
            this.TransactionMessageText.Name = "TransactionMessageText";
            this.TransactionMessageText.Size = new System.Drawing.Size(390, 31);
            this.TransactionMessageText.TabIndex = 36;
            this.TransactionMessageText.Text = "Demo transaction message";
            // 
            // SelectButton
            // 
            this.SelectButton.Location = new System.Drawing.Point(784, 497);
            this.SelectButton.Margin = new System.Windows.Forms.Padding(6);
            this.SelectButton.Name = "SelectButton";
            this.SelectButton.Size = new System.Drawing.Size(170, 53);
            this.SelectButton.TabIndex = 37;
            this.SelectButton.Text = "Select";
            this.SelectButton.UseVisualStyleBackColor = true;
            this.SelectButton.Click += new System.EventHandler(this.SelectTx_Click);
            // 
            // PublishTransactionButton
            // 
            this.PublishTransactionButton.Enabled = false;
            this.PublishTransactionButton.Location = new System.Drawing.Point(966, 497);
            this.PublishTransactionButton.Margin = new System.Windows.Forms.Padding(6);
            this.PublishTransactionButton.Name = "PublishTransactionButton";
            this.PublishTransactionButton.Size = new System.Drawing.Size(170, 53);
            this.PublishTransactionButton.TabIndex = 38;
            this.PublishTransactionButton.Text = "Publish";
            this.PublishTransactionButton.UseVisualStyleBackColor = true;
            this.PublishTransactionButton.Click += new System.EventHandler(this.PublishTx_Click);
            // 
            // RollbackButton
            // 
            this.RollbackButton.Enabled = false;
            this.RollbackButton.Location = new System.Drawing.Point(1329, 497);
            this.RollbackButton.Margin = new System.Windows.Forms.Padding(6);
            this.RollbackButton.Name = "RollbackButton";
            this.RollbackButton.Size = new System.Drawing.Size(170, 53);
            this.RollbackButton.TabIndex = 39;
            this.RollbackButton.Text = "Rollback";
            this.RollbackButton.UseVisualStyleBackColor = true;
            this.RollbackButton.Click += new System.EventHandler(this.RollbackTx_Click);
            // 
            // CommitButton
            // 
            this.CommitButton.Enabled = false;
            this.CommitButton.Location = new System.Drawing.Point(1149, 497);
            this.CommitButton.Margin = new System.Windows.Forms.Padding(6);
            this.CommitButton.Name = "CommitButton";
            this.CommitButton.Size = new System.Drawing.Size(170, 53);
            this.CommitButton.TabIndex = 40;
            this.CommitButton.Text = "Commit";
            this.CommitButton.UseVisualStyleBackColor = true;
            this.CommitButton.Click += new System.EventHandler(this.CommitTx_Click);
            // 
            // LogMessagesLabel
            // 
            this.LogMessagesLabel.AutoSize = true;
            this.LogMessagesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogMessagesLabel.Location = new System.Drawing.Point(34, 598);
            this.LogMessagesLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LogMessagesLabel.Name = "LogMessagesLabel";
            this.LogMessagesLabel.Size = new System.Drawing.Size(211, 31);
            this.LogMessagesLabel.TabIndex = 41;
            this.LogMessagesLabel.Text = "Log Messages:";
            // 
            // TransactionExchangeText
            // 
            this.TransactionExchangeText.Location = new System.Drawing.Point(968, 403);
            this.TransactionExchangeText.Margin = new System.Windows.Forms.Padding(6);
            this.TransactionExchangeText.Name = "TransactionExchangeText";
            this.TransactionExchangeText.Size = new System.Drawing.Size(390, 31);
            this.TransactionExchangeText.TabIndex = 43;
            this.TransactionExchangeText.Text = "demo_txn_exchange";
            // 
            // TransactionExchangeLabel
            // 
            this.TransactionExchangeLabel.AutoSize = true;
            this.TransactionExchangeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TransactionExchangeLabel.Location = new System.Drawing.Point(788, 402);
            this.TransactionExchangeLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.TransactionExchangeLabel.Name = "TransactionExchangeLabel";
            this.TransactionExchangeLabel.Size = new System.Drawing.Size(151, 31);
            this.TransactionExchangeLabel.TabIndex = 42;
            this.TransactionExchangeLabel.Text = "Exchange:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(22, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 44;
            this.pictureBox1.TabStop = false;
            // 
            // AMQPDemoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1526, 1175);
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
            this.Controls.Add(this.PasswordText);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.UsernameText);
            this.Controls.Add(this.UsernameLabel);
            this.Controls.Add(this.LocationText);
            this.Controls.Add(this.LocationLabel);
            this.Margin = new System.Windows.Forms.Padding(6);
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
        private System.Windows.Forms.TextBox UsernameText;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.TextBox PasswordText;
        private System.Windows.Forms.Label PasswordLabel;
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
    }
    
}