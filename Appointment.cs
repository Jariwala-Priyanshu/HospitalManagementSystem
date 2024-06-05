using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HospitalManagementSystem
{
    public partial class Appointment : Form
    {
        public Appointment()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Back)
            {
                dateTimePicker1.CustomFormat = "";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8NH2GBN;Initial Catalog=hospitaldb;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into appointment values(@AppID,@PatientName,@DoctorName,@AppointmentDate)", con);
            cmd.Parameters.AddWithValue("@AppID", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@PatientName", textBox2.Text);
            cmd.Parameters.AddWithValue("@DoctorName", textBox4.Text);
            cmd.Parameters.AddWithValue("@AppointmentDate", dateTimePicker1.Value);
            
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Saved Successfully!");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8NH2GBN;Initial Catalog=hospitaldb;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from appointment", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8NH2GBN;Initial Catalog=hospitaldb;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("update appointment set patientname=@PatientName,doctorname=@DoctorName,appointmentdate=@AppointmentDate where appid=@appid", con);
            cmd.Parameters.AddWithValue("@AppID", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@PatientName", textBox2.Text);
            cmd.Parameters.AddWithValue("@DoctorName", textBox4.Text);
            cmd.Parameters.AddWithValue("@AppointmentDate", dateTimePicker1.Value);

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Update Successfully!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8NH2GBN;Initial Catalog=hospitaldb;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("delete appointment where appid=@appid", con);
            cmd.Parameters.AddWithValue("@AppID", int.Parse(textBox1.Text));
            

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Are you sure you want to delete");
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8NH2GBN;Initial Catalog=hospitaldb;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from appointment", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Appointment_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8NH2GBN;Initial Catalog=hospitaldb;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from appointment", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
