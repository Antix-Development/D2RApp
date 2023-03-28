
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(serverForm));
            this.Settings_Button = new System.Windows.Forms.Button();
            this.Net_Timer = new System.Windows.Forms.Timer(this.components);
            this.Script_Button_Panel = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Settings_Button
            // 
            this.Settings_Button.Location = new System.Drawing.Point(6, 157);
            this.Settings_Button.Name = "Settings_Button";
            this.Settings_Button.Size = new System.Drawing.Size(281, 23);
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
            this.Script_Button_Panel.Size = new System.Drawing.Size(281, 132);
            this.Script_Button_Panel.TabIndex = 14;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Script_Button_Panel);
            this.groupBox1.Controls.Add(this.Settings_Button);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(293, 186);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Scripts";
            // 
            // serverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 210);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "serverForm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Settings_Button;
        private System.Windows.Forms.Timer Net_Timer;
        private System.Windows.Forms.Panel Script_Button_Panel;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

