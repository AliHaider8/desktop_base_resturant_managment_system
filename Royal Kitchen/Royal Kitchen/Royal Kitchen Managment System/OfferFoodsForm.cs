using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace Royal_Kitchen_Managment_System
{
    public partial class OfferFoodsForm : Form
    {
        int chk = 0;
        string constr, offerid, foodid, foodsizeid, offerfoodid;
        void Fun()
        {
            Form1 obj = new Form1();
            constr = obj.con();
        }
        void deletefields()
        {
            comfoodid.Text = null;
            comfoodsizeid.Text = null;
            comofferid.Text = offerid;
            txtquantity.Text = null;
        }
        public OfferFoodsForm(string id)
        {
            InitializeComponent();
            Fun();
            offerid = id;
            comofferid.Text = id;
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            if (chk == 0)
            {
                this.Close();
            }
            else if (chk == 1)
            {
                OfferFoodsForm_Load(sender, e);
                chk = 0;
                btndelete.Visible = false;
                btnadd.Visible = true;
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cn = new SqlConnection(constr);
                cn.Open();
                string querry = "INSERT INTO OffersFood (OfferID,FoodID,FoodSizeID,Quantity,EntryDate) VALUES('" + comofferid.Text.Trim() + "','" + comfoodid.Text.Trim() + "','" + comfoodsizeid.Text.Trim() + "','" + txtquantity.Text.Trim() + "',getdate())";
                SqlDataAdapter obj = new SqlDataAdapter(querry, cn);
                obj.SelectCommand.ExecuteNonQuery();
                cn.Close();
                OfferFoodsForm_Load(sender, e);
                deletefields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured Reason:( \n\n" + ex);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            if(btndelete.Visible==false)
            {
                {
                    SqlConnection cn = new SqlConnection(constr);
                    cn.Open();
                    string querry = "Select F.FoodID,FS.FoodSizeID,F.FoodName,F.FoodType,FS.FoodSize,FS.FoodPrice FROM Food F INNER JOIN FoodSize FS ON F.FoodID=FS.FoodID WHERE F.FoodID LIKE '%" + txtsearch.Text.Trim() + "%' OR FS.FoodSizeID LIKE '%" + txtsearch.Text.Trim() + "%' OR F.FoodName LIKE '%" + txtsearch.Text.Trim() + "%' OR F.FoodType LIKE '%" + txtsearch.Text.Trim() + "%' OR FS.FoodSize LIKE '%" + txtsearch.Text.Trim() + "%' OR FS.FoodPrice LIKE '%" + txtsearch.Text.Trim() + "%' ORDER BY(F.FOODID)";
                    SqlDataAdapter obj = new SqlDataAdapter(querry, cn);
                    DataTable dt = new DataTable();
                    obj.Fill(dt);
                    guna2DataGridView1.DataSource = dt;
                    cn.Close();
                }
                {
                    SqlConnection cnn = new SqlConnection(constr);
                    cnn.Open();
                    string query = "Select Count(F.FoodID) FROM Food F INNER JOIN FoodSize FS ON F.FoodID=FS.FoodID WHERE F.FoodID LIKE '%" + txtsearch.Text.Trim() + "%' OR FS.FoodSizeID LIKE '%" + txtsearch.Text.Trim() + "%' OR F.FoodName LIKE '%" + txtsearch.Text.Trim() + "%' OR F.FoodType LIKE '%" + txtsearch.Text.Trim() + "%' OR FS.FoodSize LIKE '%" + txtsearch.Text.Trim() + "%' OR FS.FoodPrice LIKE '%" + txtsearch.Text.Trim() + "%'";
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

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Food will be removed from Offer. Are you sure?", "Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                try
                {
                    SqlConnection cn = new SqlConnection(constr);
                    cn.Open();
                    string querry = "Delete from OffersFood WHERE OffersFoodID='" + offerfoodid + "'";
                    SqlDataAdapter obj1 = new SqlDataAdapter(querry, cn);
                    DataTable dt1 = new DataTable();
                    obj1.Fill(dt1);
                    cn.Close();
                    OfferFoodsForm_Load(sender, e);
                    deletefields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Delete Offers Module reason :( \n\n" + ex);
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            btndelete.Visible = true;
            btnadd.Visible = false;
            SqlConnection cn = new SqlConnection(constr);
            cn.Open();
            string querry = "Select OFRF.OffersFoodID,O.OfferName,F.FoodName,FS.FoodSize,OFRF.Quantity,OFRF.EntryDate FROM OffersFood OFRF INNER JOIN Offers O ON O.OfferID=OFRF.OfferID INNER JOIN Food F ON F.FoodID=OFRF.FoodID INNER JOIN FoodSize FS ON FS.FoodSizeID=OFRF.FoodSizeID WHERE O.OfferID='" + comofferid.Text.Trim() + "'";
            SqlDataAdapter obj = new SqlDataAdapter(querry, cn);
            DataTable dt = new DataTable();
            obj.Fill(dt);
            guna2DataGridView1.DataSource = dt;
            cn.Close();
            chk = 1;
        }

        private void guna2DataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            foodid = guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            foodsizeid = guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            comfoodid.Text = foodid;
            comfoodsizeid.Text = foodsizeid;
            if (btndelete.Visible == true)
            {
                offerfoodid = guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            }
            //    txtofferprice.Text = guna2DataGridView1.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void OfferFoodsForm_Load(object sender, EventArgs e)
        {
            {
                SqlConnection cn = new SqlConnection(constr);
                cn.Open();
                string querry = "Select F.FoodID,FS.FoodSizeID,F.FoodName,F.FoodType,FS.FoodSize,FS.FoodPrice FROM Food F INNER JOIN FoodSize FS ON F.FoodID=FS.FoodID ORDER BY(F.FOODID)";
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
            btndelete.Visible = false;
            btnadd.Visible = true;
        }
    }
}
