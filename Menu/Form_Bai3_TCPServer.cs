using System;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace Menu
{
    public partial class Form_Bai3_TCPServer : Form
    {
        Socket listener;
        Socket client;

        Thread thread;

        NetworkStream stream;
        StreamReader reader;

        IPAddress ip;
        int port;
        IPEndPoint ipe;
        

        /// <summary>
        /// Child fucntions
        /// </summary>

        public delegate void Add_Items(ListBox lb, string infor);
        public void Infor_Message(ListBox lb, string infor)
        {
            if (lb.InvokeRequired)
            {
                Add_Items d = new Add_Items(Infor_Message);
                this.Invoke(d, new object[] { lb, infor});
            }
            else
            {
                lb_message.Items.Add(infor);
            }
        }
        
        public void Show_ERROR(string err)
        {
            MessageBox.Show(err, "Error");
        }

        bool SocketConnected(Socket s)
        {
            bool part1 = s.Poll(1000, SelectMode.SelectRead);
            bool part2 = (s.Available == 0);
            if (part1 && part2)
                return false;
            else
                return true;
        }

        public void Server_Thread()
        {
            while (true)
            {
                client = listener.Accept();

                stream = new NetworkStream(client);
                reader = new StreamReader(stream);

                Infor_Message(lb_message, "New client connected");

                while(SocketConnected(client))
                {
                    string data_received = string.Empty;
                    data_received = reader.ReadLine();

                    if (data_received == string.Empty)
                        continue;


                    // ---- Uncomment if you want to close client disconnection use "quit" command ----
                    //if (data_received == "quit")
                    //    break;

                    if(SocketConnected(client))
                    {
                        Infor_Message(lb_message, data_received);
                    }
                }

                Infor_Message(lb_message, "Client was disconnected");

                stream.Close();
                client.Close();
            }
        }

        /// <summary>
        /// Main functions
        /// </summary>
        
        public Form_Bai3_TCPServer()
        {
            InitializeComponent();
        }

        private void Form_Bai3_TCPServer_Load(object sender, EventArgs e)
        {
            ip = IPAddress.Parse("127.0.0.1");
            port = 8080;
        }

        private void btn_listen_Click(object sender, EventArgs e)
        {
            try
            {
                thread = new Thread(new ThreadStart(Server_Thread));

                listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                ipe = new IPEndPoint(ip, port);

                listener.Bind(ipe);
                listener.Listen(-1);

                Infor_Message(lb_message, $"Listening from {ip}:{port}");

                btn_listen.Enabled = false;
                btn_close.Enabled = true;

                thread.Start();
            }
            catch(Exception ex)
            {
                Show_ERROR(ex.Message);
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            try
            {
                listener.Close();

                thread.Abort();

                Infor_Message(lb_message, "Connection was closed");

                btn_listen.Enabled = true;
                btn_close.Enabled = false;
            }
            catch(Exception ex)
            {
                Show_ERROR(ex.Message);
            }
        }
    }
}
