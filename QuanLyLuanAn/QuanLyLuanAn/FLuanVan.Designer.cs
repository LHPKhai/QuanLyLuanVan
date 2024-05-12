namespace QuanLyLuanAn
{
    partial class FLuanVan
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
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.flpDanhSachDeTai = new System.Windows.Forms.FlowLayoutPanel();
            this.cbSLsv = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnTimKiem = new Guna.UI2.WinForms.Guna2Button();
            this.cbGiangVien = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbTheLoai = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbCongNghe = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.btnThem = new Guna.UI2.WinForms.Guna2ImageButton();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.ucThaoTacDeTai = new QuanLyLuanAn.UCThaoTacLuanVan();
            this.guna2CustomGradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 25;
            // 
            // guna2Elipse2
            // 
            this.guna2Elipse2.BorderRadius = 22;
            this.guna2Elipse2.TargetControl = this;
            // 
            // flpDanhSachDeTai
            // 
            this.flpDanhSachDeTai.AutoScroll = true;
            this.flpDanhSachDeTai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(234)))), ((int)(((byte)(238)))));
            this.flpDanhSachDeTai.Location = new System.Drawing.Point(1, 62);
            this.flpDanhSachDeTai.Margin = new System.Windows.Forms.Padding(2);
            this.flpDanhSachDeTai.Name = "flpDanhSachDeTai";
            this.flpDanhSachDeTai.Size = new System.Drawing.Size(972, 550);
            this.flpDanhSachDeTai.TabIndex = 12;       
            // 
            // cbSLsv
            // 
            this.cbSLsv.BackColor = System.Drawing.Color.Transparent;
            this.cbSLsv.BorderColor = System.Drawing.Color.Transparent;
            this.cbSLsv.BorderRadius = 16;
            this.cbSLsv.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbSLsv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSLsv.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.cbSLsv.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbSLsv.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbSLsv.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.cbSLsv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbSLsv.ItemHeight = 30;
            this.cbSLsv.Items.AddRange(new object[] {
            "Số lượng sinh viên",
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cbSLsv.Location = new System.Drawing.Point(266, 15);
            this.cbSLsv.Name = "cbSLsv";
            this.cbSLsv.Size = new System.Drawing.Size(155, 36);
            this.cbSLsv.StartIndex = 0;
            this.cbSLsv.TabIndex = 17;
            this.cbSLsv.TextOffset = new System.Drawing.Point(2, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.label3.Location = new System.Drawing.Point(17, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 18);
            this.label3.TabIndex = 12;
            this.label3.Text = "Sắp xếp theo:";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BorderColor = System.Drawing.Color.Gray;
            this.btnTimKiem.BorderThickness = 1;
            this.btnTimKiem.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnTimKiem.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.btnTimKiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnTimKiem.Location = new System.Drawing.Point(777, 21);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(98, 28);
            this.btnTimKiem.TabIndex = 13;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // cbGiangVien
            // 
            this.cbGiangVien.BackColor = System.Drawing.Color.Transparent;
            this.cbGiangVien.BorderColor = System.Drawing.Color.Transparent;
            this.cbGiangVien.BorderRadius = 16;
            this.cbGiangVien.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbGiangVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGiangVien.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.cbGiangVien.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbGiangVien.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbGiangVien.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.cbGiangVien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbGiangVien.ItemHeight = 30;
            this.cbGiangVien.Items.AddRange(new object[] {
            "Giảng viên"});
            this.cbGiangVien.Location = new System.Drawing.Point(588, 15);
            this.cbGiangVien.Name = "cbGiangVien";
            this.cbGiangVien.Size = new System.Drawing.Size(155, 36);
            this.cbGiangVien.StartIndex = 0;
            this.cbGiangVien.TabIndex = 14;
            this.cbGiangVien.TextOffset = new System.Drawing.Point(2, 0);
            // 
            // cbTheLoai
            // 
            this.cbTheLoai.BackColor = System.Drawing.Color.Transparent;
            this.cbTheLoai.BorderColor = System.Drawing.Color.Transparent;
            this.cbTheLoai.BorderRadius = 16;
            this.cbTheLoai.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbTheLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTheLoai.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.cbTheLoai.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbTheLoai.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbTheLoai.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.cbTheLoai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbTheLoai.ItemHeight = 30;
            this.cbTheLoai.Items.AddRange(new object[] {
            "Thể loại"});
            this.cbTheLoai.Location = new System.Drawing.Point(105, 15);
            this.cbTheLoai.Name = "cbTheLoai";
            this.cbTheLoai.Size = new System.Drawing.Size(155, 36);
            this.cbTheLoai.StartIndex = 0;
            this.cbTheLoai.TabIndex = 15;
            this.cbTheLoai.TextOffset = new System.Drawing.Point(2, 0);
            // 
            // cbCongNghe
            // 
            this.cbCongNghe.BackColor = System.Drawing.Color.Transparent;
            this.cbCongNghe.BorderColor = System.Drawing.Color.Transparent;
            this.cbCongNghe.BorderRadius = 16;
            this.cbCongNghe.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbCongNghe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCongNghe.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.cbCongNghe.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbCongNghe.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbCongNghe.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.cbCongNghe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbCongNghe.ItemHeight = 30;
            this.cbCongNghe.Items.AddRange(new object[] {
            "Công nghệ"});
            this.cbCongNghe.Location = new System.Drawing.Point(428, 15);
            this.cbCongNghe.Name = "cbCongNghe";
            this.cbCongNghe.Size = new System.Drawing.Size(155, 36);
            this.cbCongNghe.StartIndex = 0;
            this.cbCongNghe.TabIndex = 16;
            this.cbCongNghe.TextOffset = new System.Drawing.Point(2, 0);
            // 
            // guna2CustomGradientPanel1
            // 
            this.guna2CustomGradientPanel1.Controls.Add(this.btnThem);
            this.guna2CustomGradientPanel1.Controls.Add(this.cbCongNghe);
            this.guna2CustomGradientPanel1.Controls.Add(this.cbTheLoai);
            this.guna2CustomGradientPanel1.Controls.Add(this.cbGiangVien);
            this.guna2CustomGradientPanel1.Controls.Add(this.btnTimKiem);
            this.guna2CustomGradientPanel1.Controls.Add(this.label3);
            this.guna2CustomGradientPanel1.Controls.Add(this.cbSLsv);
            this.guna2CustomGradientPanel1.FillColor = System.Drawing.Color.Snow;
            this.guna2CustomGradientPanel1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.guna2CustomGradientPanel1.FillColor3 = System.Drawing.Color.Purple;
            this.guna2CustomGradientPanel1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.guna2CustomGradientPanel1.Location = new System.Drawing.Point(1, -1);
            this.guna2CustomGradientPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            this.guna2CustomGradientPanel1.Size = new System.Drawing.Size(972, 61);
            this.guna2CustomGradientPanel1.TabIndex = 13;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.Transparent;
            this.btnThem.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnThem.HoverState.ImageSize = new System.Drawing.Size(30, 30);
            this.btnThem.Image = global::QuanLyLuanAn.Properties.Resources.them;
            this.btnThem.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnThem.ImageRotate = 0F;
            this.btnThem.ImageSize = new System.Drawing.Size(40, 40);
            this.btnThem.Location = new System.Drawing.Point(901, 0);
            this.btnThem.Name = "btnThem";
            this.btnThem.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnThem.Size = new System.Drawing.Size(56, 46);
            this.btnThem.TabIndex = 21;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // ucThaoTacDeTai
            // 
            this.ucThaoTacDeTai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.ucThaoTacDeTai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucThaoTacDeTai.Location = new System.Drawing.Point(0, 0);
            this.ucThaoTacDeTai.Margin = new System.Windows.Forms.Padding(2);
            this.ucThaoTacDeTai.Name = "ucThaoTacDeTai";
            this.ucThaoTacDeTai.Size = new System.Drawing.Size(974, 610);
            this.ucThaoTacDeTai.TabIndex = 0;
            this.ucThaoTacDeTai.Visible = false;
            // 
            // FLuanVan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(207)))), ((int)(((byte)(239)))));
            this.ClientSize = new System.Drawing.Size(974, 610);
            this.Controls.Add(this.flpDanhSachDeTai);
            this.Controls.Add(this.guna2CustomGradientPanel1);
            this.Controls.Add(this.ucThaoTacDeTai);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FLuanVan";
            this.Text = "v";
            this.Load += new System.EventHandler(this.FDanhSachDeTai_Load);
            this.guna2CustomGradientPanel1.ResumeLayout(false);
            this.guna2CustomGradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse2;
        private System.Windows.Forms.FlowLayoutPanel flpDanhSachDeTai;
        private UCThaoTacLuanVan ucThaoTacDeTai;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
        private Guna.UI2.WinForms.Guna2ImageButton btnThem;
        private Guna.UI2.WinForms.Guna2ComboBox cbCongNghe;
        private Guna.UI2.WinForms.Guna2ComboBox cbTheLoai;
        private Guna.UI2.WinForms.Guna2ComboBox cbGiangVien;
        private Guna.UI2.WinForms.Guna2Button btnTimKiem;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2ComboBox cbSLsv;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}