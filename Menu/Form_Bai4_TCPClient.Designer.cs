
namespace Menu
{
    partial class Form_Bai4_TCPClient
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_connect = new System.Windows.Forms.Button();
            this.btn_disconnect = new System.Windows.Forms.Button();
            this.btn_send = new System.Windows.Forms.Button();
            this.btn_clearMessage = new System.Windows.Forms.Button();
            this.txt_remoteIP = new System.Windows.Forms.TextBox();
            this.txt_remotePort = new System.Windows.Forms.TextBox();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.txt_message = new System.Windows.Forms.TextBox();
            this.lb_message = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Remote IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(376, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Remote Port";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(27, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "Message";
            // 
            // btn_connect
            // 
            this.btn_connect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_connect.Location = new System.Drawing.Point(635, 20);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(129, 44);
            this.btn_connect.TabIndex = 1;
            this.btn_connect.Text = "Connect";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // btn_disconnect
            // 
            this.btn_disconnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_disconnect.AutoSize = true;
            this.btn_disconnect.Enabled = false;
            this.btn_disconnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_disconnect.Location = new System.Drawing.Point(603, 539);
            this.btn_disconnect.Name = "btn_disconnect";
            this.btn_disconnect.Size = new System.Drawing.Size(161, 45);
            this.btn_disconnect.TabIndex = 1;
            this.btn_disconnect.Text = "Disconnect";
            this.btn_disconnect.UseVisualStyleBackColor = true;
            this.btn_disconnect.Click += new System.EventHandler(this.btn_disconnect_Click);
            // 
            // btn_send
            // 
            this.btn_send.Enabled = false;
            this.btn_send.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_send.Location = new System.Drawing.Point(635, 132);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(129, 44);
            this.btn_send.TabIndex = 1;
            this.btn_send.Text = "Send";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // btn_clearMessage
            // 
            this.btn_clearMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_clearMessage.Enabled = false;
            this.btn_clearMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_clearMessage.Location = new System.Drawing.Point(32, 539);
            this.btn_clearMessage.Name = "btn_clearMessage";
            this.btn_clearMessage.Size = new System.Drawing.Size(206, 45);
            this.btn_clearMessage.TabIndex = 1;
            this.btn_clearMessage.Text = "Clear message";
            this.btn_clearMessage.UseVisualStyleBackColor = true;
            this.btn_clearMessage.Click += new System.EventHandler(this.btn_clearMessage_Click);
            // 
            // txt_remoteIP
            // 
            this.txt_remoteIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_remoteIP.Location = new System.Drawing.Point(135, 25);
            this.txt_remoteIP.Name = "txt_remoteIP";
            this.txt_remoteIP.Size = new System.Drawing.Size(198, 30);
            this.txt_remoteIP.TabIndex = 2;
            // 
            // txt_remotePort
            // 
            this.txt_remotePort.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_remotePort.Location = new System.Drawing.Point(510, 27);
            this.txt_remotePort.Name = "txt_remotePort";
            this.txt_remotePort.Size = new System.Drawing.Size(100, 30);
            this.txt_remotePort.TabIndex = 2;
            // 
            // txt_name
            // 
            this.txt_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_name.Location = new System.Drawing.Point(135, 83);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(198, 30);
            this.txt_name.TabIndex = 2;
            // 
            // txt_message
            // 
            this.txt_message.Enabled = false;
            this.txt_message.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_message.Location = new System.Drawing.Point(135, 139);
            this.txt_message.Name = "txt_message";
            this.txt_message.Size = new System.Drawing.Size(475, 30);
            this.txt_message.TabIndex = 2;
            // 
            // lb_message
            // 
            this.lb_message.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_message.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_message.FormattingEnabled = true;
            this.lb_message.ItemHeight = 25;
            this.lb_message.Location = new System.Drawing.Point(30, 195);
            this.lb_message.Name = "lb_message";
            this.lb_message.Size = new System.Drawing.Size(734, 329);
            this.lb_message.TabIndex = 3;
            // 
            // Form_Bai4_TCPClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 596);
            this.Controls.Add(this.lb_message);
            this.Controls.Add(this.txt_message);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.txt_remotePort);
            this.Controls.Add(this.txt_remoteIP);
            this.Controls.Add(this.btn_disconnect);
            this.Controls.Add(this.btn_clearMessage);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.btn_connect);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form_Bai4_TCPClient";
            this.Text = "Bài 4 - TCP Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.Button btn_disconnect;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.Button btn_clearMessage;
        private System.Windows.Forms.TextBox txt_remoteIP;
        private System.Windows.Forms.TextBox txt_remotePort;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.TextBox txt_message;
        private System.Windows.Forms.ListBox lb_message;
    }
}