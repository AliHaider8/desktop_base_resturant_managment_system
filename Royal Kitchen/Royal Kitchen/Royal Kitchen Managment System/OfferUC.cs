using DGVPrinterHelper;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
namespace Royal_Kitchen_Managment_System
{
    public partial class OfferUC : UserControl
    {
        string constr, offerid;
        void Fun()
        {
            Form1 obj = new Form1();
            constr = obj.con();
        }
        void deletefields()
        {
            txtoffername.Text = null;
            txtofferprice.Text = null;
            comgender.Text = "Offer Availability";
        }
        public OfferUC()
        {
            InitializeComponent();
            Fun();
        }

        private void OfferUC_Load(object sender, EventArgs e)
        {
            {
                SqlConnection cn = new SqlConnection(constr);
                cn.Open();
                string querry = "Select * from Offers";
                SqlDataAdapter obj = new SqlDataAdapter(querry, cn);
                DataTable dt = new DataTable();
                obj.Fill(dt);
                guna2DataGridView1.DataSource = dt;
                cn.Close();
            }

            {
                SqlConnection cnn = new SqlConnection(constr);
                cnn.Open();
                string query = "Select count(OfferID) from Offers ";
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
                string querry = "INSERT INTO Offers (OfferName,OfferPrice,Availability,CreateTime) VALUES('" + txtoffername.Text.Trim() + "','" + txtofferprice.Text.Trim() + "','" + comgender.Text.Trim() + "',getdate())";
                SqlDataAdapter obj = new SqlDataAdapter(querry, cn);
                obj.SelectCommand.ExecuteNonQuery();
                cn.Close();
                OfferUC_Load(sender, e);
                deletefields();
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
                string querry = "update Offers set OfferName='" + txtoffername.Text + "',OfferPrice='" + txtofferprice.Text + "',Availability='" + comgender.Text + "'WHERE OfferID='" + offerid + "'";
                SqlDataAdapter obj1 = new SqlDataAdapter(querry, cn);
                DataTable dt1 = new DataTable();
                obj1.Fill(dt1);
                cn.Close();
                OfferUC_Load(sender, e);
                deletefields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Update offers Module Reason:( \n\n" + ex);
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Offer will be removed. Are you sure?", "Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                try
                {
                    SqlConnection cn = new SqlConnection(constr);
                    cn.Open();
                    string querry = "Delete from Offers WHERE OfferID='" + offerid + "'";
                    SqlDataAdapter obj1 = new SqlDataAdapter(querry, cn);
                    DataTable dt1 = new DataTable();
                    obj1.Fill(dt1);
                    cn.Close();
                    OfferUC_Load(sender, e);
                    deletefields();
                }
                catch (Exception )
                {
                    MessageBox.Show("Action not allowed");
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            new OfferFoodsForm(offerid).Show();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cn = new SqlConnection(constr);
                cn.Open();
                string querry = "Select * from Offers WHERE OfferID LIKE '%" + txtsearch.Text.Trim() + "%' OR OfferName LIKE '%" + txtsearch.Text.Trim() + "%' OR OfferPrice LIKE '%" + txtsearch.Text.Trim() + "%'";
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
                string query = "Select Count(OfferID) from Offers WHERE OfferID LIKE '%" + txtsearch.Text.Trim() + "%' OR OfferName LIKE '%" + txtsearch.Text.Trim() + "%' OR OfferPrice LIKE '%" + txtsearch.Text.Trim() + "%'";
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
            printer.Title = "Offers Report"; //give your report name
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

        private void btnrefresh_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            offerid = guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtoffername.Text = guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtofferprice.Text = guna2DataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            comgender.Text = guna2DataGridView1.SelectedRows[0].Cells[3].Value.ToString();
        }
    }
}
