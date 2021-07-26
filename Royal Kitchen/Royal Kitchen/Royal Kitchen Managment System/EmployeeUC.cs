using DGVPrinterHelper;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
namespace Royal_Kitchen_Managment_System
{
    public partial class EmployeeUC : UserControl
    {
        string constr, epid="Empty";
        void Fun()
        {
            Form1 obj = new Form1();
            constr = obj.con();
        }
        void deletefields()
        {
            txtage.Text = null;
            txtcnic.Text = null;
            txtfather.Text = null;
            txtfname.Text = null;
            txtlname.Text = null;
            txtsearch.Text = null;
            comgender.Text = "Gender";
            commarried.Text = "Marital Status";
        }
        public EmployeeUC()
        {
            InitializeComponent();
            Fun();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            new EmployeeForm(epid).Show();
        }

        private void EmployeeUC_Load(object sender, EventArgs e)
        {
            {
                SqlConnection cn = new SqlConnection(constr);
                cn.Open();
                string querry = "Select * FROM EmployeePesonalDetail";
                SqlDataAdapter obj = new SqlDataAdapter(querry, cn);
                DataTable dt = new DataTable();
                obj.Fill(dt);
                guna2DataGridView1.DataSource = dt;
                cn.Close();
            }
            {
                SqlConnection cnn = new SqlConnection(constr);
                cnn.Open();
                string query = "Select count(EmployeePID) FROM EmployeePesonalDetail";
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
                string querry = "INSERT INTO EmployeePesonalDetail (FirstName,LastName,CNIC,FatherName,Age,Gender,MaritalStatus,EntryDate) VALUES('" + txtfname.Text.Trim() + "','" + txtlname.Text.Trim() + "','" + txtcnic.Text.Trim() + "','" + txtfather.Text.Trim() + "','" + txtage.Text.Trim() + "','" + comgender.Text.Trim() + "','" + commarried.Text.Trim() + "',getdate())";
                SqlDataAdapter obj = new SqlDataAdapter(querry, cn);
                obj.SelectCommand.ExecuteNonQuery();
                cn.Close();
                deletefields();
                EmployeeUC_Load(sender, e);
            }
            catch (Exception)
            {
                MessageBox.Show("Please Enter Correct Information");
            }
        }

        private void guna2DataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            epid = guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtfname.Text = guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtlname.Text = guna2DataGridView1.SelectedRows[0].Cells[2].Value.ToString(); ;
            txtcnic.Text = guna2DataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txtfather.Text = guna2DataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            txtage.Text = guna2DataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            comgender.Text = guna2DataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            commarried.Text = guna2DataGridView1.SelectedRows[0].Cells[7].Value.ToString();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("All information including contact,brand and personal will be removed. Are you sure?", "Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    SqlConnection cn = new SqlConnection(constr);
                    cn.Open();
                    string querry = "Delete from EmployeePesonalDetail WHERE EmployeePID='" + epid + "'";
                    SqlDataAdapter obj1 = new SqlDataAdapter(querry, cn);
                    DataTable dt1 = new DataTable();
                    obj1.Fill(dt1);
                    cn.Close();
                    deletefields();
                    EmployeeUC_Load(sender, e);
                }
                catch (Exception)
                {
                    MessageBox.Show("Action not allowed");
                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            new EmpQualificationForm(epid).Show();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            new EmpSkillsForm(epid).Show();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            new EmpExperianceForm(epid).Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            new EmployeecontactForm(epid).Show();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cn = new SqlConnection(constr);
                cn.Open();
                string querry = "Select * FROM EmployeePesonalDetail WHERE  EmployeePID LIKE '%" + txtsearch.Text.Trim() + "%' OR FirstName LIKE '%" + txtsearch.Text.Trim() + "%' OR LastName LIKE '%" + txtsearch.Text.Trim() + "%' OR CNIC LIKE '%" + txtsearch.Text.Trim() + "%' OR FatherName LIKE '%" + txtsearch.Text.Trim() + "%' OR Gender LIKE '%" + txtsearch.Text.Trim() + "%' OR MaritalStatus LIKE '%" + txtsearch.Text.Trim() + "%' OR Age LIKE '%" + txtsearch.Text.Trim() + "%'";
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
                string query = "Select Count(EmployeePID) FROM EmployeePesonalDetail WHERE  EmployeePID LIKE '%" + txtsearch.Text.Trim() + "%' OR FirstName LIKE '%" + txtsearch.Text.Trim() + "%' OR LastName LIKE '%" + txtsearch.Text.Trim() + "%' OR CNIC LIKE '%" + txtsearch.Text.Trim() + "%' OR FatherName LIKE '%" + txtsearch.Text.Trim() + "%' OR Gender LIKE '%" + txtsearch.Text.Trim() + "%' OR MaritalStatus LIKE '%" + txtsearch.Text.Trim() + "%' OR Age LIKE '%" + txtsearch.Text.Trim() + "%'";
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
            printer.Title = "Employee's Personal Detail Report"; //give your report name
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

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cn = new SqlConnection(constr);
                cn.Open();
                string querry = "update EmployeePesonalDetail set FirstName='" + txtfname.Text + "',LastName='" + txtlname.Text + "',CNIC='" + txtcnic.Text + "',FatherName='" + txtfather.Text + "',Gender='" + comgender.Text + "',Age='" + txtage.Text + "',MaritalStatus='" + commarried.Text + "'WHERE EmployeePID='" + epid + "'";
                SqlDataAdapter obj1 = new SqlDataAdapter(querry, cn);
                DataTable dt1 = new DataTable();
                obj1.Fill(dt1);
                cn.Close();
                deletefields();
                EmployeeUC_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Update Module: \n" + ex);
            }
        }
    }
}
