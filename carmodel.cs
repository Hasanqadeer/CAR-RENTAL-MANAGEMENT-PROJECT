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
    public partial class carmodel : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=HASANQADEER;Initial Catalog=CarRentalSystem;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adp;
        DataTable dt;
        int CMODEL_ID = 0;
        int CMAKE_ID = 0;
        int CTYPE_ID = 0;
        public carmodel()
        {
            InitializeComponent();
            dd();
        }
        private void dd()
        {
            con.Open();
            adp = new SqlDataAdapter("select * from CARMODEL", con);
            dt = new DataTable();
            adp.Fill(dt);
             dataGridView1.DataSource = dt;
            con.Close();
        }
        private void cleardata()
        {
            comboBox1.Text = "";
            textBox1.Text = "";
            comboBox2.Text = "";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && textBox1.Text != "" && comboBox2.Text != "")
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("insert into CARMODEL (CMAKE_ID,CMODEL_NAME,CTYPE_ID) values(@cmake_id,@cmodel_name,@ctype_id)", con);
                cmd.Parameters.AddWithValue("@cmake_id", comboBox1.Text);
                cmd.Parameters.AddWithValue("@cmodel_name", textBox1.Text);
                cmd.Parameters.AddWithValue("@ctype_id", comboBox2.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("INFORMATION INSERTED", "INSERTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dd();
                cleardata();
               


            }
            else
            {
                MessageBox.Show("Please Insert Data", "INSERTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dd();
                cleardata();
            }
        }

        private void carmodel_Load(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("select CMAKE_ID FROM CARMAKE", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string query = dr[0].ToString();
                comboBox1.Items.Add(query);
            }
            dr.Close();
            con.Close();
            {
                con.Open();
                cmd = new SqlCommand("select CTYPE_ID FROM CARTYPE", con);
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
       
        
       
        private void label2_Click(object sender, EventArgs e)
        {
            imdashboard db = new imdashboard();
            db.Show();
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CMODEL_ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            CMAKE_ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            CTYPE_ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
           
            
        }
    }
}
