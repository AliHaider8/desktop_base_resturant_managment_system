using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
namespace Royal_Kitchen_Managment_System
{
    public partial class Form1 : Form
    {
        int a = 1;
        int globalrandomnumber;
        static string constr = @"Data Source=DESKTOP-MPDTTH5;Initial Catalog=RoyalKitchen;Integrated Security=True";
        SqlConnection cnn = new SqlConnection(constr);
        public Form1()
        {
            InitializeComponent();
        }
        public string con()
        {
            return constr;
        }
        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        void falsetoolsvisibility()
        {
            //////////////////////////////////
            guna2CircleButton1.Visible = false;
            guna2Button4.Visible = false;
            guna2TextBox1.Visible = false;
            guna2TextBox2.Visible = false;
            guna2Button1.Visible = false;
            /////////////////////
            guna2CircleButton2.Visible = false;
            guna2TextBox3.Visible = false;
            guna2TextBox4.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            falsetoolsvisibility();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            
            guna2TextBox1.Clear();
            guna2TextBox2.Clear();
            guna2TextBox1.Visible = true;
            guna2TextBox2.Visible = true;
            guna2Button1.Visible = true;
            guna2Button4.Visible = false;
            guna2CircleButton1.Visible = false;
            guna2TextBox1.PlaceholderText = "Username";
            guna2TextBox2.PlaceholderText = "Password";
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            guna2TextBox1.Clear();
            guna2TextBox2.Clear();
            guna2Button4.Visible = true;
            guna2TextBox1.PlaceholderText = "Email Address";
            guna2TextBox2.PlaceholderText = "OTP";
            guna2Button1.Visible = false;
            guna2CircleButton1.Visible = false;
            guna2TextBox1.Visible = true;
            guna2TextBox2.Visible = true;
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (guna2Button4.Visible == true)
            {
                cnn.Open();
                string querry = "select * from Login where Email='" + guna2TextBox1.Text.Trim() + "'";
                SqlDataAdapter obj = new SqlDataAdapter(querry, cnn);
                DataTable obj1 = new DataTable();
                obj.Fill(obj1);
                if (obj1.Rows.Count == 1)
                {
                    guna2CircleButton1.Visible = true;
                }
                else
                {
                    guna2CircleButton1.Visible = false;
                }
                cnn.Close();
            }
        }

        private void guna2TextBox1_MouseLeave(object sender, EventArgs e)
        {
            ///////////rando number to email
            guna2TextBox2.Text = guna2TextBox2.Text;
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (guna2TextBox2.Text == "" || guna2TextBox2.Text == " " || guna2TextBox2.Text == "   ")
            {
                MessageBox.Show("Please enter OTP ");
                return;
            }
            if (guna2TextBox2.Text == Convert.ToString(globalrandomnumber))
            {
                guna2CircleButton2.Visible = true;
                guna2TextBox3.Visible = true;
                guna2TextBox4.Visible = true;

            }
            else if (guna2TextBox2.Text != Convert.ToString(globalrandomnumber))
            {
                MessageBox.Show("Wrong OTP");
                Application.Exit();
            }

            guna2TextBox2.Enabled = false;
            guna2TextBox1.Enabled = false;
            guna2Button4.Enabled = false;
            guna2CircleButton1.Enabled = false;
            guna2Button3.Enabled = false;
            guna2Button2.Enabled = false;
        }

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            if (guna2TextBox3.Text.Length == 0 || guna2TextBox3.Text.Length < 4)
            {
                MessageBox.Show("Please enter Valid Credentials");
                return;
            }
            if (guna2TextBox3.Text == guna2TextBox4.Text)
            {
                try
                {
                    cnn.Open();
                    string querry = "update Login set Password='" + guna2TextBox3.Text + "'WHERE Email='" + guna2TextBox1.Text + "'";
                    SqlDataAdapter obj1 = new SqlDataAdapter(querry, cnn);
                    DataTable dt1 = new DataTable();
                    obj1.Fill(dt1);
                    cnn.Close();

                    new Form1().Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Occured at: \n" + ex);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Passwords Mismatched");
            }
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                SmtpClient obj = new SmtpClient();
                obj.Port = 587;
                obj.Host = "smtp.gmail.com";
                obj.EnableSsl = true;
                obj.DeliveryMethod = SmtpDeliveryMethod.Network;
                obj.UseDefaultCredentials = false;
                obj.Credentials = new NetworkCredential("mozaua15@gmail.com", "Mozaua_15?");
                MailMessage maildetails = new MailMessage();
                maildetails.From = new MailAddress("mozaua15@gmail.com");
                maildetails.To.Add(guna2TextBox1.Text.Trim());
                maildetails.Subject = "Password Reset Request";
                maildetails.IsBodyHtml = true;
                ////////////////////generating random number////////////////////////
                Random r = new Random();
                int genRand = r.Next(101011, 999999);
                globalrandomnumber = genRand;
                ////////////////////////////////////////////////////////////////////
                maildetails.Body = "Your OTP Code is: " + Convert.ToString(genRand);  //random num
                obj.Send(maildetails);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured :" + ex);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                cnn.Open();
                string querry = "select * from Login where Username='" + guna2TextBox1.Text.Trim() + "'and Password ='" + guna2TextBox2.Text.Trim() + "'";
                SqlDataAdapter obj = new SqlDataAdapter(querry, cnn);
                DataTable obj1 = new DataTable();
                obj.Fill(obj1);
                if (obj1.Rows.Count == 1)
                {
                    string val1 = "", val2 = "";
                    try
                    {
                        ////////////////////////////////////////////////////////////////////////////                       
                        string query22 = "Select LoginID,Email from Login WHERE Username='" + guna2TextBox1.Text.Trim() + "'and password='" + guna2TextBox2.Text.Trim() + "'";
                        SqlCommand cmd = new SqlCommand(query22, cnn);
                        SqlDataReader obj22 = cmd.ExecuteReader();
                        while (obj22.Read())
                        {

                            val1 = obj22.GetValue(0).ToString();
                            val2 = obj22.GetValue(1).ToString();
                        }

                        cnn.Close();

                        //////////////////////////////////////////////////////////////////////////
                        cnn.Open();
                        string querry1 = "INSERT INTO LoginDetail (LoginID,Username,Email,LoginTime) VALUES('" + val1 + "','" + guna2TextBox1.Text + "','" + val2 + "',getdate())";
                        SqlDataAdapter obj2 = new SqlDataAdapter(querry1, cnn);
                        obj2.SelectCommand.ExecuteNonQuery();
                        cnn.Close();
                        new LoadingForm(constr,val2,guna2TextBox1.Text).Show();
                        
                        this.Hide();
                        //////////////////////////////////////////////////////////////////////////

                        //////////////////////////////////////////////////////////////////////////
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error at Login History: \n" + ex);
                    }

                }
                else if (guna2TextBox2.Text == "admin" && guna2TextBox1.Text == "admin")
                {
                    new DashBoard(constr, "Admin", "Admin").Show();
                    this.Close();
                }
                else if (a == 3)
                {
                    MessageBox.Show("  Three tries completed");
                    Application.Exit();
                }
                else
                {
                    // MessageBox.Show("    Username or Password Incorrect\n\n                      " + (3 - a) + " Tries left   \n\n                            (*-*)");
                    guna2TextBox1.Clear();
                    guna2TextBox2.Clear();
                    guna2TextBox1.PlaceholderText = "Incorrect Username";
                    guna2TextBox2.PlaceholderText = "Incorrect Password";
                    a++;
                }
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Server Error: " + ex);
                this.Close();
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            new DashBoard(constr, "test", "test").Show();
            this.Hide();
        }
    }
}
