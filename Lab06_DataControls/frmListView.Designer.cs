namespace Lab06_DataControls
{
    partial class frmListView
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
            this.lblLocTheoKhoa = new System.Windows.Forms.Label();
            this.cboLoc = new System.Windows.Forms.ComboBox();
            this.lvSinhVien = new System.Windows.Forms.ListView();
            this.lblTong = new System.Windows.Forms.Label();
            this.lblChiTiet = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblLocTheoKhoa
            // 
            this.lblLocTheoKhoa.AutoSize = true;
            this.lblLocTheoKhoa.Location = new System.Drawing.Point(191, 15);
            this.lblLocTheoKhoa.Name = "lblLocTheoKhoa";
            this.lblLocTheoKhoa.Size = new System.Drawing.Size(94, 16);
            this.lblLocTheoKhoa.TabIndex = 0;
            this.lblLocTheoKhoa.Text = "Lọc theo khoa:";
            // 
            // cboLoc
            // 
            this.cboLoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoc.FormattingEnabled = true;
            this.cboLoc.Location = new System.Drawing.Point(291, 12);
            this.cboLoc.Name = "cboLoc";
            this.cboLoc.Size = new System.Drawing.Size(121, 24);
            this.cboLoc.TabIndex = 1;
            this.cboLoc.SelectedIndexChanged += new System.EventHandler(this.cboLoc_SelectedIndexChanged);
            // 
            // lvSinhVien
            // 
            this.lvSinhVien.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvSinhVien.FullRowSelect = true;
            this.lvSinhVien.GridLines = true;
            this.lvSinhVien.HideSelection = false;
            this.lvSinhVien.Location = new System.Drawing.Point(12, 50);
            this.lvSinhVien.MultiSelect = false;
            this.lvSinhVien.Name = "lvSinhVien";
            this.lvSinhVien.Size = new System.Drawing.Size(760, 340);
            this.lvSinhVien.TabIndex = 2;
            this.lvSinhVien.UseCompatibleStateImageBehavior = false;
            this.lvSinhVien.View = System.Windows.Forms.View.Details;
            this.lvSinhVien.SelectedIndexChanged += new System.EventHandler(this.lvSinhVien_SelectedIndexChanged);
            // 
            // lblTong
            // 
            this.lblTong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTong.AutoSize = true;
            this.lblTong.Location = new System.Drawing.Point(99, 407);
            this.lblTong.Name = "lblTong";
            this.lblTong.Size = new System.Drawing.Size(92, 16);
            this.lblTong.TabIndex = 3;
            this.lblTong.Text = "Số sinh viên: 0";
            // 
            // lblChiTiet
            // 
            this.lblChiTiet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblChiTiet.AutoSize = true;
            this.lblChiTiet.Location = new System.Drawing.Point(99, 437);
            this.lblChiTiet.Name = "lblChiTiet";
            this.lblChiTiet.Size = new System.Drawing.Size(184, 16);
            this.lblChiTiet.TabIndex = 4;
            this.lblChiTiet.Text = "Chọn một dòng để xem chi tiết";
            // 
            // frmListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 473);
            this.Controls.Add(this.lblChiTiet);
            this.Controls.Add(this.lblTong);
            this.Controls.Add(this.lvSinhVien);
            this.Controls.Add(this.cboLoc);
            this.Controls.Add(this.lblLocTheoKhoa);
            this.Name = "frmListView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách sinh viên (ListView)";
            this.Load += new System.EventHandler(this.frmListView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLocTheoKhoa;
        private System.Windows.Forms.ComboBox cboLoc;
        private System.Windows.Forms.ListView lvSinhVien;
        private System.Windows.Forms.Label lblTong;
        private System.Windows.Forms.Label lblChiTiet;
    }
}