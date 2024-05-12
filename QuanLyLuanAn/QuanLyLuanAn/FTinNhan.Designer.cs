namespace QuanLyLuanAn
{
    partial class FTinNhan
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.btnTinNhan = new Guna.UI2.WinForms.Guna2GradientButton();
            this.GunaTab = new Guna.UI2.WinForms.Guna2TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgvTinNhanDen = new Guna.UI2.WinForms.Guna2DataGridView();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.dgvTinNhanDaGui = new Guna.UI2.WinForms.Guna2DataGridView();
            this.GunaTab.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTinNhanDen)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTinNhanDaGui)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 25;
            // 
            // btnTinNhan
            // 
            this.btnTinNhan.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTinNhan.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTinNhan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTinNhan.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTinNhan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTinNhan.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnTinNhan.FillColor2 = System.Drawing.Color.Violet;
            this.btnTinNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnTinNhan.ForeColor = System.Drawing.Color.White;
            this.btnTinNhan.Location = new System.Drawing.Point(241, 658);
            this.btnTinNhan.Name = "btnTinNhan";
            this.btnTinNhan.Size = new System.Drawing.Size(954, 45);
            this.btnTinNhan.TabIndex = 12;
            this.btnTinNhan.Text = "+ Tin Nhắn Mới";
            this.btnTinNhan.Click += new System.EventHandler(this.btnTinNhan_Click);
            // 
            // GunaTab
            // 
            this.GunaTab.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.GunaTab.Controls.Add(this.tabPage3);
            this.GunaTab.Controls.Add(this.tabPage5);
            this.GunaTab.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GunaTab.ItemSize = new System.Drawing.Size(180, 40);
            this.GunaTab.Location = new System.Drawing.Point(-6, -3);
            this.GunaTab.Name = "GunaTab";
            this.GunaTab.SelectedIndex = 0;
            this.GunaTab.Size = new System.Drawing.Size(1370, 655);
            this.GunaTab.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.GunaTab.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.GunaTab.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.GunaTab.TabButtonHoverState.ForeColor = System.Drawing.Color.White;
            this.GunaTab.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.GunaTab.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
            this.GunaTab.TabButtonIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.GunaTab.TabButtonIdleState.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GunaTab.TabButtonIdleState.ForeColor = System.Drawing.Color.Black;
            this.GunaTab.TabButtonIdleState.InnerColor = System.Drawing.Color.AliceBlue;
            this.GunaTab.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
            this.GunaTab.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.GunaTab.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.GunaTab.TabButtonSelectedState.ForeColor = System.Drawing.Color.White;
            this.GunaTab.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.GunaTab.TabButtonSize = new System.Drawing.Size(180, 40);
            this.GunaTab.TabIndex = 13;
            this.GunaTab.TabMenuBackColor = System.Drawing.Color.LightPink;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.White;
            this.tabPage3.Controls.Add(this.dgvTinNhanDen);
            this.tabPage3.ForeColor = System.Drawing.Color.White;
            this.tabPage3.Location = new System.Drawing.Point(184, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage3.Size = new System.Drawing.Size(1182, 647);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Tin nhắn đến";
            // 
            // dgvTinNhanDen
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvTinNhanDen.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTinNhanDen.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTinNhanDen.ColumnHeadersHeight = 28;
            this.dgvTinNhanDen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTinNhanDen.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTinNhanDen.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTinNhanDen.Location = new System.Drawing.Point(3, 3);
            this.dgvTinNhanDen.Name = "dgvTinNhanDen";
            this.dgvTinNhanDen.RowHeadersVisible = false;
            this.dgvTinNhanDen.RowHeadersWidth = 62;
            this.dgvTinNhanDen.RowTemplate.Height = 28;
            this.dgvTinNhanDen.Size = new System.Drawing.Size(1078, 628);
            this.dgvTinNhanDen.TabIndex = 2;
            this.dgvTinNhanDen.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvTinNhanDen.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvTinNhanDen.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvTinNhanDen.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvTinNhanDen.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvTinNhanDen.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvTinNhanDen.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTinNhanDen.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvTinNhanDen.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvTinNhanDen.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTinNhanDen.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvTinNhanDen.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvTinNhanDen.ThemeStyle.HeaderStyle.Height = 28;
            this.dgvTinNhanDen.ThemeStyle.ReadOnly = false;
            this.dgvTinNhanDen.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvTinNhanDen.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTinNhanDen.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTinNhanDen.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvTinNhanDen.ThemeStyle.RowsStyle.Height = 28;
            this.dgvTinNhanDen.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTinNhanDen.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvTinNhanDen.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTinNhanDen_CellContentClick);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.dgvTinNhanDaGui);
            this.tabPage5.Location = new System.Drawing.Point(184, 4);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage5.Size = new System.Drawing.Size(1182, 647);
            this.tabPage5.TabIndex = 2;
            this.tabPage5.Text = "Tin nhắn đã gửi";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // dgvTinNhanDaGui
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dgvTinNhanDaGui.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTinNhanDaGui.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvTinNhanDaGui.ColumnHeadersHeight = 28;
            this.dgvTinNhanDaGui.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTinNhanDaGui.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvTinNhanDaGui.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTinNhanDaGui.Location = new System.Drawing.Point(6, 0);
            this.dgvTinNhanDaGui.Name = "dgvTinNhanDaGui";
            this.dgvTinNhanDaGui.RowHeadersVisible = false;
            this.dgvTinNhanDaGui.RowHeadersWidth = 62;
            this.dgvTinNhanDaGui.RowTemplate.Height = 28;
            this.dgvTinNhanDaGui.Size = new System.Drawing.Size(1176, 641);
            this.dgvTinNhanDaGui.TabIndex = 3;
            this.dgvTinNhanDaGui.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvTinNhanDaGui.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvTinNhanDaGui.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvTinNhanDaGui.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvTinNhanDaGui.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvTinNhanDaGui.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvTinNhanDaGui.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTinNhanDaGui.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvTinNhanDaGui.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvTinNhanDaGui.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTinNhanDaGui.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvTinNhanDaGui.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvTinNhanDaGui.ThemeStyle.HeaderStyle.Height = 28;
            this.dgvTinNhanDaGui.ThemeStyle.ReadOnly = false;
            this.dgvTinNhanDaGui.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvTinNhanDaGui.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTinNhanDaGui.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTinNhanDaGui.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvTinNhanDaGui.ThemeStyle.RowsStyle.Height = 28;
            this.dgvTinNhanDaGui.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTinNhanDaGui.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvTinNhanDaGui.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTinNhanDaGui_CellContentClick);
            // 
            // FTinNhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 709);
            this.Controls.Add(this.GunaTab);
            this.Controls.Add(this.btnTinNhan);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FTinNhan";
            this.Text = "FTinNhan";
            this.Load += new System.EventHandler(this.FTinNhan_Load);
            this.GunaTab.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTinNhanDen)).EndInit();
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTinNhanDaGui)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2GradientButton btnTinNhan;
        private Guna.UI2.WinForms.Guna2TabControl GunaTab;
        private System.Windows.Forms.TabPage tabPage3;
        private Guna.UI2.WinForms.Guna2DataGridView dgvTinNhanDen;
        private System.Windows.Forms.TabPage tabPage5;
        private Guna.UI2.WinForms.Guna2DataGridView dgvTinNhanDaGui;
    }
}