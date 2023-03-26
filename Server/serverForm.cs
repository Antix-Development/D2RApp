﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.IO;
using Classes;
using Gma.System.MouseKeyHook;
using LiteNetLib;
using LiteNetLib.Utils;
using Newtonsoft.Json;

namespace D2RServer
{
    public partial class serverForm : Form
    {
        //                                 000 001 002 003 004 005 006 007 008 009 010 011 012 013 014 015 016 017 018 019 020 021 022 023 024 025 026 027 028 029 030 031 032      033 034 035 036 037 038 039 040 041 042 043 044 045 046 047 048  049  050  051  052  053  054  055  056  057  058 059 060 061 062 063 064 065  066  067  068  069  070  071  072  073  074  075  076  077  078  079  080  081  082  083  084  085  086  087  088  089  090  091 092 093 094 095 096 097 098 099 100 101 102 103 104 105 106 107 108 109 110 111 112   113   114   115   116   117   118   119   120   121    122    123    124 125 126 127 128 129 130 131 132 133 134 135 136 137 138 139 140 141 142 143 144 145 146 147 148 149 150 151 152 153 154 155 156 157 158 159 160 161 162 163 164 165 166 167 168 169 170 171 172 173 174 175 176 177 178 179 180 181 182 183 184 185 186  187  188  189  190  191  192  193 194 195 196 197 198 199 200 201 202 203 204 205 206 207 208 209 210 211 212 213 214 215 216 217 218 219  220   221  222  223 224 225 226 227 228 229 230 231 232 233 234 235 236 237 238 239 240 241 242 243 244 245 246 247 248 249 250 251 252 253 254 255
        public static string[] asciiMap = {"", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "SPACE", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "", "", "", "", "", "", "", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F9", "F10", "F11", "F12", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ";", "=", ",", "-", ".", "/", "`", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "[", "\\", "]", "'", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""};
        public static IDictionary<string, int> keyValueCodeMap;

        public static List<D2RScript> scripts;

        public static List<D2RScript> tempScripts;

        public SettingsForm settingsForm;

        public string IPAddress;
        public int port = 9000;

        public EventBasedNetListener netListener;
        public NetManager netServer;
        public NetDataWriter netWriter;

        public IKeyboardMouseEvents m_GlobalHook;
        public bool altHeld = false; // true if the ALT key is currenty being held down

        // Windows Form initialisation
        public serverForm()
        {
            InitializeComponent();

            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0)) // Get local machines IP Address
            {
                socket.Connect("8.8.8.8", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                IPAddress = endPoint.Address.ToString();
            }

            this.Text = $"{IPAddress}:{port}"; // Set forms title to ip address and port

            // Generate key map
            keyValueCodeMap = new Dictionary<string, int>();
            for (int i = 0; i < asciiMap.Length; i++)
            {
                var key = asciiMap[i];

                if (key != "")
                {
                    keyValueCodeMap[key] = i;
                }
            }
        }

        // Application start-up
        private void Form1_Load(object sender, EventArgs e)
        {
            scripts = new List<D2RScript>();


            //D2RScript script = new D2RScript($"new1");
            //script.sId = 1;
            //scripts.Add(script);
            //string jsonString = JsonConvert.SerializeObject(scripts);
            //Log($"{jsonString}");
            //scripts = JsonConvert.DeserializeObject<List<D2RScript>>(jsonString);
            //for (int i = 0; i < scripts.Count; i++)
            //{
            //    var s = (D2RScript)scripts[i];
            //    Log($"{s.sId}, {s.sName}");
            //}



            Log(File.Exists(D2RConstants.ScriptFileName) ? "File exists." : "File does not exist.");

            if (File.Exists(D2RConstants.ScriptFileName))
            {
                // Load file
                string scriptFile = File.ReadAllText(D2RConstants.ScriptFileName);

                scripts = JsonConvert.DeserializeObject<List<D2RScript>>(scriptFile);




                Log($"Loaded scripts ({scripts.Count})");

                for (int i = 0; i < scripts.Count; i++)
                {
                    var s = (D2RScript)scripts[i];
                    Log($"{s.sId}, {s.sName}");
                }


                // scripts = JsonConvert.DeserializeObject<D2RScript[]>(scriptFile);

                ArrayList actualScripts = new ArrayList();

                for (int i = 0; i < scripts.Count; i++)
                {
                    var encodedScript = scripts[i];
                    Log($"{encodedScript.GetType()}");

                    //D2RScript decodedScript = JsonConvert.DeserializeObject(encodedScript);

                }
            }

            settingsForm = new SettingsForm();

            // Start server
            netListener = new EventBasedNetListener();
            netServer = new NetManager(netListener);
            netWriter = new NetDataWriter();
            netServer.Start(port);
            netListener.ConnectionRequestEvent += NetListener_ConnectionRequestEvent;
            netListener.PeerConnectedEvent += NetListener_PeerConnectedEvent;
            netListener.PeerDisconnectedEvent += NetListener_PeerDisconnectedEvent;
            timer1.Enabled = true;

            // Start intercepting input events
            m_GlobalHook = Hook.GlobalEvents();
            m_GlobalHook.KeyUp += M_GlobalHook_KeyUp;
            m_GlobalHook.KeyDown += M_GlobalHook_KeyDown;
            m_GlobalHook.MouseMove += M_GlobalHook_MouseMove;
            m_GlobalHook.MouseClick += M_GlobalHook_MouseClick;

            Log($"Server started at {TimeStamp()}.");
        }

        // Application shut-down
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Stop intercepting input events
            m_GlobalHook.MouseClick -= M_GlobalHook_MouseClick;
            m_GlobalHook.MouseMove -= M_GlobalHook_MouseMove;
            m_GlobalHook.KeyDown -= M_GlobalHook_KeyDown;
            m_GlobalHook.KeyUp -= M_GlobalHook_KeyUp;
            m_GlobalHook.Dispose();

            // Stop server
            timer1.Enabled = false;
            netListener.ConnectionRequestEvent -= NetListener_ConnectionRequestEvent;
            netListener.PeerConnectedEvent -= NetListener_PeerConnectedEvent;
            netListener.PeerDisconnectedEvent -= NetListener_PeerDisconnectedEvent;
            netServer.Stop();
        }

        // Perform server polling stuff
        private void timer1_Tick(object sender, EventArgs e)
        {
            netServer.PollEvents();
        }

        // Send intercepted MouseMove event to all connected clients if the ALT key is held
        private void M_GlobalHook_MouseMove(object sender, MouseEventArgs e)
        {
            if (altHeld)
            {
                //Log($"MouseMove: {e.X}, {e.Y}, {e.Button}");

                BroadcastMessage($"1,{e.X},{e.Y}");
            }
        }

        // Send intercepted MouseClick event to all connected clients if the ALT key is held
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
                    BroadcastMessage($"2,{button}");
                }
            }
        }

        // Send intercepted KeyUp event to all connected clients if the ALT key is held
        private void M_GlobalHook_KeyUp(object sender, KeyEventArgs e)
        {
            Log($"code:{e.KeyCode} value:{e.KeyValue}");

            if ((e.KeyCode == Keys.LMenu || e.KeyCode == Keys.RMenu) && altHeld)
            {
                // ALT key has been released
                altHeld = false;
            }
            else if (altHeld)
            {
                // Determine if key is valid
                if ((e.KeyValue>= 65 && e.KeyValue<= 90) || (e.KeyValue>= 48 && e.KeyValue<= 57) || (e.KeyValue>= 112 && e.KeyValue<= 123) || (e.KeyValue>= 186 && e.KeyValue<= 192) || (e.KeyValue>= 219 && e.KeyValue<= 222)) // (a-z) (0-9) (F1-F12) (;=,-./`) ([\]')
                {
                    // Key IS valid.. broadcast to all connected clients
                    BroadcastMessage($"3,{e.KeyValue}");
                }
            }
        }
        // Update status of ALT key held flag
        private void M_GlobalHook_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.LMenu || e.KeyCode == Keys.RMenu) && !altHeld)
            {
                altHeld = true; // ALT key has been pressed down
            }
            else
            {
                // Nothing needs to happen when a key is pressed down, because we really don't care about keys other than the ALT key

                //Log($"KeyDown: Code:{e.KeyCode}, Value:{e.KeyValue}(0x{e.KeyValue.ToString("X2")}), alt:{e.Alt}");
            }
        }

        // Broadcast given message to all connected clients
        private void BroadcastMessage(string message)
        {
            netWriter.Put(message);
            netServer.SendToAll(netWriter, DeliveryMethod.ReliableOrdered);
            netWriter.Reset(port);
        }

        // Server received a connection request from an IP address
        private void NetListener_ConnectionRequestEvent(ConnectionRequest request)
        {
            if (netServer.ConnectedPeersCount < 10) // Max connections
                request.AcceptIfKey("D2RApp");
            else
                request.Reject();
                Log($"Refused connection from {request.RemoteEndPoint.Address} at {TimeStamp()}");
        }

        // A client connected to the server
        private void NetListener_PeerConnectedEvent(NetPeer peer)
        {
            Clients_ListBox.Items.Add(peer.EndPoint);
            Log($"{peer.EndPoint} connected at {TimeStamp()}");
        }

        // A client disconnected from the server
        private void NetListener_PeerDisconnectedEvent(NetPeer peer, DisconnectInfo disconnectInfo)
        {
            Clients_ListBox.Items.Remove(peer.EndPoint);

            Log($"{peer.EndPoint} disconnected at {TimeStamp()}");
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

        private void Settings_Button_Click(object sender, EventArgs e)
        {
            string tempScripts = JsonConvert.SerializeObject(scripts);

            // Show testDialog as a modal dialog and determine if DialogResult = OK.
            if (settingsForm.ShowDialog(this) == DialogResult.OK)
            {
                string jsonString = JsonConvert.SerializeObject(scripts);
                File.WriteAllText(D2RConstants.ScriptFileName, jsonString);

                Log("Accepted");
            }
            else
            {
                scripts = JsonConvert.DeserializeObject<List<D2RScript>>(tempScripts);

                Log("Cancelled");
            }

        }


    }
}
