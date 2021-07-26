
namespace Royal_Kitchen_Managment_System
{
    partial class DistributerContactForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DistributerContactForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblrecord = new System.Windows.Forms.Label();
            this.comcnic = new System.Windows.Forms.ComboBox();
            this.distributerPersonalDetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.royalKitchenDataSet = new Royal_Kitchen_Managment_System.RoyalKitchenDataSet();
            this.txtothers = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txtemail = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txtaddress = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txtlandline = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.btnrefresh = new Guna.UI2.WinForms.Guna2Button();
            this.btnreport = new Guna.UI2.WinForms.Guna2Button();
            this.btnupdate = new Guna.UI2.WinForms.Guna2Button();
            this.btndelete = new Guna.UI2.WinForms.Guna2Button();
            this.btnadd = new Guna.UI2.WinForms.Guna2Button();
            this.btnexit = new Guna.UI2.WinForms.Guna2Button();
            this.txtsearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtcity = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txtphone = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txtcountry = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.guna2DataGridView1 = new Guna.UI2.WinForms.Guna2DataGridView();
            this.guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse3 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.distributerPersonalDetailTableAdapter = new Royal_Kitchen_Managment_System.RoyalKitchenDataSetTableAdapters.DistributerPersonalDetailTableAdapter();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.distributerPersonalDetailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.royalKitchenDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 30;
            this.guna2Elipse1.TargetControl = this;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblrecord);
            this.panel1.Controls.Add(this.comcnic);
            this.panel1.Controls.Add(this.txtothers);
            this.panel1.Controls.Add(this.txtemail);
            this.panel1.Controls.Add(this.txtaddress);
            this.panel1.Controls.Add(this.txtlandline);
            this.panel1.Controls.Add(this.btnrefresh);
            this.panel1.Controls.Add(this.btnreport);
            this.panel1.Controls.Add(this.btnupdate);
            this.panel1.Controls.Add(this.btndelete);
            this.panel1.Controls.Add(this.btnadd);
            this.panel1.Controls.Add(this.btnexit);
            this.panel1.Controls.Add(this.txtsearch);
            this.panel1.Controls.Add(this.txtcity);
            this.panel1.Controls.Add(this.txtphone);
            this.panel1.Controls.Add(this.txtcountry);
            this.panel1.Controls.Add(this.guna2DataGridView1);
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1180, 580);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(367, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 253;
            this.label2.Text = "Records: ";
            // 
            // lblrecord
            // 
            this.lblrecord.AutoSize = true;
            this.lblrecord.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblrecord.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblrecord.Location = new System.Drawing.Point(428, 14);
            this.lblrecord.Name = "lblrecord";
            this.lblrecord.Size = new System.Drawing.Size(56, 17);
            this.lblrecord.TabIndex = 254;
            this.lblrecord.Text = "Records";
            // 
            // comcnic
            // 
            this.comcnic.DataSource = this.distributerPersonalDetailBindingSource;
            this.comcnic.DisplayMember = "CNIC";
            this.comcnic.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comcnic.ForeColor = System.Drawing.Color.Gray;
            this.comcnic.FormattingEnabled = true;
            this.comcnic.Location = new System.Drawing.Point(953, 71);
            this.comcnic.Name = "comcnic";
            this.comcnic.Size = new System.Drawing.Size(202, 25);
            this.comcnic.TabIndex = 250;
            this.comcnic.ValueMember = "CNIC";
            // 
            // distributerPersonalDetailBindingSource
            // 
            this.distributerPersonalDetailBindingSource.DataMember = "DistributerPersonalDetail";
            this.distributerPersonalDetailBindingSource.DataSource = this.royalKitchenDataSet;
            // 
            // royalKitchenDataSet
            // 
            this.royalKitchenDataSet.DataSetName = "RoyalKitchenDataSet";
            this.royalKitchenDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtothers
            // 
            this.txtothers.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtothers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtothers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.txtothers.HintForeColor = System.Drawing.Color.Gray;
            this.txtothers.HintText = "Others";
            this.txtothers.isPassword = false;
            this.txtothers.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.txtothers.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(221)))));
            this.txtothers.LineMouseHoverColor = System.Drawing.Color.Teal;
            this.txtothers.LineThickness = 4;
            this.txtothers.Location = new System.Drawing.Point(953, 355);
            this.txtothers.Margin = new System.Windows.Forms.Padding(4);
            this.txtothers.Name = "txtothers";
            this.txtothers.Size = new System.Drawing.Size(202, 33);
            this.txtothers.TabIndex = 249;
            this.txtothers.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtothers.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtothers_KeyPress);
            // 
            // txtemail
            // 
            this.txtemail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtemail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtemail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.txtemail.HintForeColor = System.Drawing.Color.Gray;
            this.txtemail.HintText = "Type Email Address";
            this.txtemail.isPassword = false;
            this.txtemail.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.txtemail.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(221)))));
            this.txtemail.LineMouseHoverColor = System.Drawing.Color.Teal;
            this.txtemail.LineThickness = 4;
            this.txtemail.Location = new System.Drawing.Point(953, 314);
            this.txtemail.Margin = new System.Windows.Forms.Padding(4);
            this.txtemail.Name = "txtemail";
            this.txtemail.Size = new System.Drawing.Size(202, 33);
            this.txtemail.TabIndex = 248;
            this.txtemail.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtemail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtemail_KeyPress);
            // 
            // txtaddress
            // 
            this.txtaddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtaddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtaddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.txtaddress.HintForeColor = System.Drawing.Color.Gray;
            this.txtaddress.HintText = "Type Address";
            this.txtaddress.isPassword = false;
            this.txtaddress.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.txtaddress.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(221)))));
            this.txtaddress.LineMouseHoverColor = System.Drawing.Color.Teal;
            this.txtaddress.LineThickness = 4;
            this.txtaddress.Location = new System.Drawing.Point(953, 99);
            this.txtaddress.Margin = new System.Windows.Forms.Padding(4);
            this.txtaddress.Name = "txtaddress";
            this.txtaddress.Size = new System.Drawing.Size(202, 33);
            this.txtaddress.TabIndex = 247;
            this.txtaddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtaddress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtaddress_KeyPress);
            // 
            // txtlandline
            // 
            this.txtlandline.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtlandline.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtlandline.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.txtlandline.HintForeColor = System.Drawing.Color.Gray;
            this.txtlandline.HintText = "Type Land Line (Optional)";
            this.txtlandline.isPassword = false;
            this.txtlandline.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.txtlandline.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(221)))));
            this.txtlandline.LineMouseHoverColor = System.Drawing.Color.Teal;
            this.txtlandline.LineThickness = 4;
            this.txtlandline.Location = new System.Drawing.Point(953, 273);
            this.txtlandline.Margin = new System.Windows.Forms.Padding(4);
            this.txtlandline.Name = "txtlandline";
            this.txtlandline.Size = new System.Drawing.Size(202, 33);
            this.txtlandline.TabIndex = 246;
            this.txtlandline.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtlandline.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtlandline_KeyPress);
            // 
            // btnrefresh
            // 
            this.btnrefresh.Animated = true;
            this.btnrefresh.AutoRoundedCorners = true;
            this.btnrefresh.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnrefresh.BorderRadius = 17;
            this.btnrefresh.BorderThickness = 2;
            this.btnrefresh.CheckedState.Parent = this.btnrefresh;
            this.btnrefresh.CustomImages.Parent = this.btnrefresh;
            this.btnrefresh.FillColor = System.Drawing.Color.White;
            this.btnrefresh.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.btnrefresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.btnrefresh.HoverState.Parent = this.btnrefresh;
            this.btnrefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnrefresh.Image")));
            this.btnrefresh.ImageSize = new System.Drawing.Size(35, 35);
            this.btnrefresh.Location = new System.Drawing.Point(841, 4);
            this.btnrefresh.Name = "btnrefresh";
            this.btnrefresh.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnrefresh.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnrefresh.ShadowDecoration.Parent = this.btnrefresh;
            this.btnrefresh.Size = new System.Drawing.Size(105, 37);
            this.btnrefresh.TabIndex = 245;
            this.btnrefresh.Text = "Refresh";
            // 
            // btnreport
            // 
            this.btnreport.Animated = true;
            this.btnreport.AutoRoundedCorners = true;
            this.btnreport.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnreport.BorderRadius = 17;
            this.btnreport.BorderThickness = 2;
            this.btnreport.CheckedState.Parent = this.btnreport;
            this.btnreport.CustomImages.Parent = this.btnreport;
            this.btnreport.FillColor = System.Drawing.Color.White;
            this.btnreport.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnreport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.btnreport.HoverState.Parent = this.btnreport;
            this.btnreport.Image = ((System.Drawing.Image)(resources.GetObject("btnreport.Image")));
            this.btnreport.ImageOffset = new System.Drawing.Point(-2, 0);
            this.btnreport.ImageSize = new System.Drawing.Size(35, 35);
            this.btnreport.Location = new System.Drawing.Point(1059, 465);
            this.btnreport.Name = "btnreport";
            this.btnreport.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnreport.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnreport.ShadowDecoration.Parent = this.btnreport;
            this.btnreport.Size = new System.Drawing.Size(105, 37);
            this.btnreport.TabIndex = 244;
            this.btnreport.Text = "Report";
            this.btnreport.TextOffset = new System.Drawing.Point(-3, 0);
            this.btnreport.Click += new System.EventHandler(this.btnreport_Click);
            // 
            // btnupdate
            // 
            this.btnupdate.Animated = true;
            this.btnupdate.AutoRoundedCorners = true;
            this.btnupdate.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnupdate.BorderRadius = 17;
            this.btnupdate.BorderThickness = 2;
            this.btnupdate.CheckedState.Parent = this.btnupdate;
            this.btnupdate.CustomImages.Parent = this.btnupdate;
            this.btnupdate.FillColor = System.Drawing.Color.White;
            this.btnupdate.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnupdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.btnupdate.HoverState.Parent = this.btnupdate;
            this.btnupdate.Image = ((System.Drawing.Image)(resources.GetObject("btnupdate.Image")));
            this.btnupdate.ImageOffset = new System.Drawing.Point(1, 0);
            this.btnupdate.ImageSize = new System.Drawing.Size(35, 35);
            this.btnupdate.Location = new System.Drawing.Point(1059, 422);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnupdate.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnupdate.ShadowDecoration.Parent = this.btnupdate;
            this.btnupdate.Size = new System.Drawing.Size(105, 37);
            this.btnupdate.TabIndex = 243;
            this.btnupdate.Text = "Update";
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // btndelete
            // 
            this.btndelete.Animated = true;
            this.btndelete.AutoRoundedCorners = true;
            this.btndelete.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btndelete.BorderRadius = 17;
            this.btndelete.BorderThickness = 2;
            this.btndelete.CheckedState.Parent = this.btndelete;
            this.btndelete.CustomImages.Parent = this.btndelete;
            this.btndelete.FillColor = System.Drawing.Color.White;
            this.btndelete.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.btndelete.HoverState.Parent = this.btndelete;
            this.btndelete.Image = ((System.Drawing.Image)(resources.GetObject("btndelete.Image")));
            this.btndelete.ImageSize = new System.Drawing.Size(35, 35);
            this.btndelete.Location = new System.Drawing.Point(948, 465);
            this.btndelete.Name = "btndelete";
            this.btndelete.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btndelete.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btndelete.ShadowDecoration.Parent = this.btndelete;
            this.btndelete.Size = new System.Drawing.Size(105, 37);
            this.btndelete.TabIndex = 243;
            this.btndelete.Text = "Delete";
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // btnadd
            // 
            this.btnadd.Animated = true;
            this.btnadd.AutoRoundedCorners = true;
            this.btnadd.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnadd.BorderRadius = 17;
            this.btnadd.BorderThickness = 2;
            this.btnadd.CheckedState.Parent = this.btnadd;
            this.btnadd.CustomImages.Parent = this.btnadd;
            this.btnadd.FillColor = System.Drawing.Color.White;
            this.btnadd.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnadd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.btnadd.HoverState.Parent = this.btnadd;
            this.btnadd.Image = ((System.Drawing.Image)(resources.GetObject("btnadd.Image")));
            this.btnadd.ImageOffset = new System.Drawing.Point(-5, 0);
            this.btnadd.ImageSize = new System.Drawing.Size(35, 35);
            this.btnadd.Location = new System.Drawing.Point(948, 422);
            this.btnadd.Name = "btnadd";
            this.btnadd.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnadd.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnadd.ShadowDecoration.Parent = this.btnadd;
            this.btnadd.Size = new System.Drawing.Size(105, 37);
            this.btnadd.TabIndex = 242;
            this.btnadd.Text = "Add";
            this.btnadd.TextOffset = new System.Drawing.Point(-3, 0);
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // btnexit
            // 
            this.btnexit.Animated = true;
            this.btnexit.AutoRoundedCorners = true;
            this.btnexit.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnexit.BorderRadius = 18;
            this.btnexit.BorderThickness = 2;
            this.btnexit.CheckedState.Parent = this.btnexit;
            this.btnexit.CustomImages.Parent = this.btnexit;
            this.btnexit.FillColor = System.Drawing.Color.White;
            this.btnexit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnexit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.btnexit.HoverState.Parent = this.btnexit;
            this.btnexit.Image = ((System.Drawing.Image)(resources.GetObject("btnexit.Image")));
            this.btnexit.ImageSize = new System.Drawing.Size(35, 35);
            this.btnexit.Location = new System.Drawing.Point(1123, 3);
            this.btnexit.Name = "btnexit";
            this.btnexit.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnexit.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnexit.ShadowDecoration.Parent = this.btnexit;
            this.btnexit.Size = new System.Drawing.Size(55, 38);
            this.btnexit.TabIndex = 241;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // txtsearch
            // 
            this.txtsearch.Animated = true;
            this.txtsearch.AutoRoundedCorners = true;
            this.txtsearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txtsearch.BorderRadius = 17;
            this.txtsearch.BorderThickness = 2;
            this.txtsearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtsearch.DefaultText = "";
            this.txtsearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtsearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtsearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtsearch.DisabledState.Parent = this.txtsearch;
            this.txtsearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtsearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtsearch.FocusedState.Parent = this.txtsearch;
            this.txtsearch.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.txtsearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtsearch.HoverState.Parent = this.txtsearch;
            this.txtsearch.IconLeft = ((System.Drawing.Image)(resources.GetObject("txtsearch.IconLeft")));
            this.txtsearch.IconLeftOffset = new System.Drawing.Point(2, 2);
            this.txtsearch.IconLeftSize = new System.Drawing.Size(30, 30);
            this.txtsearch.Location = new System.Drawing.Point(4, 4);
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.PasswordChar = '\0';
            this.txtsearch.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtsearch.PlaceholderText = "Search Record......";
            this.txtsearch.SelectedText = "";
            this.txtsearch.ShadowDecoration.Parent = this.txtsearch;
            this.txtsearch.Size = new System.Drawing.Size(357, 37);
            this.txtsearch.TabIndex = 237;
            this.txtsearch.TextOffset = new System.Drawing.Point(2, 0);
            this.txtsearch.TextChanged += new System.EventHandler(this.txtsearch_TextChanged);
            // 
            // txtcity
            // 
            this.txtcity.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtcity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.txtcity.HintForeColor = System.Drawing.Color.Gray;
            this.txtcity.HintText = "Type City Name";
            this.txtcity.isPassword = false;
            this.txtcity.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.txtcity.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(221)))));
            this.txtcity.LineMouseHoverColor = System.Drawing.Color.Teal;
            this.txtcity.LineThickness = 4;
            this.txtcity.Location = new System.Drawing.Point(953, 140);
            this.txtcity.Margin = new System.Windows.Forms.Padding(4);
            this.txtcity.Name = "txtcity";
            this.txtcity.Size = new System.Drawing.Size(202, 33);
            this.txtcity.TabIndex = 235;
            this.txtcity.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtcity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcity_KeyPress);
            // 
            // txtphone
            // 
            this.txtphone.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtphone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtphone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.txtphone.HintForeColor = System.Drawing.Color.Gray;
            this.txtphone.HintText = "Type Phone Number";
            this.txtphone.isPassword = false;
            this.txtphone.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.txtphone.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(221)))));
            this.txtphone.LineMouseHoverColor = System.Drawing.Color.Teal;
            this.txtphone.LineThickness = 4;
            this.txtphone.Location = new System.Drawing.Point(953, 232);
            this.txtphone.Margin = new System.Windows.Forms.Padding(4);
            this.txtphone.Name = "txtphone";
            this.txtphone.Size = new System.Drawing.Size(202, 33);
            this.txtphone.TabIndex = 234;
            this.txtphone.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtphone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtphone_KeyPress);
            // 
            // txtcountry
            // 
            this.txtcountry.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtcountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcountry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.txtcountry.HintForeColor = System.Drawing.Color.Gray;
            this.txtcountry.HintText = "Type Country Name";
            this.txtcountry.isPassword = false;
            this.txtcountry.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.txtcountry.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(221)))));
            this.txtcountry.LineMouseHoverColor = System.Drawing.Color.Teal;
            this.txtcountry.LineThickness = 4;
            this.txtcountry.Location = new System.Drawing.Point(953, 191);
            this.txtcountry.Margin = new System.Windows.Forms.Padding(4);
            this.txtcountry.Name = "txtcountry";
            this.txtcountry.Size = new System.Drawing.Size(202, 33);
            this.txtcountry.TabIndex = 233;
            this.txtcountry.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtcountry.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcountry_KeyPress);
            // 
            // guna2DataGridView1
            // 
            this.guna2DataGridView1.AllowUserToAddRows = false;
            this.guna2DataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(244)))));
            this.guna2DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle19;
            this.guna2DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.guna2DataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.guna2DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.guna2DataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.guna2DataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.guna2DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.guna2DataGridView1.ColumnHeadersHeight = 28;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(234)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(186)))), ((int)(((byte)(231)))));
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.guna2DataGridView1.DefaultCellStyle = dataGridViewCellStyle21;
            this.guna2DataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.guna2DataGridView1.EnableHeadersVisualStyles = false;
            this.guna2DataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(220)))), ((int)(((byte)(242)))));
            this.guna2DataGridView1.Location = new System.Drawing.Point(6, 47);
            this.guna2DataGridView1.Name = "guna2DataGridView1";
            this.guna2DataGridView1.ReadOnly = true;
            this.guna2DataGridView1.RowHeadersVisible = false;
            this.guna2DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.guna2DataGridView1.Size = new System.Drawing.Size(940, 525);
            this.guna2DataGridView1.TabIndex = 231;
            this.guna2DataGridView1.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.FeterRiver;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(244)))));
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(220)))), ((int)(((byte)(242)))));
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.Height = 28;
            this.guna2DataGridView1.ThemeStyle.ReadOnly = true;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(234)))), ((int)(((byte)(247)))));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Height = 22;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(186)))), ((int)(((byte)(231)))));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.guna2DataGridView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.guna2DataGridView1_MouseClick);
            this.guna2DataGridView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.guna2DataGridView1_MouseDoubleClick);
            // 
            // guna2Elipse2
            // 
            this.guna2Elipse2.BorderRadius = 30;
            this.guna2Elipse2.TargetControl = this.panel1;
            // 
            // guna2Elipse3
            // 
            this.guna2Elipse3.BorderRadius = 22;
            this.guna2Elipse3.TargetControl = this.guna2DataGridView1;
            // 
            // distributerPersonalDetailTableAdapter
            // 
            this.distributerPersonalDetailTableAdapter.ClearBeforeFill = true;
            // 
            // DistributerContactForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1190, 588);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "DistributerContactForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Supplier Contact Details";
            this.Load += new System.EventHandler(this.DistributerContactForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.distributerPersonalDetailBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.royalKitchenDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse2;
        private Guna.UI2.WinForms.Guna2TextBox txtsearch;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtcity;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtphone;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtcountry;
        private Guna.UI2.WinForms.Guna2DataGridView guna2DataGridView1;
        private Guna.UI2.WinForms.Guna2Button btnrefresh;
        private Guna.UI2.WinForms.Guna2Button btnreport;
        private Guna.UI2.WinForms.Guna2Button btnupdate;
        private Guna.UI2.WinForms.Guna2Button btndelete;
        private Guna.UI2.WinForms.Guna2Button btnadd;
        private Guna.UI2.WinForms.Guna2Button btnexit;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse3;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtothers;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtemail;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtaddress;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtlandline;
        private System.Windows.Forms.ComboBox comcnic;
        private RoyalKitchenDataSet royalKitchenDataSet;
        private System.Windows.Forms.BindingSource distributerPersonalDetailBindingSource;
        private RoyalKitchenDataSetTableAdapters.DistributerPersonalDetailTableAdapter distributerPersonalDetailTableAdapter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblrecord;
    }
}