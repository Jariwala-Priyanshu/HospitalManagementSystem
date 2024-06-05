using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HospitalManagementSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8NH2GBN;Initial Catalog=hospitaldb;Integrated Security=True;Encrypt=False"))
            {
                con.Open();
                string username = txtUsername.Text;
                string password = txtPassword.Text;

                // Use parameterized query to prevent SQL injection
                using (SqlCommand cmd = new SqlCommand("SELECT Username, Password FROM logintab WHERE Username=@Username AND Password=@Password", con))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        Main mn = new Main();
                        mn.Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password");
                    }
                }
            }
        }
    }
}

