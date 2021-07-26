
namespace Royal_Kitchen_Managment_System
{
    partial class SalePaymentForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.comcnic = new System.Windows.Forms.ComboBox();
            this.txtbrandname = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.btnadd = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnadd);
            this.panel1.Controls.Add(this.comcnic);
            this.panel1.Controls.Add(this.txtbrandname);
            this.panel1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(5, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(385, 441);
            this.panel1.TabIndex = 0;
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 30;
            this.guna2Elipse1.TargetControl = this.panel1;
            // 
            // guna2Elipse2
            // 
            this.guna2Elipse2.BorderRadius = 30;
            this.guna2Elipse2.TargetControl = this;
            // 
            // comcnic
            // 
            this.comcnic.DisplayMember = "CNIC";
            this.comcnic.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comcnic.ForeColor = System.Drawing.Color.Gray;
            this.comcnic.FormattingEnabled = true;
            this.comcnic.Items.AddRange(new object[] {
            "Cash",
            "Online",
            "Bank Transfer",
            "Other"});
            this.comcnic.Location = new System.Drawing.Point(78, 256);
            this.comcnic.Name = "comcnic";
            this.comcnic.Size = new System.Drawing.Size(202, 25);
            this.comcnic.TabIndex = 253;
            this.comcnic.Text = "Select Payment Medium";
            this.comcnic.ValueMember = "CNIC";
            // 
            // txtbrandname
            // 
            this.txtbrandname.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtbrandname.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbrandname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.txtbrandname.HintForeColor = System.Drawing.Color.Gray;
            this.txtbrandname.HintText = "Total Amount";
            this.txtbrandname.isPassword = false;
            this.txtbrandname.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.txtbrandname.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(221)))));
            this.txtbrandname.LineMouseHoverColor = System.Drawing.Color.Teal;
            this.txtbrandname.LineThickness = 4;
            this.txtbrandname.Location = new System.Drawing.Point(78, 296);
            this.txtbrandname.Margin = new System.Windows.Forms.Padding(4);
            this.txtbrandname.Name = "txtbrandname";
            this.txtbrandname.Size = new System.Drawing.Size(202, 35);
            this.txtbrandname.TabIndex = 252;
            this.txtbrandname.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
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
            this.btnadd.ImageOffset = new System.Drawing.Point(-5, 0);
            this.btnadd.ImageSize = new System.Drawing.Size(35, 35);
            this.btnadd.Location = new System.Drawing.Point(125, 358);
            this.btnadd.Name = "btnadd";
            this.btnadd.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnadd.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnadd.ShadowDecoration.Parent = this.btnadd;
            this.btnadd.Size = new System.Drawing.Size(105, 37);
            this.btnadd.TabIndex = 254;
            this.btnadd.Text = "Recived";
            this.btnadd.TextOffset = new System.Drawing.Point(-3, 0);
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(74, 210);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 21);
            this.label1.TabIndex = 255;
            this.label1.Text = "Order#";
            // 
            // SalePaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(395, 458);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SalePaymentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SalePaymentForm";
            this.Load += new System.EventHandler(this.SalePaymentForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse2;
        private System.Windows.Forms.ComboBox comcnic;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtbrandname;
        private Guna.UI2.WinForms.Guna2Button btnadd;
        private System.Windows.Forms.Label label1;
    }
}