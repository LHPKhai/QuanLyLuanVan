namespace QuanLyLuanAn
{
    partial class UCGVChamDiem1
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
            this.txtTen = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtDiem = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnXoa = new Guna.UI2.WinForms.Guna2ImageButton();
            this.SuspendLayout();
            // 
            // txtTen
            // 
            this.txtTen.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTen.DefaultText = "Ten GV";
            this.txtTen.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTen.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTen.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTen.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTen.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTen.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTen.ForeColor = System.Drawing.Color.Black;
            this.txtTen.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTen.Location = new System.Drawing.Point(2, 3);
            this.txtTen.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtTen.Name = "txtTen";
            this.txtTen.PasswordChar = '\0';
            this.txtTen.PlaceholderText = "";
            this.txtTen.ReadOnly = true;
            this.txtTen.SelectedText = "";
            this.txtTen.Size = new System.Drawing.Size(235, 39);
            this.txtTen.TabIndex = 0;
            // 
            // txtDiem
            // 
            this.txtDiem.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDiem.DefaultText = "10";
            this.txtDiem.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDiem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDiem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDiem.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDiem.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDiem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDiem.ForeColor = System.Drawing.Color.Black;
            this.txtDiem.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDiem.Location = new System.Drawing.Point(258, 3);
            this.txtDiem.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtDiem.Name = "txtDiem";
            this.txtDiem.PasswordChar = '\0';
            this.txtDiem.PlaceholderText = "";
            this.txtDiem.ReadOnly = true;
            this.txtDiem.SelectedText = "";
            this.txtDiem.Size = new System.Drawing.Size(37, 39);
            this.txtDiem.TabIndex = 0;
            this.txtDiem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDiem.TextChanged += new System.EventHandler(this.txtDiem_TextChanged);
            // 
            // btnXoa
            // 
            this.btnXoa.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnXoa.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnXoa.Image = global::QuanLyLuanAn.Properties.Resources.xoa_2;
            this.btnXoa.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnXoa.ImageRotate = 0F;
            this.btnXoa.ImageSize = new System.Drawing.Size(30, 30);
            this.btnXoa.Location = new System.Drawing.Point(300, 3);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnXoa.Size = new System.Drawing.Size(43, 39);
            this.btnXoa.TabIndex = 1;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // UCGVChamDiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.txtDiem);
            this.Controls.Add(this.txtTen);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UCGVChamDiem";
            this.Size = new System.Drawing.Size(347, 60);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox txtTen;
        private Guna.UI2.WinForms.Guna2TextBox txtDiem;
        private Guna.UI2.WinForms.Guna2ImageButton btnXoa;
    }
}
