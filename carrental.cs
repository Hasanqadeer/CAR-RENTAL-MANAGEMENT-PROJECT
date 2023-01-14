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
    public partial class carrental : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=HASANQADEER;Initial Catalog=CarRentalSystem;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adp;
        SqlDataReader dr;
        DataTable dt;
        int CRENTAL_ID;
        int cust_id;
        string cname = "";
        public carrental()
        {
            InitializeComponent();
            dd();
        }
        private void cleardata()
        {
            comboBox1.Text = "";
            comboBox2.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            


           
        }
        private void dd()
        {
            con.Open();
            adp = new SqlDataAdapter("select carrental.cr_id, carrental.crental_hiredate, carrental.crental_returndate, " +
                "carrental.crental_requiredfor, customer.cust_name,carrental.crental_status " +
                "from carrental inner join customer on customer.cust_id = carrental.cust_id", con);
            dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        private void carrental_Load(object sender, EventArgs e)
        {
            {
                con.Open();
                cmd = new SqlCommand("select CR_ID FROM CARRENT", con);
                SqlDataReader dr1 = cmd.ExecuteReader();
                while (dr1.Read())
                {
                    string query1 = dr1[0].ToString();
                    comboBox1.Items.Add(query1);
                }
                dr1.Close();
                con.Close();
            }
            {
                con.Open();
                cmd = new SqlCommand("select CUST_NAME FROM CUSTOMER", con);
                SqlDataReader dr1 = cmd.ExecuteReader();
                while (dr1.Read())
                {
                    string query1 = dr1[0].ToString();
                    comboBox2.Items.Add(query1);
                }
                dr1.Close();
                con.Close();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            bmdeshboard bd = new bmdeshboard();
            bd.Show();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cname = comboBox2.SelectedItem.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && comboBox2.Text != "" && textBox1.Text != "" && textBox2.Text != "")
            {
                String query = "select cust_id from customer where cust_name = '" + cname + "'";
                con.Open();
                SqlCommand cmdd = new SqlCommand(query, con);

                cust_id = Convert.ToInt32(cmdd.ExecuteScalar());

                con.Close();
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into CARRENTAL (CR_ID,CRENTAL_HIREDATE,CRENTAL_RETURNDATE,CRENTAL_REQUIREDFOR,CUST_ID,CRENTAL_STATUS)" +
                    " values(@cr_id,@crental_hiredate,@crental_returndate,@crental_requiredfor,@cust_id,@crental_status)", con);
                cmd.Parameters.AddWithValue("@cr_id", comboBox1.Text);
                cmd.Parameters.AddWithValue("@crental_hiredate", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@crental_returndate", dateTimePicker2.Value);
                cmd.Parameters.AddWithValue("@crental_requiredfor", textBox1.Text);
              
                cmd.Parameters.AddWithValue("@cust_id", cust_id);
                cmd.Parameters.AddWithValue("@crental_status", textBox2.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("INFORMATION INSERTED", "INSERTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dd();
                cleardata();



            }
            else
            {
                MessageBox.Show("Please Insert Data", "INSERTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                cleardata();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            CRENTAL_ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
            dateTimePicker2.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
        }
    }
}
