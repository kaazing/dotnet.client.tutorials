/**
 * Copyright (c) 2007-2015, Kaazing Corporation. All rights reserved.
 */
namespace EchoDemo
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.checkBox_Binary = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Subtitle = new System.Windows.Forms.Label();
            this.Title = new System.Windows.Forms.Label();
            this.SendButton = new System.Windows.Forms.Button();
            this.MessageText = new System.Windows.Forms.TextBox();
            this.MessageLabel = new System.Windows.Forms.Label();
            this.DisconnectButton = new System.Windows.Forms.Button();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.ClearLogButton = new System.Windows.Forms.Button();
            this.Output = new System.Windows.Forms.TextBox();
            this.LocationText = new System.Windows.Forms.TextBox();
            this.LocationLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBox_Binary
            // 
            this.checkBox_Binary.AutoSize = true;
            this.checkBox_Binary.Location = new System.Drawing.Point(1058, 282);
            this.checkBox_Binary.Margin = new System.Windows.Forms.Padding(6);
            this.checkBox_Binary.Name = "checkBox_Binary";
            this.checkBox_Binary.Size = new System.Drawing.Size(105, 29);
            this.checkBox_Binary.TabIndex = 38;
            this.checkBox_Binary.Text = "Binary";
            this.checkBox_Binary.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(150, 140);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(656, 31);
            this.label3.TabIndex = 37;
            this.label3.Text = "directly with an echo service on the Kaazing Gateway";
            // 
            // Subtitle
            // 
            this.Subtitle.AutoSize = true;
            this.Subtitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Subtitle.Location = new System.Drawing.Point(150, 108);
            this.Subtitle.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Subtitle.Name = "Subtitle";
            this.Subtitle.Size = new System.Drawing.Size(748, 31);
            this.Subtitle.TabIndex = 36;
            this.Subtitle.Text = "This is a demo of a .Net Framework client that communicates";
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(216, 57);
            this.Title.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(854, 51);
            this.Title.TabIndex = 35;
            this.Title.Text = "Kaazing .Net Framework WebSocket Demo";
            // 
            // SendButton
            // 
            this.SendButton.Enabled = false;
            this.SendButton.Location = new System.Drawing.Point(1218, 266);
            this.SendButton.Margin = new System.Windows.Forms.Padding(6);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(170, 54);
            this.SendButton.TabIndex = 34;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // MessageText
            // 
            this.MessageText.Location = new System.Drawing.Point(330, 281);
            this.MessageText.Margin = new System.Windows.Forms.Padding(6);
            this.MessageText.Name = "MessageText";
            this.MessageText.Size = new System.Drawing.Size(694, 31);
            this.MessageText.TabIndex = 33;
            this.MessageText.Text = "Hello, Message";
            // 
            // MessageLabel
            // 
            this.MessageLabel.AutoSize = true;
            this.MessageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MessageLabel.Location = new System.Drawing.Point(154, 283);
            this.MessageLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(140, 31);
            this.MessageLabel.TabIndex = 32;
            this.MessageLabel.Text = "Message:";
            // 
            // DisconnectButton
            // 
            this.DisconnectButton.Enabled = false;
            this.DisconnectButton.Location = new System.Drawing.Point(1218, 195);
            this.DisconnectButton.Margin = new System.Windows.Forms.Padding(6);
            this.DisconnectButton.Name = "DisconnectButton";
            this.DisconnectButton.Size = new System.Drawing.Size(170, 54);
            this.DisconnectButton.TabIndex = 31;
            this.DisconnectButton.Text = "Disconnect";
            this.DisconnectButton.UseVisualStyleBackColor = true;
            this.DisconnectButton.Click += new System.EventHandler(this.DisconnectButton_Click);
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(1036, 195);
            this.ConnectButton.Margin = new System.Windows.Forms.Padding(6);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(170, 54);
            this.ConnectButton.TabIndex = 30;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // ClearLogButton
            // 
            this.ClearLogButton.Location = new System.Drawing.Point(1212, 1035);
            this.ClearLogButton.Margin = new System.Windows.Forms.Padding(6);
            this.ClearLogButton.Name = "ClearLogButton";
            this.ClearLogButton.Size = new System.Drawing.Size(198, 63);
            this.ClearLogButton.TabIndex = 29;
            this.ClearLogButton.Text = "Clear Log";
            this.ClearLogButton.UseVisualStyleBackColor = true;
            this.ClearLogButton.Click += new System.EventHandler(this.ClearLogButton_Click);
            // 
            // Output
            // 
            this.Output.Location = new System.Drawing.Point(160, 348);
            this.Output.Margin = new System.Windows.Forms.Padding(6);
            this.Output.Multiline = true;
            this.Output.Name = "Output";
            this.Output.Size = new System.Drawing.Size(1246, 671);
            this.Output.TabIndex = 28;
            // 
            // LocationText
            // 
            this.LocationText.Location = new System.Drawing.Point(330, 204);
            this.LocationText.Margin = new System.Windows.Forms.Padding(6);
            this.LocationText.Name = "LocationText";
            this.LocationText.Size = new System.Drawing.Size(694, 31);
            this.LocationText.TabIndex = 27;
            this.LocationText.TextChanged += new System.EventHandler(this.LocationText_TextChanged);
            // 
            // LocationLabel
            // 
            this.LocationLabel.AutoSize = true;
            this.LocationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LocationLabel.Location = new System.Drawing.Point(154, 204);
            this.LocationLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LocationLabel.Name = "LocationLabel";
            this.LocationLabel.Size = new System.Drawing.Size(134, 31);
            this.LocationLabel.TabIndex = 26;
            this.LocationLabel.Text = "Location:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(156, 48);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 39;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1568, 1164);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.checkBox_Binary);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Subtitle);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.MessageText);
            this.Controls.Add(this.MessageLabel);
            this.Controls.Add(this.DisconnectButton);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.ClearLogButton);
            this.Controls.Add(this.Output);
            this.Controls.Add(this.LocationText);
            this.Controls.Add(this.LocationLabel);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "MainForm";
            this.Text = "Kaaazing WebSocket Echo Demo";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox_Binary;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Subtitle;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.TextBox MessageText;
        private System.Windows.Forms.Label MessageLabel;
        private System.Windows.Forms.Button DisconnectButton;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Button ClearLogButton;
        private System.Windows.Forms.TextBox Output;
        private System.Windows.Forms.TextBox LocationText;
        private System.Windows.Forms.Label LocationLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

