/**
 * Copyright (c) 2007-2015, Kaazing Corporation. All rights reserved.
 */

namespace Kaazing.JMS.Demo
{
    partial class StompDemoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StompDemoForm));
            this.LocationLabel = new System.Windows.Forms.Label();
            this.LocationText = new System.Windows.Forms.TextBox();
            this.Output = new System.Windows.Forms.TextBox();
            this.ClearLogButton = new System.Windows.Forms.Button();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.DisconnectButton = new System.Windows.Forms.Button();
            this.MessageLabel = new System.Windows.Forms.Label();
            this.MessageText = new System.Windows.Forms.TextBox();
            this.DestinationText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SubscribeButton = new System.Windows.Forms.Button();
            this.SendButton = new System.Windows.Forms.Button();
            this.UnsubscribeButton = new System.Windows.Forms.Button();
            this.Title = new System.Windows.Forms.Label();
            this.Subtitle = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BinaryCheckBox = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
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
            this.LocationText.Location = new System.Drawing.Point(104, 88);
            this.LocationText.Name = "LocationText";
            this.LocationText.Size = new System.Drawing.Size(197, 20);
            this.LocationText.TabIndex = 1;
            this.LocationText.TextChanged += new System.EventHandler(this.LocationText_TextChanged);
            // 
            // Output
            // 
            this.Output.Location = new System.Drawing.Point(19, 173);
            this.Output.Multiline = true;
            this.Output.Name = "Output";
            this.Output.Size = new System.Drawing.Size(625, 338);
            this.Output.TabIndex = 6;
            // 
            // ClearLogButton
            // 
            this.ClearLogButton.Location = new System.Drawing.Point(545, 517);
            this.ClearLogButton.Name = "ClearLogButton";
            this.ClearLogButton.Size = new System.Drawing.Size(99, 33);
            this.ClearLogButton.TabIndex = 7;
            this.ClearLogButton.Text = "Clear Log";
            this.ClearLogButton.UseVisualStyleBackColor = true;
            this.ClearLogButton.Click += new System.EventHandler(this.ClearLogButton_Click);
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(101, 139);
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
            this.DisconnectButton.Location = new System.Drawing.Point(192, 139);
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
            this.MessageLabel.Location = new System.Drawing.Point(16, 116);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(77, 17);
            this.MessageLabel.TabIndex = 10;
            this.MessageLabel.Text = "Message:";
            // 
            // MessageText
            // 
            this.MessageText.Location = new System.Drawing.Point(104, 113);
            this.MessageText.Name = "MessageText";
            this.MessageText.Size = new System.Drawing.Size(454, 20);
            this.MessageText.TabIndex = 11;
            this.MessageText.Text = "Hello, Message";
            // 
            // DestinationText
            // 
            this.DestinationText.Location = new System.Drawing.Point(447, 88);
            this.DestinationText.Name = "DestinationText";
            this.DestinationText.Size = new System.Drawing.Size(197, 20);
            this.DestinationText.TabIndex = 13;
            this.DestinationText.Text = "/topic/destination";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(338, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Subscription:";
            // 
            // SubscribeButton
            // 
            this.SubscribeButton.Enabled = false;
            this.SubscribeButton.Location = new System.Drawing.Point(353, 139);
            this.SubscribeButton.Name = "SubscribeButton";
            this.SubscribeButton.Size = new System.Drawing.Size(85, 28);
            this.SubscribeButton.TabIndex = 14;
            this.SubscribeButton.Text = "Subscribe";
            this.SubscribeButton.UseVisualStyleBackColor = true;
            this.SubscribeButton.Click += new System.EventHandler(this.SubscribeButton_Click);
            // 
            // SendButton
            // 
            this.SendButton.Enabled = false;
            this.SendButton.Location = new System.Drawing.Point(444, 139);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(85, 28);
            this.SendButton.TabIndex = 15;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // UnsubscribeButton
            // 
            this.UnsubscribeButton.Enabled = false;
            this.UnsubscribeButton.Location = new System.Drawing.Point(535, 139);
            this.UnsubscribeButton.Name = "UnsubscribeButton";
            this.UnsubscribeButton.Size = new System.Drawing.Size(85, 28);
            this.UnsubscribeButton.TabIndex = 16;
            this.UnsubscribeButton.Text = "Unsubscribe";
            this.UnsubscribeButton.UseVisualStyleBackColor = true;
            this.UnsubscribeButton.Click += new System.EventHandler(this.UnsubscribeButton_Click);
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(46, 8);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(367, 26);
            this.Title.TabIndex = 18;
            this.Title.Text = "Kaazing .Net Framework JMS Demo";
            // 
            // Subtitle
            // 
            this.Subtitle.AutoSize = true;
            this.Subtitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Subtitle.Location = new System.Drawing.Point(14, 35);
            this.Subtitle.Name = "Subtitle";
            this.Subtitle.Size = new System.Drawing.Size(639, 17);
            this.Subtitle.TabIndex = 19;
            this.Subtitle.Text = "This is a demo of a JMS .Net Framework client application that communicates with " +
    "a message broker";
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
            this.label4.Location = new System.Drawing.Point(564, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 17);
            this.label4.TabIndex = 25;
            this.label4.Text = "Binary:";
            // 
            // BinaryCheckBox
            // 
            this.BinaryCheckBox.AutoSize = true;
            this.BinaryCheckBox.Location = new System.Drawing.Point(629, 116);
            this.BinaryCheckBox.Name = "BinaryCheckBox";
            this.BinaryCheckBox.Size = new System.Drawing.Size(15, 14);
            this.BinaryCheckBox.TabIndex = 26;
            this.BinaryCheckBox.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(17, 7);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 31);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // StompDemoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(666, 562);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.BinaryCheckBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Subtitle);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.UnsubscribeButton);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.SubscribeButton);
            this.Controls.Add(this.DestinationText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MessageText);
            this.Controls.Add(this.MessageLabel);
            this.Controls.Add(this.DisconnectButton);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.ClearLogButton);
            this.Controls.Add(this.Output);
            this.Controls.Add(this.LocationText);
            this.Controls.Add(this.LocationLabel);
            this.Name = "StompDemoForm";
            this.Text = "JMS .Net Client Demo";
            this.Load += new System.EventHandler(this.StompDemoForm_Load);
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
        private System.Windows.Forms.TextBox DestinationText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SubscribeButton;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.Button UnsubscribeButton;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label Subtitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox BinaryCheckBox;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

