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
    public partial class fmDangnhap : DevExpress.XtraEditors.XtraForm
    {
        QLNSTLEntities db = new QLNSTLEntities();
        public fmDangnhap()
        {
            InitializeComponent();
        }

        private void btnAllow_Click(object sender, EventArgs e)
        {
            if (txtTendangnhap.Text == "" || txtMatkhau.Text == "")
            {
                XtraMessageBox.Show("Bạn chưa nhập Tên Đăng Nhập hoặc Mật Khẩu!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            else
            {
                var tk = db.TAIKHOANs.SingleOrDefault(x => x.TENDANGNHAP == txtTendangnhap.Text && x.MATKHAU == txtMatkhau.Text);
                if (tk != null)
                {
                    fmQLNSTL form = new fmQLNSTL();
                    form.nguoidung = tk.TENDANGNHAP;
                    form.manager = tk.TYPE;
                    XtraMessageBox.Show("Đăng nhập thành công.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    form.Show();
                    this.Hide();
                }
                else
                {
                    XtraMessageBox.Show("Tài khoản không đúng!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            fmQLNSTL Main = new fmQLNSTL();
            Main.Show();
            this.Close();
        }
    }
}