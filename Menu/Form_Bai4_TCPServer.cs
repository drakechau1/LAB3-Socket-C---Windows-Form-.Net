using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using Newtonsoft.Json;


namespace Menu
{
    public partial class Form_Bai4_TCPServer : Form
    {
        Socket listener;

        Thread thread_handle_connection;

        IPAddress ip;
        int port;
        IPEndPoint ipe;

        static readonly object _lock = new object();
        static readonly Dictionary<int, Socket> listClients = new Dictionary<int, Socket>();
        static readonly Dictionary<int, Thread> listThreads = new Dictionary<int, Thread>();
        int count_clients;

        public class Infor
        {
            public string Name { get; set; }
            public string Message { get; set; }
        }
        /// <summary>
        /// Child fucntions
        /// </summary>

        public delegate void Add_Items(ListBox lb, string infor);
        public void Infor_Message(ListBox lb, string infor)
        {
            if (lb.InvokeRequired)
            {
                Add_Items d = new Add_Items(Infor_Message);
                this.Invoke(d, new object[] { lb, infor });
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

        public void Server_Handle_Connection()
        {
            while(true)
            {
                count_clients += 1;

                Socket client = listener.Accept();
                lock (_lock) listClients.Add(count_clients, client);

                Thread thread = new Thread(Server_Handle_Client);
                lock (_lock) listThreads.Add(count_clients, thread);
                thread.Start(count_clients);
            }
        }

        public void Server_Handle_Client(object id)
        {
            int client_id = (int)id;
            Socket client = listClients[client_id];

            NetworkStream stream = new NetworkStream(client);
            StreamReader reader = new StreamReader(stream);
            StreamWriter writer = new StreamWriter(stream);

            string indentify_id = reader.ReadLine();
            Infor_Message(lb_message, $"------ {indentify_id} connected");

            while (SocketConnected(client))
            {
                string data_str =  reader.ReadLine();

                if (data_str == string.Empty)
                    continue;

                if (SocketConnected(client))
                {
                    Infor infor = JsonConvert.DeserializeObject<Infor>(data_str);
                    Infor_Message(lb_message, infor.Name + ": " + infor.Message);
                }
            }

            Infor_Message(lb_message, $"------ {indentify_id} disconnected");

            lock (_lock) listClients.Remove(client_id);

            stream.Close();
            client.Close();
        }

        /// <summary>
        /// Main functions
        /// </summary>

        public Form_Bai4_TCPServer()
        {
            InitializeComponent();
        }

        private void btn_listen_Click(object sender, EventArgs e)
        {
            ip = IPAddress.Parse("127.0.0.1");
            port = 8080;

            try
            {
                thread_handle_connection = new Thread(new ThreadStart(Server_Handle_Connection));

                ipe = new IPEndPoint(ip, port);
                listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                listener.Bind(ipe);
                listener.Listen(-1);

                Infor_Message(lb_message, $"Listening from {ip}:{port}");

                btn_listen.Enabled = false;
                btn_close.Enabled = true;

                thread_handle_connection.Start();
            }
            catch (Exception ex)
            {
                Show_ERROR(ex.Message);
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Thread thread in listThreads.Values)
                {
                    thread.Abort();
                }

                listClients.Clear();
                listener.Close();

                thread_handle_connection.Abort();

                Infor_Message(lb_message, "Connection was closed");

                btn_listen.Enabled = true;
                btn_close.Enabled = false;
            }
            catch (Exception ex)
            {
                Show_ERROR(ex.Message);
            }
        }
    }
}
