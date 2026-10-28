namespace Lab06_DataControls.GUI
{
    partial class frmListViewIcon
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
            this.lblKieuHienThi = new System.Windows.Forms.Label();
            this.cboKieuXem = new System.Windows.Forms.ComboBox();
            this.lvSinhVien = new System.Windows.Forms.ListView();
            this.lblChuThich = new System.Windows.Forms.Label();
            this.lblTong = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblKieuHienThi
            // 
            this.lblKieuHienThi.AutoSize = true;
            this.lblKieuHienThi.Location = new System.Drawing.Point(263, 9);
            this.lblKieuHienThi.Name = "lblKieuHienThi";
            this.lblKieuHienThi.Size = new System.Drawing.Size(80, 16);
            this.lblKieuHienThi.TabIndex = 0;
            this.lblKieuHienThi.Text = "Kiểu hiển thị:";
            // 
            // cboKieuXem
            // 
            this.cboKieuXem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKieuXem.FormattingEnabled = true;
            this.cboKieuXem.Location = new System.Drawing.Point(370, 6);
            this.cboKieuXem.Name = "cboKieuXem";
            this.cboKieuXem.Size = new System.Drawing.Size(121, 24);
            this.cboKieuXem.TabIndex = 1;
            this.cboKieuXem.SelectedIndexChanged += new System.EventHandler(this.cboKieuXem_SelectedIndexChanged);
            // 
            // lvSinhVien
            // 
            this.lvSinhVien.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvSinhVien.HideSelection = false;
            this.lvSinhVien.Location = new System.Drawing.Point(10, 36);
            this.lvSinhVien.Name = "lvSinhVien";
            this.lvSinhVien.Size = new System.Drawing.Size(760, 340);
            this.lvSinhVien.TabIndex = 2;
            this.lvSinhVien.UseCompatibleStateImageBehavior = false;
            // 
            // lblChuThich
            // 
            this.lblChuThich.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblChuThich.AutoSize = true;
            this.lblChuThich.Location = new System.Drawing.Point(213, 402);
            this.lblChuThich.Name = "lblChuThich";
            this.lblChuThich.Size = new System.Drawing.Size(303, 16);
            this.lblChuThich.TabIndex = 3;
            this.lblChuThich.Text = "S: Xuất sắc   G: Giỏi   K: Khá   T: Trung bình   Y: Yếu";
            // 
            // lblTong
            // 
            this.lblTong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTong.AutoSize = true;
            this.lblTong.Location = new System.Drawing.Point(213, 448);
            this.lblTong.Name = "lblTong";
            this.lblTong.Size = new System.Drawing.Size(39, 16);
            this.lblTong.TabIndex = 4;
            this.lblTong.Text = "Tong";
            // 
            // frmListViewIcon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 473);
            this.Controls.Add(this.lblTong);
            this.Controls.Add(this.lblChuThich);
            this.Controls.Add(this.lvSinhVien);
            this.Controls.Add(this.cboKieuXem);
            this.Controls.Add(this.lblKieuHienThi);
            this.Name = "frmListViewIcon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách sinh viên có biểu tượng";
            this.Load += new System.EventHandler(this.frmListViewIcon_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblKieuHienThi;
        private System.Windows.Forms.ComboBox cboKieuXem;
        private System.Windows.Forms.ListView lvSinhVien;
        private System.Windows.Forms.Label lblChuThich;
        private System.Windows.Forms.Label lblTong;
    }
}