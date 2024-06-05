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
namespace HospitalManagementSystem
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            display();
            display1();
            display2();
        }

        private void display()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8NH2GBN;Initial Catalog=hospitaldb;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM department", con);
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                label6.Text = Convert.ToString(count.ToString());
            }
            else
            {
                label6.Text = "0";
            }
            con.Close();
        }
        private void display1()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8NH2GBN;Initial Catalog=hospitaldb;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM patient", con);
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                label7.Text = Convert.ToString(count.ToString());
            }
            else
            {
                label7.Text = "0";
            }
            con.Close();
        }
        private void display2()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8NH2GBN;Initial Catalog=hospitaldb;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM doctor", con);
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                label8.Text = Convert.ToString(count.ToString());
            }
            else
            {
                label8.Text = "0";
            }
            con.Close();
        }
        private void display3()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8NH2GBN;Initial Catalog=hospitaldb;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Nurse", con);
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                label9.Text = Convert.ToString(count.ToString());
            }
            else
            {
                label9.Text = "0";
            }
            con.Close();
        }
        private void display4()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8NH2GBN;Initial Catalog=hospitaldb;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM appointment", con);
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                label10.Text = Convert.ToString(count.ToString());
            }
            else
            {
                label10.Text = "0";
            }
            con.Close();
        }
    }
}
