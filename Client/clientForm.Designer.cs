
namespace D2RApp
{
    partial class client_Form
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
            this.components = new System.ComponentModel.Container();
            this.Connection_Button = new System.Windows.Forms.Button();
            this.ServerIP_TextBox = new System.Windows.Forms.TextBox();
            this.Log_TextBox = new System.Windows.Forms.TextBox();
            this.MousePosition_Label = new System.Windows.Forms.Label();
            this.ServerPort_TextBox = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // Connection_Button
            // 
            this.Connection_Button.Location = new System.Drawing.Point(217, 12);
            this.Connection_Button.Name = "Connection_Button";
            this.Connection_Button.Size = new System.Drawing.Size(93, 20);
            this.Connection_Button.TabIndex = 0;
            this.Connection_Button.Text = "Connect";
            this.Connection_Button.UseVisualStyleBackColor = true;
            this.Connection_Button.Click += new System.EventHandler(this.ConnectionButton_Click);
            // 
            // ServerIP_TextBox
            // 
            this.ServerIP_TextBox.Location = new System.Drawing.Point(12, 12);
            this.ServerIP_TextBox.Name = "ServerIP_TextBox";
            this.ServerIP_TextBox.Size = new System.Drawing.Size(132, 20);
            this.ServerIP_TextBox.TabIndex = 2;
            this.ServerIP_TextBox.Text = "192.168.64.200";
            // 
            // Log_TextBox
            // 
            this.Log_TextBox.Location = new System.Drawing.Point(12, 38);
            this.Log_TextBox.Multiline = true;
            this.Log_TextBox.Name = "Log_TextBox";
            this.Log_TextBox.ReadOnly = true;
            this.Log_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Log_TextBox.Size = new System.Drawing.Size(375, 108);
            this.Log_TextBox.TabIndex = 3;
            // 
            // MousePosition_Label
            // 
            this.MousePosition_Label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MousePosition_Label.Location = new System.Drawing.Point(316, 12);
            this.MousePosition_Label.Name = "MousePosition_Label";
            this.MousePosition_Label.Size = new System.Drawing.Size(71, 20);
            this.MousePosition_Label.TabIndex = 8;
            // 
            // ServerPort_TextBox
            // 
            this.ServerPort_TextBox.Location = new System.Drawing.Point(150, 12);
            this.ServerPort_TextBox.Name = "ServerPort_TextBox";
            this.ServerPort_TextBox.Size = new System.Drawing.Size(61, 20);
            this.ServerPort_TextBox.TabIndex = 9;
            this.ServerPort_TextBox.Text = "9000";
            // 
            // timer1
            // 
            this.timer1.Interval = 16;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // client_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 158);
            this.Controls.Add(this.ServerPort_TextBox);
            this.Controls.Add(this.MousePosition_Label);
            this.Controls.Add(this.Log_TextBox);
            this.Controls.Add(this.ServerIP_TextBox);
            this.Controls.Add(this.Connection_Button);
            this.MaximizeBox = false;
            this.Name = "client_Form";
            this.Text = "Client";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Connection_Button;
        private System.Windows.Forms.TextBox ServerIP_TextBox;
        private System.Windows.Forms.TextBox Log_TextBox;
        private System.Windows.Forms.Label MousePosition_Label;
        private System.Windows.Forms.TextBox ServerPort_TextBox;
        private System.Windows.Forms.Timer timer1;
    }
}

