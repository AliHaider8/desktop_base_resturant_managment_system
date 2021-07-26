using DGVPrinterHelper;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
namespace Royal_Kitchen_Managment_System
{
    public partial class IngrediantsUC : UserControl
    {
        string ingid;
        public string constr;
        void Fun()
        {
            Form1 obj = new Form1();
            constr = obj.con();
        }
        void deletefields()
        {
            txtname.Text = null;
            txtprice.Text = null;
            txtdes.Text = null;
        }
        public IngrediantsUC()
        {
            InitializeComponent();
            Fun();
        }

        private void IngrediantsUC_Load(object sender, EventArgs e)
        {
            {
                SqlConnection cn = new SqlConnection(constr);
                cn.Open();
                string querry = "SELECT * FROM Ingredient";
                SqlDataAdapter obj = new SqlDataAdapter(querry, cn);
                DataTable dt = new DataTable();
                obj.Fill(dt);
                guna2DataGridView1.DataSource = dt;
                cn.Close();
            }
            {
                SqlConnection cnn = new SqlConnection(constr);
                cnn.Open();
                string query = "Select count(IngredientID) FROM Ingredient";
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
                string querry = "INSERT INTO Ingredient (IngredientName,IngredientPrice,Size,Description,EntryDate) VALUES('" + txtname.Text + "','" + txtprice.Text + "','" + comsize.Text + "','" + txtdes.Text + "',getdate())";
                SqlDataAdapter obj = new SqlDataAdapter(querry, cn);
                obj.SelectCommand.ExecuteNonQuery();
                cn.Close();
                deletefields();
                IngrediantsUC_Load(sender, e);
            }
            catch (Exception)
            {
                MessageBox.Show("Please Enter Correct Information");
                IngrediantsUC_Load(sender, e);
            }
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            deletefields();
            IngrediantsUC_Load(sender, e);
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cn = new SqlConnection(constr);
                cn.Open();
                string querry = "update Ingredient set IngredientName='" + txtname.Text + "',IngredientPrice='" + txtprice.Text + "',Size='" + comsize.Text + "',Description='" + txtdes.Text + "'WHERE IngredientID='" + ingid + "'";
                SqlDataAdapter obj1 = new SqlDataAdapter(querry, cn);
                DataTable dt1 = new DataTable();
                obj1.Fill(dt1);
                cn.Close();
                deletefields();
                IngrediantsUC_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Update Module: \n" + ex);
                IngrediantsUC_Load(sender, e);
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ingredient Record will be removed. Are you sure?", "Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    SqlConnection cn = new SqlConnection(constr);
                    cn.Open();
                    string querry = "Delete from Ingredient where IngredientID='" + ingid + "'";
                    SqlDataAdapter obj1 = new SqlDataAdapter(querry, cn);
                    DataTable dt1 = new DataTable();
                    obj1.Fill(dt1);
                    cn.Close();
                    deletefields();
                    IngrediantsUC_Load(sender, e);
                }
                catch (Exception)
                {
                    MessageBox.Show("Action not allowed");
                    IngrediantsUC_Load(sender, e);
                }
            }
        }

        private void guna2DataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            ingid = guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtname.Text = guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtprice.Text = guna2DataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            comsize.Text = guna2DataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txtdes.Text = guna2DataGridView1.SelectedRows[0].Cells[4].Value.ToString();

        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cn = new SqlConnection(constr);
                cn.Open();
                string querry = "SELECT * FROM Ingredient WHERE IngredientID LIKE '%"+txtsearch.Text.Trim()+ "%' OR IngredientName LIKE '%" + txtsearch.Text.Trim() + "%' OR IngredientPrice LIKE '%" + txtsearch.Text.Trim() + "%' OR Size LIKE '%" + txtsearch.Text.Trim() + "%'";
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
                string query = "Select Count(IngredientID) FROM Ingredient WHERE IngredientID LIKE '%" + txtsearch.Text.Trim() + "%' OR IngredientName LIKE '%" + txtsearch.Text.Trim() + "%' OR IngredientPrice LIKE '%" + txtsearch.Text.Trim() + "%' OR Size LIKE '%" + txtsearch.Text.Trim() + "%'";
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
            printer.Title = "Ingredients Report"; //give your report name
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

        private void txtname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && e.KeyChar!=(char)8 && !char.IsWhiteSpace(e.KeyChar);
        }

        private void txtname_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void txtprice_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void txtprice_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)8;
        }

        private void txtdes_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void txtdes_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled =  e.KeyChar != (char)8 && !char.IsWhiteSpace(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar);
        }
    }
}
