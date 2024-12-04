using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace QLNSTL
{
    public partial class fmThemtaikhoan : DevExpress.XtraEditors.XtraForm
    {
        QLNSTLEntities db = new QLNSTLEntities();
        public fmThemtaikhoan()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtTennguoidung.Text == "" || txtMatkhau.Text == "" || txtTendangnhap.Text == "")
            {
                XtraMessageBox.Show("Bạn cần điền đầy đủ thông tin!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            if (txtNhaplaimatkhau.Text != txtMatkhau.Text)
            {
                XtraMessageBox.Show("Mật khẩu nhập lại không khớp!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            string User = txtTendangnhap.Text;
            List<TAIKHOAN> tk = db.TAIKHOANs.Where(x => x.TENDANGNHAP.Equals(User)).ToList();
            if (tk.Count != 0)
            {
                XtraMessageBox.Show("Tài khoản này đã có người đăng ký", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            TAIKHOAN Newtk = new TAIKHOAN();
            Newtk.TENNGUOIDUNG = txtTennguoidung.Text;
            Newtk.TENDANGNHAP = txtTendangnhap.Text;
            Newtk.MATKHAU = txtMatkhau.Text;
            if (cboPhanQuyen.SelectedIndex == 0)
            {
                Newtk.TYPE = 0;
            }
            else if (cboPhanQuyen.SelectedIndex == 1)
            {
                Newtk.TYPE = 1;
            }
            else if (cboPhanQuyen.SelectedIndex == 2)
            {
                Newtk.TYPE = 2;
            }
            db.TAIKHOANs.Add(Newtk);
            db.SaveChanges();
            XtraMessageBox.Show("Đăng ký thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void fmThemtaikhoan_Load(object sender, EventArgs e)
        {
            cboPhanQuyen.Items.Add("Quản trị viên");
            cboPhanQuyen.Items.Add("Quản lý nhân sự");
            cboPhanQuyen.Items.Add("Quản lý tiền lương");
            cboPhanQuyen.SelectedIndex = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}