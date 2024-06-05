using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalManagementSystem
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Department dm = new Department();
            dm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Patient pt = new Patient();
            pt.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Doctor dr = new Doctor();
            dr.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Nurse ns = new Nurse();
            ns.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Appointment am = new Appointment();
            am.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Payment pt = new Payment();
            pt.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Dashboard dd = new Dashboard();
            dd.Show();
        }
    }
}
