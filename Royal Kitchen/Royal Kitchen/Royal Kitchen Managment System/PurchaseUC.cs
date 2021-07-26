using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace Royal_Kitchen_Managment_System
{
    public partial class PurchaseUC : UserControl
    {
        double glob;
        string ingid, brandid, CNIC, amt;
        public string constr;
        void Fun()
        {
            Form1 obj = new Form1();
            constr = obj.con();
        }
        void deletefields()
        {
            txtprice.Text = null;
            txtquantity.Text = null;
            txtsize.Text = null;
            lbling.Text = null;
            lblbrand.Text = null;
        }
        public PurchaseUC()
        {
            InitializeComponent();
            Fun();
        }
        void ing()
        {
            SqlConnection cn = new SqlConnection(constr);
            cn.Open();
            string querry = "SELECT IngredientID,IngredientName,IngredientPrice,Size FROM Ingredient";
            SqlDataAdapter obj = new SqlDataAdapter(querry, cn);
            DataTable dt = new DataTable();
            obj.Fill(dt);
            guna2DataGridView1.DataSource = dt;
            cn.Close();
        }
        void brand()
        {
            SqlConnection cn = new SqlConnection(constr);
            cn.Open();
            string querry = "SELECT DBD.BrandID,DBD.BrandName,D.FirstName AS 'Supplier',D.CNIC FROM  DistributerPersonalDetail D INNER JOIN DistributerBrandDetail DBD ON D.DistributerPID=DBD.DistributerPID";
            SqlDataAdapter obj = new SqlDataAdapter(querry, cn);
            DataTable dt = new DataTable();
            obj.Fill(dt);
            guna2DataGridView2.DataSource = dt;
            cn.Close();
        }
        private void PurchaseUC_Load(object sender, EventArgs e)
        {
            ing();
            brand();

            lblbrand.Text = "Brand not selected";
            lbling.Text = "Ingredient not selected";
        }

        private void guna2DataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            brandid = guna2DataGridView2.SelectedRows[0].Cells[0].Value.ToString();
            lblbrand.Text = guna2DataGridView2.SelectedRows[0].Cells[1].Value.ToString();
            CNIC = guna2DataGridView2.SelectedRows[0].Cells[3].Value.ToString();
        }
        void stock()
        {
            SqlConnection cnn = new SqlConnection(constr);
            cnn.Open();

            string querry = "select * from CurrentStock where IngredientID='" + ingid.Trim() + "'";
            SqlDataAdapter obj = new SqlDataAdapter(querry, cnn);
            DataTable obj1 = new DataTable();
            obj.Fill(obj1);
            if (obj1.Rows.Count == 1)
            {
                String ID = "", quant = "";
                SqlConnection cn = new SqlConnection(constr);
                cn.Open();
                string querY = "select CurrentStockID,Quantity from CurrentStock where IngredientID='" + ingid.Trim() + "'";
                SqlCommand cmd = new SqlCommand(querY, cn);
                SqlDataReader obj22 = cmd.ExecuteReader();
                while (obj22.Read())
                {
                    ID = obj22.GetValue(0).ToString();
                    quant = obj22.GetValue(1).ToString();
                }
                cnn.Close();

                int q1=0, qtxt=0;
                q1 = Convert.ToInt32(quant);
                qtxt = Convert.ToInt32(txtquantity.Text);
                qtxt=qtxt * 1000;
                q1 += qtxt;

                /////////////////////////updating stock//////////////////////////////
                try
                {
                    SqlConnection cnnn = new SqlConnection(constr);
                    cnnn.Open();
                    string querry44 = "update CurrentStock set Quantity='" + q1 + "'WHERE CurrentStockID='" + ID + "'";
                    SqlDataAdapter obj44 = new SqlDataAdapter(querry44, cnnn);
                    DataTable dt44 = new DataTable();
                    obj44.Fill(dt44);
                    cn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Update Module: \n" + ex);
                }
            }
            else if (obj1.Rows.Count != 1)
            {
                SqlConnection cn = new SqlConnection(constr);
                cn.Open();
                string querry1 = "INSERT INTO CurrentStock (IngredientID,Quantity,EntryDate) VALUES('" + ingid.Trim() + "','" + (1000 * Convert.ToInt32(txtquantity.Text)) + "',getdate())";
                SqlDataAdapter obj88 = new SqlDataAdapter(querry1, cn);
                obj88.SelectCommand.ExecuteNonQuery();
                cn.Close();
            }
            else
            {
                MessageBox.Show("Stock error!!");
            }
            cnn.Close();

            deletefields();
        }
        private void btnadd_Click(object sender, EventArgs e)
        {
            if(compaymethod.Text.Trim()=="Payment Method" || compaytype.Text.Trim()=="Payment Status")
            {
                MessageBox.Show("Please select payment method or Payment Status");
                return;
            }
            try
            {
                SqlConnection cn = new SqlConnection(constr);
                cn.Open();
                string querry = "INSERT INTO ProductPurchase (BrandID,IngredientID,PurchasePrice,Quantity,Size,PurchaseDate) VALUES('" + brandid + "','" + ingid + "','" + txtprice.Text + "','" + txtquantity.Text + "','" + txtsize.Text + "',getdate())";
                SqlDataAdapter obj = new SqlDataAdapter(querry, cn);
                obj.SelectCommand.ExecuteNonQuery();
                cn.Close();
                /// inserting data to distributerpayment table using the max purchase id from productpurchase table
                // new Distributerpayment().Show();
                string val = "";
                SqlConnection cnn = new SqlConnection(constr);
                cnn.Open();
                string query = "Select max(PurchaseID) FROM   ProductPurchase";
                SqlCommand cmd = new SqlCommand(query, cnn);
                SqlDataReader obj1 = cmd.ExecuteReader();
                while (obj1.Read())
                {
                    val = obj1.GetValue(0).ToString();
                }
                cnn.Close();
                //////////////////////////////////////////////////
                string DPID = "";
                try
                {
                    cnn.Open();
                    string query1 = "Select DistributerPID FROM   DistributerPersonalDetail WHERE CNIC='" + CNIC + "'";
                    SqlCommand cmd1 = new SqlCommand(query1, cnn);
                    SqlDataReader obj11 = cmd1.ExecuteReader();
                    while (obj11.Read())
                    {
                        DPID = obj11.GetValue(0).ToString();
                    }
                    cnn.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Error Finding DistributerID ");
                }
                //////////////////////////////////////////////////
                SqlConnection cn3 = new SqlConnection(constr);
                cn3.Open();
                string querry3 = "INSERT INTO DistributerPayment (DistributerPID,PurchaseID,PaidAmount,RemaningAmount,PaymentMethod,PaymentType,EntryDate) VALUES('" + DPID + "','" + val + "','" + txtpaid.Text + "','" + txtremaning.Text + "','" + compaymethod.Text + "','" + compaytype.Text + "',getdate())";
                SqlDataAdapter obj3 = new SqlDataAdapter(querry3, cn3);
                obj3.SelectCommand.ExecuteNonQuery();
                cn3.Close();
                stock();
                PurchaseUC_Load(sender, e);
            }
            catch (Exception)
            {
                MessageBox.Show("Please Enter Correct Information");
                PurchaseUC_Load(sender, e);
            }
            
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            new PurchaseViewForm().Show();
        }

        private void txtquantity_OnValueChanged(object sender, EventArgs e)
        {
            try
            {

                double quant;
                double price;
                quant = Convert.ToDouble(txtquantity.Text);
                price = Convert.ToDouble(txtprice.Text);
                double paid = quant * price;
                ////////////////////////////////////////

                txtpaid.Text = Convert.ToString(paid);
                amt = txtpaid.Text;
                txtremaning.Text = "0.00";
            }
            catch (Exception)
            {

            }
        }

        private void compaytype_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void txtremaning_OnValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDouble(glob) < 0)
            {
                compaytype.Text = "Pending";
            }
            else if (Convert.ToDouble(glob) >= 0)
            {
                compaytype.Text = "Paid";
            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cn = new SqlConnection(constr);
                cn.Open();
                string querry = "SELECT IngredientID,IngredientName,IngredientPrice,Size FROM Ingredient WHERE IngredientID LIKE '%" + txtsearch.Text.Trim() + "%' OR IngredientName LIKE '%" + txtsearch.Text.Trim() + "%' OR IngredientPrice LIKE '%" + txtsearch.Text.Trim() + "%' OR Size LIKE '%" + txtsearch.Text.Trim() + "%'";
                SqlDataAdapter obj = new SqlDataAdapter(querry, cn);
                DataTable dt = new DataTable();
                obj.Fill(dt);
                guna2DataGridView1.DataSource = dt;
                cn.Close();
            }
            catch { }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cn = new SqlConnection(constr);
                cn.Open();
                string querry = "SELECT DBD.BrandID,DBD.BrandName,D.FirstName AS 'Supplier',D.CNIC FROM  DistributerPersonalDetail D INNER JOIN DistributerBrandDetail DBD ON D.DistributerPID=DBD.DistributerPID WHERE DBD.BrandID LIKE '%" + guna2TextBox1.Text.Trim() + "%' OR DBD.BrandName LIKE '%" + guna2TextBox1.Text.Trim() + "%'OR D.FirstName LIKE '%" + guna2TextBox1.Text.Trim() + "%' OR D.CNIC LIKE '%" + guna2TextBox1.Text.Trim() + "%'";
                SqlDataAdapter obj = new SqlDataAdapter(querry, cn);
                DataTable dt = new DataTable();
                obj.Fill(dt);
                guna2DataGridView2.DataSource = dt;
                cn.Close();
            }
            catch { }
        }

        private void txtpaid_OnValueChanged(object sender, EventArgs e)
        {
            try
            {
                double m, v;
                m = Convert.ToDouble(amt);
                v = Convert.ToDouble(txtpaid.Text) - m;
                glob = v;
                txtremaning.Text = Convert.ToString(v);
                if (txtpaid.Text.Contains(" "))
                {
                    MessageBox.Show("Please enter valid value");
                    txtpaid.Text = amt;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Enter correct value");
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            new Distributerpayment().Show();
        }

        private void guna2DataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            ingid = guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            lbling.Text = guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtprice.Text = guna2DataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txtsize.Text = guna2DataGridView1.SelectedRows[0].Cells[3].Value.ToString();
        }
    }
}
