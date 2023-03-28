/*
D2RApp - A MultiBoxing application for Diablo II Ressurrected.
Copyright (c) Cliff Earl, Antix Development, 2023.
MIT License.
*/

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

using Newtonsoft.Json;
using Gma.System.MouseKeyHook;
using WindowsInput.Native;
using WindowsInput;
using LiteNetLib;

using Classes;

namespace D2RApp
{

    public partial class client_Form : Form
    {
        public List<D2RScript> scripts; // Scripts (sent from server)

        public EventBasedNetListener netListener;
        public NetManager netClient;

        public bool connected;

        public bool scriptRunning;
        public D2RScript currentScript;
        public int actionIndex;

        public InputSimulator inputSimulator;

        public IKeyboardMouseEvents m_GlobalHook;

        public int screenWidth;
        public int screenHeight;

        // Windows Form initialisation
        public client_Form()
        {
            InitializeComponent();

            Rectangle resolution = Screen.PrimaryScreen.Bounds;
            screenWidth = resolution.Width - 1;
            screenHeight = resolution.Height - 1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Start intercepting input events
            m_GlobalHook = Hook.GlobalEvents();
            m_GlobalHook.MouseMove += M_GlobalHook_MouseMove;

            // Start inpute event simulation
            inputSimulator = new InputSimulator();

            connected = false;

            // Start client
            netListener = new EventBasedNetListener();
            netClient = new NetManager(netListener);
            netClient.Start();
            netListener.PeerConnectedEvent += NetListener_PeerConnectedEvent;
            netListener.PeerDisconnectedEvent += NetListener_PeerDisconnectedEvent;
            netListener.NetworkReceiveEvent += NetListener_NetworkReceiveEvent;
            Net_Timer.Enabled = true;

            scriptRunning = false;
        }

        // Update mouse position readout
        private void M_GlobalHook_MouseMove(object sender, MouseEventArgs e)
        {
            MousePosition_Label.Text = $"{Clamp(e.X, 0, screenWidth)}, {Clamp(e.Y, 0, screenHeight)}";
        }

        // Application shut-down
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Script_Timer.Stop();

            // Stop client
            Net_Timer.Enabled = false;
            netListener.PeerConnectedEvent -= NetListener_PeerConnectedEvent;
            netListener.PeerDisconnectedEvent -= NetListener_PeerDisconnectedEvent;
            netListener.NetworkReceiveEvent -= NetListener_NetworkReceiveEvent;
            netClient.Stop();
        }

        // Perform client polling stuff
        private void timer1_Tick(object sender, EventArgs e)
        {
            netClient.PollEvents();
        }

        // A message was received from the server
        private void NetListener_NetworkReceiveEvent(NetPeer peer, NetPacketReader reader, DeliveryMethod deliveryMethod)
        {
            string data = reader.GetString(1000); // Max data length
            reader.Recycle();

            //Log($"Server: {data}"); // Max length of string

            string[] parts = data.Split(',');

            switch (parts[0])
            {
                // 
                // MouseMove
                // 

                case "1":
                    //inputSimulator.Mouse.MoveMouseTo(Clamp(Int16.Parse(parts[1]), 0, screenWidth) * 65535 / (screenWidth + 1), Clamp(Int16.Parse(parts[2]), 0, screenHeight) * 65535 / (screenHeight + 1));

                    int x = Clamp(Int32.Parse(parts[1]), 0, screenWidth);
                    int y = Clamp(Int32.Parse(parts[2]), 0, screenHeight);
                    inputSimulator.Mouse.MoveMouseTo(x * 65535 / (screenWidth + 1), y * 65535 / (screenHeight + 1));

                    MousePosition_Label.Text = $"{x}, {y}";

                    break;

                // 
                // MouseClick
                // 

                case "2":
                    if (parts[1] == "1")
                    {
                        inputSimulator.Mouse.LeftButtonClick();
                    }
                    else
                    {
                        inputSimulator.Mouse.RightButtonClick();
                    }

                    break;

                // 
                // KeyPress
                // 

                case "3":
                    inputSimulator.Keyboard.KeyPress((VirtualKeyCode)Int16.Parse(parts[1]));
                    break;

                // 
                // Scripted action
                //

                case "4":
                    // TODO: perform the given script

                    //Console.WriteLine($"script {parts[1]} requested.");

                    if (!scriptRunning)
                    {
                        currentScript = scripts[Int16.Parse(parts[1])];
                        actionIndex = 0;
                        Script_Timer.Interval = currentScript.sActions[0].aDelay;
                        Script_Timer.Start();
                        //Console.WriteLine($"{currentScript.sName}: {currentScript.sActions[0].aType}");

                        scriptRunning = true;
                    }

                    else
                    {
                        //Console.WriteLine($"server requested script {parts[1]} but script {currentScript.sId} already running!");
                    }

                    break;

                // 
                // The only other data the client can receive is updated scripts
                // 

                default:
                    try
                    {
                        scripts = JsonConvert.DeserializeObject<List<D2RScript>>(data); // Deserialize scripts from received data
                        scripts.Sort((a, b) => a.sId.CompareTo(b.sId)); // Sort scripts into ascending order

                        for (int i = 0; i < scripts.Count; i++)
                        {
                            var s = (D2RScript)scripts[i]; // Next script
                            s.sActions.Sort((a, b) => a.aId.CompareTo(b.aId)); // Sort actions belonging to the current script into ascending order
                        }
                        Console.WriteLine($"Received scripts from server at {TimeStamp()}");
                    }
                    catch (Exception ex)
                    {
                        //Console.WriteLine($"{ex.Message}");
                    }
                    break;
            }
        }

        // Execute current scripted action and queue the next in the sequence
        private void Script_Timer_Tick(object sender, EventArgs e)
        {
            Script_Timer.Stop();

            // Execute action
            var action = currentScript.sActions[actionIndex];

            switch (action.aType)
            {
                case (D2RScriptedActionTypes.MouseMove):
                    inputSimulator.Mouse.MoveMouseTo(action.aX * 65535 / (screenWidth + 1), action.aY * 65535 / (screenHeight + 1));
                    break;

                case (D2RScriptedActionTypes.LeftClick):
                    inputSimulator.Mouse.LeftButtonClick();
                    break;

                case (D2RScriptedActionTypes.RightClick):
                    inputSimulator.Mouse.RightButtonClick();
                    break;

                case (D2RScriptedActionTypes.KeyPress):
                    inputSimulator.Keyboard.KeyPress((VirtualKeyCode)action.aKey);
                    break;

                default:
                    break;
            }
            //Console.WriteLine($"{currentScript.sName}: Executed");

            // Queue next action

            actionIndex++;

            if (actionIndex < currentScript.sActions.Count)
            {
                action = currentScript.sActions[actionIndex];
                Script_Timer.Interval = action.aDelay;
                Script_Timer.Start();
            } 

            else

            {
                scriptRunning = false; // Done
            }
        }


        // Established connection to server
        private void NetListener_PeerConnectedEvent(NetPeer peer)
        {
            connected = true;
            Connection_Button.Text = "Disconnect";

            //Console.WriteLine($"Connected to {peer.EndPoint} at {TimeStamp()}.");
        }

        // Lost connection to server
        private void NetListener_PeerDisconnectedEvent(NetPeer peer, DisconnectInfo disconnectInfo)
        {
            Connection_Button.Text = "Connect";
            connected = false;

            //Console.WriteLine($"Disconnected from {peer.EndPoint} at {TimeStamp()}.");
        }

        // Attempt to disconnect from the server if already connected, otherwise attempt to connect to the server
        private void ConnectionButton_Click(object sender, EventArgs e)
        {
            if (connected)
            {
                //Console.WriteLine("TODO: initiate a manual disconnect?");

            } else
            {
                try
                {
                    netClient.Connect(ServerIP_TextBox.Text, Int32.Parse(ServerPort_TextBox.Text), "D2RApp"); // Host, port, key
                }
                catch (Exception ex)
                {
                    //Console.WriteLine(ex.Message); // Server could not be reached
                }
            }
        }

        // Constrain given value to given range
        public int Clamp(int value, int min, int max)
        {
            return (value < min) ? min : (value > max) ? max : value;
        }

        // Get the current system date and time as a string
        private string TimeStamp()
        {
            return DateTime.Now.ToString("dd/MM/yyyy h:mm:ss");
        }

        // Append the given text to the log textbox
        //private void Log(string text)
        //{
        //    Log_TextBox.AppendText(text);
        //    Log_TextBox.AppendText(Environment.NewLine);
        //    Log_TextBox.ScrollToCaret();
        //}

    }
}
