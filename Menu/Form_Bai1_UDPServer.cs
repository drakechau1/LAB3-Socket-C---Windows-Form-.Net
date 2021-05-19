using System;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Menu
{
    public partial class Form_Bai1_UDPServer : Form
    {
        UdpClient listener;
        Thread thread;
        /// <summary>
        /// child functions
        /// </summary>

        public delegate void Add_Itmes(ListBox lb, string message);
        public void Infor_Message(ListBox lb, string message)
        {
            if (lb.InvokeRequired)
            {
                Add_Itmes d = new Add_Itmes(Infor_Message);
                this.Invoke(d, new object[] { lb, message }); ;
            }
            else
            {
                lb.Items.Add(message);
            }
        }

        private void Receive_Message(IPEndPoint ipe)
        {
            Byte[] received_byte = listener.Receive(ref ipe);
            string message = Encoding.ASCII.GetString(received_byte);
            string message_show = ipe.Address.ToString() + ":" + ipe.Port.ToString() + ": " + message;
            Infor_Message(lb_message, message_show);
        }

        private bool Check_Format()
        {
            string text = txt_port.Text;
            int n;
            if (text == "" || int.TryParse(text, out n) == false)
            {
                return false;
            }
            return true;
        }

        public void Server_Thread()
        {
            int listening_port = int.Parse(txt_port.Text);
            listener = new UdpClient(listening_port);
            Infor_Message(lb_message, $"Listening from port {listening_port}");

            while (true)
            {
                IPEndPoint ipe = new IPEndPoint(IPAddress.Any, 0);
                Receive_Message(ipe);
            }
        }

        /// <summary>
        /// main functions
        /// </summary>
        public Form_Bai1_UDPServer()
        {
            InitializeComponent();
        }

        private void btn_listen_Click(object sender, EventArgs e)
        {
            if (Check_Format())
            {
                thread = new Thread(new ThreadStart(Server_Thread));
                thread.Start();
                btn_close.Enabled = true;
                btn_listen.Enabled = false;
                txt_port.Enabled = false;
            }
            else
            {
                MessageBox.Show("Port is not validated", "Error");
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            listener.Close();
            thread.Abort();

            Infor_Message(lb_message, "Closed connection");

            btn_close.Enabled = false;
            btn_listen.Enabled = true;
            txt_port.Enabled = true;
        }
    }
}
