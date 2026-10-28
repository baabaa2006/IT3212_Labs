namespace Lab06_DataControls
{
    partial class frmTreeView
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
            this.tvKhoa = new System.Windows.Forms.TreeView();
            this.grpChiTiet = new System.Windows.Forms.GroupBox();
            this.lblMa = new System.Windows.Forms.Label();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.lblDiem = new System.Windows.Forms.Label();
            this.lblXepLoai = new System.Windows.Forms.Label();
            this.lblThongBao = new System.Windows.Forms.Label();
            this.grpChiTiet.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvKhoa
            // 
            this.tvKhoa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvKhoa.Location = new System.Drawing.Point(12, 12);
            this.tvKhoa.Name = "tvKhoa";
            this.tvKhoa.Size = new System.Drawing.Size(300, 420);
            this.tvKhoa.TabIndex = 0;
            this.tvKhoa.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvKhoa_AfterSelect);
            // 
            // grpChiTiet
            // 
            this.grpChiTiet.Controls.Add(this.lblXepLoai);
            this.grpChiTiet.Controls.Add(this.lblDiem);
            this.grpChiTiet.Controls.Add(this.lblNgaySinh);
            this.grpChiTiet.Controls.Add(this.lblHoTen);
            this.grpChiTiet.Controls.Add(this.lblMa);
            this.grpChiTiet.Location = new System.Drawing.Point(330, 12);
            this.grpChiTiet.Name = "grpChiTiet";
            this.grpChiTiet.Size = new System.Drawing.Size(400, 256);
            this.grpChiTiet.TabIndex = 1;
            this.grpChiTiet.TabStop = false;
            this.grpChiTiet.Text = "Chi tiết sinh viên";
            // 
            // lblMa
            // 
            this.lblMa.AutoSize = true;
            this.lblMa.Location = new System.Drawing.Point(33, 42);
            this.lblMa.Name = "lblMa";
            this.lblMa.Size = new System.Drawing.Size(50, 16);
            this.lblMa.TabIndex = 0;
            this.lblMa.Text = "Mã SV:";
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Location = new System.Drawing.Point(33, 73);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(49, 16);
            this.lblHoTen.TabIndex = 1;
            this.lblHoTen.Text = "Họ tên:";
            // 
            // lblNgaySinh
            // 
            this.lblNgaySinh.AutoSize = true;
            this.lblNgaySinh.Location = new System.Drawing.Point(33, 104);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(70, 16);
            this.lblNgaySinh.TabIndex = 2;
            this.lblNgaySinh.Text = "Ngày sinh:";
            // 
            // lblDiem
            // 
            this.lblDiem.AutoSize = true;
            this.lblDiem.Location = new System.Drawing.Point(33, 140);
            this.lblDiem.Name = "lblDiem";
            this.lblDiem.Size = new System.Drawing.Size(62, 16);
            this.lblDiem.TabIndex = 3;
            this.lblDiem.Text = "Điểm TB:";
            // 
            // lblXepLoai
            // 
            this.lblXepLoai.AutoSize = true;
            this.lblXepLoai.Location = new System.Drawing.Point(33, 173);
            this.lblXepLoai.Name = "lblXepLoai";
            this.lblXepLoai.Size = new System.Drawing.Size(59, 16);
            this.lblXepLoai.TabIndex = 4;
            this.lblXepLoai.Text = "Xếp loại:";
            // 
            // lblThongBao
            // 
            this.lblThongBao.AutoSize = true;
            this.lblThongBao.Location = new System.Drawing.Point(366, 295);
            this.lblThongBao.Name = "lblThongBao";
            this.lblThongBao.Size = new System.Drawing.Size(168, 16);
            this.lblThongBao.TabIndex = 2;
            this.lblThongBao.Text = "Chọn một sinh viên trên cây";
            // 
            // frmTreeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 433);
            this.Controls.Add(this.lblThongBao);
            this.Controls.Add(this.grpChiTiet);
            this.Controls.Add(this.tvKhoa);
            this.Name = "frmTreeView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cây Khoa - Sinh viên";
            this.Load += new System.EventHandler(this.frmTreeView_Load);
            this.grpChiTiet.ResumeLayout(false);
            this.grpChiTiet.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvKhoa;
        private System.Windows.Forms.GroupBox grpChiTiet;
        private System.Windows.Forms.Label lblXepLoai;
        private System.Windows.Forms.Label lblDiem;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.Label lblMa;
        private System.Windows.Forms.Label lblThongBao;
    }
}