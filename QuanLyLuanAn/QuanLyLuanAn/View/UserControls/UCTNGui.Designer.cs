namespace QuanLyLuanAn
{
    partial class UCTNGui
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
            this.labelGui = new System.Windows.Forms.Label();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelGui
            // 
            this.labelGui.AutoSize = true;
            this.labelGui.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.labelGui.Location = new System.Drawing.Point(8, 6);
            this.labelGui.Margin = new System.Windows.Forms.Padding(2);
            this.labelGui.MaximumSize = new System.Drawing.Size(225, 0);
            this.labelGui.Name = "labelGui";
            this.labelGui.Padding = new System.Windows.Forms.Padding(2);
            this.labelGui.Size = new System.Drawing.Size(50, 21);
            this.labelGui.TabIndex = 0;
            this.labelGui.Text = "label1";
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Panel2.AutoSize = true;
            this.guna2Panel2.BorderColor = System.Drawing.Color.Black;
            this.guna2Panel2.BorderRadius = 15;
            this.guna2Panel2.BorderThickness = 2;
            this.guna2Panel2.Controls.Add(this.labelGui);
            this.guna2Panel2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.guna2Panel2.Location = new System.Drawing.Point(238, 4);
            this.guna2Panel2.Margin = new System.Windows.Forms.Padding(2);
            this.guna2Panel2.MaximumSize = new System.Drawing.Size(262, 0);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(60, 29);
            this.guna2Panel2.TabIndex = 3;
            // 
            // UCTNGui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.guna2Panel2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UCTNGui";
            this.Size = new System.Drawing.Size(300, 35);
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelGui;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
    }
}
