namespace Lab06_DataControls
{
    partial class frmKhoa
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
            this.lstKhoa = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstKhoa
            // 
            this.lstKhoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstKhoa.FormattingEnabled = true;
            this.lstKhoa.ItemHeight = 16;
            this.lstKhoa.Location = new System.Drawing.Point(0, 0);
            this.lstKhoa.Name = "lstKhoa";
            this.lstKhoa.Size = new System.Drawing.Size(800, 450);
            this.lstKhoa.TabIndex = 0;
            this.lstKhoa.SelectedIndexChanged += new System.EventHandler(this.lstKhoa_SelectedIndexChanged);
            // 
            // frmKhoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lstKhoa);
            this.Name = "frmKhoa";
            this.Text = "Danh sách khoa";
            this.Load += new System.EventHandler(this.frmKhoa_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstKhoa;
    }
}