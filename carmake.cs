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
    public partial class carmake : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=HASANQADEER;Initial Catalog=CarRentalSystem;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adp;
        SqlDataReader dr;
        DataTable dt;
        int CMAKE_ID = 0;
        public carmake()
        {
            InitializeComponent();
            dd();
        }
        private void dd()
        {
            con.Open();
            adp = new SqlDataAdapter("select * from CARMAKE",con);
            dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into CARMAKE (CMAKE_NAME) values(@cmake_name)", con);
                cmd.Parameters.AddWithValue("@cmake_name", textBox1.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("INFORMATION INSERTED", "INSERTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Clear();
                dd();

            }
            else
            {
                MessageBox.Show("PLEASE INSERT DATA", "INSERTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Clear();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CMAKE_ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {
           
            imdashboard imdb = new imdashboard();
            imdb.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("update CARMAKE set CMAKE_NAME = @cmake_name where CMAKE_ID = @CMAKE_ID", con);
                cmd.Parameters.AddWithValue("@cmake_name", textBox1.Text);
                cmd.Parameters.AddWithValue("@CMAKE_ID", CMAKE_ID);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("INFORMATION UPDATED", "UPDATED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Clear();
                dd();

            }
            else
            {
                MessageBox.Show("INSERT ALL DATA", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Clear();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (CMAKE_ID != 0)
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("delete from CARMAKE where CMAKE_ID = @CMAKE_ID", con);
           
                cmd.Parameters.AddWithValue("@CMAKE_ID", CMAKE_ID);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record deleted", "UPDATED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Clear();
                dd();

            }
            else
            {
                MessageBox.Show("PLEASE SELECT RECORD", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Clear();
            }
        }

        private void carmake_Load(object sender, EventArgs e)
        {

        }
    }
}
