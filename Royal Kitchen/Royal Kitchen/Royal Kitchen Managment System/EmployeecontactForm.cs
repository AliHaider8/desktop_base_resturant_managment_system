using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace Royal_Kitchen_Managment_System
{
    public partial class EmployeecontactForm : Form
    {
        public string constr, ecid;
        void Fun()
        {
            Form1 obj = new Form1();
            constr = obj.con();
        }
        void deletefields()
        {
            txtaddress1.Text = null;
            txtcity.Text = null;
            txtcountry.Text = null;
            txtemail.Text = null;
            txtlandline.Text = null;
            txtphone1.Text = null;
            txtsearch.Text = null;
        }
        public EmployeecontactForm(string id)
        {
            InitializeComponent();
            Fun();
            comepid.Text = id;
        }

        private void EmployeecontactForm_Load(object sender, EventArgs e)
        {
            if(comepid.Text.Trim()=="Empty")
            {
                SqlConnection cn = new SqlConnection(constr);
                cn.Open();
                string querry = "SELECT * FROM EmployeeContactDetail";
                SqlDataAdapter obj = new SqlDataAdapter(querry, cn);
                DataTable dt = new DataTable();
                obj.Fill(dt);
                guna2DataGridView1.DataSource = dt;
                cn.Close();
            }
            else if (comepid.Text.Trim() != "Empty")
            {
                SqlConnection cn = new SqlConnection(constr);
                cn.Open();
                string querry = "SELECT * FROM EmployeeContactDetail WHERE EmployeePID='"+comepid.Text.Trim()+"'";
                SqlDataAdapter obj = new SqlDataAdapter(querry, cn);
                DataTable dt = new DataTable();
                obj.Fill(dt);
                guna2DataGridView1.DataSource = dt;
                cn.Close();
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
                SqlConnection cn = new SqlConnection(constr);
                cn.Open();
                string querry = "INSERT INTO EmployeeContactDetail (EmployeePID,Address,City,Country,PhoneNo,LandLineNo,Email,EntryDate) VALUES('" + comepid.Text + "','" + txtaddress1.Text.Trim() + "','" + txtcity.Text.Trim() + "','" + txtcountry.Text.Trim() + "','" + txtphone1.Text.Trim() + "','" + txtlandline.Text.Trim() + "','" + txtemail.Text.Trim() + "',getdate())";
                SqlDataAdapter obj = new SqlDataAdapter(querry, cn);
                obj.SelectCommand.ExecuteNonQuery();
                cn.Close();
                deletefields();
                EmployeecontactForm_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please Enter Correct Information reason :(\n\n" + ex);
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cn = new SqlConnection(constr);
                cn.Open();
                string querry = "update EmployeeContactDetail set Address='" + txtaddress1.Text.Trim() + "',City='" + txtcity.Text.Trim() + "',Country='" + txtcountry.Text.Trim() + "',PhoneNo='" + txtphone1.Text.Trim() + "',LandLineNo='" + txtlandline.Text.Trim() + "',Email='" + txtemail.Text.Trim() + "'WHERE EmployeeCID='" + ecid + "'";
                SqlDataAdapter obj1 = new SqlDataAdapter(querry, cn);
                DataTable dt1 = new DataTable();
                obj1.Fill(dt1);
                cn.Close();
                deletefields();
                EmployeecontactForm_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Update Module: \n" + ex);
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("All Contact info will be removed. Are you sure?", "Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    SqlConnection cn = new SqlConnection(constr);
                    cn.Open();
                    string querry = "Delete from EmployeeContactDetail WHERE EmployeeCID='" + ecid + "'";
                    SqlDataAdapter obj1 = new SqlDataAdapter(querry, cn);
                    DataTable dt1 = new DataTable();
                    obj1.Fill(dt1);
                    cn.Close();
                    deletefields();
                    EmployeecontactForm_Load(sender, e);
                }
                catch (Exception)
                {
                    MessageBox.Show("Please enter correct format");
                }
            }
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2DataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            ecid = guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            comepid.Text = guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtaddress1.Text = guna2DataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txtcity.Text = guna2DataGridView1.SelectedRows[0].Cells[3].Value.ToString(); ;
            txtcountry.Text = guna2DataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            txtphone1.Text = guna2DataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            txtlandline.Text = guna2DataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            txtemail.Text = guna2DataGridView1.SelectedRows[0].Cells[7].Value.ToString();
        }
    }
}
