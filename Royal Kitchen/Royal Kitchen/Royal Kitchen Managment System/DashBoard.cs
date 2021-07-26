using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;
namespace Royal_Kitchen_Managment_System
{
    public partial class DashBoard : Form
    {
        string constr;
        public DashBoard(string x, string y, string z)
        {
            InitializeComponent();
            constr = x;
            guna2Button8.Text = z;
            guna2Button5.Text = y;
        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
            stockUC1.Visible = true;
            stockUC1.BringToFront();
            timer1.Start();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void moveImageBox(object sender)
        {
            Guna2Button b = (Guna2Button)sender;
            imgSlide.Location = new Point(b.Location.X + 140, b.Location.Y - 36);
            // imgSlide.SendToBack();
        }
        private void guna2Button1_CheckedChanged(object sender, EventArgs e)
        {
            moveImageBox(sender);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button14_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button15_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btncustomer_Click(object sender, EventArgs e)
        {
            customerUC1.Visible = true;
            customerUC1.BringToFront();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            distributerUC1.Visible = true;
            distributerUC1.BringToFront();
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            ingrediantsUC1.Visible = true;
            ingrediantsUC1.BringToFront();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            purchaseUC1.Visible = true;
            purchaseUC1.BringToFront();
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            new DashBoard(constr, guna2Button5.Text, guna2Button8.Text).Show();
            this.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            stockUC1.Visible = true;
            stockUC1.BringToFront();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            managerUC1.Visible = true;
            managerUC1.BringToFront();
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            employeeUC1.Visible = true;
            employeeUC1.BringToFront();
        }

        private void guna2Button13_Click(object sender, EventArgs e)
        {
            foodUC1.Visible = true;
            foodUC1.BringToFront();
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            offerUC1.Visible = true;
            offerUC1.BringToFront();
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            extrasUC1.Visible = true;
            extrasUC1.BringToFront();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            saleUC1.Visible = true;
            saleUC1.BringToFront();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime datetime = DateTime.Now;
            this.label2.Text = datetime.ToString();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            new AboutForm().Show();
        }
    }
}
