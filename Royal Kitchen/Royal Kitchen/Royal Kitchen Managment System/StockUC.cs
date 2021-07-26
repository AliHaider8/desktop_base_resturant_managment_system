using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DGVPrinterHelper;
namespace Royal_Kitchen_Managment_System
{
    public partial class StockUC : UserControl
    {
        public string constr;
        void Fun()
        {
            Form1 obj = new Form1();
            constr = obj.con();
        }
        public StockUC()
        {
            InitializeComponent();
            Fun();
        }
        void chart()
        {
            using (RoyalKitchenEntities db = new RoyalKitchenEntities())
            {
                chartRevenue.DataSource = db.CurrentStocks.ToList();
                chartRevenue.Series["Revenue"].XValueMember = "IngredientID";
                chartRevenue.Series["Revenue"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
                chartRevenue.Series["Revenue"].YValueMembers = "Quantity";
                chartRevenue.Series["Revenue"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            }

        }
        private void StockUC_Load(object sender, EventArgs e)
        {
            {
                SqlConnection cn = new SqlConnection(constr);
                cn.Open();
                string querry = "Select CS.IngredientID,ING.IngredientName,CS.Quantity AS 'Quantity(G)' FROM CurrentStock CS INNER JOIN Ingredient ING ON ING.IngredientID=CS.IngredientID";
                SqlDataAdapter obj = new SqlDataAdapter(querry, cn);
                DataTable dt = new DataTable();
                obj.Fill(dt);
                guna2DataGridView1.DataSource = dt;
                cn.Close();
            }

            {
                string val = "";
                SqlConnection cnn = new SqlConnection(constr);
                cnn.Open();
                string query = "Select Count(CS.CurrentStockID) FROM CurrentStock CS INNER JOIN Ingredient ING ON ING.IngredientID = CS.IngredientID";
                SqlCommand cmd = new SqlCommand(query, cnn);
                SqlDataReader obj = cmd.ExecuteReader();
                while (obj.Read())
                {
                    val=  obj.GetValue(0).ToString();
                }
                lblrecord.Text = val;
                cnn.Close();              
            }

            
            chart();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void chartRevenue_Click(object sender, EventArgs e)
        {

        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cn = new SqlConnection(constr);
                cn.Open();
                string querry = "Select CS.IngredientID,ING.IngredientName,CS.Quantity AS 'Quantity(G)' FROM CurrentStock CS INNER JOIN Ingredient ING ON ING.IngredientID=CS.IngredientID WHERE  CS.IngredientID LIKE '%" + txtsearch.Text.Trim() + "%' OR ING.IngredientName LIKE '%" + txtsearch.Text.Trim() + "%' OR CS.Quantity LIKE '%" + txtsearch.Text.Trim() + "%'";
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
                string query = "Select Count(CurrentStockID) FROM CurrentStock CS INNER JOIN Ingredient ING ON ING.IngredientID=CS.IngredientID WHERE  CS.IngredientID LIKE '%" + txtsearch.Text.Trim() + "%' OR ING.IngredientName LIKE '%" + txtsearch.Text.Trim() + "%' OR CS.Quantity LIKE '%" + txtsearch.Text.Trim() + "%'";
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
            printer.Title = "Stock Report"; //give your report name
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
