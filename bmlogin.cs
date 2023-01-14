using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CARRENTALMANAGEMENTSYSTEM
{
    public partial class bmlogin : Form
    {
        public bmlogin()
        {
            InitializeComponent();
        }

        private void bmlogin_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                textBox2.UseSystemPasswordChar = true;
            }
            else
            {
                textBox2.UseSystemPasswordChar = false;

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=HASANQADEER;Initial Catalog=CarRentalSystem;Integrated Security=True");
            SqlDataAdapter adp = new SqlDataAdapter("select BM_UN,BM_PASSWORD FROM BMANAGER WHERE BM_UN='" + textBox1.Text + "' AND BM_PASSWORD ='" + textBox2.Text + "' ", con);
            con.Open();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Login Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Clear();
                textBox2.Clear();
                bmdeshboard bmdb = new bmdeshboard();
                bmdb.Show();
                con.Close();
            }
            else
            {
                MessageBox.Show("Enter Correct Information", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Clear();
                textBox2.Clear();
                checkBox1.Checked = false;
            }
        }
    }
}
