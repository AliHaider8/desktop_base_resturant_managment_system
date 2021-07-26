using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DGVPrinterHelper;
using System.Drawing;
namespace Royal_Kitchen_Managment_System
{
    public partial class DistributerBrandForm : Form
    {
        string did, bid;
        string constr;
        public DistributerBrandForm(string con, string id)
        {
            InitializeComponent();
            constr = con;
            did = id;
        }

        private void DistributerBrandForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'royalKitchenDataSet1.DistributerPersonalDetail' table. You can move, or remove it, as needed.
            this.distributerPersonalDetailTableAdapter.Fill(this.royalKitchenDataSet1.DistributerPersonalDetail);

            
            if (did != "0")
            {
                {
                    comcnic.Text = did;
                    SqlConnection cn = new SqlConnection(constr);
                    cn.Open();
                    string querry = "SELECT BrandID AS ID#,BrandName,Address,Email,PhoneNo,EntryDate AS Date FROM DistributerBrandDetail WHERE DistributerPID='" + did.Trim() + "'";
                    SqlDataAdapter obj = new SqlDataAdapter(querry, cn);
                    DataTable dt = new DataTable();
                    obj.Fill(dt);
                    guna2DataGridView1.DataSource = dt;
                    cn.Close();
                }

                {
                    SqlConnection cnn = new SqlConnection(constr);
                    cnn.Open();
                    string query = "Select count(BrandID) FROM DistributerBrandDetail WHERE DistributerPID='" + did.Trim() + "'";
                    SqlCommand cmd = new SqlCommand(query, cnn);
                    SqlDataReader obj = cmd.ExecuteReader();
                    while (obj.Read())
                    {
                        lblrecord.Text = obj.GetValue(0).ToString();
                    }
                    cnn.Close();
                }
            }
            else if (did == "0")
            {
                {
                    comcnic.Text = "Select Supplier CNIC";
                    SqlConnection cn = new SqlConnection(constr);
                    cn.Open();
                    string querry = "SELECT BrandID AS ID#,BrandName,Address,Email,PhoneNo,EntryDate AS Date FROM DistributerBrandDetail";
                    SqlDataAdapter obj = new SqlDataAdapter(querry, cn);
                    DataTable dt = new DataTable();
                    obj.Fill(dt);
                    guna2DataGridView1.DataSource = dt;
                    cn.Close();
                }

                {
                    SqlConnection cnn = new SqlConnection(constr);
                    cnn.Open();
                    string query = "Select count(BrandID) FROM DistributerBrandDetail";
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (did != "0")
            {
                try
                {
                    SqlConnection cn = new SqlConnection(constr);
                    cn.Open();
                    string querry = "INSERT INTO DistributerBrandDetail (DistributerPID,BrandName,Address,Email,PhoneNo,EntryDate) VALUES('" + comcnic.Text.Trim() + "','" + txtbrandname.Text.Trim() + "','" + txtaddress.Text.Trim() + "','" + txtemail.Text.Trim() + "','" + txtphone.Text.Trim() + "',getdate())";
                    SqlDataAdapter obj = new SqlDataAdapter(querry, cn);
                    obj.SelectCommand.ExecuteNonQuery();
                    cn.Close();
                    new DistributerBrandForm(constr, did).Show();
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Please Enter Correct Information");
                }
            }
            else if (did == "0")
            {
                try
                {
                    string val1 = "";
                    SqlConnection cn = new SqlConnection(constr);
                    cn.Open();
                    string query22 = "Select DistributerPID from DistributerPersonalDetail WHERE CNIC='" + comcnic.Text.Trim() + "'";
                    SqlCommand cmd = new SqlCommand(query22, cn);
                    SqlDataReader obj22 = cmd.ExecuteReader();
                    while (obj22.Read())
                    {
                        val1 = obj22.GetValue(0).ToString();
                    }
                    cn.Close();
                    ////////////////////////////////////////////
                    cn.Open();
                    string querry = "INSERT INTO DistributerBrandDetail (DistributerPID,BrandName,Address,Email,PhoneNo,EntryDate) VALUES('" + val1 + "','" + txtbrandname.Text.Trim() + "','" + txtaddress.Text.Trim() + "','" + txtemail.Text.Trim() + "','" + txtphone.Text.Trim() + "',getdate())";
                    SqlDataAdapter obj = new SqlDataAdapter(querry, cn);
                    obj.SelectCommand.ExecuteNonQuery();
                    cn.Close();

                    new DistributerBrandForm(constr, did).Show();
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Please enter correct information");
                }
            }
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Brand Info will be removed. Are you sure?", "Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    SqlConnection cn = new SqlConnection(constr);
                    cn.Open();
                    string querry = "Delete from DistributerBrandDetail WHERE BrandID='" + bid + "'";
                    SqlDataAdapter obj1 = new SqlDataAdapter(querry, cn);
                    DataTable dt1 = new DataTable();
                    obj1.Fill(dt1);
                    cn.Close();
                    new DistributerBrandForm(constr, did).Show();
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Deletion Error");
                }
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cn = new SqlConnection(constr);
                cn.Open();
                string querry = "update DistributerBrandDetail set BrandName='" + txtbrandname.Text + "',Address='" + txtaddress.Text + "',Email='" + txtemail.Text + "',PhoneNo='" + txtphone.Text + "'WHERE BrandID='" + bid + "'";
                SqlDataAdapter obj1 = new SqlDataAdapter(querry, cn);
                DataTable dt1 = new DataTable();
                obj1.Fill(dt1);
                cn.Close();
                new DistributerBrandForm(constr, did).Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Update Module: \n" + ex);
            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cn = new SqlConnection(constr);
                cn.Open();
                string querry = "SELECT BrandID AS ID#,BrandName,Address,Email,PhoneNo,EntryDate AS Date FROM DistributerBrandDetail WHERE BrandID LIKE '%"+txtsearch.Text.Trim()+ "%' OR BrandName LIKE '%" + txtsearch.Text.Trim() + "%' OR Address LIKE '%" + txtsearch.Text.Trim() + "%' OR Email LIKE '%" + txtsearch.Text.Trim() + "%' OR PhoneNo LIKE '%" + txtsearch.Text.Trim() + "%'";
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
                    string query = "Select Count(BrandID) FROM DistributerBrandDetail WHERE BrandID LIKE '%" + txtsearch.Text.Trim() + "%' OR BrandName LIKE '%" + txtsearch.Text.Trim() + "%' OR Address LIKE '%" + txtsearch.Text.Trim() + "%' OR Email LIKE '%" + txtsearch.Text.Trim() + "%' OR PhoneNo LIKE '%" + txtsearch.Text.Trim() + "%'";
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

        private void btnreport_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Suppliers Brand Report"; //give your report name
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

        private void txtbrandname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && e.KeyChar != (char)8 && !char.IsWhiteSpace(e.KeyChar);
        }

        private void txtaddress_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void txtaddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != (char)8 && !char.IsWhiteSpace(e.KeyChar) && !char.IsPunctuation(e.KeyChar) ;
        }

        private void txtemail_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != (char)8 && !char.IsPunctuation(e.KeyChar);
        }

        private void txtphone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)8;
        }

        private void guna2DataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            bid = guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtbrandname.Text = guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtaddress.Text = guna2DataGridView1.SelectedRows[0].Cells[2].Value.ToString(); ;
            txtemail.Text = guna2DataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txtphone.Text = guna2DataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }
    }
}
