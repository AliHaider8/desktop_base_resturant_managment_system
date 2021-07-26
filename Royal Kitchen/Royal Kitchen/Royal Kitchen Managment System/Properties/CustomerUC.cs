using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DGVPrinterHelper;
using System.Drawing;
namespace Royal_Kitchen_Managment_System.Properties
{
    public partial class CustomerUC : UserControl
    {
        string id;
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
            txtaddress.Text = null;
            txtemail.Text = null;
            txtphone1.Text = null;
            txtphone2.Text = null;
        }
        public CustomerUC()
        {
            InitializeComponent();
            Fun();
        }

        private void CustomerUC_Load(object sender, EventArgs e)
        {

            {
                SqlConnection cn = new SqlConnection(constr);
                cn.Open();
                string querry = "SELECT * FROM Customer";
                SqlDataAdapter obj = new SqlDataAdapter(querry, cn);
                DataTable dt = new DataTable();
                obj.Fill(dt);
                guna2DataGridView1.DataSource = dt;
                cn.Close();
            }
            {
                {
                    SqlConnection cnn = new SqlConnection(constr);
                    cnn.Open();
                    string query = "SELECT count(CustomerID) FROM Customer ";
                    SqlCommand cmd = new SqlCommand(query, cnn);
                    SqlDataReader obj = cmd.ExecuteReader();
                    while (obj.Read())
                    {
                        lblrecord.Text = obj.GetValue(0).ToString();
                    }
                    cnn.Close();
                }
            }

        }

        private void Search_OnTextChange(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox5_OnValueChanged(object sender, EventArgs e)
        {

        }
        private void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cn = new SqlConnection(constr);
                cn.Open();
                string querry = "INSERT INTO Customer (FirstName,LastName,CNIC,PhoneNo1,PhoneNo2,Email,Address,EntryDate) VALUES('" + txtfirstname.Text.Trim() + "','" + txtlastname.Text.Trim() + "','" + txtcnic.Text.Trim() + "','" + txtphone1.Text.Trim() + "','" + txtphone2.Text.Trim() + "','" + txtemail.Text.Trim() + "','" + txtaddress.Text.Trim() + "',getdate())";
                SqlDataAdapter obj = new SqlDataAdapter(querry, cn);
                obj.SelectCommand.ExecuteNonQuery();
                cn.Close();
                deletefields();
                CustomerUC_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Action not allowed or Entered Value is not correct reason :(" + ex);
                CustomerUC_Load(sender, e);
            }
        }

        private void guna2DataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            id = guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtfirstname.Text = guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtlastname.Text = guna2DataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txtcnic.Text = guna2DataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txtphone1.Text = guna2DataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            txtphone2.Text = guna2DataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            txtemail.Text = guna2DataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            txtaddress.Text = guna2DataGridView1.SelectedRows[0].Cells[7].Value.ToString();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Customer Record will be removed. Are you sure?", "Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    SqlConnection cn = new SqlConnection(constr);
                    cn.Open();
                    string querry = "Delete from Customer where CustomerID='" + id + "'";
                    SqlDataAdapter obj1 = new SqlDataAdapter(querry, cn);
                    DataTable dt1 = new DataTable();
                    obj1.Fill(dt1);
                    cn.Close();
                    deletefields();
                    CustomerUC_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Action not allowed or Entered Value is not correct reason :("+ex);
                    CustomerUC_Load(sender, e);
                }
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cn = new SqlConnection(constr);
                cn.Open();
                string querry = "update Customer set FirstName='" + txtfirstname.Text + "',LastName='" + txtlastname.Text + "',CNIC='" + txtcnic.Text + "',PhoneNo1='" + txtphone1.Text + "',PhoneNo2='" + txtphone2.Text + "',Email='" + txtemail.Text + "',Address='" + txtaddress.Text + "'WHERE CustomerID='" + id + "'";
                SqlDataAdapter obj1 = new SqlDataAdapter(querry, cn);
                DataTable dt1 = new DataTable();
                obj1.Fill(dt1);
                cn.Close();
                CustomerUC_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Update Module: \n" + ex);
                CustomerUC_Load(sender, e);
            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cn = new SqlConnection(constr);
                cn.Open();
                string querry = "SELECT * FROM Customer WHERE CustomerID LIKE '%" + txtsearch.Text + "%' or FirstName LIKE '%" + txtsearch.Text + "%' or LastName LIKE '%" + txtsearch.Text + "%' or CNIC LIKE '%" + txtsearch.Text + "%' or PhoneNo1 LIKE '%" + txtsearch.Text + "%' or PhoneNo2 LIKE '%" + txtsearch.Text + "%' or Email LIKE '%" + txtsearch.Text + "%' or Address LIKE '%" + txtsearch.Text + "%'";
                SqlDataAdapter obj = new SqlDataAdapter(querry, cn);
                DataTable dt = new DataTable();
                obj.Fill(dt);
                guna2DataGridView1.DataSource = dt;
                cn.Close();
            }
            catch { }

            {
                {
                    SqlConnection cnn = new SqlConnection(constr);
                    cnn.Open();
                    string query = "SELECT count(CustomerID) FROM Customer WHERE CustomerID LIKE '%" + txtsearch.Text + "%' or FirstName LIKE '%" + txtsearch.Text + "%' or LastName LIKE '%" + txtsearch.Text + "%' or CNIC LIKE '%" + txtsearch.Text + "%' or PhoneNo1 LIKE '%" + txtsearch.Text + "%' or PhoneNo2 LIKE '%" + txtsearch.Text + "%' or Email LIKE '%" + txtsearch.Text + "%' or Address LIKE '%" + txtsearch.Text + "%'";
                    SqlCommand cmd = new SqlCommand(query, cnn);
                    SqlDataReader obj = cmd.ExecuteReader();
                    while (obj.Read())
                    {
                        lblrecord.Text = obj.GetValue(0).ToString();
                    }
                    cnn.Close();
                }
            }
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            CustomerUC obj = new CustomerUC();
            obj.CustomerUC_Load(sender, e);
        }

        private void btnreport_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Customers Report"; //give your report name
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
    }
}
