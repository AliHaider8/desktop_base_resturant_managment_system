using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace Royal_Kitchen_Managment_System
{
    public partial class ManagerUC : UserControl
    {
        public string constr, LOGID;
        void Fun()
        {
            Form1 obj = new Form1();
            constr = obj.con();
        }
        public ManagerUC()
        {
            InitializeComponent();
            Fun();
            txtpasscon.isPassword = true;
        }
        void login()
        {
            {
                SqlConnection cn = new SqlConnection(constr);
                cn.Open();
                string querry = "SELECT LoginID AS ID#,Username,Email,EntryDate FROM Login";
                SqlDataAdapter obj = new SqlDataAdapter(querry, cn);
                DataTable dt = new DataTable();
                obj.Fill(dt);
                guna2DataGridView1.DataSource = dt;
                cn.Close();
            }
                {
                    SqlConnection cnn = new SqlConnection(constr);
                    cnn.Open();
                    string query = "Select count(LoginID) FROM Login ";
                    SqlCommand cmd = new SqlCommand(query, cnn);
                    SqlDataReader obj = cmd.ExecuteReader();
                    while (obj.Read())
                    {
                        lblrecord.Text = obj.GetValue(0).ToString();
                    }
                    cnn.Close();
                }
        }
        void logindetail()
        {
            {
                SqlConnection cn = new SqlConnection(constr);
                cn.Open();
                string querry = "SELECT LoginDetailID AS ID#,Username,Email,LoginTime FROM LoginDetail";
                SqlDataAdapter obj = new SqlDataAdapter(querry, cn);
                DataTable dt = new DataTable();
                obj.Fill(dt);
                guna2DataGridView1.DataSource = dt;
                cn.Close();
                btnback.Visible = true;
            }
            {
                {
                    SqlConnection cnn = new SqlConnection(constr);
                    cnn.Open();
                    string query = "Select count(LoginDetailID) FROM LoginDetail";
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
        private void ManagerUC_Load(object sender, EventArgs e)
        {
            btnback.Visible = false;
            login();

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            logindetail();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            btnback.Visible = false;
            login();
        }
        void deletefields()
        {
            txtemail.Text = null;
            txtpass.Text = null;
            txtpasscon.Text = null;
            txtuser.Text = null;
            txtsearch.Text = null;
        }
        private void btnadd_Click(object sender, EventArgs e)
        {
            if (txtpass.Text != txtpasscon.Text)
            {
                MessageBox.Show("Password does not matched");
                return;
            }
            try
            {
                SqlConnection cn = new SqlConnection(constr);
                cn.Open();
                string querry = "INSERT INTO Login (Username,Password,Email,EntryDate) VALUES('" + txtuser.Text.Trim() + "','" + txtpass.Text.Trim() + "','" + txtemail.Text.Trim() + "',getdate())";
                SqlDataAdapter obj = new SqlDataAdapter(querry, cn);
                obj.SelectCommand.ExecuteNonQuery();
                cn.Close();

                ManagerUC_Load(sender, e);
                deletefields();
            }
            catch (Exception)
            {
                MessageBox.Show("Please Enter Correct Information");
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (txtpass.Text != txtpasscon.Text)
            {
                MessageBox.Show("Password does not matched");
                return;
            }
            try
            {
                SqlConnection cn = new SqlConnection(constr);
                cn.Open();
                string querry = "update Login set Username='" + txtuser.Text + "',Password='" + txtpass.Text + "',Email='" + txtemail.Text + "'WHERE LoginID='" + LOGID + "'";
                SqlDataAdapter obj1 = new SqlDataAdapter(querry, cn);
                DataTable dt1 = new DataTable();
                obj1.Fill(dt1);
                cn.Close();
                deletefields();
                ManagerUC_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Update Module: \n" + ex);
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("User account and Login History will be removed. Are you sure?", "Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    SqlConnection cn = new SqlConnection(constr);
                    cn.Open();
                    string querry1 = "Delete from LoginDetail WHERE LoginID='" + LOGID + "'";
                    SqlDataAdapter obj11 = new SqlDataAdapter(querry1, cn);
                    DataTable dt11 = new DataTable();
                    obj11.Fill(dt11);
                    cn.Close();



                    cn.Open();
                    string querry = "Delete from Login WHERE LoginID='" + LOGID + "'";
                    SqlDataAdapter obj1 = new SqlDataAdapter(querry, cn);
                    DataTable dt1 = new DataTable();
                    obj1.Fill(dt1);
                    cn.Close();
                    deletefields();
                    ManagerUC_Load(sender, e);
                }
                catch (Exception)
                {
                    MessageBox.Show("Error Deletion");
                }
            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            if(btnback.Visible==true)
            {
                try
                {
                    SqlConnection cn = new SqlConnection(constr);
                    cn.Open();
                    string querry = "SELECT LoginDetailID AS ID#,Username,Email,LoginTime FROM LoginDetail WHERE LoginDetailID Like '%" + txtsearch.Text.Trim() + "%' or Username like '%" + txtsearch.Text.Trim() + "%' or Email like '%" + txtsearch.Text.Trim() + "%' ";
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
                    string query = "Select Count(LoginDetailID) FROM LoginDetail WHERE LoginDetailID Like '%" + txtsearch.Text.Trim() + "%' or Username like '%" + txtsearch.Text.Trim() + "%' or Email like '%" + txtsearch.Text.Trim() + "%' ";
                    SqlCommand cmd = new SqlCommand(query, cnn);
                    SqlDataReader obj = cmd.ExecuteReader();
                    while (obj.Read())
                    {
                        lblrecord.Text = obj.GetValue(0).ToString();
                    }
                    cnn.Close();
                }
            }
            else if(btnback.Visible==false)
            {
                try
                {
                    SqlConnection cn = new SqlConnection(constr);
                    cn.Open();
                    string querry = "SELECT LoginID AS ID#,Username,Email,EntryDate FROM Login WHERE LoginID Like '%" + txtsearch.Text.Trim() + "%' or Username LIKE '%" + txtsearch.Text.Trim() + "%' OR Email LIKE '%" + txtsearch.Text.Trim() + "%'";
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
                    string query = "Select Count(LoginID) FROM Login WHERE LoginID Like '%" + txtsearch.Text.Trim() + "%' or Username LIKE '%" + txtsearch.Text.Trim() + "%' OR Email LIKE '%" + txtsearch.Text.Trim() + "%'";
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

        private void guna2DataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (btnback.Visible != true)
            {
                LOGID = guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                txtuser.Text = guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                txtemail.Text = guna2DataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            }
        }
    }
}
