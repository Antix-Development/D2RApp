using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

using SuperSimpleTcp;
using Gma.System.MouseKeyHook;

namespace D2RServer
{
    public partial class serverForm : Form
    {
        SimpleTcpServer server;

        public bool altHeld = false; // true if the ALT key is currenty being held down

        public int port = 9000;

        public string IPAddress;

        public IKeyboardMouseEvents m_GlobalHook;

        private void M_GlobalHook_MouseMove(object sender, MouseEventArgs e)
        {
            if (altHeld)
            {
                //Log($"MouseMove: {e.X}, {e.Y}");

                BroadcastMessage($"[1,{e.X},{e.Y}]");

                //MouseMoveMessage mouseMovekMessage = new MouseMoveMessage(e.X, e.Y);
                //ServerMessage serverMessage = new ServerMessage("mousemove", JsonConvert.SerializeObject(mouseMovekMessage));
                //BroadcastMessage(JsonConvert.SerializeObject(serverMessage));
            }
        }

        private void M_GlobalHook_MouseClick(object sender, MouseEventArgs e)
        {
            if (altHeld)
            {
                //Log($"MouseClick: {e.X}, {e.Y}, {e.Button}");

                int button = 0;
                switch (e.Button)
                {
                    case MouseButtons.Left:
                        button = 1;
                        break;
                    case MouseButtons.Right:
                        button = 2;
                        break;
                    default:
                        break;
                }

                if (button > 0) // Only broadcast if it was a left or right click
                {
                    BroadcastMessage($"[2,{button}]");
                }

                //MouseClickMessage mouseClickMessage = new MouseClickMessage(e.X, e.Y, (int)e.Button);
                //ServerMessage serverMessage = new ServerMessage("mouseclick", JsonConvert.SerializeObject(mouseClickMessage));
                //BroadcastMessage(JsonConvert.SerializeObject(serverMessage));
            }
        }

        private void M_GlobalHook_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.LMenu || e.KeyCode == Keys.RMenu) && altHeld)
            {
                // ALT key has been released
                altHeld = false;
                AltHeld_TextBox.Text = "false";
            }
            else if (altHeld)
            {
                //Log($"KeyUp: Code:{e.KeyCode}, Value:{e.KeyValue}(0x{e.KeyValue.ToString("X2")}), alt:{e.Alt}");

                BroadcastMessage($"[3,{e.KeyValue}]");

                //KeyUpMessage keyUpMessage = new KeyUpMessage(e.KeyValue);
                //ServerMessage serverMessage = new ServerMessage("keyup", JsonConvert.SerializeObject(keyUpMessage));
                //BroadcastMessage(JsonConvert.SerializeObject(serverMessage));
            }
        }

        private void M_GlobalHook_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.LMenu || e.KeyCode == Keys.RMenu) && !altHeld)
            {
                // ALT key has been pressed down
                altHeld = true;
                AltHeld_TextBox.Text = "true";
            }
            else
            {
                // 
                // Nothing really needs to happen when a key is pressed down, because we really don't care about keys other than the ALT key
                // 

                //Log($"KeyDown: Code:{e.KeyCode}, Value:{e.KeyValue}(0x{e.KeyValue.ToString("X2")}), alt:{e.Alt}");
            }
        }

        // Broadcast given message to all connected clients
        private void BroadcastMessage(string message)
        {
            this.Invoke((MethodInvoker)delegate
            {
                if (server.IsListening)
                {
                    for (int i = 0; i < Clients_ListBox.Items.Count; i++)
                    {
                        server.Send(Clients_ListBox.Items[i].ToString(), message);
                    }
                }
            });
        }

        // Windows Form initialisation
        public serverForm()
        {
            InitializeComponent();

            // Get local machines IP Address
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0)) // Get
            {
                socket.Connect("8.8.8.8", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                IPAddress = endPoint.Address.ToString();
            }

            this.Text = $"Server: {IPAddress}:{port}";
        }

        // Application initialisation
        private void Form1_Load(object sender, EventArgs e)
        {
            m_GlobalHook = Hook.GlobalEvents();

            m_GlobalHook.KeyUp += M_GlobalHook_KeyUp;
            m_GlobalHook.KeyDown += M_GlobalHook_KeyDown;
            m_GlobalHook.MouseMove += M_GlobalHook_MouseMove;
            m_GlobalHook.MouseClick += M_GlobalHook_MouseClick;
            
            server = new SimpleTcpServer($"{IPAddress}:{port}");

            server.Events.ClientConnected += Events_ClientConnected;
            server.Events.ClientDisconnected += Events_ClientDisconnected;
            server.Events.DataReceived += Events_DataReceived;

            server.Start();

            Log($"Server started at {TimeStamp()}.");
        }

        // Application shut-down
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_GlobalHook.MouseClick -= M_GlobalHook_MouseClick;
            m_GlobalHook.MouseMove -= M_GlobalHook_MouseMove;
            m_GlobalHook.KeyDown -= M_GlobalHook_KeyDown;
            m_GlobalHook.KeyUp -= M_GlobalHook_KeyUp;

            m_GlobalHook.Dispose();

            server.Events.DataReceived -= Events_DataReceived;
            server.Events.ClientDisconnected -= Events_ClientDisconnected;
            server.Events.ClientConnected -= Events_ClientConnected;
            server.Stop();

            server.Dispose();
        }

        // A client connected to the server
        private void Events_ClientConnected(object sender, ConnectionEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                Log($"{e.IpPort} connected at {TimeStamp()}.");
                Clients_ListBox.Items.Add(e.IpPort);
            });
        }

        // A client disconnected from the server
        private void Events_ClientDisconnected(object sender, ConnectionEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                Clients_ListBox.Items.Remove(e.IpPort);
                Log($"{e.IpPort} disconnected at {TimeStamp()}.");
            });
        }

        private void Events_DataReceived(object sender, DataReceivedEventArgs e) // NOT REQUIRED... DELETE
        {
            this.Invoke((MethodInvoker)delegate
            {
                Log($"{e.IpPort}: {Encoding.UTF8.GetString(e.Data.Array, 0, e.Data.Count)}");
                //txtInfo.Text += $"{e.IpPort}: {Encoding.UTF8.GetString(e.Data.Array, 0, e.Data.Count)}{Environment.NewLine}";
            });
        }

        // Get current date and time as a string
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
