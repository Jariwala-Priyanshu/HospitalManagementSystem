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

using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HospitalManagementSystem
{
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8NH2GBN;Initial Catalog=hospitaldb;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into payment values(@PID,@PaymentMethod,@PatientName,@Amount)", con);
            cmd.Parameters.AddWithValue("@PID", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@PaymentMethod", comboBox1.Text);
            cmd.Parameters.AddWithValue("@PatientName", textBox4.Text);
            cmd.Parameters.AddWithValue("@Amount", textBox3.Text);

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Saved Successfully!");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8NH2GBN;Initial Catalog=hospitaldb;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from payment", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8NH2GBN;Initial Catalog=hospitaldb;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("update payment set paymentmethod=@PaymentMethod,patientname=@PatientName,amount=@Amount where pid=@pid", con);
            cmd.Parameters.AddWithValue("@PID", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@PaymentMethod", comboBox1.Text);
            cmd.Parameters.AddWithValue("@PatientName", textBox4.Text);
            cmd.Parameters.AddWithValue("@Amount", textBox3.Text);

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Saved Successfully!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8NH2GBN;Initial Catalog=hospitaldb;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("delete payment where pid=@pid", con);
            cmd.Parameters.AddWithValue("@PID", int.Parse(textBox1.Text));
           
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Saved Successfully!");
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8NH2GBN;Initial Catalog=hospitaldb;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from payment", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Payment_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8NH2GBN;Initial Catalog=hospitaldb;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from payment", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
