using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Royal_Kitchen_Managment_System
{
    public partial class LoadingForm : Form
    {
        string constr, val2, guna2TextBox1;
        public LoadingForm(string x,string y,string z)
        {
            InitializeComponent();
            constr = x;
            val2 = y;
            guna2TextBox1 = z;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            guna2CircleProgressBar1.Increment(1);
            if(guna2CircleProgressBar1.Value==100)
            {
                new DashBoard(constr, val2, guna2TextBox1).Show();
                this.Close();
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            

        }

        private void LoadingForm_Load(object sender, EventArgs e)
        {
            this.BringToFront();
            guna2CircleProgressBar1.Value = 0;
            timer1.Start();
        }
    }
}
