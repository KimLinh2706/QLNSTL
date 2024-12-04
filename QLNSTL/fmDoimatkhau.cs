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
    public partial class fmDoimatkhau : DevExpress.XtraEditors.XtraForm
    {
        QLNSTLEntities db = new QLNSTLEntities();
        public string nguoidung;
        public fmDoimatkhau()
        {
            InitializeComponent();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (txtMatkhaucu.Text == "" || txtMatkhaumoi.Text == "")
            {
                MessageBox.Show("Bạn cần nhập đầy đủ thông tin!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (txtNhaplaimatkhau.Text != txtMatkhaumoi.Text)
                {
                    MessageBox.Show("Mật khẩu nhập lại không khớp!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    TAIKHOAN tk = db.TAIKHOANs.Single(x => x.TENDANGNHAP.Equals(nguoidung));
                    if (tk.MATKHAU == txtMatkhaucu.Text)
                    {
                        tk.MATKHAU = txtMatkhaumoi.Text;
                        db.SaveChanges();
                        MessageBox.Show("Đỗi mật khẩu thành công!!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu cũ không đúng!!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}