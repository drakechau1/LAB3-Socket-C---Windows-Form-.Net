using System;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Menu
{
    public partial class Form_Bai2_Server : Form
    {

        Socket socket;
        Socket client;

        IPAddress ip = IPAddress.Parse("127.0.0.1");
        int port = 8080;
        IPEndPoint ipe;

        Thread thread;

        /// <summary>
        /// child fuctions
        /// </summary>

        public delegate void Add_Items(ListBox lb, string data);
        public void Infor_Message(ListBox lb, string data)
        {
            if (lb.InvokeRequired)
            {
                Add_Items d = new Add_Items(Infor_Message);
                this.Invoke(d, new object[] { lb, data });
            }
            else
            {
                lb.Items.Add(data);
            }
        }

        public void Server_Thread()
        {
            Byte[] received_byte = new Byte[1];
            int n_bytes = 0;

            ipe = new IPEndPoint(ip, port);

            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            socket.Bind(ipe);
            socket.Listen(-1);

            client = socket.Accept();

            Infor_Message(lb_message, "New client connected");

            while (client.Connected)
            {
                string text = "";
                do
                {
                    n_bytes = client.Receive(received_byte);
                    text += Encoding.ASCII.GetString(received_byte);
                }
                while (text[text.Length - 1] != '\n');
                Infor_Message(lb_message, text);
            }
            client.Close();
            socket.Close();
        }

        /// <summary>
        /// Main functions
        /// </summary>

        public Form_Bai2_Server()
        {
            InitializeComponent();
        }

        private void btn_listen_Click(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            thread = new Thread(new ThreadStart(Server_Thread));
            thread.Start();
            Infor_Message(lb_message, $"Listening port {port}");
            btn_listen.Enabled = false;
            btn_close.Enabled = true;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            socket.Close();
            thread.Abort();

            Infor_Message(lb_message, "Connection closed");

            btn_listen.Enabled = true;
            btn_close.Enabled = false;
        }

        private void btn_clearmessage_Click(object sender, EventArgs e)
        {
            lb_message.Items.Clear();
        }
    }
}
