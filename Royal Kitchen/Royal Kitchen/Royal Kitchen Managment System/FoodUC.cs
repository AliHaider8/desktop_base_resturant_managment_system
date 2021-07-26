using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using DGVPrinterHelper;
namespace Royal_Kitchen_Managment_System
{
    public partial class FoodUC : UserControl
    {
        public string constr, foodid = "EMPTY", foodsizeid;
        void Fun()
        {
            Form1 obj = new Form1();
            constr = obj.con();
        }
        void deletefields()
        {
            txtfoodname.Text = null;
            txtfoodtype.Text = null;
            txtfoodprice.Text = null;
            txtfoodsize.Text = null;
            txtfooddesc.Text = null;
            txtsearch.Text = null; ;
        }
        public FoodUC()
        {
            InitializeComponent();
            Fun();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                if (foodid != "EMPTY")
                {
                    SqlConnection cnn = new SqlConnection(constr);
                    string querry2 = "select * from FoodSize where FoodID='" + foodid + "'and FoodSize ='" + txtfoodsize.Text.Trim() + "'";
                    SqlDataAdapter obj2 = new SqlDataAdapter(querry2, cnn);
                    DataTable obj12 = new DataTable();
                    obj2.Fill(obj12);
                    if (obj12.Rows.Count == 1)
                    {
                        MessageBox.Show("Size already exists");
                        deletefields();
                        foodid = "EMPTY";
                        return;
                    }
                    else if (obj12.Rows.Count != 1)
                    {

                        SqlConnection cn = new SqlConnection(constr);
                        cn.Open();
                        string querry = "INSERT INTO FoodSize (FoodID,FoodSize,FoodPrice,EntryDate) VALUES('" + foodid + "','" + txtfoodsize.Text.Trim() + "','" + txtfoodprice.Text.Trim() + "',getdate())";
                        SqlDataAdapter obj = new SqlDataAdapter(querry, cn);
                        obj.SelectCommand.ExecuteNonQuery();
                        cn.Close();
                        deletefields();
                        FoodUC_Load(sender, e);
                    }
                }
                else if (foodid == "EMPTY")
                {
                    /////////////inserting data into food table///////////
                    try
                    {
                        SqlConnection cn = new SqlConnection(constr);
                        cn.Open();
                        string querry = "INSERT INTO Food (FoodName,FoodType,FoodDescription,EntryDate) VALUES('" + txtfoodname.Text.Trim() + "','" + txtfoodtype.Text.Trim() + "','" + txtfooddesc.Text.Trim() + "',getdate())";
                        SqlDataAdapter obj = new SqlDataAdapter(querry, cn);
                        obj.SelectCommand.ExecuteNonQuery();
                        cn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error Occured Reason:( \n\n" + ex);
                    }

                    ////////////inserting data into food size table///////////
                    string maxid = "";
                    {
                        SqlConnection cnn = new SqlConnection(constr);
                        cnn.Open();
                        string query = "Select Max(FoodID) FROM  Food";
                        SqlCommand cmd = new SqlCommand(query, cnn);
                        SqlDataReader obj = cmd.ExecuteReader();
                        while (obj.Read())
                        {
                            maxid = obj.GetValue(0).ToString();
                        }
                        cnn.Close();
                    }

                    try
                    {
                        SqlConnection cn = new SqlConnection(constr);
                        cn.Open();
                        string querry = "INSERT INTO FoodSize (FoodID,FoodSize,FoodPrice,EntryDate) VALUES('" + maxid + "','" + txtfoodsize.Text.Trim() + "','" + txtfoodprice.Text.Trim() + "',getdate())";
                        SqlDataAdapter obj = new SqlDataAdapter(querry, cn);
                        obj.SelectCommand.ExecuteNonQuery();
                        cn.Close();
                        deletefields();
                        FoodUC_Load(sender, e);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error Occured Reason:( \n\n" + ex);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Insert Module reason:( \n\n" + ex);
            }

            deletefields();
            foodid = "EMPTY";
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cn = new SqlConnection(constr);
                cn.Open();
                string querry = "update Food set FoodName='" + txtfoodname.Text + "',FoodType='" + txtfoodtype.Text + "',FoodDescription='" + txtfooddesc.Text + "'WHERE FoodID='" + foodid + "'";
                SqlDataAdapter obj1 = new SqlDataAdapter(querry, cn);
                DataTable dt1 = new DataTable();
                obj1.Fill(dt1);
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Update Food Module Reason:( \n\n" + ex);
            }

            try
            {
                SqlConnection cn = new SqlConnection(constr);
                cn.Open();
                string querry = "update FoodSize set FoodSize='" + txtfoodsize.Text + "',FoodPrice='" + txtfoodprice.Text + "'WHERE FoodSizeID='" + foodsizeid + "'";
                SqlDataAdapter obj1 = new SqlDataAdapter(querry, cn);
                DataTable dt1 = new DataTable();
                obj1.Fill(dt1);
                cn.Close();
                deletefields();
                FoodUC_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Update Food size Module Reason:( \n\n" + ex);
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Food will be removed. Are you sure?", "Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {


                 try
                 {
                          SqlConnection cn = new SqlConnection(constr);
                          cn.Open();
                          string querry = "Delete from Food WHERE FoodID='" + foodid + "'";
                          SqlDataAdapter obj1 = new SqlDataAdapter(querry, cn);
                          DataTable dt1 = new DataTable();
                          obj1.Fill(dt1);
                          cn.Close();
                 }
                catch (Exception)
                {
                    MessageBox.Show("Action not allowed" );
                }
                deletefields();
                FoodUC_Load(sender, e);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if(foodid=="EMPTY"|| foodid==" ")
            {
                MessageBox.Show("Please select food");
                return;
            }
            new FoodRecipeForm(foodid, foodsizeid).Show();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cn = new SqlConnection(constr);
                cn.Open();
                string querry = "Select F.FoodID,FS.FoodSizeID,F.FoodName,F.FoodType,FS.FoodSize,FS.FoodPrice,F.FoodDescription,FS.EntryDate FROM Food F INNER JOIN FoodSize FS ON F.FoodID=FS.FoodID WHERE F.FoodID LIKE '%"+txtsearch.Text.Trim()+ "%' OR FS.FoodSizeID LIKE '%" + txtsearch.Text.Trim() + "%' OR F.FoodName LIKE '%" + txtsearch.Text.Trim() + "%' OR F.FoodType LIKE '%" + txtsearch.Text.Trim() + "%' OR FS.FoodSize LIKE '%" + txtsearch.Text.Trim() + "%' OR FS.FoodPrice LIKE '%" + txtsearch.Text.Trim() + "%' ORDER BY(F.FOODID)";
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
                string query = "Select count(F.FoodID) FROM Food F INNER JOIN FoodSize FS ON F.FoodID=FS.FoodID WHERE F.FoodID LIKE '%" + txtsearch.Text.Trim() + "%' OR FS.FoodSizeID LIKE '%" + txtsearch.Text.Trim() + "%' OR F.FoodName LIKE '%" + txtsearch.Text.Trim() + "%' OR F.FoodType LIKE '%" + txtsearch.Text.Trim() + "%' OR FS.FoodSize LIKE '%" + txtsearch.Text.Trim() + "%' OR FS.FoodPrice LIKE '%" + txtsearch.Text.Trim() + "%'";
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
            printer.Title = "Foods Report"; //give your report name
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

        private void FoodUC_Load(object sender, EventArgs e)
        {
            {
                SqlConnection cn = new SqlConnection(constr);
                cn.Open();
                string querry = "Select F.FoodID,FS.FoodSizeID,F.FoodName,F.FoodType,FS.FoodSize,FS.FoodPrice,F.FoodDescription,FS.EntryDate FROM Food F INNER JOIN FoodSize FS ON F.FoodID=FS.FoodID ORDER BY(F.FOODID)";
                SqlDataAdapter obj = new SqlDataAdapter(querry, cn);
                DataTable dt = new DataTable();
                obj.Fill(dt);
                guna2DataGridView1.DataSource = dt;
                cn.Close();
            }
            {
                SqlConnection cnn = new SqlConnection(constr);
                cnn.Open();
                string query = "Select count(F.FoodID) FROM Food F INNER JOIN FoodSize FS ON F.FoodID=FS.FoodID ";
                SqlCommand cmd = new SqlCommand(query, cnn);
                SqlDataReader obj = cmd.ExecuteReader();
                while (obj.Read())
                {
                    lblrecord.Text = obj.GetValue(0).ToString();
                }
                cnn.Close();
            }
        }

        private void guna2DataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            foodid = guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            foodsizeid = guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtfoodname.Text = guna2DataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txtfoodtype.Text = guna2DataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txtfoodsize.Text = guna2DataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            txtfoodprice.Text = guna2DataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            txtfooddesc.Text = guna2DataGridView1.SelectedRows[0].Cells[6].Value.ToString();
        }
    }
}
