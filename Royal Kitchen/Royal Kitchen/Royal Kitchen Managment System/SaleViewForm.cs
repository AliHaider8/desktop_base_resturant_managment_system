using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DGVPrinterHelper;

namespace Royal_Kitchen_Managment_System
{
    public partial class SaleViewForm : Form
    {
        public string constr;
        void Fun()
        {
            Form1 obj = new Form1();
            constr = obj.con();
        }
        void deletefields()
        {

        }
        public SaleViewForm()
        {
            InitializeComponent();
            Fun();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaleViewForm_Load(object sender, EventArgs e)
        {
            {
                SqlConnection cn = new SqlConnection(constr);
                cn.Open();
                string querry = "SELECT  COB.CustomerOrderID AS ODR#,Cob.EmployeePID,COB.CustomerID,EPD.FirstName AS 'Emp Name',C.FirstName AS 'Cust Name',COB.TotalBill,COB.EntryDate AS Date FROM CustomerOrderBooking COB INNER JOIN Customer C ON C.CustomerID=COB.CustomerID INNER JOIN  EmployeePesonalDetail EPD ON EPD.EmployeePID=COB.EmployeePID";
                SqlDataAdapter obj = new SqlDataAdapter(querry, cn);
                DataTable dt = new DataTable();
                obj.Fill(dt);
                guna2DataGridView1.DataSource = dt;
                cn.Close();
            }

            {
                lblsale.Text = "Total Sale :";
                string val="";
                SqlConnection cnn = new SqlConnection(constr);
                cnn.Open();
                string query = "SELECT  SUM(COB.TotalBill) FROM CustomerOrderBooking COB INNER JOIN Customer C ON C.CustomerID=COB.CustomerID INNER JOIN  EmployeePesonalDetail EPD ON EPD.EmployeePID=COB.EmployeePID";
                SqlCommand cmd = new SqlCommand(query, cnn);
                SqlDataReader obj = cmd.ExecuteReader();
                while (obj.Read())
                {
                    val = obj.GetValue(0).ToString();
                }
                lblsale.Text += val;
                cnn.Close();
            }
        }

        private void comepid_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comepid.Text.Trim()=="Order's")
            {
                {
                    SqlConnection cn = new SqlConnection(constr);
                    cn.Open();
                    string querry = "SELECT  COB.CustomerOrderID AS ODR#,Cob.EmployeePID,COB.CustomerID,EPD.FirstName AS 'Emp Name',C.FirstName AS 'Cust Name',COB.TotalBill,COB.EntryDate AS Date FROM CustomerOrderBooking COB INNER JOIN Customer C ON C.CustomerID=COB.CustomerID INNER JOIN  EmployeePesonalDetail EPD ON EPD.EmployeePID=COB.EmployeePID";
                    SqlDataAdapter obj = new SqlDataAdapter(querry, cn);
                    DataTable dt = new DataTable();
                    obj.Fill(dt);
                    guna2DataGridView1.DataSource = dt;
                    cn.Close();
                }
                {
                    lblsale.Text = "Total Sale :";
                    string val = "";
                    SqlConnection cnn = new SqlConnection(constr);
                    cnn.Open();
                    string query = "SELECT  SUM(COB.TotalBill) FROM CustomerOrderBooking COB INNER JOIN Customer C ON C.CustomerID=COB.CustomerID INNER JOIN  EmployeePesonalDetail EPD ON EPD.EmployeePID=COB.EmployeePID";
                    SqlCommand cmd = new SqlCommand(query, cnn);
                    SqlDataReader obj = cmd.ExecuteReader();
                    while (obj.Read())
                    {
                        val = obj.GetValue(0).ToString();
                    }
                    lblsale.Text += val;
                    cnn.Close();
                }
            }
            else if(comepid.Text.Trim()=="Payment")
            {
                {
                    SqlConnection cn = new SqlConnection(constr);
                    cn.Open();
                    string querry = "SELECT  COB.CustomerOrderID AS ODR#,COB.CustomerID,C.FirstName AS 'Cust Name',COP.PaymentMedium,COP.PaymentAmount AS Paid,COP.EntryDate AS Date FROM CustomerOrderBooking COB INNER JOIN Customer C ON C.CustomerID=COB.CustomerID INNER JOIN CustomerOrderPayment COP ON COP.CustomerOrderID=COB.CustomerOrderID";
                    SqlDataAdapter obj = new SqlDataAdapter(querry, cn);
                    DataTable dt = new DataTable();
                    obj.Fill(dt);
                    guna2DataGridView1.DataSource = dt;
                    cn.Close();
                }
                {
                    lblsale.Text = "Total Paid:";
                    string val = "";
                    SqlConnection cn = new SqlConnection(constr);
                    cn.Open();
                    string querry = "SELECT  SUM(COP.PaymentAmount) FROM CustomerOrderBooking COB INNER JOIN Customer C ON C.CustomerID=COB.CustomerID INNER JOIN CustomerOrderPayment COP ON COP.CustomerOrderID=COB.CustomerOrderID";
                    SqlCommand cmd = new SqlCommand(querry, cn);
                    SqlDataReader obj = cmd.ExecuteReader();
                    while (obj.Read())
                    {
                        val = obj.GetValue(0).ToString();
                    }
                    lblsale.Text += val;
                    cn.Close();
                }
            }
            else if(comepid.Text.Trim()=="Delivery")
            {
                SqlConnection cn = new SqlConnection(constr);
                cn.Open();
                string querry = "SELECT COB.CustomerOrderID AS ODR#,D.EmployeePID,EPD.FirstName AS EmpName,COB.CustomerID,C.FirstName AS CustName,D.DeliveryAddress,D.ExpectedTime,D.EntryDate AS Date FROM CustomerOrderBooking COB INNER JOIN Customer C ON C.CustomerID=COB.CustomerID INNER JOIN Delivery D ON D.CustomerOrderID=COB.CustomerOrderID INNER JOIN EmployeePesonalDetail EPD ON EPD.EmployeePID=D.EmployeePID";
                SqlDataAdapter obj = new SqlDataAdapter(querry, cn);
                DataTable dt = new DataTable();
                obj.Fill(dt);
                guna2DataGridView1.DataSource = dt;
                cn.Close();
            }
            else if(comepid.Text.Trim() == "Product")
            {
                SqlConnection cn = new SqlConnection(constr);
                cn.Open();
                string querry = "SELECT COB.CustomerOrderID AS ODR#,COD.ProductName,COD.ProductSize,COD.ProductQuantity AS QTY,COD.SalePrice*COD.ProductQuantity AS Price,COD.EntryDate AS Date FROM CustomerOrderBooking COB INNER JOIN CustomerOrderDetail COD ON COD.CustomerOrderID=COB.CustomerOrderID";
                SqlDataAdapter obj = new SqlDataAdapter(querry, cn);
                DataTable dt = new DataTable();
                obj.Fill(dt);
                guna2DataGridView1.DataSource = dt;
                cn.Close();
            }
        }

        private void btnreport_Click(object sender, EventArgs e)
        {
            string str="Order's";
            if (comepid.Text.Trim() == "Order's")
            {
                str = "Order's Detail";
            }
            else if (comepid.Text.Trim() == "Payment")
            {
                str = "Order Payments";
            }
            else if (comepid.Text.Trim() == "Delivery")
            {
                str = "Delivery Orders";
            }
            else if (comepid.Text.Trim() == "Product")
            {
                str = "Order Products";
            }
            DGVPrinter printer = new DGVPrinter();
            printer.Title = str+ " Report"; //give your report name
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            if (comepid.Text.Trim() == "Order's")
            {
                {
                    SqlConnection cn = new SqlConnection(constr);
                    cn.Open();
                    string querry = "SELECT  COB.CustomerOrderID AS ODR#,Cob.EmployeePID,COB.CustomerID,EPD.FirstName AS 'Emp Name',C.FirstName AS 'Cust Name',COB.TotalBill,COB.EntryDate AS Date FROM CustomerOrderBooking COB INNER JOIN Customer C ON C.CustomerID=COB.CustomerID INNER JOIN  EmployeePesonalDetail EPD ON EPD.EmployeePID=COB.EmployeePID WHERE COB.CustomerOrderID LIKE '%" + txtsearch.Text.Trim() + "%'";
                    SqlDataAdapter obj = new SqlDataAdapter(querry, cn);
                    DataTable dt = new DataTable();
                    obj.Fill(dt);
                    guna2DataGridView1.DataSource = dt;
                    cn.Close();
                }
                {
                    lblsale.Text = "Total Sale :";
                    string val = "";
                    SqlConnection cnn = new SqlConnection(constr);
                    cnn.Open();
                    string query = "SELECT  SUM(COB.TotalBill) FROM CustomerOrderBooking COB INNER JOIN Customer C ON C.CustomerID=COB.CustomerID INNER JOIN  EmployeePesonalDetail EPD ON EPD.EmployeePID=COB.EmployeePID WHERE COB.CustomerOrderID LIKE '%" + txtsearch.Text.Trim() + "%'";
                    SqlCommand cmd = new SqlCommand(query, cnn);
                    SqlDataReader obj = cmd.ExecuteReader();
                    while (obj.Read())
                    {
                        val = obj.GetValue(0).ToString();
                    }
                    lblsale.Text += val;
                    cnn.Close();
                }
            }
            else if (comepid.Text.Trim() == "Payment")
            {
                {
                    SqlConnection cn = new SqlConnection(constr);
                    cn.Open();
                    string querry = "SELECT  COB.CustomerOrderID AS ODR#,COB.CustomerID,C.FirstName AS 'Cust Name',COP.PaymentMedium,COP.PaymentAmount AS Paid,COP.EntryDate AS Date FROM CustomerOrderBooking COB INNER JOIN Customer C ON C.CustomerID=COB.CustomerID INNER JOIN CustomerOrderPayment COP ON COP.CustomerOrderID=COB.CustomerOrderID WHERE COB.CustomerOrderID LIKE '%" + txtsearch.Text.Trim() + "%'";
                    SqlDataAdapter obj = new SqlDataAdapter(querry, cn);
                    DataTable dt = new DataTable();
                    obj.Fill(dt);
                    guna2DataGridView1.DataSource = dt;
                    cn.Close();
                }
                {
                    lblsale.Text = "Total Paid:";
                    string val = "";
                    SqlConnection cn = new SqlConnection(constr);
                    cn.Open();
                    string querry = "SELECT  SUM(COP.PaymentAmount) FROM CustomerOrderBooking COB INNER JOIN Customer C ON C.CustomerID=COB.CustomerID INNER JOIN CustomerOrderPayment COP ON COP.CustomerOrderID=COB.CustomerOrderID WHERE COB.CustomerOrderID LIKE '%" + txtsearch.Text.Trim() + "%'";
                    SqlCommand cmd = new SqlCommand(querry, cn);
                    SqlDataReader obj = cmd.ExecuteReader();
                    while (obj.Read())
                    {
                        val = obj.GetValue(0).ToString();
                    }
                    lblsale.Text += val;
                    cn.Close();
                }
            }
            else if (comepid.Text.Trim() == "Delivery")
            {
                SqlConnection cn = new SqlConnection(constr);
                cn.Open();
                string querry = "SELECT COB.CustomerOrderID AS ODR#,D.EmployeePID,EPD.FirstName AS EmpName,COB.CustomerID,C.FirstName AS CustName,D.DeliveryAddress,D.ExpectedTime,D.EntryDate AS Date FROM CustomerOrderBooking COB INNER JOIN Customer C ON C.CustomerID=COB.CustomerID INNER JOIN Delivery D ON D.CustomerOrderID=COB.CustomerOrderID INNER JOIN EmployeePesonalDetail EPD ON EPD.EmployeePID=D.EmployeePID WHERE COB.CustomerOrderID LIKE '%" + txtsearch.Text.Trim() + "%'";
                SqlDataAdapter obj = new SqlDataAdapter(querry, cn);
                DataTable dt = new DataTable();
                obj.Fill(dt);
                guna2DataGridView1.DataSource = dt;
                cn.Close();
            }
            else if (comepid.Text.Trim() == "Product")
            {
                SqlConnection cn = new SqlConnection(constr);
                cn.Open();
                string querry = "SELECT COB.CustomerOrderID AS ODR#,COD.ProductName,COD.ProductSize,COD.ProductQuantity AS QTY,COD.SalePrice*COD.ProductQuantity AS Price,COD.EntryDate AS Date FROM CustomerOrderBooking COB INNER JOIN CustomerOrderDetail COD ON COD.CustomerOrderID=COB.CustomerOrderID WHERE COB.CustomerOrderID LIKE '%" + txtsearch.Text.Trim() + "%'";
                SqlDataAdapter obj = new SqlDataAdapter(querry, cn);
                DataTable dt = new DataTable();
                obj.Fill(dt);
                guna2DataGridView1.DataSource = dt;
                cn.Close();
            }
        }
    }
}
