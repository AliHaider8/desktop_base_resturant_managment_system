using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace Royal_Kitchen_Managment_System
{
    public partial class EmpQualificationForm : Form
    {
        public string constr, eqid;
        void Fun()
        {
            Form1 obj = new Form1();
            constr = obj.con();
        }
        void deletefields()
        {
            txtdegreename.Text = null;
            txtinstitutename.Text = null;
            txtpassingyear.Text = null;
            txttotal.Text = null;
            txtobtained.Text = null;
            txtsearch.Text = null;
        }
        public EmpQualificationForm(string id)
        {
            InitializeComponent();
            Fun();
            comepid.Text = id;
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cn = new SqlConnection(constr);
                cn.Open();
                string querry = "INSERT INTO Qualification (EmployeePID,DegreeName,InstituteName,PassingYear,ObtainedMarks,TotalMarks,Grade,Other,EntryDate) VALUES('" + comepid.Text.Trim() + "','" + txtdegreename.Text.Trim() + "','" + txtinstitutename.Text.Trim() + "','" + txtpassingyear.Text.Trim() + "','" + txtobtained.Text.Trim() + "','" + txttotal.Text.Trim() + "','" + comgrade.Text.Trim() + "','" + txtother.Text.Trim() + "',getdate())";
                SqlDataAdapter obj = new SqlDataAdapter(querry, cn);
                obj.SelectCommand.ExecuteNonQuery();
                cn.Close();
                deletefields();
                EmpQualificationForm_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please Enter Correct Information reason :(\n\n" + ex);
            }
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cn = new SqlConnection(constr);
                cn.Open();
                string querry = "update Qualification set DegreeName='" + txtdegreename.Text.Trim() + "',InstituteName='" + txtinstitutename.Text.Trim() + "',PassingYear='" + txtpassingyear.Text.Trim() + "',ObtainedMarks='" + txtobtained.Text.Trim() + "',TotalMarks='" + txttotal.Text.Trim() + "',Grade='" + comgrade.Text + "',Other='" + txtother.Text.Trim() + "'WHERE QualificationID='" + eqid + "'";
                SqlDataAdapter obj1 = new SqlDataAdapter(querry, cn);
                DataTable dt1 = new DataTable();
                obj1.Fill(dt1);
                cn.Close();
                deletefields();
                EmpQualificationForm_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Update Module: \n" + ex);
            }

        }

        private void guna2DataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            eqid = guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            comepid.Text = guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtdegreename.Text = guna2DataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txtinstitutename.Text = guna2DataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txtpassingyear.Text = guna2DataGridView1.SelectedRows[0].Cells[4].Value.ToString(); ;
            txtobtained.Text = guna2DataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            txttotal.Text = guna2DataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            comgrade.Text = guna2DataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            txtother.Text = guna2DataGridView1.SelectedRows[0].Cells[8].Value.ToString();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Employee Qualification info will be removed. Are you sure?", "Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    SqlConnection cn = new SqlConnection(constr);
                    cn.Open();
                    string querry = "Delete from EmployeePesonalDetail WHERE EmployeePID='" + eqid + "'";
                    SqlDataAdapter obj1 = new SqlDataAdapter(querry, cn);
                    DataTable dt1 = new DataTable();
                    obj1.Fill(dt1);
                    cn.Close();
                    deletefields();
                    EmpQualificationForm_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Deletion reason :( \n\n" + ex);
                }
            }
        }

        private void EmpQualificationForm_Load(object sender, EventArgs e)
        {
            if(comepid.Text.Trim()=="Empty")
            {
                SqlConnection cn = new SqlConnection(constr);
                cn.Open();
                string querry = "SELECT * FROM Qualification";
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
                string querry = "SELECT * FROM Qualification WHERE EmployeePID='"+comepid.Text.Trim()+"'";
                SqlDataAdapter obj = new SqlDataAdapter(querry, cn);
                DataTable dt = new DataTable();
                obj.Fill(dt);
                guna2DataGridView1.DataSource = dt;
                cn.Close();
            }
        }
    }
}
