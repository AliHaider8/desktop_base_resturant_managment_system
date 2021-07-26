using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DGVPrinterHelper;
using System.Drawing;
namespace Royal_Kitchen_Managment_System
{
    public partial class DistributerUC : UserControl
    {
        string did = "0";
        public string constr;
        void Fun()
        {
            Form1 obj = new Form1();
            constr = obj.con();
        }
        void deletefields()
        {
            txtfirstname.Text = null;
            txtlastname.Text = null;
            txtcnic.Text = null;
            txtage.Text = null;
            txtfather.Text = null;
            commarried.Text = "Marital Status";
            comgender.Text = "Gender";
        }
        public DistributerUC()
        {
            InitializeComponent();
            Fun();
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DistributerUC_Load(object sender, EventArgs e)
        {
            {
                SqlConnection cn = new SqlConnection(constr);
                cn.Open();
                string querry = "SELECT * FROM DistributerPersonalDetail";
                SqlDataAdapter obj = new SqlDataAdapter(querry, cn);
                DataTable dt = new DataTable();
                obj.Fill(dt);
                guna2DataGridView1.DataSource = dt;
                cn.Close();
            }

            {
                SqlConnection cnn = new SqlConnection(constr);
                cnn.Open();
                string query = "Select count(DistributerPID) FROM DistributerPersonalDetail ";
                SqlCommand cmd = new SqlCommand(query, cnn);
                SqlDataReader obj = cmd.ExecuteReader();
                while (obj.Read())
                {
                    lblrecord.Text = obj.GetValue(0).ToString();
                }
                cnn.Close();
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cn = new SqlConnection(constr);
                cn.Open();
                string querry = "INSERT INTO DistributerPersonalDetail (FirstName,LastName,CNIC,FatherName,Age,Gender,MaritalStatus,EntryDate) VALUES('" + txtfirstname.Text.Trim() + "','" + txtlastname.Text.Trim() + "','" + txtcnic.Text.Trim() + "','" + txtfather.Text.Trim() + "','" + txtage.Text.Trim() + "','" + comgender.Text.Trim() + "','" + commarried.Text.Trim() + "',getdate())";
                SqlDataAdapter obj = new SqlDataAdapter(querry, cn);
                obj.SelectCommand.ExecuteNonQuery();
                cn.Close();
                deletefields();
                DistributerUC_Load(sender, e);
            }
            catch (Exception)
            {
                MessageBox.Show("Please Enter Correct Information");
                DistributerUC_Load(sender, e);
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("All information including contact,brand and personal will be removed. Are you sure?", "Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //Process.Start("cmd");
                try
                {
                    SqlConnection cn = new SqlConnection(constr);
                    cn.Open();
                    string querry = "Delete from DistributerPersonalDetail WHERE DistributerPID='" + did + "'";
                    SqlDataAdapter obj1 = new SqlDataAdapter(querry, cn);
                    DataTable dt1 = new DataTable();
                    obj1.Fill(dt1);
                    cn.Close();
                    deletefields();
                    DistributerUC_Load(sender, e);
                }
                catch (Exception)
                {
                    MessageBox.Show("Action not allowed");
                    DistributerUC_Load(sender, e);
                }
            }
        }

        private void guna2DataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            did = guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtfirstname.Text = guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtlastname.Text = guna2DataGridView1.SelectedRows[0].Cells[2].Value.ToString(); ;
            txtcnic.Text = guna2DataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            txtfather.Text = guna2DataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txtage.Text = guna2DataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            comgender.Text = guna2DataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            commarried.Text = guna2DataGridView1.SelectedRows[0].Cells[7].Value.ToString();

        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cn = new SqlConnection(constr);
                cn.Open();
                string querry = "update DistributerPersonalDetail set FirstName='" + txtfirstname.Text + "',LastName='" + txtlastname.Text + "',CNIC='" + txtcnic.Text + "',FatherName='" + txtfather.Text + "',Gender='" + comgender.Text + "',Age='" + txtage.Text + "',MaritalStatus='" + commarried.Text + "'WHERE DistributerPID='" + did + "'";
                SqlDataAdapter obj1 = new SqlDataAdapter(querry, cn);
                DataTable dt1 = new DataTable();
                obj1.Fill(dt1);
                cn.Close();
                deletefields();
                DistributerUC_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Update Module: \n" + ex);
                DistributerUC_Load(sender, e);
            }
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            this.Refresh();
            deletefields();
            did = "0";
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            new DistributerContactForm(constr, did).Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            new DistributerBrandForm(constr, did).Show();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cn = new SqlConnection(constr);
                cn.Open();
                string querry = "SELECT * FROM DistributerPersonalDetail WHERE   DistributerPID LIKE '%"+txtsearch.Text.Trim()+ "%' OR FirstName Like '%" + txtsearch.Text.Trim() + "%' OR LastName LIKE '%" + txtsearch.Text.Trim() + "%' OR CNIC LIKE '%" + txtsearch.Text.Trim() + "%' OR Gender LIKE '%" + txtsearch.Text.Trim() + "%' OR MaritalStatus LIKE '%" + txtsearch.Text.Trim() + "%'";
                SqlDataAdapter obj = new SqlDataAdapter(querry, cn);
                DataTable dt = new DataTable();
                obj.Fill(dt);
                guna2DataGridView1.DataSource = dt;
                cn.Close();
            }
            catch { }

            {
                SqlConnection cnn = new SqlConnection(constr);
                cnn.Open();
                string query = "Select Count(DistributerPID) FROM DistributerPersonalDetail WHERE   DistributerPID LIKE '%" + txtsearch.Text.Trim() + "%' OR FirstName Like '%" + txtsearch.Text.Trim() + "%' OR LastName LIKE '%" + txtsearch.Text.Trim() + "%' OR CNIC LIKE '%" + txtsearch.Text.Trim() + "%' OR Gender LIKE '%" + txtsearch.Text.Trim() + "%' OR MaritalStatus LIKE '%" + txtsearch.Text.Trim() + "%'";
                SqlCommand cmd = new SqlCommand(query, cnn);
                SqlDataReader obj = cmd.ExecuteReader();
                while (obj.Read())
                {
                    lblrecord.Text = obj.GetValue(0).ToString();
                }
                cnn.Close();
            }
        }

        private void btnreport_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Suppliers Report"; //give your report name
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true; // if you need page numbers you can keep this as true other wise false
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Powered by Royal Kitchen"; //this is the footer
            printer.FooterSpacing = 15;
            printer.printDocument.DefaultPageSettings.Landscape = true;
            printer.PrintDataGridView(guna2DataGridView1);
        }

        private void txtfirstname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && e.KeyChar != (char)8 && !char.IsWhiteSpace(e.KeyChar);
        }

        private void txtlastname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && e.KeyChar != (char)8 && !char.IsWhiteSpace(e.KeyChar);
        }

        private void txtcnic_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void txtcnic_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)8;
        }

        private void txtfather_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && e.KeyChar != (char)8 && !char.IsWhiteSpace(e.KeyChar);
        }

        private void txtage_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)8;
        }
    }
}
