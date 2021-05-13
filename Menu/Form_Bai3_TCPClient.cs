using System;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Menu
{
    public partial class Form_Bai3_TCPClient : Form
    {
        TcpClient client;
        IPEndPoint remote_ipe;

        Stream stream;
        StreamWriter writer;
        StreamReader reader;

        IPAddress remote_ip;
        int remote_port;


        /// <summary>
        /// Child functions
        /// </summary>

        private void Show_ERROR(string err)
        {
            MessageBox.Show(err, "Error");
        }

        public delegate void Add_Items(ListBox lb, string info);
        public void Infor_Message(ListBox lb, string info)
        {
            if (lb.InvokeRequired)
            {
                Add_Items d = new Add_Items(Infor_Message);
                this.Invoke(d, new object[] { lb, info });
            }
            else
            {
                lb_message.Items.Add(info);
            }
        }

        public void Send_Message(string message)
        {
            writer.AutoFlush = true;

            try
            {
                writer.WriteLine(message);

                if (message != string.Empty)
                {
                    Infor_Message(lb_message, message);
                }

                // ---- Uncomment if you want to close client disconnection use "quit" command ----
                //if (message == "quit")
                //{
                //    Close_Connection();
                //}

                txt_message.Text = string.Empty;
            }
            catch(Exception ex)
            {
                Show_ERROR(ex.Message);
            }
        }

        public void Close_Connection()
        {
            try
            {
                stream.Close();
                client.Close();

                Infor_Message(lb_message, "Disconnected");

                btn_connect.Enabled = true;
                btn_disconnect.Enabled = false;
                btn_send.Enabled = false;

                txt_remoteIP.ReadOnly = false;
                txt_remotePort.ReadOnly = false;
                txt_message.ReadOnly = true;
            }
            catch (Exception ex)
            {
                Show_ERROR(ex.Message);
            }
        }

        /// <summary>
        /// Main functions
        /// </summary>
        public Form_Bai3_TCPClient()
        {
            InitializeComponent();
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            try
            {
                remote_ip = IPAddress.Parse(txt_remoteIP.Text);
                remote_port = int.Parse(txt_remotePort.Text);
                remote_ipe = new IPEndPoint(remote_ip, remote_port);

                client = new TcpClient();
                client.Connect(remote_ipe);

                stream = client.GetStream();
                writer = new StreamWriter(stream);
                reader = new StreamReader(stream);

                btn_connect.Enabled = false;
                btn_disconnect.Enabled = true;
                btn_send.Enabled = true;

                txt_remoteIP.ReadOnly = true;
                txt_remotePort.ReadOnly = true;
                txt_message.ReadOnly = false;

                Infor_Message(lb_message, $"Connected to {remote_ip}:{remote_port}");
            }
            catch(Exception ex)
            {
                Show_ERROR(ex.Message);
                Infor_Message(lb_message, "Connection was aborted");
            }
            finally
            {
                btn_clearMessage.Enabled = true;
            }
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            Send_Message(txt_message.Text);
        }

        private void btn_clearMessage_Click(object sender, EventArgs e)
        {
            lb_message.Items.Clear();
        }

        private void btn_disconnect_Click(object sender, EventArgs e)
        {
            Close_Connection();
        }
    }
}
