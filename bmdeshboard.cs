using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CARRENTALMANAGEMENTSYSTEM
{
    public partial class bmdeshboard : Form
    {
        public bmdeshboard()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            customer c = new customer();
            c.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            rentcar rc = new rentcar();
            rc.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            carrental cr = new carrental();
            cr.Show();
            this.Hide();
        }
    }
}
