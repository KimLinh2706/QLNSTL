namespace QLNSTL
{
    partial class fmChucvu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmChucvu));
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.LVCV = new System.Windows.Forms.ListView();
            this.clmMacv = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmTenCV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmSoluong = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LVPCCV = new System.Windows.Forms.ListView();
            this.clmManv = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmTenNV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmChucvu = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnHuyTKCV = new DevExpress.XtraEditors.SimpleButton();
            this.btnTimkem = new DevExpress.XtraEditors.SimpleButton();
            this.txtMaCVTK = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.btnHuytimkiem = new DevExpress.XtraEditors.SimpleButton();
            this.btnTimkiemNVCV = new DevExpress.XtraEditors.SimpleButton();
            this.txtSoluong = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btnOut = new DevExpress.XtraEditors.SimpleButton();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.txtTencv = new DevExpress.XtraEditors.TextEdit();
            this.txtMacv = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaCVTK.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoluong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTencv.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMacv.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(494, 9);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(194, 40);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Bảng chức vụ";
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1182, 58);
            this.panelControl1.TabIndex = 4;
            // 
            // LVCV
            // 
            this.LVCV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LVCV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmMacv,
            this.clmTenCV,
            this.clmSoluong});
            this.LVCV.FullRowSelect = true;
            this.LVCV.GridLines = true;
            this.LVCV.HideSelection = false;
            this.LVCV.Location = new System.Drawing.Point(470, 64);
            this.LVCV.Name = "LVCV";
            this.LVCV.Size = new System.Drawing.Size(700, 264);
            this.LVCV.TabIndex = 6;
            this.LVCV.UseCompatibleStateImageBehavior = false;
            this.LVCV.View = System.Windows.Forms.View.Details;
            this.LVCV.SelectedIndexChanged += new System.EventHandler(this.LVCV_SelectedIndexChanged);
            // 
            // clmMacv
            // 
            this.clmMacv.Text = "Mã chức vụ";
            this.clmMacv.Width = 100;
            // 
            // clmTenCV
            // 
            this.clmTenCV.Text = "Tên chức vụ";
            this.clmTenCV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clmTenCV.Width = 200;
            // 
            // clmSoluong
            // 
            this.clmSoluong.Text = "Số lương";
            this.clmSoluong.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clmSoluong.Width = 150;
            // 
            // LVPCCV
            // 
            this.LVPCCV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LVPCCV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmManv,
            this.clmTenNV,
            this.clmChucvu});
            this.LVPCCV.FullRowSelect = true;
            this.LVPCCV.GridLines = true;
            this.LVPCCV.HideSelection = false;
            this.LVPCCV.Location = new System.Drawing.Point(470, 334);
            this.LVPCCV.Name = "LVPCCV";
            this.LVPCCV.Size = new System.Drawing.Size(700, 207);
            this.LVPCCV.TabIndex = 7;
            this.LVPCCV.UseCompatibleStateImageBehavior = false;
            this.LVPCCV.View = System.Windows.Forms.View.Details;
            // 
            // clmManv
            // 
            this.clmManv.Text = "Mã nhân viên";
            this.clmManv.Width = 100;
            // 
            // clmTenNV
            // 
            this.clmTenNV.Text = "Tên nhân viên";
            this.clmTenNV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clmTenNV.Width = 200;
            // 
            // clmChucvu
            // 
            this.clmChucvu.Text = "Tên chức vụ";
            this.clmChucvu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clmChucvu.Width = 200;
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupControl1.Controls.Add(this.btnHuyTKCV);
            this.groupControl1.Controls.Add(this.btnTimkem);
            this.groupControl1.Controls.Add(this.txtMaCVTK);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.btnHuytimkiem);
            this.groupControl1.Controls.Add(this.btnTimkiemNVCV);
            this.groupControl1.Controls.Add(this.txtSoluong);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.btnOut);
            this.groupControl1.Controls.Add(this.btnClear);
            this.groupControl1.Controls.Add(this.btnDelete);
            this.groupControl1.Controls.Add(this.btnEdit);
            this.groupControl1.Controls.Add(this.btnAdd);
            this.groupControl1.Controls.Add(this.txtTencv);
            this.groupControl1.Controls.Add(this.txtMacv);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(12, 64);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(452, 477);
            this.groupControl1.TabIndex = 8;
            this.groupControl1.Text = "Thông tin chức vụ";
            // 
            // btnHuyTKCV
            // 
            this.btnHuyTKCV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHuyTKCV.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuyTKCV.Appearance.Options.UseFont = true;
            this.btnHuyTKCV.Location = new System.Drawing.Point(321, 329);
            this.btnHuyTKCV.Name = "btnHuyTKCV";
            this.btnHuyTKCV.Size = new System.Drawing.Size(118, 39);
            this.btnHuyTKCV.TabIndex = 24;
            this.btnHuyTKCV.Text = "Hủy";
            this.btnHuyTKCV.Click += new System.EventHandler(this.btnHuyTKCV_Click);
            // 
            // btnTimkem
            // 
            this.btnTimkem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTimkem.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimkem.Appearance.Options.UseFont = true;
            this.btnTimkem.Location = new System.Drawing.Point(197, 329);
            this.btnTimkem.Name = "btnTimkem";
            this.btnTimkem.Size = new System.Drawing.Size(118, 39);
            this.btnTimkem.TabIndex = 23;
            this.btnTimkem.Text = "Tìm Kiếm";
            this.btnTimkem.Click += new System.EventHandler(this.btnTimkem_Click);
            // 
            // txtMaCVTK
            // 
            this.txtMaCVTK.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaCVTK.Location = new System.Drawing.Point(138, 295);
            this.txtMaCVTK.Name = "txtMaCVTK";
            // 
            // 
            // 
            this.txtMaCVTK.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaCVTK.Properties.Appearance.Options.UseFont = true;
            this.txtMaCVTK.Size = new System.Drawing.Size(301, 28);
            this.txtMaCVTK.TabIndex = 22;
            // 
            // labelControl5
            // 
            this.labelControl5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(25, 297);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(107, 24);
            this.labelControl5.TabIndex = 21;
            this.labelControl5.Text = "Mã chức vụ:";
            // 
            // btnHuytimkiem
            // 
            this.btnHuytimkiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHuytimkiem.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuytimkiem.Appearance.Options.UseFont = true;
            this.btnHuytimkiem.Location = new System.Drawing.Point(25, 433);
            this.btnHuytimkiem.Name = "btnHuytimkiem";
            this.btnHuytimkiem.Size = new System.Drawing.Size(414, 39);
            this.btnHuytimkiem.TabIndex = 20;
            this.btnHuytimkiem.Text = "Hủy Tìm kiếm nhân viên";
            this.btnHuytimkiem.Click += new System.EventHandler(this.btnHuytimkiem_Click);
            // 
            // btnTimkiemNVCV
            // 
            this.btnTimkiemNVCV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTimkiemNVCV.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimkiemNVCV.Appearance.Options.UseFont = true;
            this.btnTimkiemNVCV.Location = new System.Drawing.Point(25, 388);
            this.btnTimkiemNVCV.Name = "btnTimkiemNVCV";
            this.btnTimkiemNVCV.Size = new System.Drawing.Size(414, 39);
            this.btnTimkiemNVCV.TabIndex = 19;
            this.btnTimkiemNVCV.Text = "Tìm kiếm nhân viên nhân chức vụ";
            this.btnTimkiemNVCV.Click += new System.EventHandler(this.btnTimkiemNVCV_Click);
            // 
            // txtSoluong
            // 
            this.txtSoluong.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSoluong.Enabled = false;
            this.txtSoluong.Location = new System.Drawing.Point(195, 131);
            this.txtSoluong.Name = "txtSoluong";
            // 
            // 
            // 
            this.txtSoluong.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoluong.Properties.Appearance.Options.UseFont = true;
            this.txtSoluong.Size = new System.Drawing.Size(215, 28);
            this.txtSoluong.TabIndex = 12;
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(25, 133);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(85, 24);
            this.labelControl3.TabIndex = 11;
            this.labelControl3.Text = "Số lượng:";
            // 
            // btnOut
            // 
            this.btnOut.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOut.Appearance.Options.UseFont = true;
            this.btnOut.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOut.ImageOptions.Image")));
            this.btnOut.Location = new System.Drawing.Point(249, 225);
            this.btnOut.Name = "btnOut";
            this.btnOut.Size = new System.Drawing.Size(124, 39);
            this.btnOut.TabIndex = 10;
            this.btnOut.Text = "Thoát";
            this.btnOut.Click += new System.EventHandler(this.btnOut_Click);
            // 
            // btnClear
            // 
            this.btnClear.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Appearance.Options.UseFont = true;
            this.btnClear.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.ImageOptions.Image")));
            this.btnClear.Location = new System.Drawing.Point(92, 225);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(124, 39);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "Hũy";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Appearance.Options.UseFont = true;
            this.btnDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.ImageOptions.Image")));
            this.btnDelete.Location = new System.Drawing.Point(315, 180);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(124, 39);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Appearance.Options.UseFont = true;
            this.btnEdit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.ImageOptions.Image")));
            this.btnEdit.Location = new System.Drawing.Point(170, 180);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(124, 39);
            this.btnEdit.TabIndex = 7;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Appearance.Options.UseFont = true;
            this.btnAdd.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.ImageOptions.Image")));
            this.btnAdd.Location = new System.Drawing.Point(25, 180);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(124, 39);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtTencv
            // 
            this.txtTencv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTencv.Location = new System.Drawing.Point(195, 86);
            this.txtTencv.Name = "txtTencv";
            // 
            // 
            // 
            this.txtTencv.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTencv.Properties.Appearance.Options.UseFont = true;
            this.txtTencv.Size = new System.Drawing.Size(215, 28);
            this.txtTencv.TabIndex = 4;
            // 
            // txtMacv
            // 
            this.txtMacv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMacv.Location = new System.Drawing.Point(195, 41);
            this.txtMacv.Name = "txtMacv";
            // 
            // 
            // 
            this.txtMacv.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMacv.Properties.Appearance.Options.UseFont = true;
            this.txtMacv.Size = new System.Drawing.Size(215, 28);
            this.txtMacv.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(25, 88);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(115, 24);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Tên chức vụ:";
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(25, 43);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(107, 24);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Mã chức vụ:";
            // 
            // fmChucvu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 553);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.LVPCCV);
            this.Controls.Add(this.LVCV);
            this.Controls.Add(this.panelControl1);
            this.Name = "fmChucvu";
            this.Text = "Chức vụ";
            this.Load += new System.EventHandler(this.fmChucvu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaCVTK.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoluong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTencv.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMacv.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.ListView LVCV;
        private System.Windows.Forms.ColumnHeader clmMacv;
        private System.Windows.Forms.ColumnHeader clmTenCV;
        private System.Windows.Forms.ColumnHeader clmSoluong;
        private System.Windows.Forms.ListView LVPCCV;
        private System.Windows.Forms.ColumnHeader clmManv;
        private System.Windows.Forms.ColumnHeader clmTenNV;
        private System.Windows.Forms.ColumnHeader clmChucvu;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnOut;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.TextEdit txtTencv;
        private DevExpress.XtraEditors.TextEdit txtMacv;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtSoluong;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton btnTimkiemNVCV;
        private DevExpress.XtraEditors.SimpleButton btnHuytimkiem;
        private DevExpress.XtraEditors.SimpleButton btnTimkem;
        private DevExpress.XtraEditors.TextEdit txtMaCVTK;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SimpleButton btnHuyTKCV;
    }
}