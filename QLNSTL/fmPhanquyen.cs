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
    public partial class fmPhanquyen : DevExpress.XtraEditors.XtraForm
    {
        QLNSTLEntities db = new QLNSTLEntities();
        public fmPhanquyen()
        {
            InitializeComponent();
        }

        public void cboItems()
        {
            cboPhanQuyen.Items.Clear();
            cboPhanQuyen.Items.Add("Quản trị viên");
            cboPhanQuyen.Items.Add("Quản lý nhân sự");
            cboPhanQuyen.Items.Add("Quản lý tiền lương");
        }

        public int? ID;
        public void clearfm()
        {
            txtTennguoidung.Text = "";
            txtMatkhau.Text = "";
            txtTendangnhap.Text = "";
            cboPhanQuyen.SelectedIndex = -1;
            ID = null;
        }

        private void fmPhanquyen_Load(object sender, EventArgs e)
        {
            clearfm();
            cboItems();
            List<TAIKHOAN> tk = db.TAIKHOANs.ToList();
            LVTK.Items.Clear();
            int i = 0;
            foreach (var item in tk)
            {
                LVTK.Items.Add(item.MATK.ToString());
                LVTK.Items[i].SubItems.Add(item.TENNGUOIDUNG);
                LVTK.Items[i].SubItems.Add(item.TENDANGNHAP);
                LVTK.Items[i].SubItems.Add(item.MATKHAU);
                if (item.TYPE == 0)
                {
                    LVTK.Items[i].SubItems.Add("Quản trị viên");
                }
                if (item.TYPE == 1)
                {
                    LVTK.Items[i].SubItems.Add("Quản lý nhân sự");
                }
                if (item.TYPE == 2)
                {
                    LVTK.Items[i].SubItems.Add("Quản lý tiền lương");
                }
                else
                {
                    LVTK.Items[i].SubItems.Add("Đợi phân quyền");
                }
                i++;
            }
        }

        private void LVTK_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView lv = sender as ListView;
            if (lv.SelectedItems.Count == 1)
            {
                ID = int.Parse(lv.SelectedItems[0].SubItems[0].Text);
                txtTennguoidung.Text = lv.SelectedItems[0].SubItems[1].Text;
                txtTendangnhap.Text = lv.SelectedItems[0].SubItems[2].Text;
                txtMatkhau.Text = lv.SelectedItems[0].SubItems[3].Text; ;
                TAIKHOAN tk = db.TAIKHOANs.Find(ID);
                if (tk.TYPE == 0)
                {
                    cboPhanQuyen.SelectedIndex = 0;
                }
                else if (tk.TYPE == 1)
                {
                    cboPhanQuyen.SelectedIndex = 1;
                }
                else if (tk.TYPE == 2)
                {
                    cboPhanQuyen.SelectedIndex = 2;
                }
                else
                {
                    cboPhanQuyen.SelectedIndex = -1;
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (ID == null)
            {
                MessageBox.Show("Bạn chưa chọn tài khoản để sửa!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            else
            {
                TAIKHOAN tk = db.TAIKHOANs.Find(ID);
                tk.TENNGUOIDUNG = txtTennguoidung.Text;
                tk.TENDANGNHAP = txtTendangnhap.Text;
                tk.MATKHAU = txtMatkhau.Text;
                if (cboPhanQuyen.SelectedIndex == 0)
                {
                    tk.TYPE = 0;
                }
                else if (cboPhanQuyen.SelectedIndex == 1)
                {
                    tk.TYPE = 1;
                }
                else if (cboPhanQuyen.SelectedIndex == 2)
                {
                    tk.TYPE = 2;
                }
                db.SaveChanges();
                MessageBox.Show("Sửa thông tin thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fmPhanquyen_Load(sender, e);
            }
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ID == null)
            {
                MessageBox.Show("Bạn chưa chọn tài khoản để Xóa!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                TAIKHOAN tk = db.TAIKHOANs.Find(ID);
                db.TAIKHOANs.Remove(tk);
                db.SaveChanges();
                MessageBox.Show("Xóa thông tin thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fmPhanquyen_Load(sender, e);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            fmThemtaikhoan form = new fmThemtaikhoan();
            form.ShowDialog();
            fmPhanquyen_Load(sender, e);
        }
    }
}