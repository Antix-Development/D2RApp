
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
            this.Clients_ListBox = new System.Windows.Forms.ListBox();
            this.Log_TextBox = new System.Windows.Forms.TextBox();
            this.AltHeld_TextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Settings_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Clients_ListBox
            // 
            this.Clients_ListBox.FormattingEnabled = true;
            this.Clients_ListBox.Location = new System.Drawing.Point(305, 12);
            this.Clients_ListBox.Name = "Clients_ListBox";
            this.Clients_ListBox.Size = new System.Drawing.Size(120, 108);
            this.Clients_ListBox.TabIndex = 7;
            // 
            // Log_TextBox
            // 
            this.Log_TextBox.Location = new System.Drawing.Point(12, 12);
            this.Log_TextBox.Multiline = true;
            this.Log_TextBox.Name = "Log_TextBox";
            this.Log_TextBox.ReadOnly = true;
            this.Log_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Log_TextBox.Size = new System.Drawing.Size(287, 137);
            this.Log_TextBox.TabIndex = 9;
            // 
            // AltHeld_TextBox
            // 
            this.AltHeld_TextBox.Location = new System.Drawing.Point(242, 155);
            this.AltHeld_TextBox.Name = "AltHeld_TextBox";
            this.AltHeld_TextBox.ReadOnly = true;
            this.AltHeld_TextBox.Size = new System.Drawing.Size(57, 20);
            this.AltHeld_TextBox.TabIndex = 12;
            this.AltHeld_TextBox.Text = "False";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(184, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "ALT Held";
            // 
            // Settings_Button
            // 
            this.Settings_Button.Location = new System.Drawing.Point(305, 126);
            this.Settings_Button.Name = "Settings_Button";
            this.Settings_Button.Size = new System.Drawing.Size(120, 23);
            this.Settings_Button.TabIndex = 13;
            this.Settings_Button.Text = "Settings";
            this.Settings_Button.UseVisualStyleBackColor = true;
            // 
            // serverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 183);
            this.Controls.Add(this.Settings_Button);
            this.Controls.Add(this.AltHeld_TextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Log_TextBox);
            this.Controls.Add(this.Clients_ListBox);
            this.MaximizeBox = false;
            this.Name = "serverForm";
            this.Text = "Server";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox Clients_ListBox;
        private System.Windows.Forms.TextBox Log_TextBox;
        private System.Windows.Forms.TextBox AltHeld_TextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Settings_Button;
    }
}

