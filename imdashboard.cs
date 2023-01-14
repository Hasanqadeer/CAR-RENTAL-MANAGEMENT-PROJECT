using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CARRENTALMANAGEMENTSYSTEM
{
    public partial class imdashboard : Form
    {
        public imdashboard()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            car c = new car();
            c.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            carmake cm = new carmake();
            cm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cartype ct = new cartype();
            ct.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            carmodel cm = new carmodel();
            cm.Show();
            this.Hide();
        }
    }
}
