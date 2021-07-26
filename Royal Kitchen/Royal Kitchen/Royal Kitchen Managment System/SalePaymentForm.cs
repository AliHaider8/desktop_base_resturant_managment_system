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
namespace Royal_Kitchen_Managment_System
{
    public partial class SalePaymentForm : Form
    {
        string cusorderid,totalamount;
        public string constr;
        void Fun()
        {
            Form1 obj = new Form1();
            constr = obj.con();
        }
        public SalePaymentForm(string coid,string total)
        {
            InitializeComponent();
            Fun();
            cusorderid = coid;
            totalamount = total;
            label1.Text = "Order# " +cusorderid;
            txtbrandname.Text = totalamount;
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if(comcnic.Text.Trim()== "Select Payment Medium")
            {
                MessageBox.Show("Please Select Payment Medium");
                return;
            }

            try
            {
                {
                    SqlConnection cn = new SqlConnection(constr);
                    cn.Open();
                    string querry = "INSERT INTO CustomerOrderPayment (CustomerOrderID,PaymentMedium,PaymentAmount,EntryDate) VALUES('" + cusorderid + "','" + comcnic.Text.Trim() + "','" + totalamount + "',getdate())";
                    SqlDataAdapter obj = new SqlDataAdapter(querry, cn);
                    obj.SelectCommand.ExecuteNonQuery();
                    cn.Close();
                }

                {
                    SqlConnection cn = new SqlConnection(constr);
                    cn.Open();
                    string querry = "update CustomerOrderBooking set TotalBill='" + txtbrandname.Text.Trim() + "'WHERE CustomerOrderID='" +cusorderid.Trim() + "'";
                    SqlDataAdapter obj1 = new SqlDataAdapter(querry, cn);
                    DataTable dt1 = new DataTable();
                    obj1.Fill(dt1);
                    cn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured Reason:( \n\n" + ex);
            }

            this.Close();
        }

        private void SalePaymentForm_Load(object sender, EventArgs e)
        {

        }
    }
}
