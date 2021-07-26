using DGVPrinterHelper;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
namespace Royal_Kitchen_Managment_System
{
    public partial class PurchaseViewForm : Form
    {
        string pid;
        public string constr;
        void Fun()
        {
            Form1 obj = new Form1();
            constr = obj.con();
        }
        void deletefields()
        {

        }
        public PurchaseViewForm()
        {
            InitializeComponent();
            Fun();
        }

        private void PurchaseViewForm_Load(object sender, EventArgs e)
        {
            {
                SqlConnection cn = new SqlConnection(constr);
                cn.Open();
                string querry = "Select PP.PurchaseID ,DBD.BrandName,ING.IngredientID,ING.IngredientName,ING.Size,PP.Quantity,(PP.Quantity*PP.PurchasePrice) AS 'Total Amount',PP.PurchaseDate FROM   ProductPurchase PP INNER JOIN DistributerPayment DP ON PP.PurchaseID=DP.PurchaseID INNER JOIN DistributerBrandDetail DBD ON DBD.BrandID=PP.BrandID INNER JOIN Ingredient ING ON ING.IngredientID=PP.IngredientID WHERE  PP.PurchaseID=DP.PurchaseID AND DBD.BrandID=PP.BrandID AND ING.IngredientID=PP.IngredientID ORDER BY DBD.BrandID ASC";
                SqlDataAdapter obj = new SqlDataAdapter(querry, cn);
                DataTable dt = new DataTable();
                obj.Fill(dt);
                guna2DataGridView1.DataSource = dt;
                cn.Close();
            }

            {
                SqlConnection cnn = new SqlConnection(constr);
                cnn.Open();
                string query = "Select count(PP.PurchaseID) FROM  ProductPurchase PP INNER JOIN DistributerPayment DP ON PP.PurchaseID=DP.PurchaseID INNER JOIN DistributerBrandDetail DBD ON DBD.BrandID=PP.BrandID INNER JOIN Ingredient ING ON ING.IngredientID=PP.IngredientID WHERE  PP.PurchaseID=DP.PurchaseID AND DBD.BrandID=PP.BrandID AND ING.IngredientID=PP.IngredientID "; 
                SqlCommand cmd = new SqlCommand(query, cnn);
                SqlDataReader obj = cmd.ExecuteReader();
                while (obj.Read())
                {
                    lblrecord.Text = obj.GetValue(0).ToString();
                }
                cnn.Close();
            }

            {
                lblpurchase.Text = "Total Purchase: ";
                string val = "";
                SqlConnection cnn = new SqlConnection(constr);
                cnn.Open();
                string query = "Select SUM(PP.Quantity*PP.PurchasePrice) FROM  ProductPurchase PP INNER JOIN DistributerPayment DP ON PP.PurchaseID=DP.PurchaseID INNER JOIN DistributerBrandDetail DBD ON DBD.BrandID=PP.BrandID INNER JOIN Ingredient ING ON ING.IngredientID=PP.IngredientID WHERE  PP.PurchaseID=DP.PurchaseID AND DBD.BrandID=PP.BrandID AND ING.IngredientID=PP.IngredientID ";
                SqlCommand cmd = new SqlCommand(query, cnn);
                SqlDataReader obj = cmd.ExecuteReader();
                while (obj.Read())
                {
                    val = obj.GetValue(0).ToString();
                }
                lblpurchase.Text += val;
                cnn.Close();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2DataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            pid = guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Purchase and payment Info will be removed. Are you sure?", "Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    SqlConnection cn = new SqlConnection(constr);
                    cn.Open();
                    string querry = "Delete from DistributerPayment WHERE purchaseID='" + pid + "'";
                    SqlDataAdapter obj1 = new SqlDataAdapter(querry, cn);
                    DataTable dt1 = new DataTable();
                    obj1.Fill(dt1);
                    cn.Close();
                    new PurchaseViewForm().Show();
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Deletion Error at distributer payment module");
                }

                try
                {
                    SqlConnection cn = new SqlConnection(constr);
                    cn.Open();
                    string querry = "Delete from ProductPurchase WHERE PurchaseID='" + pid + "'";
                    SqlDataAdapter obj1 = new SqlDataAdapter(querry, cn);
                    DataTable dt1 = new DataTable();
                    obj1.Fill(dt1);
                    cn.Close();
                    new PurchaseViewForm().Show();
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Deletion Error at purchase product module");
                }
            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cn = new SqlConnection(constr);
                cn.Open();
                string querry = "Select PP.PurchaseID ,DBD.BrandName,ING.IngredientID,ING.IngredientName,ING.Size,PP.Quantity,(PP.Quantity*PP.PurchasePrice) AS 'Total Amount',PP.PurchaseDate FROM   ProductPurchase PP INNER JOIN DistributerPayment DP ON PP.PurchaseID=DP.PurchaseID INNER JOIN DistributerBrandDetail DBD ON DBD.BrandID=PP.BrandID INNER JOIN Ingredient ING ON ING.IngredientID=PP.IngredientID WHERE  PP.PurchaseID=DP.PurchaseID AND DBD.BrandID=PP.BrandID AND ING.IngredientID=PP.IngredientID AND (PP.PurchaseID LIKE '%" + txtsearch.Text.Trim() + "%' OR DBD.BrandName LIKE '%" + txtsearch.Text.Trim() + "%'OR ING.IngredientID LIKE '%" + txtsearch.Text.Trim() + "%' OR ING.IngredientName LIKE '%" + txtsearch.Text.Trim() + "%' OR ING.Size LIKE '%" + txtsearch.Text.Trim() + "%' OR (PP.Quantity*PP.PurchasePrice) LIKE '%" + txtsearch.Text.Trim() + "%' OR PP.PurchaseDate LIKE '%"+txtsearch.Text.Trim()+"%' ) ORDER BY DBD.BrandID ASC";
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
                string query = "Select Count(PP.PurchaseID) FROM   ProductPurchase PP INNER JOIN DistributerPayment DP ON PP.PurchaseID=DP.PurchaseID INNER JOIN DistributerBrandDetail DBD ON DBD.BrandID=PP.BrandID INNER JOIN Ingredient ING ON ING.IngredientID=PP.IngredientID WHERE  PP.PurchaseID=DP.PurchaseID AND DBD.BrandID=PP.BrandID AND ING.IngredientID=PP.IngredientID AND (PP.PurchaseID LIKE '%" + txtsearch.Text.Trim() + "%' OR DBD.BrandName LIKE '%" + txtsearch.Text.Trim() + "%'OR ING.IngredientID LIKE '%" + txtsearch.Text.Trim() + "%' OR ING.IngredientName LIKE '%" + txtsearch.Text.Trim() + "%' OR ING.Size LIKE '%" + txtsearch.Text.Trim() + "%' OR (PP.Quantity*PP.PurchasePrice) LIKE '%" + txtsearch.Text.Trim() + "%') ";
                SqlCommand cmd = new SqlCommand(query, cnn);
                SqlDataReader obj = cmd.ExecuteReader();
                while (obj.Read())
                {
                    lblrecord.Text = obj.GetValue(0).ToString();
                }
                cnn.Close();
            }

            {
                lblpurchase.Text = "Total Purchase : ";
                SqlConnection cnn = new SqlConnection(constr);
                cnn.Open();
                string query = "Select SUM(PP.Quantity*PP.PurchasePrice) FROM   ProductPurchase PP INNER JOIN DistributerPayment DP ON PP.PurchaseID=DP.PurchaseID INNER JOIN DistributerBrandDetail DBD ON DBD.BrandID=PP.BrandID INNER JOIN Ingredient ING ON ING.IngredientID=PP.IngredientID WHERE  PP.PurchaseID=DP.PurchaseID AND DBD.BrandID=PP.BrandID AND ING.IngredientID=PP.IngredientID AND (PP.PurchaseID LIKE '%" + txtsearch.Text.Trim() + "%' OR DBD.BrandName LIKE '%" + txtsearch.Text.Trim() + "%'OR ING.IngredientID LIKE '%" + txtsearch.Text.Trim() + "%' OR ING.IngredientName LIKE '%" + txtsearch.Text.Trim() + "%' OR ING.Size LIKE '%" + txtsearch.Text.Trim() + "%' OR (PP.Quantity*PP.PurchasePrice) LIKE '%" + txtsearch.Text.Trim() + "%') ";
                SqlCommand cmd = new SqlCommand(query, cnn);
                SqlDataReader obj = cmd.ExecuteReader();
                while (obj.Read())
                {
                    lblpurchase.Text = lblpurchase.Text+obj.GetValue(0).ToString();
                }
                cnn.Close();
            }
        }

        private void btnreport_Click(object sender, EventArgs e)
        {

            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Purchase Report"; //give your report name
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

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
