using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLNSTL
{
    public partial class fmQLNSTL : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public fmQLNSTL()
        {
            InitializeComponent();
        }
        public string nguoidung;
        public int manager = -1;

        public void User(bool e, int manager)
        {
            if (manager == -1)
            {
                btnDangnhap.Enabled = e;
                btnDoimatkhau.Enabled = !e;
                btnPhanquyen.Enabled = !e;
                btnDangxuat.Enabled = !e;
                rbpQLNS.Visible = false;
                rbpQLTL.Visible = false;
                rbpBaocao.Visible = false;
            }
            if (manager == 0)
            {
                btnDangnhap.Enabled = !e;
                btnDoimatkhau.Enabled = e;
                btnPhanquyen.Enabled = e;
                btnDangxuat.Enabled = e;
                rbpQLNS.Visible = true;
                rbpQLTL.Visible = true;
                rbpBaocao.Visible = true;
            }
            if (manager == 1)
            {
                btnDangnhap.Enabled = !e;
                btnDoimatkhau.Enabled = e;
                btnPhanquyen.Enabled = !e;
                btnDangxuat.Enabled = e;
                rbpQLNS.Visible = true;
                rbpQLTL.Visible = false;
                rbpBaocao.Visible = true;
            }
            if (manager == 2)
            {
                btnDangnhap.Enabled = !e;
                btnDoimatkhau.Enabled = e;
                btnPhanquyen.Enabled = !e;
                btnDangxuat.Enabled = e;
                rbpQLNS.Visible = false;
                rbpQLTL.Visible = true;
                rbpBaocao.Visible = true;
            }
        }

        //Gán phông cho phần mềm
        public void skin()
        {
            DevExpress.LookAndFeel.DefaultLookAndFeel themes = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            themes.LookAndFeel.SkinName = "Office 2007 Blue";
        }

        //Kiểm tra Form con
        private bool ExistForm(Form form)
        {
            foreach (var child in MdiChildren)
            {
                if (child.Name == form.Name)
                {
                    child.Activate();
                    return true;
                }
                else
                {
                    child.Close();
                }
            }
            return false;
        }

        private void fmQLNSTL_Load(object sender, EventArgs e)
        {
            skin();
            User(true, manager);
        }

        private void btnTTNS_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var form = new fmThongtinnhansu();
            if (ExistForm(form)) return;
            form.MdiParent = this;
            form.Show();
        }

        private void btnPhongban_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var form = new fmPhongban();
            if (ExistForm(form)) return;
            form.MdiParent = this;
            form.Show();
        }

        private void btnChucvu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var form = new fmChucvu();
            if (ExistForm(form)) return;
            form.MdiParent = this;
            form.Show();
        }

        private void btnBoiduong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var form = new fmBoiduong();
            if (ExistForm(form)) return;
            form.MdiParent = this;
            form.Show();
        }

        private void btnChamcong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var form = new fmChamcong();
            if (ExistForm(form)) return;
            form.MdiParent = this;
            form.Show();
        }

        private void btnTamung_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var form = new fmTamung();
            if (ExistForm(form)) return;
            form.MdiParent = this;
            form.Show();
        }

        private void btnHinhthuc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var form = new fmKTKL();
            if (ExistForm(form)) return;
            form.MdiParent = this;
            form.Show();
        }

        private void btnLuongcanhan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var form = new fmLuongcanhan();
            if (ExistForm(form)) return;
            form.MdiParent = this;
            form.Show();
        }

        private void btnBH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var form = new fmBaohiem();
            if (ExistForm(form)) return;
            form.MdiParent = this;
            form.Show();
        }

        private void btnLuongthang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var form = new fmLuongthang();
            if (ExistForm(form)) return;
            form.MdiParent = this;
            form.Show();
        }

        private void btnDangnhap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Hide();
            fmDangnhap login = new fmDangnhap();
            login.ShowDialog();
        }

        private void btnDangxuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (var form in MdiChildren)
            {
                form.Close();
            }
            manager = -1;
            User(true, manager);
        }

        private void btnDoimatkhau_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var form = new fmDoimatkhau();
            form.nguoidung = nguoidung;
            if (ExistForm(form)) return;
            form.MdiParent = this;
            form.Show();
        }

        private void btnPhanquyen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var form = new fmPhanquyen();
            if (ExistForm(form)) return;
            form.MdiParent = this;
            form.Show();
        }

        private void btnBaocao_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var form = new fmBaocaoQLNS();
            if (ExistForm(form)) return;
            form.MdiParent = this;
            form.Show();
        }
    }
}
