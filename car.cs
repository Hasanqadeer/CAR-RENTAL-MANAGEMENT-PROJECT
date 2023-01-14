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
    public partial class car : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=HASANQADEER;Initial Catalog=CarRentalSystem;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adp;
        SqlDataReader dr;
        DataTable dt;
        int C_ID = 0;
        int CMODEL_ID = 0;
        string CMODEL_Name = "";
       
        public car()
        {
            InitializeComponent();
            dd();
        }
        private void dd()
        {
            con.Open();
            adp = new SqlDataAdapter("select car.c_id,car.c_regno,carmodel.cmodel_name ,car.status from CAR inner join carmodel on car.cmodel_id = carmodel.cmodel_id", con);
            dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        private void cleardata()
        {
           
            textBox1.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            textBox2.Text = "";
        }

        private void label2_Click(object sender, EventArgs e)
        {
            imdashboard db = new imdashboard();
            db.Show();
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            C_ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            CMODEL_ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
            comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

        }

        private void car_Load(object sender, EventArgs e)
        {
            {
                con.Open();
                cmd = new SqlCommand("select CMODEL_NAME FROM CARMODEL", con);
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
                cmd = new SqlCommand("select CTYPE_TYPE FROM CARTYPE", con);
                SqlDataReader dr2 = cmd.ExecuteReader();
                while (dr2.Read())
                {
                    string query1 = dr2[0].ToString();
                    comboBox2.Items.Add(query1);
                }
                dr2.Close();
                con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && comboBox1.Text != "" && comboBox2.Text != "" && textBox2.Text != "")
            {
                String query = "select cmodel_id from carmodel where cmodel_name = '"+CMODEL_Name+"'";
                con.Open();
                SqlCommand cmdd = new SqlCommand(query, con);

                CMODEL_ID = Convert.ToInt32(cmdd.ExecuteScalar());
      
                con.Close();
                con.Open();

                SqlCommand cmd = new SqlCommand("insert into CAR (C_REGNO,CMODEL_ID,CTYPE_TYPE,STATUS) values(@c_regno,@cmodel_id,@ctype_type,@status)", con);
                cmd.Parameters.AddWithValue("@c_regno", textBox1.Text);
                cmd.Parameters.AddWithValue("@cmodel_id", CMODEL_ID);
                cmd.Parameters.AddWithValue("@ctype_type", comboBox2.Text);
                cmd.Parameters.AddWithValue("@status", textBox2.Text);
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CMODEL_Name = comboBox1.SelectedItem.ToString();
        }
    }
}
