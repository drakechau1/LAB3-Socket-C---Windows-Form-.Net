using System;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace Menu
{
    public partial class Form_Bai1_UDPClient : Form
    {
        UdpClient udp_client;

        /// <summary>
        /// child fucntions
        /// </summary>

        private void Send_Message(IPEndPoint ipe, string message)
        {
            Byte[] bytes = Encoding.ASCII.GetBytes(message);
            udp_client.Send(bytes, bytes.Length, ipe);
        }

        private bool Check_Format()
        {
            if (txt_remoteIP.Text == "")
            {
                MessageBox.Show("Remote Ip is not validated", "Error");
                return false;
            }
            if (txt_remotePort.Text == "")
            {
                MessageBox.Show("Remote Port is not validated", "Error");
                return false;
            }
            if (rich_message.Text == "")
            {
                MessageBox.Show("Message is empty", "Error");
                return false;
            }

            return true;
        }

        /// <summary>
        /// main functions
        /// </summary>

        public Form_Bai1_UDPClient()
        {
            InitializeComponent();
            udp_client = new UdpClient();
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            if (Check_Format())
            {
                try
                {
                    UdpClient udp_client = new UdpClient();
                    IPEndPoint remote_ipe = new IPEndPoint(IPAddress.Parse(txt_remoteIP.Text), int.Parse(txt_remotePort.Text));
                    Send_Message(remote_ipe, rich_message.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
                finally
                {
                    rich_message.Text = null;
                }
            }
        }
    }
}
