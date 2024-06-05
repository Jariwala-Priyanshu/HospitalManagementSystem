using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HospitalManagementSystem
{
    public partial class Patient : Form
    {
        public Patient()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8NH2GBN;Initial Catalog=hospitaldb;Integrated Security=True;Encrypt=False"))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("insert into patient (PatientId, PatientName, Gender, Email, Address) values(@PatientId, @PatientName, @Gender, @Email, @Address)", con))
                {
                    cmd.Parameters.AddWithValue("@PatientId", int.Parse(textBox1.Text));
                    cmd.Parameters.AddWithValue("@PatientName", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Gender", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@Email", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Address", textBox4.Text);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Record Saved Successfully!");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8NH2GBN;Initial Catalog=hospitaldb;Integrated Security=True;Encrypt=False"))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("select * from patient", con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8NH2GBN;Initial Catalog=hospitaldb;Integrated Security=True;Encrypt=False"))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("update patient set PatientName=@PatientName, Gender=@Gender, Email=@Email, Address=@Address where PatientId=@PatientId", con))
                {
                    cmd.Parameters.AddWithValue("@PatientId", int.Parse(textBox1.Text));
                    cmd.Parameters.AddWithValue("@PatientName", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Gender", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@Email", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Address", textBox4.Text);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Record Updated Successfully!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8NH2GBN;Initial Catalog=hospitaldb;Integrated Security=True;Encrypt=False"))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("delete from patient where PatientId=@PatientId", con))
                {
                    cmd.Parameters.AddWithValue("@PatientId", int.Parse(textBox1.Text));
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Are you sure you want to delete?");
            }
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8NH2GBN;Initial Catalog=hospitaldb;Integrated Security=True;Encrypt=False"))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("select * from patient", con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void Patient_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8NH2GBN;Initial Catalog=hospitaldb;Integrated Security=True;Encrypt=False"))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("select * from patient", con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }
    }
}
