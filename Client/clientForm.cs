using System;
using System.Drawing;
using System.Windows.Forms;
using Newtonsoft.Json;
using Gma.System.MouseKeyHook;
using WindowsInput.Native;
using WindowsInput;
using LiteNetLib;

namespace D2RApp
{

    public partial class client_Form : Form
    {
        public EventBasedNetListener netListener;
        public NetManager netClient;

        public bool connected;

        public bool scriptRunning;

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
            timer1.Enabled = true;

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
            // Stop client
            timer1.Enabled = false;
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
            string data = reader.GetString(50); // Max data length
            reader.Recycle();

            //            Log($"Server: {data}"); // Max length of string

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
                    // TODO:
                    break;

                default:
                    break;
            }

/*
            try
            {
                int[] msg = JsonConvert.DeserializeObject<int[]>(data);

                switch (msg[0])
                {
                    case 0: // TODO: ping received

                        break;

                    case 1: // MouseMove
                        inputSimulator.Mouse.MoveMouseTo(msg[1] * 65535 / screenWidth, msg[2] * 65535 / screenHeight);
                        break;

                    case 2: // MouseClick
                        if (msg[1] == 1)
                        {
                            inputSimulator.Mouse.LeftButtonClick();
                        }
                        else
                        {
                            inputSimulator.Mouse.RightButtonClick();
                        }
                        break;

                    case 3: // KeyPress
                        inputSimulator.Keyboard.KeyPress((VirtualKeyCode)msg[1]);

                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
*/

        }

        // Established connection to server
        private void NetListener_PeerConnectedEvent(NetPeer peer)
        {
            connected = true;
            Connection_Button.Text = "Disconnect";

            Log($"Connected to {peer.EndPoint} at {TimeStamp()}.");
        }

        // Lost connection to server
        private void NetListener_PeerDisconnectedEvent(NetPeer peer, DisconnectInfo disconnectInfo)
        {
            Connection_Button.Text = "Connect";
            connected = false;

            Log($"Disconnected from {peer.EndPoint} at {TimeStamp()}.");
        }

        // Attempt to disconnect from the server if already connected, otherwise attempt to connect to the server
        private void ConnectionButton_Click(object sender, EventArgs e)
        {
            if (connected)
            {
                Log("TODO: initiate a manual disconnect?");

            } else
            {
                try
                {
                    netClient.Connect(ServerIP_TextBox.Text, Int32.Parse(ServerPort_TextBox.Text), "D2RApp"); // Host, port, key
                }
                catch (Exception ex)
                {
                    Log(ex.Message); // Server could not be reached
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
        private void Log(string text)
        {
            Log_TextBox.AppendText(text);
            Log_TextBox.AppendText(Environment.NewLine);
            Log_TextBox.ScrollToCaret();
        }

    }
}
