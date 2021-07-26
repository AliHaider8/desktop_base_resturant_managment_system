using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using DGVPrinterHelper;
namespace Royal_Kitchen_Managment_System
{
    public partial class FoodRecipeForm : Form
    {
        string foodid, foodsizeid, ingid, FDIID;
        public string constr;
        void Fun()
        {
            Form1 obj = new Form1();
            constr = obj.con();
        }
        public FoodRecipeForm(string x, string y)
        {
            InitializeComponent();
            Fun();
            foodid = x;
            foodsizeid = y;

            combofoodid.Text = foodid;
            combosizeid.Text = foodsizeid;

            if (combosizeid.Text == "")
            {
                combosizeid.Text = "EMPTY";
            }
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                {
                    SqlConnection cnn = new SqlConnection(constr);
                    string querry2 = "select * from FoodIngredient where FoodID='" + combofoodid.Text.Trim() + "'and FoodSizeID ='" + combosizeid.Text.Trim() + "'and IngredientID='" + comboingid.Text + "'";
                    SqlDataAdapter obj2 = new SqlDataAdapter(querry2, cnn);
                    DataTable obj12 = new DataTable();
                    obj2.Fill(obj12);
                    if (obj12.Rows.Count == 1)
                    {
                        MessageBox.Show("Ingredient already exists solution(delete and add it again)");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured reason :(\n\n" + ex);
            }

            try
            {
                SqlConnection cn = new SqlConnection(constr);
                cn.Open();
                string querry = "INSERT INTO FoodIngredient (FoodID,FoodSizeID,IngredientID,Quantity,Size,EntryDate) VALUES('" + foodid + "','" + foodsizeid + "','" + ingid + "','" + txtquantity.Text + "','" + combosize.Text + "',getdate())";
                SqlDataAdapter obj = new SqlDataAdapter(querry, cn);
                obj.SelectCommand.ExecuteNonQuery();
                cn.Close();
                new FoodRecipeForm(foodid, foodsizeid).Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured Reason:( \n\n" + ex);
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Complete Recipe Of food will be removed. Are you sure?", "Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                try
                {
                    SqlConnection cn = new SqlConnection(constr);
                    cn.Open();
                    string querry = "Delete from FoodIngredient WHERE FoodID='" + combofoodid.Text + "'and FoodSizeID='" + combosizeid.Text + "'";
                    SqlDataAdapter obj1 = new SqlDataAdapter(querry, cn);
                    DataTable dt1 = new DataTable();
                    obj1.Fill(dt1);
                    cn.Close();
                    FoodRecipeForm_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Delete recipe from FoodIngredients Module reason :( \n\n" + ex);
                }
            }
        }

        private void guna2DataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            FDIID = guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cn = new SqlConnection(constr);
                cn.Open();
                string querry1 = "Select IngredientID,IngredientName,IngredientPrice from Ingredient WHERE  IngredientID Like '%"+guna2TextBox1.Text.Trim()+ "%' or IngredientName Like '%" + guna2TextBox1.Text.Trim() + "%' or IngredientPrice Like '%" + guna2TextBox1.Text.Trim() + "%'";
                SqlDataAdapter obj1 = new SqlDataAdapter(querry1, cn);
                DataTable dt1 = new DataTable();
                obj1.Fill(dt1);
                guna2DataGridView2.DataSource = dt1;
                cn.Close();
            }
            catch { }
        }

        private void btnreport_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Food Recipes"; //give your report name
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

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ingredient will be removed from a food. Are you sure?", "Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                try
                {
                    SqlConnection cn = new SqlConnection(constr);
                    cn.Open();
                    string querry = "Delete from FoodIngredient WHERE FoodIngredientID='" + FDIID + "'";
                    SqlDataAdapter obj1 = new SqlDataAdapter(querry, cn);
                    DataTable dt1 = new DataTable();
                    obj1.Fill(dt1);
                    cn.Close();
                    FoodRecipeForm_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Delete Single Ing from FoodIngredients Module reason :( \n\n" + ex);
                }
            }
        }

        private void guna2DataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            ingid = guna2DataGridView2.SelectedRows[0].Cells[0].Value.ToString();
            comboingid.Text = ingid;
        }

        private void FoodRecipeForm_Load(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(constr);
            cn.Open();
            string querry = "Select FI.FoodIngredientID AS ID#,F.FoodName AS Food,FI.FoodSizeID AS SizeNo,ING.IngredientName as Ingredient,FI.Quantity AS QTY,FI.Size,FI.EntryDate from Food F INNER JOIN FoodIngredient FI ON FI.FoodID=F.FoodID INNER JOIN Ingredient ING ON ING.IngredientID=FI.IngredientID WHERE FI.FoodID='"+combofoodid.Text.Trim()+"' and FoodSizeID='"+combosizeid.Text.Trim()+"' ORDER BY (F.FoodID )";
            SqlDataAdapter obj = new SqlDataAdapter(querry, cn);
            DataTable dt = new DataTable();
            obj.Fill(dt);
            guna2DataGridView1.DataSource = dt;

            string querry1 = "Select IngredientID,IngredientName,IngredientPrice from Ingredient";
            SqlDataAdapter obj1 = new SqlDataAdapter(querry1, cn);
            DataTable dt1 = new DataTable();
            obj1.Fill(dt1);
            guna2DataGridView2.DataSource = dt1;
            cn.Close();
        }
    }
}
