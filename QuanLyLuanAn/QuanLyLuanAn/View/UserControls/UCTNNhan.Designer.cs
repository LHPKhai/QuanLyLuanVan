namespace QuanLyLuanAn
{
    partial class UCTNNhan
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
            this.labelNhan = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelNhan
            // 
            this.labelNhan.AutoSize = true;
            this.labelNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.labelNhan.Location = new System.Drawing.Point(10, 9);
            this.labelNhan.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.labelNhan.MaximumSize = new System.Drawing.Size(225, 0);
            this.labelNhan.Name = "labelNhan";
            this.labelNhan.Size = new System.Drawing.Size(46, 17);
            this.labelNhan.TabIndex = 0;
            this.labelNhan.Text = "label1";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.AutoSize = true;
            this.guna2Panel1.BorderColor = System.Drawing.Color.Black;
            this.guna2Panel1.BorderRadius = 15;
            this.guna2Panel1.BorderThickness = 2;
            this.guna2Panel1.Controls.Add(this.labelNhan);
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(181)))), ((int)(((byte)(230)))));
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.guna2Panel1.MaximumSize = new System.Drawing.Size(262, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.guna2Panel1.Size = new System.Drawing.Size(60, 30);
            this.guna2Panel1.TabIndex = 1;
            // 
            // UCTNNhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.guna2Panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "UCTNNhan";
            this.Size = new System.Drawing.Size(300, 32);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNhan;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
    }
}
