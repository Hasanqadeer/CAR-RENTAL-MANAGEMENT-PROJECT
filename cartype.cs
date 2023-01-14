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
    public partial class cartype : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=HASANQADEER;Initial Catalog=CarRentalSystem;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adp;
        SqlDataReader dr;
        DataTable dt;
        int CTYPE_ID = 0;
        public cartype()
        {
            InitializeComponent();
            dd();
        }
        private void dd()
        {
            con.Open();
            adp = new SqlDataAdapter("select * from CARTYPE", con);
            dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        private void cartype_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CTYPE_ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("insert into CARTYPE (CTYPE_TYPE) values(@ctype_type)", con);
                cmd.Parameters.AddWithValue("@ctype_type", textBox1.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("INFORMATION INSERTED", "INSERTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Clear();
                dd();

            }
            else
            {
                MessageBox.Show("Please Insert Data", "INSERTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("update CARTYPE set CTYPE_TYPE = @ctype_type where CTYPE_ID = @CTYPE_ID", con);
                cmd.Parameters.AddWithValue("@ctype_type", textBox1.Text);
                cmd.Parameters.AddWithValue("@CTYPE_ID", CTYPE_ID);
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
            if (CTYPE_ID != 0)
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("delete from CARTYPE where CTYPE_ID = @CTYPE_ID", con);

                cmd.Parameters.AddWithValue("@CTYPE_ID", CTYPE_ID);
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

        private void label3_Click(object sender, EventArgs e)
        {
            imdashboard imdb = new imdashboard();
            imdb.Show();
        }
    }
}
