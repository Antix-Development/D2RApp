
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(client_Form));
            this.Connection_Button = new System.Windows.Forms.Button();
            this.ServerIP_TextBox = new System.Windows.Forms.TextBox();
            this.MousePosition_Label = new System.Windows.Forms.Label();
            this.ServerPort_TextBox = new System.Windows.Forms.TextBox();
            this.Net_Timer = new System.Windows.Forms.Timer(this.components);
            this.Script_Timer = new System.Windows.Forms.Timer(this.components);
            this.Status_Label = new System.Windows.Forms.Label();
            this.Status_Timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // Connection_Button
            // 
            this.Connection_Button.Location = new System.Drawing.Point(155, 12);
            this.Connection_Button.Name = "Connection_Button";
            this.Connection_Button.Size = new System.Drawing.Size(70, 20);
            this.Connection_Button.TabIndex = 0;
            this.Connection_Button.Text = "Connect";
            this.Connection_Button.UseVisualStyleBackColor = true;
            this.Connection_Button.Click += new System.EventHandler(this.ConnectionButton_Click);
            // 
            // ServerIP_TextBox
            // 
            this.ServerIP_TextBox.Location = new System.Drawing.Point(12, 12);
            this.ServerIP_TextBox.Name = "ServerIP_TextBox";
            this.ServerIP_TextBox.Size = new System.Drawing.Size(94, 20);
            this.ServerIP_TextBox.TabIndex = 2;
            this.ServerIP_TextBox.Text = "192.168.64.200";
            // 
            // MousePosition_Label
            // 
            this.MousePosition_Label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MousePosition_Label.Location = new System.Drawing.Point(231, 12);
            this.MousePosition_Label.Name = "MousePosition_Label";
            this.MousePosition_Label.Size = new System.Drawing.Size(61, 20);
            this.MousePosition_Label.TabIndex = 8;
            this.MousePosition_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ServerPort_TextBox
            // 
            this.ServerPort_TextBox.Location = new System.Drawing.Point(112, 12);
            this.ServerPort_TextBox.Name = "ServerPort_TextBox";
            this.ServerPort_TextBox.Size = new System.Drawing.Size(37, 20);
            this.ServerPort_TextBox.TabIndex = 9;
            this.ServerPort_TextBox.Text = "9000";
            // 
            // Net_Timer
            // 
            this.Net_Timer.Interval = 16;
            this.Net_Timer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Script_Timer
            // 
            this.Script_Timer.Tick += new System.EventHandler(this.Script_Timer_Tick);
            // 
            // Status_Label
            // 
            this.Status_Label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Status_Label.Location = new System.Drawing.Point(12, 35);
            this.Status_Label.Name = "Status_Label";
            this.Status_Label.Size = new System.Drawing.Size(280, 20);
            this.Status_Label.TabIndex = 10;
            this.Status_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Status_Timer
            // 
            this.Status_Timer.Tick += new System.EventHandler(this.Status_Timer_Tick);
            // 
            // client_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 66);
            this.Controls.Add(this.Status_Label);
            this.Controls.Add(this.ServerPort_TextBox);
            this.Controls.Add(this.MousePosition_Label);
            this.Controls.Add(this.ServerIP_TextBox);
            this.Controls.Add(this.Connection_Button);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
        private System.Windows.Forms.Label MousePosition_Label;
        private System.Windows.Forms.TextBox ServerPort_TextBox;
        private System.Windows.Forms.Timer Net_Timer;
        private System.Windows.Forms.Timer Script_Timer;
        private System.Windows.Forms.Label Status_Label;
        private System.Windows.Forms.Timer Status_Timer;
    }
}

