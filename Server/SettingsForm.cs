﻿/*
D2RApp - A MultiBoxing application for Diablo II Ressurrected.
Copyright (c) Cliff Earl, Antix Development, 2023.
MIT License.
*/

using System;
using System.Windows.Forms;

using Classes;

namespace D2RServer
{
    public partial class ScriptEditor : Form
    {
        public bool waitingForKeyPress = false; // true if D2RApp is waiting for the user to press a key that will be associated with the currently selected action
        private bool nonNumberEntered = false; // Used for filtering out non umeric keypresses

        public D2RScript selectedScript; // Currently selected script
        public int selectedScriptIndex = -2;

        public D2RScriptedAction selectedAction; // Currently selected Action
        public int selectedActionIndex = -2;

        // Windows Form initialisation
        public ScriptEditor()
        {
            InitializeComponent();

            FormClosing += ScriptEditor_FormClosing; // Install "cleanup" code
        }

        // Cleanup after user closes the application
        private void ScriptEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            Actions_ListBox.SelectedIndex = -1;
            Actions_ListBox.Items.Clear();
            selectedActionIndex = -2;
            selectedAction = null;

            Scripts_ListBox.SelectedIndex = -1;
            Scripts_ListBox.Items.Clear();
            selectedScriptIndex = -2;
            selectedScript = null;
        }

        // Application start-up
        private void SettingsForm_Load(object sender, EventArgs e)
        {
            // Popululate list of scripts
            for (int i = 0; i < serverForm.scripts.Count; i++)
            {
                Scripts_ListBox.Items.Add(serverForm.scripts[i].sName);
            }

            // Install keyboard handlers
            this.KeyUp += SettingsForm_KeyUp;

            ActionDelay_TextBox.KeyDown += Handle_TextBox_KeyDown;
            ActionDelay_TextBox.KeyPress += Handle_TextBox_KeyPress;

            ActionX_TextBox.KeyDown += Handle_TextBox_KeyDown;
            ActionX_TextBox.KeyPress += Handle_TextBox_KeyPress;

            ActionY_TextBox.KeyPress += Handle_TextBox_KeyPress;
            ActionY_TextBox.KeyDown += Handle_TextBox_KeyDown;
        }

        // User accepted the modifications to the scripts
        private void Accept_Button_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // User cancelled modifications
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Update selected actions hotkey
        private void SettingsForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (waitingForKeyPress)
            {
                ActionKey_Button.Text = $"{e.KeyCode}";
                selectedAction.aKey = e.KeyValue;
                Actions_ListBox.Items[selectedAction.aId] = ActionToString(selectedAction);
                ActionKey_Button.Enabled = true;
                waitingForKeyPress = false;
            }
        }

        #region Action

        // Make it so the action delay, x, and y textboxes ONLY accept numeric input
        private void Handle_TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
            if (Control.ModifierKeys == Keys.Shift)
            {
                nonNumberEntered = true;
            }
        }

        private void Handle_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
            {
                e.Handled = true;
            }
        }

        private void ActionKey_Button_Click(object sender, EventArgs e)
        {
            ActionKey_Button.Enabled = false;
            ActionKey_Button.Text = "Press Key";
            waitingForKeyPress = true;
        }

        private void ActionDelay_TextBox_TextChanged(object sender, EventArgs e)
        {
            selectedAction.aDelay = GetIntFromText(ActionDelay_TextBox.Text);
            Actions_ListBox.Items[selectedAction.aId] = ActionToString(selectedAction);
        }

        private void ActionX_TextBox_TextChanged(object sender, EventArgs e)
        {
            selectedAction.aX = GetIntFromText(ActionX_TextBox.Text);
            Actions_ListBox.Items[selectedAction.aId] = ActionToString(selectedAction);
        }

        private void ActionY_TextBox_TextChanged(object sender, EventArgs e)
        {
            selectedAction.aY = GetIntFromText(ActionY_TextBox.Text);
            Actions_ListBox.Items[selectedAction.aId] = ActionToString(selectedAction);
        }

        private int GetIntFromText(string number)
        {
            try
            {
                return Int32.Parse(number);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return 0;
            }
        }

        private void NewAction_Button_Click(object sender, EventArgs e)
        {
            Actions_ListBox.SelectedIndex = -1;
            selectedAction = null;
            selectedActionIndex = -2;

            selectedAction = new D2RScriptedAction();

            selectedAction.aId = Actions_ListBox.Items.Count;
            selectedScript.sActions.Add(selectedAction);
            Actions_ListBox.Items.Add(ActionToString(selectedAction));
            Actions_ListBox.SelectedIndex = Actions_ListBox.Items.Count - 1;

            SetActioncontrols();
        }

        // Delete the selected action
        private void DeleteAction_Button_Click(object sender, EventArgs e)
        {
            if (selectedAction != null)
            {
                if (selectedScript.sActions.Count != 1) // For all actions after the one to be deleted...
                {
                    for (int i = selectedAction.aId + 1; i < selectedScript.sActions.Count; i++)
                    {
                        GetActionWithID(i).aId--; // Decrement action id
                    }
                }

                Actions_ListBox.Items.RemoveAt(selectedAction.aId); // delete from listbox

                selectedScript.sActions.Remove(selectedAction); // Delete from actions

                Actions_ListBox.SelectedIndex = -1;
                selectedActionIndex = -2;
                selectedAction = null;

                UpdateActionControls();
            }
        }

        // Move the selected action up
        private void ActionUp_Button_Click(object sender, EventArgs e)
        {
            if (selectedAction != null && selectedAction.aId > 0)
            {
                var other = GetActionWithID(selectedAction.aId - 1);

                Actions_ListBox.Items[--selectedAction.aId] = ActionToString(selectedAction);
                Actions_ListBox.Items[++other.aId] = ActionToString(other);

                Actions_ListBox.SelectedIndex = selectedAction.aId;
            }
        }

        // Move the selected action down
        private void ActionDown_Button_Click(object sender, EventArgs e)
        {
            selectedActionIndex = -2;
            Actions_ListBox.SelectedIndex = -1;

            if (selectedAction != null && selectedAction.aId < Actions_ListBox.Items.Count - 1)
            {
                var other = GetActionWithID(selectedAction.aId + 1);
                Actions_ListBox.Items[++selectedAction.aId] = ActionToString(selectedAction);
                Actions_ListBox.Items[--other.aId] = ActionToString(other);

                Actions_ListBox.SelectedIndex = selectedAction.aId;
            }
        }

        // User changed the selected actions type to "MouseMove"
        private void MouseMove_CheckedChanged(object sender, EventArgs e)
        {
            if (MouseMove_RadioButton.Checked)
            {
                ActionKey_Button.Enabled = false;
                ActionX_TextBox.Enabled = true;
                ActionY_TextBox.Enabled = true;
                ActionX_TextBox.Text = $"{selectedAction.aX}";
                ActionY_TextBox.Text = $"{selectedAction.aY}";

                selectedAction.aType = D2RScriptedActionTypes.MouseMove;
                Actions_ListBox.Items[selectedAction.aId] = ActionToString(selectedAction);
            }
        }

        // User changed the selected actions type to "LeftClick"
        private void LeftClick_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (LeftClick_RadioButton.Checked)
            {
                ActionKey_Button.Enabled = false;
                ActionX_TextBox.Enabled = false;
                ActionY_TextBox.Enabled = false;

                selectedAction.aType = D2RScriptedActionTypes.LeftClick;
                Actions_ListBox.Items[selectedAction.aId] = ActionToString(selectedAction);
            }
        }

        // User changed the selected actions type to "RightClick"
        private void RightClick_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (RightClick_RadioButton.Checked)
            {
                ActionKey_Button.Enabled = false;
                ActionX_TextBox.Enabled = false;
                ActionY_TextBox.Enabled = false;
 
                selectedAction.aType = D2RScriptedActionTypes.RightClick;
                Actions_ListBox.Items[selectedAction.aId] = ActionToString(selectedAction);
            }
        }

        // User changed the selected actions type to "KeyPress"
        private void KeyPress_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (KeyPress_RadioButton.Checked)
            {
                ActionKey_Button.Enabled = true;
                ActionX_TextBox.Enabled = false;
                ActionY_TextBox.Enabled = false;

                ActionKey_Button.Text = serverForm.asciiMap[selectedAction.aKey];
                selectedAction.aType = D2RScriptedActionTypes.KeyPress;
                Actions_ListBox.Items[selectedAction.aId] = ActionToString(selectedAction);
            }
        }

        // Build the string representation for the given action
        private string ActionToString(D2RScriptedAction action)
        {
            string actionString = "";

            switch (action.aType)
            {
                case (D2RScriptedActionTypes.MouseMove):
                    actionString = $"after {action.aDelay} ms, move the mouse to {action.aX}, {action.aY}";
                    break;

                case (D2RScriptedActionTypes.LeftClick):
                    actionString = $"after {action.aDelay} ms, click the left mouse button";
                    break;

                case (D2RScriptedActionTypes.RightClick):
                    actionString = $"after {action.aDelay}ms, click the right mouse button";
                    break;

                case (D2RScriptedActionTypes.KeyPress):
                    actionString = $"after {action.aDelay}ms, press the '{serverForm.asciiMap[action.aKey]}' key";
                    break;

                default:
                    break;
            }
            return actionString;
        }

        private void Actions_ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Actions_ListBox.SelectedIndex == -1) return;


            if (Actions_ListBox.SelectedIndex != selectedActionIndex)
            {
                Console.WriteLine($"Actions_ListBox_SelectedIndexChanged() {Actions_ListBox.SelectedIndex}, {selectedActionIndex}");

                selectedAction = GetActionWithID(Actions_ListBox.SelectedIndex);

                selectedActionIndex = Actions_ListBox.SelectedIndex;

                UpdateActionControls();

                SetActioncontrols();

            }
        }

        // Enable or disable action controls
        private void SetActioncontrols()
        {

            Actions_GroupBox.Enabled = true;
            ActionType_GroupBox.Enabled = true;

            ActionDelay_TextBox.Text = $"{selectedAction.aDelay}";
            ActionDelay_TextBox.Enabled = true;

            switch (selectedAction.aType)
            {
                case (D2RScriptedActionTypes.MouseMove):
                    ActionKey_Button.Enabled = false;
                    ActionX_TextBox.Enabled = true;
                    ActionY_TextBox.Enabled = true;
                    ActionX_TextBox.Text = $"{selectedAction.aX}";
                    ActionY_TextBox.Text = $"{selectedAction.aY}";

                    MouseMove_RadioButton.Checked = true;
                    break;

                case (D2RScriptedActionTypes.LeftClick):
                    ActionKey_Button.Enabled = false;
                    ActionX_TextBox.Enabled = false;
                    ActionY_TextBox.Enabled = false;

                    LeftClick_RadioButton.Checked = true;
                    break;

                case (D2RScriptedActionTypes.RightClick):
                    ActionKey_Button.Enabled = false;
                    ActionX_TextBox.Enabled = false;
                    ActionY_TextBox.Enabled = false;

                    RightClick_RadioButton.Checked = true;
                    break;

                case (D2RScriptedActionTypes.KeyPress):
                    ActionKey_Button.Enabled = true;
                    ActionX_TextBox.Enabled = false;
                    ActionY_TextBox.Enabled = false;
                    ActionKey_Button.Text = serverForm.asciiMap[selectedAction.aKey];
                    KeyPress_RadioButton.Checked = true;
                    break;

                default:
                    break;
            }
        }

        // Enable or disable action buttons
        private void UpdateActionControls()
        {
            ActionUp_Button.Enabled = false;
            ActionDown_Button.Enabled = false;
            DeleteAction_Button.Enabled = false;

            if (selectedAction != null)
            {
                DeleteAction_Button.Enabled = true;

                if (selectedAction.aId != Actions_ListBox.Items.Count - 1)
                {
                    ActionDown_Button.Enabled = true;
                }

                if (selectedAction.aId > 0)
                {
                    ActionUp_Button.Enabled = true;
                }
            }
            else
            {
                ActionDelay_TextBox.Enabled = false;
            }
        }

        // Get the action with the given id
        private D2RScriptedAction GetActionWithID(int id)
        {
            for (int i = 0; i < selectedScript.sActions.Count; i++)
            {
                var action = (D2RScriptedAction)selectedScript.sActions[i];
                if (action.aId == id) return action;
            }
            return null;
        }

        #endregion

        #region Script

        // Create a new script
        private void NewScript_Button_Click(object sender, EventArgs e)
        {
            Scripts_ListBox.SelectedIndex = -1;
            selectedScript = null;
            selectedScriptIndex = -2;
            ScriptName_TextBox.Enabled = false;
            ScriptName_TextBox.Text = String.Empty;

            // Generate a unique script name
            string uId;
            int i = 1;
            do
            {
                uId = $"script_{i++}";
            } while (Scripts_ListBox.Items.Contains(uId)); // don't stop generating i=names until it's unique

            // Create new script, add it to the list, and select it
            D2RScript script = new D2RScript(uId);
            script.sId = Scripts_ListBox.Items.Count;

            serverForm.scripts.Add(script);
            Scripts_ListBox.Items.Add(script.sName);

            Scripts_ListBox.SelectedIndex = Scripts_ListBox.Items.Count - 1;
        }

        // Delete the selected script
        private void DeleteScript_Button_Click(object sender, EventArgs e)
        {
            if (selectedScript != null)
            {
                if (serverForm.scripts.Count != 1) // For all scripts after the one to be deleted...
                {
                    for (int i = selectedScript.sId + 1; i < serverForm.scripts.Count; i++)
                    {
                        GetScriptWithID(i).sId--; // Decrement script id
                    }
                }

                Scripts_ListBox.Items.RemoveAt(selectedScript.sId); // delete from listbox

                serverForm.scripts.Remove(selectedScript); // Delete from scripts

                selectedScript = null;
                ScriptName_TextBox.Enabled = false;
                ScriptName_TextBox.Text = String.Empty;
                Scripts_ListBox.SelectedIndex = -1;
                selectedScriptIndex = -2;

                UpdateScriptControls();
            }
        }

        // Move the selected script up
        private void ScriptUp_Button_Click(object sender, EventArgs e)
        {
            if (selectedScript != null && selectedScript.sId > 0)
            {
                var other = GetScriptWithID(selectedScript.sId - 1);
                Scripts_ListBox.Items[--selectedScript.sId] = selectedScript.sName;
                Scripts_ListBox.Items[++other.sId] = other.sName;
                Scripts_ListBox.SelectedIndex = selectedScript.sId;

                UpdateScriptControls();
            }
        }

        // Move the selected script down
        private void ScriptDown_Button_Click(object sender, EventArgs e)
        {
            if (selectedScript != null && selectedScript.sId < Scripts_ListBox.Items.Count - 1)
            {
                var other = GetScriptWithID(selectedScript.sId + 1);
                Scripts_ListBox.Items[++selectedScript.sId] = selectedScript.sName;
                Scripts_ListBox.Items[--other.sId] = other.sName;
                Scripts_ListBox.SelectedIndex = selectedScript.sId;

                UpdateScriptControls();
            }
        }

        // User modified selected script name
        private void ScriptName_TextBox_TextChanged(object sender, EventArgs e)
        {
            if (selectedScript != null)
            {
                selectedScript.sName = ScriptName_TextBox.Text;
                Scripts_ListBox.Items[selectedScript.sId] = ScriptName_TextBox.Text;
            }
        }

        // User clicked on a script
        private void Scripts_ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Scripts_ListBox.SelectedIndex == -1) return;

            if (Scripts_ListBox.SelectedIndex != selectedScriptIndex)
            {
                selectedScript = GetScriptWithID(Scripts_ListBox.SelectedIndex);
                ScriptName_TextBox.Text = Scripts_ListBox.SelectedItem.ToString();

                selectedScriptIndex = Scripts_ListBox.SelectedIndex;
                ScriptName_TextBox.Enabled = true;

                selectedAction = null;
                selectedActionIndex = -2;
                Actions_ListBox.SelectedIndex = -1;
            }
            UpdateScriptControls();
        }

        // Conditionally enable and disable controls
        private void UpdateScriptControls()
        {
            ScriptUp_Button.Enabled = false;
            ScriptDown_Button.Enabled = false;
            DeleteScript_Button.Enabled = false;

            if (selectedScript == null)
            {
                ScriptName_TextBox.Enabled = false;
                Actions_GroupBox.Enabled = false;
            }
            else
            {
                ScriptName_TextBox.Enabled = true;

                DeleteScript_Button.Enabled = true;

                if (selectedScript.sId != Scripts_ListBox.Items.Count - 1)
                {
                    ScriptDown_Button.Enabled = true;
                }

                if (selectedScript.sId > 0)
                {
                    ScriptUp_Button.Enabled = true;
                }

                // Init actions thingy
                Actions_GroupBox.Enabled = true;
                selectedActionIndex = -2;
                Actions_ListBox.SelectedIndex = -1;
                Actions_ListBox.Items.Clear();

                selectedAction = null;

                NewAction_Button.Enabled = true;

                ActionKey_Button.Enabled = false;
                ActionX_TextBox.Enabled = false;
                ActionY_TextBox.Enabled = false;

                UpdateActionControls();

                if (selectedScript.sActions.Count > 0)
                {
                    for (int i = 0; i < selectedScript.sActions.Count; i++)
                    {
                        Actions_ListBox.Items.Add(ActionToString((D2RScriptedAction)selectedScript.sActions[i]));
                    }
                }
            }
        }

        // Get the script with the given id
        private D2RScript GetScriptWithID(int id)
        {
            for (int i = 0; i < serverForm.scripts.Count; i++)
            {
                var script = (D2RScript)serverForm.scripts[i];
                if (script.sId == id) return script;
            }
            return null;
        }

        #endregion

    }
}
