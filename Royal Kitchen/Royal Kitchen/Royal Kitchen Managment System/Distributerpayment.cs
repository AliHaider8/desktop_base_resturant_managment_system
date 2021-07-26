using DGVPrinterHelper;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
namespace Royal_Kitchen_Managment_System
{
    public partial class Distributerpayment : Form
    {
        string total, paid, pending, type, date, DPID, PID;
        public string constr;
        void Fun()
        {
            Form1 obj = new Form1();
            constr = obj.con();
        }
        public Distributerpayment()
        {
            InitializeComponent();
            Fun();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cn = new SqlConnection(constr);
                cn.Open();
                string querry = "SELECT DP.DistributerPID AS DistributerID,DP.PurchaseID,(PP.Quantity*PP.PurchasePrice) AS Total, DP.PaidAmount,DP.RemaningAmount,DP.PaymentMethod,DP.PaymentType AS Status,DP.EntryDate AS Date FROM   DistributerPayment DP INNER JOIN ProductPurchase PP ON PP.PurchaseID=DP.PurchaseID WHERE DP.DistributerPID LIKE '%" + txtsearch.Text.Trim() + "%' OR DP.PurchaseID LIKE '%" + txtsearch.Text.Trim() + "%' OR (PP.Quantity*PP.PurchasePrice) LIKE '%" + txtsearch.Text.Trim() + "%' OR DP.PaidAmount LIKE '%" + txtsearch.Text.Trim() + "%'OR DP.RemaningAmount LIKE '%" + txtsearch.Text.Trim() + "%' OR DP.PaymentMethod LIKE '%" + txtsearch.Text.Trim() + "%' OR DP.PaymentType LIKE '%" + txtsearch.Text.Trim() + "%'";
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
                string query = "Select Count(DP.DistributerPID) FROM DistributerPayment DP INNER JOIN ProductPurchase PP ON PP.PurchaseID=DP.PurchaseID WHERE DP.DistributerPID LIKE '%" + txtsearch.Text.Trim() + "%' OR DP.PurchaseID LIKE '%" + txtsearch.Text.Trim() + "%' OR (PP.Quantity*PP.PurchasePrice) LIKE '%" + txtsearch.Text.Trim() + "%' OR DP.PaidAmount LIKE '%" + txtsearch.Text.Trim() + "%'OR DP.RemaningAmount LIKE '%" + txtsearch.Text.Trim() + "%' OR DP.PaymentMethod LIKE '%" + txtsearch.Text.Trim() + "%' OR DP.PaymentType LIKE '%" + txtsearch.Text.Trim() + "%'";
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
            printer.Title = "Payments Report"; //give your report name
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

        private void Distributerpayment_Load(object sender, EventArgs e)
        {
            {
                SqlConnection cn = new SqlConnection(constr);
                cn.Open();
                string querry = "SELECT DP.DistributerPID AS DistributerID,DP.PurchaseID,(PP.Quantity*PP.PurchasePrice) AS Total, DP.PaidAmount,DP.RemaningAmount,DP.PaymentMethod,DP.PaymentType AS Status,DP.EntryDate AS Date FROM   DistributerPayment DP INNER JOIN ProductPurchase PP ON PP.PurchaseID=DP.PurchaseID";
                SqlDataAdapter obj = new SqlDataAdapter(querry, cn);
                DataTable dt = new DataTable();
                obj.Fill(dt);
                guna2DataGridView1.DataSource = dt;
                cn.Close();
            }
            {
                SqlConnection cnn = new SqlConnection(constr);
                cnn.Open();
                string query = "Select count(DP.DistributerPID) FROM   DistributerPayment DP INNER JOIN ProductPurchase PP ON PP.PurchaseID=DP.PurchaseID";
                SqlCommand cmd = new SqlCommand(query, cnn);
                SqlDataReader obj = cmd.ExecuteReader();
                while (obj.Read())
                {
                    lblrecord.Text = obj.GetValue(0).ToString();
                }
                cnn.Close();
            }
        }

        private void txtpending_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void txtpaid_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            DPID = guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            PID = guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            date = guna2DataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            total = guna2DataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            paid = guna2DataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            pending = guna2DataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            txtpaid.Text = paid;
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                double p = Convert.ToDouble(txtpaid.Text);
                if (p > Convert.ToDouble(total) || p <= Convert.ToDouble(paid))
                {
                    MessageBox.Show("Error Update Value not correctly entered");
                    return;
                }

                if (p == Convert.ToDouble(total))
                {
                    pending = "0.00";
                    type = "Paid";
                }
                else
                {
                    double v;
                    v = Convert.ToDouble(total) - Convert.ToDouble(txtpaid.Text);
                    pending = Convert.ToString(v);
                    type = "Pending";
                }

                try
                {
                    SqlConnection cn = new SqlConnection(constr);
                    cn.Open();
                    string querry = "update DistributerPayment set PaidAmount='" + txtpaid.Text + "',RemaningAmount='" + pending + "',PaymentType='" + type + "'WHERE PurchaseID='" + PID + "' AND DistributerPID='" + DPID + "'";
                    SqlDataAdapter obj1 = new SqlDataAdapter(querry, cn);
                    DataTable dt1 = new DataTable();
                    obj1.Fill(dt1);
                    cn.Close();
                    new Distributerpayment().Show();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Update Module: \n" + ex);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter correct value: \n\n " + ex);
            }
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
