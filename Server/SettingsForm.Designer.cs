
namespace D2RServer
{
    partial class ScriptEditor
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Actions_GroupBox = new System.Windows.Forms.GroupBox();
            this.ActionX_TextBox = new System.Windows.Forms.TextBox();
            this.ActionDown_Button = new System.Windows.Forms.Button();
            this.ActionKey_Button = new System.Windows.Forms.Button();
            this.ActionUp_Button = new System.Windows.Forms.Button();
            this.ActionY_TextBox = new System.Windows.Forms.TextBox();
            this.DeleteAction_Button = new System.Windows.Forms.Button();
            this.ActionDelay_TextBox = new System.Windows.Forms.TextBox();
            this.Actions_ListBox = new System.Windows.Forms.ListBox();
            this.ActionType_GroupBox = new System.Windows.Forms.GroupBox();
            this.KeyPress_RadioButton = new System.Windows.Forms.RadioButton();
            this.RightClick_RadioButton = new System.Windows.Forms.RadioButton();
            this.LeftClick_RadioButton = new System.Windows.Forms.RadioButton();
            this.MouseMove_RadioButton = new System.Windows.Forms.RadioButton();
            this.label28 = new System.Windows.Forms.Label();
            this.NewAction_Button = new System.Windows.Forms.Button();
            this.label24 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.ScriptDown_Button = new System.Windows.Forms.Button();
            this.Scripts_ListBox = new System.Windows.Forms.ListBox();
            this.DeleteScript_Button = new System.Windows.Forms.Button();
            this.NewScript_Button = new System.Windows.Forms.Button();
            this.ScriptName_TextBox = new System.Windows.Forms.TextBox();
            this.ScriptUp_Button = new System.Windows.Forms.Button();
            this.Accept_Button = new System.Windows.Forms.Button();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.Actions_GroupBox.SuspendLayout();
            this.ActionType_GroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Actions_GroupBox);
            this.groupBox3.Controls.Add(this.ScriptDown_Button);
            this.groupBox3.Controls.Add(this.Scripts_ListBox);
            this.groupBox3.Controls.Add(this.DeleteScript_Button);
            this.groupBox3.Controls.Add(this.NewScript_Button);
            this.groupBox3.Controls.Add(this.ScriptName_TextBox);
            this.groupBox3.Controls.Add(this.ScriptUp_Button);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(670, 351);
            this.groupBox3.TabIndex = 49;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Scripts";
            // 
            // Actions_GroupBox
            // 
            this.Actions_GroupBox.Controls.Add(this.ActionX_TextBox);
            this.Actions_GroupBox.Controls.Add(this.ActionDown_Button);
            this.Actions_GroupBox.Controls.Add(this.ActionKey_Button);
            this.Actions_GroupBox.Controls.Add(this.ActionUp_Button);
            this.Actions_GroupBox.Controls.Add(this.ActionY_TextBox);
            this.Actions_GroupBox.Controls.Add(this.DeleteAction_Button);
            this.Actions_GroupBox.Controls.Add(this.ActionDelay_TextBox);
            this.Actions_GroupBox.Controls.Add(this.Actions_ListBox);
            this.Actions_GroupBox.Controls.Add(this.ActionType_GroupBox);
            this.Actions_GroupBox.Controls.Add(this.label28);
            this.Actions_GroupBox.Controls.Add(this.NewAction_Button);
            this.Actions_GroupBox.Controls.Add(this.label24);
            this.Actions_GroupBox.Controls.Add(this.label21);
            this.Actions_GroupBox.Controls.Add(this.label25);
            this.Actions_GroupBox.Enabled = false;
            this.Actions_GroupBox.Location = new System.Drawing.Point(310, 19);
            this.Actions_GroupBox.Name = "Actions_GroupBox";
            this.Actions_GroupBox.Size = new System.Drawing.Size(354, 324);
            this.Actions_GroupBox.TabIndex = 70;
            this.Actions_GroupBox.TabStop = false;
            this.Actions_GroupBox.Text = "Actions";
            // 
            // ActionX_TextBox
            // 
            this.ActionX_TextBox.Enabled = false;
            this.ActionX_TextBox.Location = new System.Drawing.Point(118, 295);
            this.ActionX_TextBox.Name = "ActionX_TextBox";
            this.ActionX_TextBox.Size = new System.Drawing.Size(45, 20);
            this.ActionX_TextBox.TabIndex = 113;
            this.ActionX_TextBox.Text = "0";
            this.ActionX_TextBox.TextChanged += new System.EventHandler(this.ActionX_TextBox_TextChanged);
            // 
            // ActionDown_Button
            // 
            this.ActionDown_Button.Enabled = false;
            this.ActionDown_Button.Location = new System.Drawing.Point(267, 211);
            this.ActionDown_Button.Name = "ActionDown_Button";
            this.ActionDown_Button.Size = new System.Drawing.Size(81, 23);
            this.ActionDown_Button.TabIndex = 110;
            this.ActionDown_Button.Text = "Down";
            this.ActionDown_Button.UseVisualStyleBackColor = true;
            this.ActionDown_Button.Click += new System.EventHandler(this.ActionDown_Button_Click);
            // 
            // ActionKey_Button
            // 
            this.ActionKey_Button.Enabled = false;
            this.ActionKey_Button.Location = new System.Drawing.Point(271, 293);
            this.ActionKey_Button.Name = "ActionKey_Button";
            this.ActionKey_Button.Size = new System.Drawing.Size(77, 23);
            this.ActionKey_Button.TabIndex = 115;
            this.ActionKey_Button.Text = "Set Key";
            this.ActionKey_Button.UseVisualStyleBackColor = true;
            this.ActionKey_Button.Click += new System.EventHandler(this.ActionKey_Button_Click);
            // 
            // ActionUp_Button
            // 
            this.ActionUp_Button.Enabled = false;
            this.ActionUp_Button.Location = new System.Drawing.Point(180, 211);
            this.ActionUp_Button.Name = "ActionUp_Button";
            this.ActionUp_Button.Size = new System.Drawing.Size(81, 23);
            this.ActionUp_Button.TabIndex = 109;
            this.ActionUp_Button.Text = "Up";
            this.ActionUp_Button.UseVisualStyleBackColor = true;
            this.ActionUp_Button.Click += new System.EventHandler(this.ActionUp_Button_Click);
            // 
            // ActionY_TextBox
            // 
            this.ActionY_TextBox.Enabled = false;
            this.ActionY_TextBox.Location = new System.Drawing.Point(189, 295);
            this.ActionY_TextBox.Name = "ActionY_TextBox";
            this.ActionY_TextBox.Size = new System.Drawing.Size(45, 20);
            this.ActionY_TextBox.TabIndex = 114;
            this.ActionY_TextBox.Text = "0";
            this.ActionY_TextBox.TextChanged += new System.EventHandler(this.ActionY_TextBox_TextChanged);
            // 
            // DeleteAction_Button
            // 
            this.DeleteAction_Button.Enabled = false;
            this.DeleteAction_Button.Location = new System.Drawing.Point(93, 211);
            this.DeleteAction_Button.Name = "DeleteAction_Button";
            this.DeleteAction_Button.Size = new System.Drawing.Size(81, 23);
            this.DeleteAction_Button.TabIndex = 108;
            this.DeleteAction_Button.Text = "Delete";
            this.DeleteAction_Button.UseVisualStyleBackColor = true;
            this.DeleteAction_Button.Click += new System.EventHandler(this.DeleteAction_Button_Click);
            // 
            // ActionDelay_TextBox
            // 
            this.ActionDelay_TextBox.Enabled = false;
            this.ActionDelay_TextBox.Location = new System.Drawing.Point(47, 295);
            this.ActionDelay_TextBox.Name = "ActionDelay_TextBox";
            this.ActionDelay_TextBox.Size = new System.Drawing.Size(45, 20);
            this.ActionDelay_TextBox.TabIndex = 112;
            this.ActionDelay_TextBox.TextChanged += new System.EventHandler(this.ActionDelay_TextBox_TextChanged);
            // 
            // Actions_ListBox
            // 
            this.Actions_ListBox.FormattingEnabled = true;
            this.Actions_ListBox.Location = new System.Drawing.Point(6, 19);
            this.Actions_ListBox.Name = "Actions_ListBox";
            this.Actions_ListBox.ScrollAlwaysVisible = true;
            this.Actions_ListBox.Size = new System.Drawing.Size(342, 186);
            this.Actions_ListBox.TabIndex = 106;
            this.Actions_ListBox.SelectedIndexChanged += new System.EventHandler(this.Actions_ListBox_SelectedIndexChanged);
            // 
            // ActionType_GroupBox
            // 
            this.ActionType_GroupBox.Controls.Add(this.KeyPress_RadioButton);
            this.ActionType_GroupBox.Controls.Add(this.RightClick_RadioButton);
            this.ActionType_GroupBox.Controls.Add(this.LeftClick_RadioButton);
            this.ActionType_GroupBox.Controls.Add(this.MouseMove_RadioButton);
            this.ActionType_GroupBox.Enabled = false;
            this.ActionType_GroupBox.Location = new System.Drawing.Point(6, 240);
            this.ActionType_GroupBox.Name = "ActionType_GroupBox";
            this.ActionType_GroupBox.Size = new System.Drawing.Size(342, 49);
            this.ActionType_GroupBox.TabIndex = 111;
            this.ActionType_GroupBox.TabStop = false;
            this.ActionType_GroupBox.Text = "Type";
            // 
            // KeyPress_RadioButton
            // 
            this.KeyPress_RadioButton.AutoSize = true;
            this.KeyPress_RadioButton.Location = new System.Drawing.Point(265, 19);
            this.KeyPress_RadioButton.Name = "KeyPress_RadioButton";
            this.KeyPress_RadioButton.Size = new System.Drawing.Size(69, 17);
            this.KeyPress_RadioButton.TabIndex = 3;
            this.KeyPress_RadioButton.TabStop = true;
            this.KeyPress_RadioButton.Text = "KeyPress";
            this.KeyPress_RadioButton.UseVisualStyleBackColor = true;
            this.KeyPress_RadioButton.CheckedChanged += new System.EventHandler(this.KeyPress_RadioButton_CheckedChanged);
            // 
            // RightClick_RadioButton
            // 
            this.RightClick_RadioButton.AutoSize = true;
            this.RightClick_RadioButton.Location = new System.Drawing.Point(180, 19);
            this.RightClick_RadioButton.Name = "RightClick_RadioButton";
            this.RightClick_RadioButton.Size = new System.Drawing.Size(73, 17);
            this.RightClick_RadioButton.TabIndex = 2;
            this.RightClick_RadioButton.TabStop = true;
            this.RightClick_RadioButton.Text = "RightClick";
            this.RightClick_RadioButton.UseVisualStyleBackColor = true;
            this.RightClick_RadioButton.CheckedChanged += new System.EventHandler(this.RightClick_RadioButton_CheckedChanged);
            // 
            // LeftClick_RadioButton
            // 
            this.LeftClick_RadioButton.AutoSize = true;
            this.LeftClick_RadioButton.Location = new System.Drawing.Point(102, 19);
            this.LeftClick_RadioButton.Name = "LeftClick_RadioButton";
            this.LeftClick_RadioButton.Size = new System.Drawing.Size(66, 17);
            this.LeftClick_RadioButton.TabIndex = 1;
            this.LeftClick_RadioButton.TabStop = true;
            this.LeftClick_RadioButton.Text = "LeftClick";
            this.LeftClick_RadioButton.UseVisualStyleBackColor = true;
            this.LeftClick_RadioButton.CheckedChanged += new System.EventHandler(this.LeftClick_RadioButton_CheckedChanged);
            // 
            // MouseMove_RadioButton
            // 
            this.MouseMove_RadioButton.AutoSize = true;
            this.MouseMove_RadioButton.Location = new System.Drawing.Point(6, 19);
            this.MouseMove_RadioButton.Name = "MouseMove_RadioButton";
            this.MouseMove_RadioButton.Size = new System.Drawing.Size(84, 17);
            this.MouseMove_RadioButton.TabIndex = 0;
            this.MouseMove_RadioButton.TabStop = true;
            this.MouseMove_RadioButton.Text = "MouseMove";
            this.MouseMove_RadioButton.UseVisualStyleBackColor = true;
            this.MouseMove_RadioButton.CheckedChanged += new System.EventHandler(this.MouseMove_CheckedChanged);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(7, 298);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(34, 13);
            this.label28.TabIndex = 63;
            this.label28.Text = "Delay";
            // 
            // NewAction_Button
            // 
            this.NewAction_Button.Enabled = false;
            this.NewAction_Button.Location = new System.Drawing.Point(6, 211);
            this.NewAction_Button.Name = "NewAction_Button";
            this.NewAction_Button.Size = new System.Drawing.Size(81, 23);
            this.NewAction_Button.TabIndex = 107;
            this.NewAction_Button.Text = "New Action";
            this.NewAction_Button.UseVisualStyleBackColor = true;
            this.NewAction_Button.Click += new System.EventHandler(this.NewAction_Button_Click);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(98, 298);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(14, 13);
            this.label24.TabIndex = 64;
            this.label24.Text = "X";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(240, 298);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(25, 13);
            this.label21.TabIndex = 67;
            this.label21.Text = "Key";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(169, 298);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(14, 13);
            this.label25.TabIndex = 65;
            this.label25.Text = "Y";
            // 
            // ScriptDown_Button
            // 
            this.ScriptDown_Button.Enabled = false;
            this.ScriptDown_Button.Location = new System.Drawing.Point(234, 294);
            this.ScriptDown_Button.Name = "ScriptDown_Button";
            this.ScriptDown_Button.Size = new System.Drawing.Size(70, 23);
            this.ScriptDown_Button.TabIndex = 104;
            this.ScriptDown_Button.Text = "Down";
            this.ScriptDown_Button.UseVisualStyleBackColor = true;
            this.ScriptDown_Button.Click += new System.EventHandler(this.ScriptDown_Button_Click);
            // 
            // Scripts_ListBox
            // 
            this.Scripts_ListBox.FormattingEnabled = true;
            this.Scripts_ListBox.Location = new System.Drawing.Point(6, 38);
            this.Scripts_ListBox.Name = "Scripts_ListBox";
            this.Scripts_ListBox.ScrollAlwaysVisible = true;
            this.Scripts_ListBox.Size = new System.Drawing.Size(298, 251);
            this.Scripts_ListBox.TabIndex = 100;
            this.Scripts_ListBox.SelectedIndexChanged += new System.EventHandler(this.Scripts_ListBox_SelectedIndexChanged);
            // 
            // DeleteScript_Button
            // 
            this.DeleteScript_Button.Enabled = false;
            this.DeleteScript_Button.Location = new System.Drawing.Point(82, 294);
            this.DeleteScript_Button.Name = "DeleteScript_Button";
            this.DeleteScript_Button.Size = new System.Drawing.Size(70, 23);
            this.DeleteScript_Button.TabIndex = 102;
            this.DeleteScript_Button.Text = "Delete";
            this.DeleteScript_Button.UseVisualStyleBackColor = true;
            this.DeleteScript_Button.Click += new System.EventHandler(this.DeleteScript_Button_Click);
            // 
            // NewScript_Button
            // 
            this.NewScript_Button.Location = new System.Drawing.Point(6, 294);
            this.NewScript_Button.Name = "NewScript_Button";
            this.NewScript_Button.Size = new System.Drawing.Size(70, 23);
            this.NewScript_Button.TabIndex = 101;
            this.NewScript_Button.Text = "New Script";
            this.NewScript_Button.UseVisualStyleBackColor = true;
            this.NewScript_Button.Click += new System.EventHandler(this.NewScript_Button_Click);
            // 
            // ScriptName_TextBox
            // 
            this.ScriptName_TextBox.Enabled = false;
            this.ScriptName_TextBox.Location = new System.Drawing.Point(6, 323);
            this.ScriptName_TextBox.Name = "ScriptName_TextBox";
            this.ScriptName_TextBox.Size = new System.Drawing.Size(298, 20);
            this.ScriptName_TextBox.TabIndex = 105;
            this.ScriptName_TextBox.TextChanged += new System.EventHandler(this.ScriptName_TextBox_TextChanged);
            // 
            // ScriptUp_Button
            // 
            this.ScriptUp_Button.Enabled = false;
            this.ScriptUp_Button.Location = new System.Drawing.Point(158, 294);
            this.ScriptUp_Button.Name = "ScriptUp_Button";
            this.ScriptUp_Button.Size = new System.Drawing.Size(70, 23);
            this.ScriptUp_Button.TabIndex = 103;
            this.ScriptUp_Button.Text = "Up";
            this.ScriptUp_Button.UseVisualStyleBackColor = true;
            this.ScriptUp_Button.Click += new System.EventHandler(this.ScriptUp_Button_Click);
            // 
            // Accept_Button
            // 
            this.Accept_Button.Location = new System.Drawing.Point(426, 369);
            this.Accept_Button.Name = "Accept_Button";
            this.Accept_Button.Size = new System.Drawing.Size(125, 23);
            this.Accept_Button.TabIndex = 116;
            this.Accept_Button.Text = "Save";
            this.Accept_Button.UseVisualStyleBackColor = true;
            this.Accept_Button.Click += new System.EventHandler(this.Accept_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Location = new System.Drawing.Point(557, 369);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 23);
            this.Cancel_Button.TabIndex = 117;
            this.Cancel_Button.Text = "Cancel";
            this.Cancel_Button.UseVisualStyleBackColor = true;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // ScriptEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 404);
            this.ControlBox = false;
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Accept_Button);
            this.Controls.Add(this.groupBox3);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScriptEditor";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Script Editor";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.Actions_GroupBox.ResumeLayout(false);
            this.Actions_GroupBox.PerformLayout();
            this.ActionType_GroupBox.ResumeLayout(false);
            this.ActionType_GroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button NewAction_Button;
        private System.Windows.Forms.Button NewScript_Button;
        private System.Windows.Forms.TextBox ScriptName_TextBox;
        private System.Windows.Forms.ListBox Scripts_ListBox;
        private System.Windows.Forms.ListBox Actions_ListBox;
        private System.Windows.Forms.Button ScriptUp_Button;
        private System.Windows.Forms.Button DeleteAction_Button;
        private System.Windows.Forms.Button ActionUp_Button;
        private System.Windows.Forms.Button ActionDown_Button;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.GroupBox ActionType_GroupBox;
        private System.Windows.Forms.RadioButton RightClick_RadioButton;
        private System.Windows.Forms.RadioButton LeftClick_RadioButton;
        private System.Windows.Forms.RadioButton MouseMove_RadioButton;
        private System.Windows.Forms.GroupBox Actions_GroupBox;
        private System.Windows.Forms.RadioButton KeyPress_RadioButton;
        private System.Windows.Forms.TextBox ActionY_TextBox;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button ScriptDown_Button;
        private System.Windows.Forms.Button DeleteScript_Button;
        private System.Windows.Forms.Button Accept_Button;
        private System.Windows.Forms.Button Cancel_Button;
        private System.Windows.Forms.TextBox ActionDelay_TextBox;
        private System.Windows.Forms.Button ActionKey_Button;
        private System.Windows.Forms.TextBox ActionX_TextBox;
    }
}