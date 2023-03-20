using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SuperSimpleTcp;
using Newtonsoft.Json;
using Classes;
using WindowsInput.Native;
using WindowsInput;

using System.Runtime.InteropServices;
namespace D2RApp
{
    public class Win32
    {
        [DllImport("User32.Dll")]
        public static extern long SetCursorPos(int x, int y);

        [DllImport("User32.Dll")]
        public static extern bool ClientToScreen(IntPtr hWnd, ref POINT point);

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int x;
            public int y;

            public POINT(int X, int Y)
            {
                x = X;
                y = Y;
            }
        }
    }

    public partial class client_Form : Form
    {
        public bool currentlyDoingSomething = false;

        public InputSimulator inputSimulator;

        public int screenWidth;
        public int screenHeight;


        public client_Form()
        {
            InitializeComponent();

            Rectangle resolution = Screen.PrimaryScreen.Bounds;
            screenWidth = resolution.Width;
            screenHeight = resolution.Height;
        }

        SimpleTcpClient client;

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new SimpleTcpClient(ServerIP_TextBox.Text);

            client.Events.Connected += Events_Connected;
            client.Events.DataReceived += Events_DataReceived;
            client.Events.Disconnected += Events_Disconnected;

            inputSimulator = new InputSimulator();
        }

        // Attempt to disconnect from the server if already connected, otherwise attempt to connect to the server
        private void ConnectionButton_Click(object sender, EventArgs e)
        {
            if (client.IsConnected)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    Task.Run(() => client.Disconnect()); // Attempt to disconnect from server
                    
                    // client.Disconnect(); // Attempt to disconnect from server
                });
            }
            else
            {
                try
                {
                    client.Connect(); // Attempt to connect to server
                }

                catch (Exception ex)
                {
                    Log(ex.Message); // Generally the server is not running on the computer at the given IP Address
                }
            }

        }

        // A connection was established with the server
        private void Events_Connected(object sender, ConnectionEventArgs e)
        {
            Connection_Button.Text = "Disconnect";
            Log($"Connected to {e.IpPort} at {TimeStamp()}.");
        }

        // The client was disconnected from the server
        private void Events_Disconnected(object sender, ConnectionEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                Connection_Button.Text = "Connect";
                Log($"Disconnected from {e.IpPort} at {TimeStamp()}.");
            });
        }

        // A message was received from the server
        private void Events_DataReceived(object sender, DataReceivedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                if (e.Data.Array != null)
                {
                    string data = Encoding.UTF8.GetString(e.Data.Array, 0, e.Data.Count); // Get the data

                    //Log($"Received data: {data}");

                    try
                    {
                        int[] msg = JsonConvert.DeserializeObject<int[]>(data);

                        switch (msg[0])
                        {
                            case 0: // TODO: ping received

                                break;

                            case 1: // MouseMove
                                inputSimulator.Mouse.MoveMouseTo(msg[1] * 65535 / screenWidth, msg[2] * 65535 / screenWidth);
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

                        //ServerMessage serverMessage = JsonConvert.DeserializeObject<ServerMessage>(data); // Decode the string into a ServerMessage

                        //switch (serverMessage.mType) // Process according to the message type
                        //{
                        //    case "mousemove":

                        //        MouseMoveMessage mouseMoveMessage = JsonConvert.DeserializeObject<MouseMoveMessage>(serverMessage.mData);

                        //        MousePosition_Label.Text = $"{mouseMoveMessage.mX}, {mouseMoveMessage.mY}";

                        //        //inputSimulator.Mouse.MoveMouseTo(mouseMoveMessage.mX * 65535 / screenWidth, mouseMoveMessage.mY * 65535 / screenWidth);

                        //        //Win32.POINT p = new Win32.POINT(mouseMoveMessage.mX, mouseMoveMessage.mY);
                        //        //Win32.ClientToScreen(this.Handle, ref p);
                        //        //Win32.SetCursorPos(mouseMoveMessage.mX, mouseMoveMessage.mY);

                        //        break;

                        //    case "mouseclick":
                        //        MouseClickMessage mouseClickMessage = JsonConvert.DeserializeObject<MouseClickMessage>(serverMessage.mData);
                        //        MouseButtons mouseButtons = (MouseButtons)mouseClickMessage.mButton;
                        //        switch (mouseButtons)
                        //        {
                        //            case MouseButtons.Left:
                        //                inputSimulator.Mouse.LeftButtonClick();
                        //                break;
                        //            case MouseButtons.Right:
                        //                inputSimulator.Mouse.RightButtonClick();
                        //                break;
                        //            default:
                        //                // All other buttons are ignored
                        //                break;
                        //        }
                        //        break;

                        //    case "keyup":
                        //        KeyUpMessage keyUpMessage = JsonConvert.DeserializeObject<KeyUpMessage>(serverMessage.mData);

                        //        VirtualKeyCode virtualKeyCode = (VirtualKeyCode)keyUpMessage.mKeyValue; // Cast from int to VirtualKeyCode

                        //        inputSimulator.Keyboard.KeyPress(virtualKeyCode);

                        //        break;

                        //    default:
                        //        Log($"Received unknown message of type '{serverMessage.mType}' from {e.IpPort.ToString()}.");
                        //        break;
                        //}

                    }
                    catch (Exception ex)
                    {
                        Log(ex.Message);
                    }

                }
                else
                {
                    Log($"Received null data from {e.IpPort}... discarding.");
                }
            });
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
