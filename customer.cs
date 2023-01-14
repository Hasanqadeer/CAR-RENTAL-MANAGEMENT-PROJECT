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
    public partial class customer : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=HASANQADEER;Initial Catalog=CarRentalSystem;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adp;
        SqlDataReader dr;
        DataTable dt;
        int CUST_ID = 0;
        public customer()
        {
            InitializeComponent();
            dd();
        }
        private void dd()
        {
            con.Open();
            adp = new SqlDataAdapter("select * from CUSTOMER", con);
            dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            adp = new SqlDataAdapter("select * from CUSTOMER where CUST_NAME like'" + textBox6.Text + "%'", con);
            dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CUST_ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
        }
        private void cdata()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("insert into customer (CUST_CNIC,CUST_NAME,CUST_AGE,CUST_CONTACT,CUST_ADDRESS) values(@cust_cnic,@cust_name,@cust_age,@cust_contact,@cust_address)", con);
                cmd.Parameters.AddWithValue("@cust_cnic", textBox1.Text);
                cmd.Parameters.AddWithValue("@cust_name", textBox2.Text);
                cmd.Parameters.AddWithValue("@cust_age", textBox3.Text);
                cmd.Parameters.AddWithValue("@cust_contact", textBox4.Text);
                cmd.Parameters.AddWithValue("@cust_address", textBox5.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("INFORMATION INSERTED", "INSERTED", MessageBoxButtons.OK, MessageBoxIcon.Information);

                dd();
                cdata();

            }
            else
            {
                MessageBox.Show("Please Insert Data", "INSERTED", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            bmdeshboard db = new bmdeshboard();
            db.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("update customer set CUST_CNIC = @cust_cnic,CUST_NAME = @cust_name ,CUST_AGE = @cust_age,CUST_CONTACT = @cust_contact,CUST_ADDRESS = @cust_address where CUST_ID = @cust_id ", con);
                cmd.Parameters.AddWithValue("@cust_cnic", textBox1.Text);
                cmd.Parameters.AddWithValue("@cust_name", textBox2.Text);
                cmd.Parameters.AddWithValue("@cust_age", textBox3.Text);
                cmd.Parameters.AddWithValue("@cust_contact", textBox4.Text);
                cmd.Parameters.AddWithValue("@cust_address", textBox5.Text);
                cmd.Parameters.AddWithValue("@CUST_ID", CUST_ID);

                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("INFORMATION UPDATED", "UPDATED", MessageBoxButtons.OK, MessageBoxIcon.Information);

                dd();
                cdata();

            }
            else
            {
                MessageBox.Show("PLEASE SELECT DATA", "UPDATE", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (CUST_ID != 0)
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("delete from CUSTOMER where CUST_ID = @CUST_ID", con);

                cmd.Parameters.AddWithValue("@CUST_ID", CUST_ID);
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
    }
}
