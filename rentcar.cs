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
    public partial class rentcar : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=HASANQADEER;Initial Catalog=CarRentalSystem;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adp;
        SqlDataReader dr;
        DataTable dt;
        int CR_ID = 0;
        int C_ID;
        string carmodel;
        int carmodel_id;
        string Car_Name = "";
        public rentcar()
        {
            InitializeComponent();
            dd();
        }
        private void cleardata()
        {
            comboBox1.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
        private void dd()
        {
            con.Open();
            adp = new SqlDataAdapter("select carrent.cr_id, car.c_regno, carrent.cr_rent, carrent.cr_sdeposit from carrent inner join car on carrent.c_id = car.c_id", con);
            dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void rentcar_Load(object sender, EventArgs e)
        {
            {
               
            }
           
            {
                con.Open();
                cmd = new SqlCommand("select CMODEL_NAME FROM CARMODEL", con);
                SqlDataReader dr1 = cmd.ExecuteReader();
                while (dr1.Read())
                {
                    string query1 = dr1[0].ToString();
                    comboBox3.Items.Add(query1);
                }
                dr1.Close();
                con.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CR_ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            C_ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                String query = "select cmodel_id from carmodel where cmodel_name = '" + Car_Name + "'";
                con.Open();
                SqlCommand cmdd = new SqlCommand(query, con);

                C_ID = Convert.ToInt32(cmdd.ExecuteScalar());

                con.Close();
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into CARRENT (C_ID,CR_RENT ,CR_SDEPOSIT) values(@c_id,@cr_rent,@cr_sdeposit)", con);

                cmd.Parameters.AddWithValue("@c_id", comboBox1.Text);
                cmd.Parameters.AddWithValue("@cr_rent", textBox3.Text);
              
                cmd.Parameters.AddWithValue("@cr_sdeposit", textBox4.Text);
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

        private void label1_Click(object sender, EventArgs e)
        {
            bmdeshboard bd = new bmdeshboard();
            bd.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("update  CARRENT set C_ID = @c_id, CR_RENT = @cr_rent,CR_SDEPOSIT = @cr_sdeposit where CR_ID = @cr_id", con);
                cmd.Parameters.AddWithValue("@c_id", comboBox1.Text);
                cmd.Parameters.AddWithValue("@cr_rent", textBox3.Text);
               
                cmd.Parameters.AddWithValue("@cr_sdeposit", textBox4.Text);
                cmd.Parameters.AddWithValue("@cr_id", CR_ID);

                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("INFORMATION UPDATED", "UPDATED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dd();
                cleardata();



            }
            else
            {
                MessageBox.Show("Please select Data", "select", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dd();
                cleardata();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (CR_ID != 0)
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("delete from CARRENT where CR_ID = @CR_ID", con);

                cmd.Parameters.AddWithValue("@cr_id", CR_ID);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record deleted", "UPDATED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cleardata();
                dd();

            }
            else
            {
                MessageBox.Show("PLEASE SELECT RECORD", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Car_Name = comboBox1.SelectedItem.ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            carmodel = comboBox3.SelectedItem.ToString();
            String query = "select cmodel_id from carmodel where cmodel_name = '" + carmodel + "'";
            con.Open();
            SqlCommand cmdd = new SqlCommand(query, con);

            carmodel_id = Convert.ToInt32(cmdd.ExecuteScalar());

            con.Close();
            con.Open();

            cmd = new SqlCommand("select C_ID FROM CAR where cmodel_id = '"+carmodel_id+"' ", con);
            SqlDataReader dr1 = cmd.ExecuteReader();
            while (dr1.Read())
            {
                string query1 = dr1[0].ToString();
                comboBox1.Items.Add(query1);
            }
            dr1.Close();
            con.Close();

        }
    }
}
