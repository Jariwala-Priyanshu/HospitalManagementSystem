using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace HospitalManagementSystem
{
    public partial class Nurse : Form
    {
        public Nurse()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8NH2GBN;Initial Catalog=hospitaldb;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Nurse values(@NurseId,@NurseName,@Gender,@Phone,@Address)", con);
            cmd.Parameters.AddWithValue("@NurseId", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@NurseName", textBox2.Text);
            cmd.Parameters.AddWithValue("@Gender", comboBox1.Text);
            cmd.Parameters.AddWithValue("@Phone", textBox3.Text);
            cmd.Parameters.AddWithValue("@Address", textBox4.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Saved Successfully!");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8NH2GBN;Initial Catalog=hospitaldb;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Nurse", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8NH2GBN;Initial Catalog=hospitaldb;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("update Nurse set NurseName=@NurseName,gender=@Gender,phone=@Phone,address=@Address where Nurseid=@Nurseid", con);
            cmd.Parameters.AddWithValue("@NurseId", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@NurseName", textBox2.Text);
            cmd.Parameters.AddWithValue("@Gender", comboBox1.Text);
            cmd.Parameters.AddWithValue("@Phone", textBox3.Text);
            cmd.Parameters.AddWithValue("@Address", textBox4.Text);

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Updated Successfully!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8NH2GBN;Initial Catalog=hospitaldb;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("delete Nurse where nurseid=@nurseid", con);
            cmd.Parameters.AddWithValue("@NurseId", int.Parse(textBox1.Text));
            
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Are you sure you want to delete?");
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8NH2GBN;Initial Catalog=hospitaldb;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Nurse", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Nurse_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8NH2GBN;Initial Catalog=hospitaldb;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Nurse", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
