namespace QuanLyLuanAn
{
    partial class UCMSSV
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.lblMSSV = new System.Windows.Forms.Label();
            this.guna2VSeparator1 = new Guna.UI2.WinForms.Guna2VSeparator();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.guna2VSeparator2 = new Guna.UI2.WinForms.Guna2VSeparator();
            this.btnXoa = new Guna.UI2.WinForms.Guna2ImageButton();
            this.SuspendLayout();
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2Separator1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.guna2Separator1.FillThickness = 3;
            this.guna2Separator1.Location = new System.Drawing.Point(0, 24);
            this.guna2Separator1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(340, 5);
            this.guna2Separator1.TabIndex = 78;
            // 
            // lblMSSV
            // 
            this.lblMSSV.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblMSSV.Location = new System.Drawing.Point(0, 0);
            this.lblMSSV.Name = "lblMSSV";
            this.lblMSSV.Size = new System.Drawing.Size(87, 24);
            this.lblMSSV.TabIndex = 79;
            this.lblMSSV.Text = "MSSV";
            this.lblMSSV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // guna2VSeparator1
            // 
            this.guna2VSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.guna2VSeparator1.Dock = System.Windows.Forms.DockStyle.Left;
            this.guna2VSeparator1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.guna2VSeparator1.FillThickness = 2;
            this.guna2VSeparator1.Location = new System.Drawing.Point(87, 0);
            this.guna2VSeparator1.Margin = new System.Windows.Forms.Padding(2);
            this.guna2VSeparator1.Name = "guna2VSeparator1";
            this.guna2VSeparator1.Size = new System.Drawing.Size(8, 24);
            this.guna2VSeparator1.TabIndex = 80;
            // 
            // lblHoTen
            // 
            this.lblHoTen.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblHoTen.Location = new System.Drawing.Point(95, 0);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(201, 24);
            this.lblHoTen.TabIndex = 81;
            this.lblHoTen.Text = "Ho va Ten";
            this.lblHoTen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // guna2VSeparator2
            // 
            this.guna2VSeparator2.BackColor = System.Drawing.Color.Transparent;
            this.guna2VSeparator2.Dock = System.Windows.Forms.DockStyle.Left;
            this.guna2VSeparator2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.guna2VSeparator2.FillThickness = 2;
            this.guna2VSeparator2.Location = new System.Drawing.Point(296, 0);
            this.guna2VSeparator2.Margin = new System.Windows.Forms.Padding(2);
            this.guna2VSeparator2.Name = "guna2VSeparator2";
            this.guna2VSeparator2.Size = new System.Drawing.Size(8, 24);
            this.guna2VSeparator2.TabIndex = 82;
            // 
            // btnXoa
            // 
            this.btnXoa.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnXoa.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnXoa.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnXoa.Image = global::QuanLyLuanAn.Properties.Resources.xoa_2;
            this.btnXoa.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnXoa.ImageRotate = 0F;
            this.btnXoa.ImageSize = new System.Drawing.Size(25, 25);
            this.btnXoa.Location = new System.Drawing.Point(304, 0);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnXoa.Size = new System.Drawing.Size(40, 24);
            this.btnXoa.TabIndex = 83;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // UCMSSV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.guna2VSeparator2);
            this.Controls.Add(this.lblHoTen);
            this.Controls.Add(this.guna2VSeparator1);
            this.Controls.Add(this.lblMSSV);
            this.Controls.Add(this.guna2Separator1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UCMSSV";
            this.Size = new System.Drawing.Size(340, 29);
            this.Load += new System.EventHandler(this.UCMSSV_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private System.Windows.Forms.Label lblMSSV;
        private Guna.UI2.WinForms.Guna2VSeparator guna2VSeparator1;
        private System.Windows.Forms.Label lblHoTen;
        private Guna.UI2.WinForms.Guna2VSeparator guna2VSeparator2;
        private Guna.UI2.WinForms.Guna2ImageButton btnXoa;
    }
}
