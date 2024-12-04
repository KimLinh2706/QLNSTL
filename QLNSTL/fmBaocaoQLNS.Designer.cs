namespace QLNSTL
{
    partial class fmBaocaoQLNS
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
            this.btnDSNV = new DevExpress.XtraEditors.SimpleButton();
            this.btnDSNVPB = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cboTenpb = new System.Windows.Forms.ComboBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btnDSNVBD = new DevExpress.XtraEditors.SimpleButton();
            this.txtNam = new DevExpress.XtraEditors.TextEdit();
            this.label8 = new System.Windows.Forms.Label();
            this.cboThang = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNam.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDSNV
            // 
            this.btnDSNV.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDSNV.Appearance.Options.UseFont = true;
            this.btnDSNV.Location = new System.Drawing.Point(12, 12);
            this.btnDSNV.Name = "btnDSNV";
            this.btnDSNV.Size = new System.Drawing.Size(204, 109);
            this.btnDSNV.TabIndex = 0;
            this.btnDSNV.Text = "Danh sách nhân viên";
            this.btnDSNV.Click += new System.EventHandler(this.btnDSNV_Click);
            // 
            // btnDSNVPB
            // 
            this.btnDSNVPB.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDSNVPB.Appearance.Options.UseFont = true;
            this.btnDSNVPB.Location = new System.Drawing.Point(194, 61);
            this.btnDSNVPB.Name = "btnDSNVPB";
            this.btnDSNVPB.Size = new System.Drawing.Size(133, 39);
            this.btnDSNVPB.TabIndex = 1;
            this.btnDSNVPB.Text = "Danh sách";
            this.btnDSNVPB.Click += new System.EventHandler(this.btnDSNVPB_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.cboTenpb);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.btnDSNVPB);
            this.groupControl1.Location = new System.Drawing.Point(222, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(349, 109);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "Thông tin nhân viên phòng ban";
            // 
            // cboTenpb
            // 
            this.cboTenpb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTenpb.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTenpb.FormattingEnabled = true;
            this.cboTenpb.Location = new System.Drawing.Point(113, 28);
            this.cboTenpb.Name = "cboTenpb";
            this.cboTenpb.Size = new System.Drawing.Size(214, 30);
            this.cboTenpb.TabIndex = 3;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(5, 28);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(101, 24);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Phòng ban:";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.btnDSNVBD);
            this.groupControl2.Controls.Add(this.txtNam);
            this.groupControl2.Controls.Add(this.label8);
            this.groupControl2.Controls.Add(this.cboThang);
            this.groupControl2.Controls.Add(this.label7);
            this.groupControl2.Location = new System.Drawing.Point(577, 12);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(534, 109);
            this.groupControl2.TabIndex = 3;
            this.groupControl2.Text = "Thông tin Lương tháng";
            // 
            // btnDSNVBD
            // 
            this.btnDSNVBD.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDSNVBD.Appearance.Options.UseFont = true;
            this.btnDSNVBD.Location = new System.Drawing.Point(385, 28);
            this.btnDSNVBD.Name = "btnDSNVBD";
            this.btnDSNVBD.Size = new System.Drawing.Size(133, 57);
            this.btnDSNVBD.TabIndex = 39;
            this.btnDSNVBD.Text = "Danh sách";
            this.btnDSNVBD.Click += new System.EventHandler(this.btnDSNVBD_Click);
            // 
            // txtNam
            // 
            this.txtNam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtNam.Location = new System.Drawing.Point(259, 52);
            this.txtNam.Name = "txtNam";
            // 
            // 
            // 
            this.txtNam.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNam.Properties.Appearance.Options.UseFont = true;
            this.txtNam.Size = new System.Drawing.Size(105, 28);
            this.txtNam.TabIndex = 38;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(196, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 22);
            this.label8.TabIndex = 37;
            this.label8.Text = "Năm:";
            // 
            // cboThang
            // 
            this.cboThang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboThang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboThang.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboThang.FormattingEnabled = true;
            this.cboThang.Location = new System.Drawing.Point(103, 50);
            this.cboThang.Name = "cboThang";
            this.cboThang.Size = new System.Drawing.Size(70, 30);
            this.cboThang.TabIndex = 36;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(17, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 22);
            this.label7.TabIndex = 35;
            this.label7.Text = "Tháng:";
            // 
            // fmBaocaoQLNS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 553);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.btnDSNV);
            this.Name = "fmBaocaoQLNS";
            this.Text = "Báo cáo - Thống kê";
            this.Load += new System.EventHandler(this.fmBaocaoQLNS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNam.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnDSNV;
        private DevExpress.XtraEditors.SimpleButton btnDSNVPB;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.ComboBox cboTenpb;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton btnDSNVBD;
        private DevExpress.XtraEditors.TextEdit txtNam;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboThang;
        private System.Windows.Forms.Label label7;
    }
}