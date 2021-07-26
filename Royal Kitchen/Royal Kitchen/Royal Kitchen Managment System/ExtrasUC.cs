using DGVPrinterHelper;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
namespace Royal_Kitchen_Managment_System
{
    public partial class ExtrasUC : UserControl
    {
        public string constr, extrasid;
        void Fun()
        {
            Form1 obj = new Form1();
            constr = obj.con();
        }
        void deletefields()
        {
            txtname.Text = null;
            txtamount.Text = null;
            txtquantity.Text = null;
            txtdesc.Text = null;
            txtsearch.Text = null;
            comtype.Text = null;
        }
        public ExtrasUC()
        {
            InitializeComponent();
            Fun();
        }

        private void ExtrasUC_Load(object sender, EventArgs e)
        {
            {
                SqlConnection cn = new SqlConnection(constr);
                cn.Open();
                string querry = "Select * FROM Extras";
                SqlDataAdapter obj = new SqlDataAdapter(querry, cn);
                DataTable dt = new DataTable();
                obj.Fill(dt);
                guna2DataGridView1.DataSource = dt;
                cn.Close();
            }

            {
                SqlConnection cn = new SqlConnection(constr);
                cn.Open();
                string querry = "Select EmployeePID FROM EmployeePesonalDetail";
                SqlDataAdapter obj = new SqlDataAdapter(querry, cn);
                DataTable dt = new DataTable();
                obj.Fill(dt);
                comemploid.DataSource = dt;
                cn.Close();
                comemploid.Text = "EmployeePID";
            }
            {
                SqlConnection cnn = new SqlConnection(constr);
                cnn.Open();
                string query = "Select count(ExtrasID) FROM Extras ";
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
                string querry = "INSERT INTO Extras (EmployeePID,ExtrasName,ExtrasType,ExtrasQuantity,Amount,Description,EntryDate) VALUES('" + comemploid.Text + "','" + txtname.Text.Trim() + "','" + comtype.Text.Trim() + "','" + txtquantity.Text.Trim() + "','" + txtamount.Text + "','" + txtdesc.Text + "',getdate())";
                SqlDataAdapter obj = new SqlDataAdapter(querry, cn);
                obj.SelectCommand.ExecuteNonQuery();
                cn.Close();
                deletefields();
                ExtrasUC_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured Reason:( \n\n" + ex);
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cn = new SqlConnection(constr);
                cn.Open();
                string querry = "update Extras set ExtrasName='" + txtname.Text.Trim() + "',ExtrasType='" + comtype.Text.Trim() + "',ExtrasQuantity='" + txtquantity.Text.Trim() + "',Amount='" + txtamount.Text.Trim() + "',Description='" + txtdesc.Text.Trim() + "'WHERE ExtrasID='" + extrasid + "'";
                SqlDataAdapter obj1 = new SqlDataAdapter(querry, cn);
                DataTable dt1 = new DataTable();
                obj1.Fill(dt1);
                cn.Close();
                deletefields();
                ExtrasUC_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Update Extras Module Reason:( \n\n" + ex);
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("All Expense Info will be removed. Are you sure?", "Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                try
                {
                    SqlConnection cn = new SqlConnection(constr);
                    cn.Open();
                    string querry = "Delete from Extras WHERE ExtrasID='" + extrasid + "'";
                    SqlDataAdapter obj1 = new SqlDataAdapter(querry, cn);
                    DataTable dt1 = new DataTable();
                    obj1.Fill(dt1);
                    cn.Close();
                    deletefields();
                    ExtrasUC_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Delete EXtras Module reason :( \n\n" + ex);
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cn = new SqlConnection(constr);
                cn.Open();
                string querry = "Select * FROM Extras WHERE ExtrasID LIKE '%" + txtsearch.Text.Trim() + "%' OR ExtrasName LIKE '%" + txtsearch.Text.Trim() + "%' OR ExtrasQuantity LIKE '%" + txtsearch.Text.Trim() + "%' OR ExtrasType LIKE '%" + txtsearch.Text.Trim() + "%' OR Amount LIKE '%" + txtsearch.Text.Trim() + "%'";
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
                string query = "Select Count(ExtrasID) FROM Extras WHERE ExtrasID LIKE '%" + txtsearch.Text.Trim() + "%' OR ExtrasName LIKE '%" + txtsearch.Text.Trim() + "%' OR ExtrasQuantity LIKE '%" + txtsearch.Text.Trim() + "%' OR ExtrasType LIKE '%" + txtsearch.Text.Trim() + "%' OR Amount LIKE '%" + txtsearch.Text.Trim() + "%'";
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
            printer.Title = "Expense's Report"; //give your report name
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

        private void guna2DataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            extrasid = guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            comemploid.Text = guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtname.Text = guna2DataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            comtype.Text = guna2DataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txtquantity.Text = guna2DataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            txtamount.Text = guna2DataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            txtdesc.Text = guna2DataGridView1.SelectedRows[0].Cells[6].Value.ToString();
        }
    }
}
