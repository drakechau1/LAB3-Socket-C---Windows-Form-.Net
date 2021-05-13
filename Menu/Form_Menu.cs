using System;
using System.Windows.Forms;


namespace Menu
{
    public partial class Form_Menu : Form
    {

        public const byte Assignment1 = 1;
        public const byte Assignment3 = 3;
        public const byte Assignment4 = 4;

        Form form;

        public Form_Menu()
        {
            InitializeComponent();
            form = new Form();
        }

        private void btn_bai1_Click(object sender, EventArgs e)
        {
            form = new Form_Dashboard(Assignment1);
            form.Show();
        }

        private void btn_bai2_Click(object sender, EventArgs e)
        {
            form = new Form_Bai2_Server();
            form.Show();
        }

        private void btn_bai3_Click(object sender, EventArgs e)
        {
            form = new Form_Dashboard(Assignment3);
            form.Show();
        }

        private void btn_bai4_Click(object sender, EventArgs e)
        {
            form = new Form_Dashboard(Assignment4);
            form.Show();
        }
    }
}
