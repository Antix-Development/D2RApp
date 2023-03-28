
namespace D2RServer
{
    partial class serverForm
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
            this.Clients_ListBox = new System.Windows.Forms.ListBox();
            this.Log_TextBox = new System.Windows.Forms.TextBox();
            this.Settings_Button = new System.Windows.Forms.Button();
            this.Net_Timer = new System.Windows.Forms.Timer(this.components);
            this.Script_Button_Panel = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Clients_ListBox
            // 
            this.Clients_ListBox.FormattingEnabled = true;
            this.Clients_ListBox.Location = new System.Drawing.Point(6, 19);
            this.Clients_ListBox.Name = "Clients_ListBox";
            this.Clients_ListBox.Size = new System.Drawing.Size(150, 186);
            this.Clients_ListBox.TabIndex = 7;
            // 
            // Log_TextBox
            // 
            this.Log_TextBox.Location = new System.Drawing.Point(12, 239);
            this.Log_TextBox.Multiline = true;
            this.Log_TextBox.Name = "Log_TextBox";
            this.Log_TextBox.ReadOnly = true;
            this.Log_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Log_TextBox.Size = new System.Drawing.Size(425, 133);
            this.Log_TextBox.TabIndex = 0;
            this.Log_TextBox.TabStop = false;
            // 
            // Settings_Button
            // 
            this.Settings_Button.Location = new System.Drawing.Point(6, 174);
            this.Settings_Button.Name = "Settings_Button";
            this.Settings_Button.Size = new System.Drawing.Size(219, 23);
            this.Settings_Button.TabIndex = 13;
            this.Settings_Button.Text = "Edit Scripts";
            this.Settings_Button.UseVisualStyleBackColor = true;
            this.Settings_Button.Click += new System.EventHandler(this.Settings_Button_Click);
            // 
            // Net_Timer
            // 
            this.Net_Timer.Interval = 16;
            this.Net_Timer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Script_Button_Panel
            // 
            this.Script_Button_Panel.AutoScroll = true;
            this.Script_Button_Panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Script_Button_Panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Script_Button_Panel.Location = new System.Drawing.Point(6, 19);
            this.Script_Button_Panel.Name = "Script_Button_Panel";
            this.Script_Button_Panel.Size = new System.Drawing.Size(219, 149);
            this.Script_Button_Panel.TabIndex = 14;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Script_Button_Panel);
            this.groupBox1.Controls.Add(this.Settings_Button);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(247, 207);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Scripts";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Clients_ListBox);
            this.groupBox2.Location = new System.Drawing.Point(275, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(162, 212);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Clients";
            // 
            // serverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 383);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Log_TextBox);
            this.MaximizeBox = false;
            this.Name = "serverForm";
            this.ShowIcon = false;
            this.Text = "D2RApp";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox Clients_ListBox;
        private System.Windows.Forms.TextBox Log_TextBox;
        private System.Windows.Forms.Button Settings_Button;
        private System.Windows.Forms.Timer Net_Timer;
        private System.Windows.Forms.Panel Script_Button_Panel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

