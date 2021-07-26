using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
namespace Royal_Kitchen_Managment_System
{
    public partial class SaleUC : UserControl
    {
        int d = 1;
        int ex = 0;
        int error = 0;
        int i = 0;
        string[] foodid = new string[1000];
        string[] foodsizeid = new string[1000];
        double totalprice = 0.00;
        string proname, prosize, proprice, fid, fsid;
        string mid = "", maxid;
        public string constr, cusname;
        void Fun()
        {
            Form1 obj = new Form1();
            constr = obj.con();
        }
        void deletefields()
        {

        }
        public SaleUC()
        {
            InitializeComponent();
            Fun();
        }
        void food()
        {
            SqlConnection cn = new SqlConnection(constr);
            cn.Open();
            string querry = "Select F.FoodID,FS.FoodSizeID,F.FoodName,FS.FoodSize,FS.FoodPrice FROM Food F INNER JOIN FoodSize FS ON F.FoodID=FS.FoodID ORDER BY(F.FOODID)";
            SqlDataAdapter obj = new SqlDataAdapter(querry, cn);
            DataTable dt = new DataTable();
            obj.Fill(dt);
            guna2DataGridView2.DataSource = dt;
            cn.Close();
        }
        void offer()
        {
            SqlConnection cn = new SqlConnection(constr);
            cn.Open();
            string querry = "SELECT * FROM Customer";
            SqlDataAdapter obj = new SqlDataAdapter(querry, cn);
            DataTable dt = new DataTable();
            obj.Fill(dt);
            guna2DataGridView2.DataSource = dt;
            cn.Close();
        }
        void customer()
        {
            SqlConnection cn = new SqlConnection(constr);
            cn.Open();
            string querry = "SELECT CustomerID AS ID#,FirstName FROM Customer";
            SqlDataAdapter obj = new SqlDataAdapter(querry, cn);
            DataTable dt = new DataTable();
            obj.Fill(dt);
            guna2DataGridView1.DataSource = dt;
            cn.Close();
        }
        void employeeload()
        {
            SqlConnection cn = new SqlConnection(constr);
            cn.Open();
            string querry = "SELECT EmployeePID FROM EmployeePesonalDetail";
            SqlDataAdapter obj = new SqlDataAdapter(querry, cn);
            DataTable dt = new DataTable();
            obj.Fill(dt);
            comepid.DataSource = dt;
            cn.Close();
            comepid.Text = "EmployeePID";
        }
        void recipt()
        {
            richbox.Clear();
            richbox.Text += "Date: " + DateTime.Now;
            richbox.Text += "\n********************************************************\n";
            richbox.Text += "                  ***ROYAL KITCHEN***        \n";
        }
        private void SaleUC_Load(object sender, EventArgs e)
        {
            btnaddproduct.Enabled = false;
            btnconfirm.Enabled = false;
            txtaddress.Enabled = false;
            comdtime.Enabled = false;
            btncancel.Visible = false;
            btnprint.Visible = false;
            food();
            //     offer();
            customer();
            employeeload();
            recipt();
        }

        private void txtfirstname_OnValueChanged(object sender, EventArgs e)
        {
            richbox.Clear();
            richbox.Text += "Date: " + DateTime.Now;
            richbox.Text += "\n*******************************************************\n";
            richbox.Text += "                  ***ROYAL KITCHEN***        \n";
            richbox.Text += "*******************************************************\n";
            richbox.Text += "Name: " + txtfirstname.Text.ToUpper() + "\n";
            richbox.Text += "Cus# " + comcusid.Text;
        }

        private void btnputorder_Click(object sender, EventArgs e)
        {

            if(comepid.Text=="EmployeePID")
            {
                MessageBox.Show("Please select employee");
                return;
            }

            if (comsellmethod.Text == "Delivery")
            {
                if (txtaddress.Text == "" || comdtime.Text == "")
                {
                    MessageBox.Show("Please enter Delivery Info");
                    return;
                }
            }
            btncancel.Visible = true;
            SqlConnection cnn = new SqlConnection(constr);
            try
            {

                cnn.Open();

                if (comcusid.Text == "CustomerID")
                {
                    comcusid.Text = "0";
                }

                string querry = "select * from Customer where CustomerID='" + comcusid.Text.Trim() + "'and FirstName ='" + txtfirstname.Text.Trim() + "'";
                SqlDataAdapter obj = new SqlDataAdapter(querry, cnn);
                DataTable obj1 = new DataTable();
                obj.Fill(obj1);
                if (obj1.Rows.Count == 1)
                {
                    try
                    {
                        SqlConnection cn = new SqlConnection(constr);
                        cn.Open();
                        string querry2 = "INSERT INTO CustomerOrderBooking (CustomerID,EmployeePID,EntryDate) VALUES('" + comcusid.Text.Trim() + "','" + comepid.Text.Trim() + "',getdate())";
                        SqlDataAdapter obj2 = new SqlDataAdapter(querry2, cn);
                        obj2.SelectCommand.ExecuteNonQuery();
                        cn.Close();
                        deletefields();
                        btnaddproduct.Enabled = true;
                        btnputorder.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error at Customer Order Booking Insertion reason :(\n\n" + ex);
                        return;
                    }
                }
                else if (obj1.Rows.Count != 1)
                {
                    try
                    {
                        SqlConnection cn = new SqlConnection(constr);
                        cn.Open();
                        string querry3 = "INSERT INTO Customer (FirstName,LastName,CNIC,PhoneNo1,PhoneNo2,Email,Address,EntryDate) VALUES('" + txtfirstname.Text.Trim() + "','" + "Direct Sale" + "','" + "Direct Sale" + "','" + "Direct Sale" + "','" + "Direct Sale" + "','" + "Direct Sale" + "','" + "Direct Sale" + "',getdate())";
                        SqlDataAdapter obj3 = new SqlDataAdapter(querry3, cn);
                        obj3.SelectCommand.ExecuteNonQuery();

                        ///////////////////////////////////////////////////////
                        string id = "";
                        string query = "Select MAX(CustomerID) from Customer";
                        SqlCommand cmd = new SqlCommand(query, cn);
                        SqlDataReader obj4 = cmd.ExecuteReader();
                        while (obj4.Read())
                        {
                            id = obj4.GetValue(0).ToString();
                        }
                        cn.Close();

                        comcusid.Text = id.Trim();

                        try
                        {
                            SqlConnection cnnn = new SqlConnection(constr);
                            cnnn.Open();
                            string querry5 = "INSERT INTO CustomerOrderBooking (CustomerID,EmployeePID,EntryDate) VALUES('" + comcusid.Text.Trim() + "','" + comepid.Text.Trim() + "',getdate())";
                            SqlDataAdapter obj5 = new SqlDataAdapter(querry5, cnnn);
                            obj5.SelectCommand.ExecuteNonQuery();
                            cnnn.Close();

                            btnaddproduct.Enabled = true;
                            btnputorder.Enabled = false;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error at Customer Order Booking where customer record does'n exists   Insertion reason :(\n\n" + ex);
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error Occured at Customer Record Insertion reason :( \n\n" + ex);
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
                /////////////choose max id of customerorderdetails
                string query = "Select MAX(CustomerOrderID) from CustomerOrderBooking";
                SqlCommand cmd = new SqlCommand(query, cnn);
                SqlDataReader obj4 = cmd.ExecuteReader();
                while (obj4.Read())
                {
                    maxid = obj4.GetValue(0).ToString();
                }

                richbox.Clear();
                richbox.Text += "Date: " + DateTime.Now;
                richbox.Text += "\n*******************************************************\n";
                richbox.Text += "                  ***ROYAL KITCHEN***        \n";
                richbox.Text += "*******************************************************\n";
                richbox.Text += "Name: " + txtfirstname.Text.ToUpper() + "\n";
                richbox.Text += "Cus# " + comcusid.Text;
                richbox.Text += " | Emp# " + comepid.Text;
                richbox.Text += " | Order# " + maxid + "\n";
                ///////////////////////////////////////////////////////////
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured reason:(\n\n" + ex);
            }

            cnn.Close();


            {
                ///delivery 
                if (comsellmethod.Text == "Delivery")
                {
                    try
                    {
                        SqlConnection cnnn = new SqlConnection(constr);
                        cnnn.Open();
                        string querry5 = "INSERT INTO Delivery (EmployeePID,CustomerOrderID,DeliveryAddress,ExpectedTime,EntryDate) VALUES('" + comepid.Text.Trim() + "','" + maxid + "','" + txtaddress.Text.Trim() + "','" + comdtime.Text.Trim()+ "',getdate())";
                        SqlDataAdapter obj5 = new SqlDataAdapter(querry5, cnnn);
                        obj5.SelectCommand.ExecuteNonQuery();
                        cnnn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error storing delivery data reason :(\n\n" + ex);
                    }
                }
            }
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        void Stock()
        {
            SqlConnection cnn = new SqlConnection(constr);
            for (int x = 0; x < i; x++)
            {
                string a, b;
                a = foodid[x];
                b = foodsizeid[x];

                string min = "";
                string max = "";
                {
                    cnn.Open();
                    string query = "select min(FoodIngredientID),max(FoodIngredientID) FROM FoodIngredient WHERE FoodID='" + a + "'AND FoodSizeID='" + b + "'";
                    SqlCommand cmd = new SqlCommand(query, cnn);
                    SqlDataReader obj = cmd.ExecuteReader();
                    while (obj.Read())
                    {
                        min = obj.GetValue(0).ToString();
                        max = obj.GetValue(1).ToString();
                    }
                    cnn.Close();
                }

                try
                {
                    for (int j = Convert.ToInt32(min); j <= Convert.ToInt32(max); j++)
                    {
                        string ingid = "", quant = "", size = "";
                        {
                            cnn.Open();
                            string query = "select IngredientID,Quantity,Size FROM FoodIngredient WHERE FoodIngredientID='" + j + "'";
                            SqlCommand cmd = new SqlCommand(query, cnn);
                            SqlDataReader obj = cmd.ExecuteReader();
                            while (obj.Read())
                            {
                                ingid = obj.GetValue(0).ToString();
                                quant = obj.GetValue(1).ToString();
                                size = obj.GetValue(2).ToString();
                            }
                            cnn.Close();
                        }

                        string actulq = "";
                        {
                            cnn.Open();
                            string query1 = "select Quantity FROM CurrentStock WHERE IngredientID='" + ingid + "'";
                            SqlCommand cmd1 = new SqlCommand(query1, cnn);
                            SqlDataReader obj1 = cmd1.ExecuteReader();
                            while (obj1.Read())
                            {
                                actulq = obj1.GetValue(0).ToString();
                            }
                            cnn.Close();
                        }
                        try
                        {
                            int q = Convert.ToInt32(actulq);
                            int qq = Convert.ToInt32(quant);
                            if (size.Trim() == "KG")
                            {
                                qq = qq * 1000;
                            }
                            q -= qq;

                            try
                            {
                                SqlConnection cn = new SqlConnection(constr);
                                cn.Open();
                                string querry = "update CurrentStock set Quantity='" + q + "'WHERE IngredientID='" + ingid + "'";
                                SqlDataAdapter obj4 = new SqlDataAdapter(querry, cn);
                                DataTable dt1 = new DataTable();
                                obj4.Fill(dt1);
                                cn.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error at updating current stock\n\n" + ex);

                                error = 1;
                            }
                        }
                        catch { }
                    }
                }
               catch (Exception)
                {
                    MessageBox.Show("Ingredients are not present in stock in enough quantity");
                    error = 2;
                }
            }
        }
        void reset()
        {
            txtfirstname.Text = null;
            comepid.Text = "EmployeeID";
            comquantity.Text = "Quantity";
            recipt();
            lbltotal.Text = "Total : 0.00";
            totalprice = 0;
            btnaddproduct.Enabled = false;
            btnconfirm.Enabled = false;
            btncancel.Visible = false;
            btnputorder.Enabled = true;
            comsellmethod.Text = "Dinning";
            txtaddress.Text = null;
            txtaddress.Enabled = false;
            comdtime.Text = "Expected Time";
            comdtime.Enabled = false;
            comcusid.Text="CustomerID";
        }
        private void btncancel_Click(object sender, EventArgs e)
        {

            if(btnprint.Visible==true)
            {
                reset();
                btncancel.Visible = false;
                btnprint.Visible = false;
                return; 
            }

            if (MessageBox.Show("Cancel Order are you sure?", "Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                txtfirstname.Text = null;
                
                comepid.Text = "EmployeeID";
                comquantity.Text = "Quantity";
                recipt();
                lbltotal.Text = "Total : 0.00";
                totalprice = 0;
                btnaddproduct.Enabled = false;
                btnconfirm.Enabled = false;
                btncancel.Visible = false;
                btnputorder.Enabled = true;
                comsellmethod.Text = "Dinning";
                txtaddress.Text = null;
                txtaddress.Enabled = false;
                comdtime.Text = "Expected Time";
                comdtime.Enabled = false;
                try
                {
                    {
                        SqlConnection cn = new SqlConnection(constr);
                        cn.Open();
                        string querry = "Delete from CustomerOrderDetail WHERE CustomerOrderID='" + maxid + "'";
                        SqlDataAdapter obj1 = new SqlDataAdapter(querry, cn);
                        DataTable dt1 = new DataTable();
                        obj1.Fill(dt1);
                        cn.Close();
                    }

                    {
                        SqlConnection cn = new SqlConnection(constr);
                        cn.Open();
                        string querry = "Delete from Delivery WHERE CustomerOrderID='" + maxid + "'";
                        SqlDataAdapter obj1 = new SqlDataAdapter(querry, cn);
                        DataTable dt1 = new DataTable();
                        obj1.Fill(dt1);
                        cn.Close();
                    }

                    {
                        SqlConnection cn = new SqlConnection(constr);
                        cn.Open();
                        string querry = "Delete from CustomerOrderBooking WHERE CustomerOrderID='" + maxid + "'";
                        SqlDataAdapter obj1 = new SqlDataAdapter(querry, cn);
                        DataTable dt1 = new DataTable();
                        obj1.Fill(dt1);
                        cn.Close();
                    }
                    try
                    {
                        SqlConnection cn = new SqlConnection(constr);
                        cn.Open();
                        string querry = "Delete from Customer WHERE CustomerID='" + comcusid.Text.Trim() + "'";
                        SqlDataAdapter obj1 = new SqlDataAdapter(querry, cn);
                        DataTable dt1 = new DataTable();
                        obj1.Fill(dt1);
                        cn.Close();
                    }
                    catch(Exception)
                    {
                        //pass
                    }

                    comcusid.Text = "CustomerID";
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error cancelling order Module reason :( \n\n" + ex);
                }
            }
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
                printDocument1.Print();

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(richbox.Text, new Font("Century Gothic", 12, FontStyle.Regular), Brushes.Black, new Point(0, 0));
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            new SaleViewForm().Show();
        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cn = new SqlConnection(constr);
                cn.Open();
                string querry = "Select F.FoodID,FS.FoodSizeID,F.FoodName,FS.FoodSize,FS.FoodPrice FROM Food F INNER JOIN FoodSize FS ON F.FoodID=FS.FoodID WHERE  FS.FoodPrice LIKE '%" + txtsearchfood.Text.Trim() + "%' OR FS.FoodSize LIKE '%" + txtsearchfood.Text.Trim() + "%' OR F.FoodName LIKE '%" + txtsearchfood.Text.Trim() + "%' OR F.FoodType LIKE '%" + txtsearchfood.Text.Trim() + "%' OR F.FoodID LIKE '%" + txtsearchfood.Text.Trim() + "%' ORDER BY(F.FOODID)";
                SqlDataAdapter obj = new SqlDataAdapter(querry, cn);
                DataTable dt = new DataTable();
                obj.Fill(dt);
                guna2DataGridView2.DataSource = dt;
                cn.Close();
            }
            catch { }
        }

        private void bunifuMaterialTextbox2_OnValueChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cn = new SqlConnection(constr);
                cn.Open();
                string querry = "SELECT C.CustomerID AS ID#,C.FirstName FROM Customer C WHERE  C.FirstName LIKE '%" + txtcustomer.Text.Trim() + "%' OR C.CNIC LIKE '%" + txtcustomer.Text.Trim() + "%' OR C.PhoneNo1 LIKE '%" + txtcustomer.Text.Trim() + "%' OR C.CustomerID LIKE '%" + txtcustomer.Text.Trim() + "%'";
                SqlDataAdapter obj = new SqlDataAdapter(querry, cn);
                DataTable dt = new DataTable();
                obj.Fill(dt);
                guna2DataGridView1.DataSource = dt;
                cn.Close();
            }
           catch { }
        }

        private void btnconfirm_Click(object sender, EventArgs e)
        {
            Stock();

            if(error>0)
            {
                return;
            }
            new SalePaymentForm(mid,totalprice.ToString()).Show();

            richbox.Text += "*******************************************************\n";
            richbox.Text += "Total Bill: " + totalprice.ToString() + "\n";
            richbox.Text += "*******************************************************\n";
            richbox.Text += "------------------------------------------------------------------\n";
            richbox.Text += "Thanks For Your Visit.....!!\n";
            richbox.Text += "------------------------------------------------------------------\n";
            richbox.Text += "Developer info:\n";
            richbox.Text += "waqaskhaliddogar420@gmail.com\n";
            richbox.Text += "------------------------------------------------------------------\n";

            btnprint.Visible = true;
            btnconfirm.Enabled = false;
            btnaddproduct.Enabled = false;
        }

        private void comsellmethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comsellmethod.Text == "Dining")
            {
                txtaddress.Enabled = false;
                comdtime.Enabled = false;
            }
            else if (comsellmethod.Text == "Delivery")
            {
                txtaddress.Enabled = true;
                comdtime.Enabled = true;
            }
        }

        private void comepid_SelectedIndexChanged(object sender, EventArgs e)
        {
            richbox.Clear();
            richbox.Text += "Date: " + DateTime.Now;
            richbox.Text += "\n*******************************************************\n";
            richbox.Text += "                  ***ROYAL KITCHEN***        \n";
            richbox.Text += "*******************************************************\n";
            richbox.Text += "Name: " + txtfirstname.Text.ToUpper() + "\n";
            richbox.Text += "Cus# " + comcusid.Text + "|";
            richbox.Text += "Emp# " + comepid.Text + "|";
        }
        void productchk()
        {
                SqlConnection cnn = new SqlConnection(constr);
                {
                    string min = "";
                    string max = "";
                    {
                        cnn.Open();
                        string query = "select min(FoodIngredientID),max(FoodIngredientID) FROM FoodIngredient WHERE FoodID='" + fid + "'AND FoodSizeID='" + fsid + "'";
                        SqlCommand cmd = new SqlCommand(query, cnn);
                        SqlDataReader obj = cmd.ExecuteReader();
                        while (obj.Read())
                        {
                            min = obj.GetValue(0).ToString();
                            max = obj.GetValue(1).ToString();
                        }
                        cnn.Close();
                    }

                    {
                        for (int j = Convert.ToInt32(min); j <= Convert.ToInt32(max); j++)
                        {
                        string ingid = "", quant = "";
                            {
                                cnn.Open();
                                string query = "select IngredientID,Quantity,Size FROM FoodIngredient WHERE FoodIngredientID='" + j + "'";
                                SqlCommand cmd = new SqlCommand(query, cnn);
                                SqlDataReader obj = cmd.ExecuteReader();
                                while (obj.Read())
                                {
                                    ingid = obj.GetValue(0).ToString();
                                    quant = obj.GetValue(1).ToString();
                                }
                                cnn.Close();
                            }

                            string actulq = "";
                            {
                                cnn.Open();
                                string query1 = "select Quantity FROM CurrentStock WHERE IngredientID='" + ingid + "'";
                                SqlCommand cmd1 = new SqlCommand(query1, cnn);
                                SqlDataReader obj1 = cmd1.ExecuteReader();
                                while (obj1.Read())
                                {
                                    actulq = obj1.GetValue(0).ToString();
                                }
                                cnn.Close();
                            }
                        try
                        {
                            if(Convert.ToInt32( actulq)<Convert.ToInt32(quant))
                            {
                                MessageBox.Show("Ingredients are not avalible");
                                ex = 1;

                            }
                        }
                        catch
                        {

                        }

                        }
                    }
                }
        }
        private void btnaddproduct_Click(object sender, EventArgs e)
        {
            if(d>8)
            {
                MessageBox.Show("Please make new Order recipt is full");
                return;
            }
            d++;
            productchk();
            if (ex>0)
            {
                ex = 0;
                return;
            }
            //////////////////storing food and food size id in array///////////////
            foodid[i] = fid;
            foodsizeid[i] = fsid;
            i++;
            ////////////////////////////////////////////////////////////////////////
            try
            {
                {
                    SqlConnection cn = new SqlConnection(constr);
                    cn.Open();
                    string query = "Select MAX(CustomerOrderID) from CustomerOrderBooking";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    SqlDataReader obj4 = cmd.ExecuteReader();
                    while (obj4.Read())
                    {
                        mid = obj4.GetValue(0).ToString();
                    }
                    cn.Close();
                }
                /////////////////////////////////////////////////////////////////////
                {
                    SqlConnection cn = new SqlConnection(constr);
                    cn.Open();
                    string querry3 = "INSERT INTO CustomerOrderDetail (CustomerOrderID,ProductName,ProductSize,ProductQuantity,SalePrice,EntryDate) VALUES('" + mid.Trim() + "','" + proname.Trim() + "','" + prosize.Trim() + "','" + comquantity.Text.Trim() + "','" + proprice.Trim() + "',getdate())";
                    SqlDataAdapter obj3 = new SqlDataAdapter(querry3, cn);
                    obj3.SelectCommand.ExecuteNonQuery();
                }
                ///////////////////////////////////////////////////////////////////////
                richbox.Text += "------------------------------------------------------------------\n";
                richbox.Text += "Item   : " + proname + "\n";
                richbox.Text += "Price   : " + proprice + "\n";
                richbox.Text += "Qty     : " + comquantity.Text + "\n";
                richbox.Text += "Size     : " + prosize + "\n";
                ////////////////////////////////////////////////////////////////////////
                totalprice += Convert.ToDouble(comquantity.Text) * Convert.ToDouble(proprice);
                lbltotal.Text = "Total : " + Convert.ToString(totalprice);
                ////////////////////////////////////////////////////////////////////////
                
                btnconfirm.Enabled = true;
                ///////////////////////////////////////////////////////////////////////
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured Reason : \n\n" + ex);
            }

        }

        private void guna2DataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            fid = guna2DataGridView2.SelectedRows[0].Cells[0].Value.ToString();
            fsid = guna2DataGridView2.SelectedRows[0].Cells[1].Value.ToString();
            proname = guna2DataGridView2.SelectedRows[0].Cells[2].Value.ToString();
            prosize = guna2DataGridView2.SelectedRows[0].Cells[3].Value.ToString();
            proprice = guna2DataGridView2.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void guna2DataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            comcusid.Text = guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtfirstname.Text = guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
        }
    } 
}
