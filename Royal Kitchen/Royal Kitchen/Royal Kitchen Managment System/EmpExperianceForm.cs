using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace Royal_Kitchen_Managment_System
{
    public partial class EmpExperianceForm : Form
    {
        public string constr, eexid;
        void Fun()
        {
            Form1 obj = new Form1();
            constr = obj.con();
        }
        void deletefields()
        {
            txtorgname.Text = null;
            txtjobname.Text = null;
            txtjobdesc.Text = null;
            txtsearch.Text = null;
        }
        public EmpExperianceForm(string id)
        {
            InitializeComponent();
            Fun();
            comepid.Text = id;
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            string start = start1.Text + "/" + start2.Text + "/" + start3.Text;
            string end = end1.Text + "/" + end2.Text + "/" + end3.Text;
            try
            {
                SqlConnection cn = new SqlConnection(constr);
                cn.Open();
                string querry = "INSERT INTO EmployeePrevoiusExperiance (EmployeePID,OrganizationName,JobName,JobDescription,StartDate,EndDate,Others,EntryDate) VALUES('" + comepid.Text.Trim() + "','" + txtorgname.Text.Trim() + "','" + txtjobname.Text.Trim() + "','" + txtjobdesc.Text.Trim() + "','" + start.Trim() + "','" + end.Trim() + "','" + txtother.Text.Trim() + "',getdate())";
                SqlDataAdapter obj = new SqlDataAdapter(querry, cn);
                obj.SelectCommand.ExecuteNonQuery();
                cn.Close();
                deletefields();
                EmpExperianceForm_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please Enter Correct Information reason :(\n\n" + ex);
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            string start = start1.Text + "/" + start2.Text + "/" + start3.Text;
            string end = end1.Text + "/" + end2.Text + "/" + end3.Text;
            try
            {
                SqlConnection cn = new SqlConnection(constr);
                cn.Open();
                string querry = "update EmployeePrevoiusExperiance set OrganizationName='" + txtorgname.Text.Trim() + "',JobName='" + txtjobname.Text.Trim() + "',JobDescription='" + txtjobdesc.Text.Trim() + "',StartDate='" + start.Trim() + "',EndDate='" + end.Trim() + "',Others='" + txtother.Text.Trim() + "'WHERE EmployeePEID='" + eexid + "'";
                SqlDataAdapter obj1 = new SqlDataAdapter(querry, cn);
                DataTable dt1 = new DataTable();
                obj1.Fill(dt1);
                cn.Close();
                deletefields();
                EmpExperianceForm_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Update Module: \n" + ex);
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Experiance Record will be removed. Are you sure?", "Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    SqlConnection cn = new SqlConnection(constr);
                    cn.Open();
                    string querry = "Delete from EmployeePrevoiusExperiance WHERE EmployeePEID='" + eexid + "'";
                    SqlDataAdapter obj1 = new SqlDataAdapter(querry, cn);
                    DataTable dt1 = new DataTable();
                    obj1.Fill(dt1);
                    cn.Close();
                    deletefields();
                    EmpExperianceForm_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Deletion reason :( \n\n" + ex);
                }
            }
        }

        private void guna2DataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            eexid = guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            comepid.Text = guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtorgname.Text = guna2DataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txtjobname.Text = guna2DataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txtjobdesc.Text = guna2DataGridView1.SelectedRows[0].Cells[4].Value.ToString();

            {
                int i = 0, T = 0;
                string startstr;
                start1.Text = null;
                start2.Text = null;
                start3.Text = null;
                startstr = guna2DataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                for (int x = 0; x < startstr.Length; x++)
                {
                    if (Convert.ToString(startstr[x]) == "/")
                    {
                        i++;
                        continue;
                    }
                    if (i == 0)
                    {
                        start2.Text += Convert.ToString(startstr[x]);
                    }
                    if (i == 1)
                    {
                        start3.Text += Convert.ToString(startstr[x]);
                    }
                    if (i == 2)
                    {
                        if (Convert.ToString(startstr[x]) == " ")
                        {
                            T++;
                        }
                        if (T == 0)
                        {
                            start1.Text += Convert.ToString(startstr[x]);
                        }
                    }

                }
            }

            {
                int i = 0, T = 0;
                string endstr;
                end1.Text = null;
                end2.Text = null;
                end3.Text = null;
                endstr = guna2DataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                for (int x = 0; x < endstr.Length; x++)
                {
                    if (Convert.ToString(endstr[x]) == "/")
                    {
                        i++;
                        continue;
                    }
                    if (i == 0)
                    {
                        end2.Text += Convert.ToString(endstr[x]);
                    }
                    if (i == 1)
                    {
                        end3.Text += Convert.ToString(endstr[x]);
                    }
                    if (i == 2)
                    {
                        if (Convert.ToString(endstr[x]) == " ")
                        {
                            T++;
                        }
                        if (T == 0)
                        {
                            end1.Text += Convert.ToString(endstr[x]);
                        }
                    }

                }
            }


            txtother.Text = guna2DataGridView1.SelectedRows[0].Cells[7].Value.ToString();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EmpExperianceForm_Load(object sender, EventArgs e)
        {
            if(comepid.Text.Trim()=="Empty")
            {
                SqlConnection cn = new SqlConnection(constr);
                cn.Open();
                string querry = "SELECT * FROM EmployeePrevoiusExperiance";
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
                string querry = "SELECT * FROM EmployeePrevoiusExperiance WHERE EmployeePID='"+comepid.Text.Trim()+"'";
                SqlDataAdapter obj = new SqlDataAdapter(querry, cn);
                DataTable dt = new DataTable();
                obj.Fill(dt);
                guna2DataGridView1.DataSource = dt;
                cn.Close();
            }
        }
    }
}
