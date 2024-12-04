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
    public partial class fmKTKL : DevExpress.XtraEditors.XtraForm
    {
        QLNSTLEntities db = new QLNSTLEntities();
        public fmKTKL()
        {
            InitializeComponent();
            cbo();
        }

        public void cbo()
        {
            var NV = db.NHANVIENs.ToList();
            cboManv.Items.Clear();
            foreach (var item in NV)
            {
                cboManv.Items.Add(item.MANV);
            }
            cboHinhthuc.Items.Clear();
            cboHinhthuc.Items.Add("Khen thưởng");
            cboHinhthuc.Items.Add("Kỷ luật");
            cboThang.Items.Clear();
            for (int i = 1; i < 13; i++)
            {
                cboThang.Items.Add(i);
            }
        }

        public void LVADD()
        {
            LVKTKL.Items.Clear();
            var KTKL = db.KHENTHUONG_KYLUAT.ToList();
            int i = 0;
            foreach (var item in KTKL)
            {
                NHANVIEN NV = db.NHANVIENs.Find(item.MANV);
                LVKTKL.Items.Add(item.MA.ToString());
                LVKTKL.Items[i].SubItems.Add(item.MANV);
                LVKTKL.Items[i].SubItems.Add(NV.HOTEN);
                LVKTKL.Items[i].SubItems.Add(item.HINHTHUC);
                LVKTKL.Items[i].SubItems.Add(item.SOTIEN.ToString());
                LVKTKL.Items[i].SubItems.Add(item.THOIGIAN.Value.Date.ToShortDateString());
                LVKTKL.Items[i].SubItems.Add(item.LYDO);
                i++;
            }
        }

        public int? ID;

        public void Clear()
        {
            cboManv.SelectedIndex = -1;
            cboHinhthuc.SelectedIndex = -1;
            txtTennv.Text = "";
            dtpTG.Text = "";
            txtTien.Text = "0";
            txtLydo.Text = "";
            ID = null;
        }

        public void KKey(bool e)
        {
            dtpTG.Enabled = e;
            cboManv.Enabled = e;
            btnLuu.Enabled = e;
            btnThem.Enabled = !e;
            btnCapnhat.Enabled = !e;
            btnXoa.Enabled = !e;
        }

        private void fmKTKL_Load(object sender, EventArgs e)
        {
            Clear();
            LVADD();
            KKey(true);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            fmKTKL_Load(sender, e);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (cboManv.SelectedIndex == -1 || cboHinhthuc.SelectedIndex == -1 || txtLydo.Text == "" || txtTien.Text == "")
            {
                XtraMessageBox.Show("Bạn cần điền đầy đủ thông tin.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            KHENTHUONG_KYLUAT KTKL = new KHENTHUONG_KYLUAT();
            KTKL.MANV = cboManv.Text;
            KTKL.HINHTHUC = cboHinhthuc.Text;
            KTKL.SOTIEN = float.Parse(txtTien.Text);
            KTKL.THOIGIAN = dtpTG.Value;
            KTKL.LYDO = txtLydo.Text;
            db.KHENTHUONG_KYLUAT.Add(KTKL);
            db.SaveChanges();
            XtraMessageBox.Show("Thêm thành công.");
            fmKTKL_Load(sender, e);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboManv_SelectedIndexChanged(object sender, EventArgs e)
        {
            string TK;
            if (cboManv.SelectedIndex != -1)
            {
                TK = cboManv.Text;
                NHANVIEN NV = db.NHANVIENs.Find(TK);
                txtTennv.Text = NV.HOTEN;
            }
        }

        public void SelectComboBox(System.Windows.Forms.ComboBox cbo, string TK)
        {
            for (int i = 0; i < cbo.Items.Count; i++)
            {
                if (cbo.Items[i].ToString() == TK)
                {
                    cbo.SelectedIndex = i;
                    break;
                }
            }
        }

        private void LVKTKL_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView lv = sender as ListView;
            if (lv.SelectedItems.Count == 1)
            {
                ID = int.Parse(lv.SelectedItems[0].SubItems[0].Text);
                SelectComboBox(cboManv, Convert.ToString(lv.SelectedItems[0].SubItems[1].Text));
                txtTennv.Text = lv.SelectedItems[0].SubItems[2].Text;
                SelectComboBox(cboHinhthuc, Convert.ToString(lv.SelectedItems[0].SubItems[3].Text));
                txtTien.Text = lv.SelectedItems[0].SubItems[4].Text;
                dtpTG.Text = lv.SelectedItems[0].SubItems[5].Text;
                txtLydo.Text = lv.SelectedItems[0].SubItems[6].Text;
                KKey(false);
            }
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            if (ID == null)
            {
                XtraMessageBox.Show("Bạn chưa chọn dữ liệu Sửa dữ liệu.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            KHENTHUONG_KYLUAT KT = db.KHENTHUONG_KYLUAT.Find(ID);
            KT.MANV = cboManv.Text;
            KT.HINHTHUC = cboHinhthuc.Text;
            KT.SOTIEN = float.Parse(txtTien.Text);
            KT.THOIGIAN = dtpTG.Value;
            KT.LYDO = txtLydo.Text;
            db.SaveChanges();
            XtraMessageBox.Show("Sửa thành công.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            fmKTKL_Load(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (ID == null)
            {
                XtraMessageBox.Show("Bạn chưa chọn dữ liệu để xóa.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            KHENTHUONG_KYLUAT KT = db.KHENTHUONG_KYLUAT.Find(ID);
            db.KHENTHUONG_KYLUAT.Remove(KT);
            db.SaveChanges();
            XtraMessageBox.Show("Xóa thành công.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            fmKTKL_Load(sender, e);
        }

        private void btnTiemkiem_Click(object sender, EventArgs e)
        {
            if (txtNam.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập năm tìm kiếm.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            else
            {
                var KTKL = db.KHENTHUONG_KYLUAT.ToList();
                if (txtTiemkiemNV.Text == "")
                {
                    LVKTKL.Items.Clear();
                    int i = 0;
                    foreach (var item in KTKL)
                    {
                        if (cboThang.Text == item.THOIGIAN.Value.Month.ToString() && txtNam.Text == item.THOIGIAN.Value.Year.ToString())
                        {
                            NHANVIEN NV = db.NHANVIENs.Find(item.MANV);
                            LVKTKL.Items.Add(item.MA.ToString());
                            LVKTKL.Items[i].SubItems.Add(item.MANV);
                            LVKTKL.Items[i].SubItems.Add(NV.HOTEN);
                            LVKTKL.Items[i].SubItems.Add(item.HINHTHUC);
                            LVKTKL.Items[i].SubItems.Add(item.SOTIEN.ToString());
                            LVKTKL.Items[i].SubItems.Add(item.THOIGIAN.Value.Date.ToShortDateString());
                            LVKTKL.Items[i].SubItems.Add(item.LYDO);
                            i++;
                        }
                    }
                }
                else
                {
                    LVKTKL.Items.Clear();
                    int i = 0;
                    foreach (var item in KTKL)
                    {
                        if (cboThang.Text == item.THOIGIAN.Value.Month.ToString() && txtNam.Text == item.THOIGIAN.Value.Year.ToString() && txtTiemkiemNV.Text == item.MANV)
                        {
                            NHANVIEN NV = db.NHANVIENs.Find(item.MANV);
                            LVKTKL.Items.Add(item.MA.ToString());
                            LVKTKL.Items[i].SubItems.Add(item.MANV);
                            LVKTKL.Items[i].SubItems.Add(NV.HOTEN);
                            LVKTKL.Items[i].SubItems.Add(item.HINHTHUC);
                            LVKTKL.Items[i].SubItems.Add(item.SOTIEN.ToString());
                            LVKTKL.Items[i].SubItems.Add(item.THOIGIAN.Value.Date.ToShortDateString());
                            LVKTKL.Items[i].SubItems.Add(item.LYDO);
                            i++;
                        }
                    }
                }
            }
        }

        private void btnHuytimkiem_Click(object sender, EventArgs e)
        {
            LVADD();
        }
    }
}