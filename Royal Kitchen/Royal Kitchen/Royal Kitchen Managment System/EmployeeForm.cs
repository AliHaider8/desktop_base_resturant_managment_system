using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace Royal_Kitchen_Managment_System
{
    public partial class EmployeeForm : Form
    {
        string constr, eid;
        void Fun()
        {
            Form1 obj = new Form1();
            constr = obj.con();
        }
        void deletefields()
        {
            txtempyears.Text = null;
            txtbonus.Text = null;
            txtjobdesc.Text = null;
            txtjobname.Text = null;
            txtsalary.Text = null;
            txtsearch.Text = null;
            comstart1.Text = "Hour";
            comstart2.Text = "Minute";
            comend1.Text = "Hour";
            comend2.Text = "Minute";
        }
        public EmployeeForm(string id)
        {
            InitializeComponent();
            Fun();
            comepid.Text = id;
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            //old copy
        }

        private void btnadd_Click_1(object sender, EventArgs e)
        {
            string start = comstart1.Text + ":" + comstart2.Text;
            string end = comend1.Text + ":" + comend2.Text;
            try
            {
                SqlConnection cn = new SqlConnection(constr);
                cn.Open();
                string querry = "INSERT INTO Employee (EmployeePID,JobName,EmployeementYears,Salary,Bonus,DutyStartTime,DutyEndTime,JobDescription,EntryDate) VALUES('" + comepid.Text.Trim() + "','" + txtjobname.Text.Trim() + "','" + txtempyears.Text.Trim() + "','" + txtsalary.Text.Trim() + "','" + txtbonus.Text.Trim() + "','" + start + "','" + end + "','" + txtjobdesc.Text.Trim() + "',getdate())";
                SqlDataAdapter obj = new SqlDataAdapter(querry, cn);
                obj.SelectCommand.ExecuteNonQuery();
                cn.Close();
                deletefields();
                EmployeeForm_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured Reason:( \n\n" + ex);
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            string start = comstart1.Text + ":" + comstart2.Text;
            string end = comend1.Text + ":" + comend2.Text;
            try
            {
                SqlConnection cn = new SqlConnection(constr);
                cn.Open();
                string querry = "update Employee set  JobName='" + txtjobname.Text.Trim() + "',EmployeementYears='" + txtempyears.Text.Trim() + "',Salary='" + txtsalary.Text.Trim() + "',Bonus='" + txtbonus.Text.Trim() + "',DutyStartTime='" + start + "',DutyEndTime='" + end + "',JobDescription='" + txtjobdesc.Text.Trim() + "'WHERE EmployeeID='" + eid + "'";
                SqlDataAdapter obj1 = new SqlDataAdapter(querry, cn);
                DataTable dt1 = new DataTable();
                obj1.Fill(dt1);
                deletefields();
                EmployeeForm_Load(sender, e);
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Update Food Module Reason:( \n\n" + ex);
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Employee Job Record will be removed. Are you sure?", "Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    SqlConnection cn = new SqlConnection(constr);
                    cn.Open();
                    string querry = "Delete from Employee WHERE EmployeeID='" + eid + "'";
                    SqlDataAdapter obj1 = new SqlDataAdapter(querry, cn);
                    DataTable dt1 = new DataTable();
                    obj1.Fill(dt1);
                    cn.Close();
                    deletefields();
                    EmployeeForm_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Deletion reason :( \n\n" + ex);
                }
            }
        }

        private void guna2DataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            eid = guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            comepid.Text = guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtjobname.Text = guna2DataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txtempyears.Text = guna2DataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txtsalary.Text = guna2DataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            txtbonus.Text = guna2DataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            txtjobdesc.Text = guna2DataGridView1.SelectedRows[0].Cells[8].Value.ToString();
            string startstr;
            startstr = guna2DataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            comstart1.Text = Convert.ToString(startstr[0]) + Convert.ToString(startstr[1]);
            comstart2.Text = Convert.ToString(startstr[3]) + Convert.ToString(startstr[4]);
            string endstr;
            endstr = guna2DataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            comend1.Text = Convert.ToString(endstr[0]) + Convert.ToString(endstr[1]);
            comend2.Text = Convert.ToString(endstr[3]) + Convert.ToString(endstr[4]);
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            if(comepid.Text.Trim()=="Empty")
            {
                SqlConnection cn = new SqlConnection(constr);
                cn.Open();
                string querry = "Select * FROM Employee";
                SqlDataAdapter obj = new SqlDataAdapter(querry, cn);
                DataTable dt = new DataTable();
                obj.Fill(dt);
                guna2DataGridView1.DataSource = dt;
                cn.Close();
            }
            else if(comepid.Text.Trim() != "Empty")
            {
                SqlConnection cn = new SqlConnection(constr);
                cn.Open();
                string querry = "Select * FROM Employee WHERE EmployeePID='"+comepid.Text.Trim()+"'";
                SqlDataAdapter obj = new SqlDataAdapter(querry, cn);
                DataTable dt = new DataTable();
                obj.Fill(dt);
                guna2DataGridView1.DataSource = dt;
                cn.Close();
            }
            
        }
    }
}
