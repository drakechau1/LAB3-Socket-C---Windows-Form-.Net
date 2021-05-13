using System;
using System.Windows.Forms;


namespace Menu
{
    public partial class Form_Dashboard : Form
    {
        byte selective_flag;
        Form form_client;
        Form form_server;

        public Form_Dashboard()
        {
            InitializeComponent();
            form_client = new Form();
            form_server = new Form();
        }

        public Form_Dashboard(byte type)
        {
            InitializeComponent();
            this.selective_flag = type;
        }

        private void Form_Dashboard_Load(object sender, EventArgs e)
        {
            this.Text = $"Dashboard {selective_flag}";
        }

        private void btn_client_Click(object sender, EventArgs e)
        {
            switch (this.selective_flag)
            {
                case 1:
                    form_client = new Form_Bai1_UDPClient();
                    break;
                case 3:
                    form_client = new Form_Bai3_TCPClient();
                    break;
                case 4:
                    form_client = new Form_Bai4_TCPClient();
                    break;
                default:
                    break;
            }
            form_client.Show();
        }

        private void btn_server_Click(object sender, EventArgs e)
        {
            switch (this.selective_flag)
            {
                case 1:
                    form_server = new Form_Bai1_UDPServer();
                    break;
                case 3:
                    form_server = new Form_Bai3_TCPServer();
                    break;
                case 4:
                    form_server = new Form_Bai4_TCPServer();
                    break;
                default:
                    break;
            }

            form_server.Show();
        }
    }
}
