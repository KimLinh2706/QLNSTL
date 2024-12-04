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
    public partial class fmBaohiem : DevExpress.XtraEditors.XtraForm
    {
        QLNSTLEntities db = new QLNSTLEntities();
        public fmBaohiem()
        {
            InitializeComponent();
            cbo();
        }

        public void cbo()
        {
            var NV = db.NHANVIENs.ToList();
            cboManv.Items.Clear();
            foreach (var itemNV in NV)
            {
                cboManv.Items.Add(itemNV.MANV);
            }
        }

        public void KKey(bool e)
        {
            txtMaBH.Enabled = e;
            cboManv.Enabled = e;
            btnLuu.Enabled = e;
            btnThem.Enabled = !e;
            btnCapnhat.Enabled = !e;
            btnXoa.Enabled = !e;
        }

        public void LVADD()
        {
            LVBH.Items.Clear();
            var BH = db.BAOHIEMs.ToList();
            int i = 0;
            foreach (var item in BH)
            {
                LVBH.Items.Add(item.MASOBH.ToString());
                LVBH.Items[i].SubItems.Add(item.MANV);
                NHANVIEN NV = db.NHANVIENs.Find(item.MANV);
                LVBH.Items[i].SubItems.Add(NV.HOTEN);
                LVBH.Items[i].SubItems.Add(item.TENBH);
                LVBH.Items[i].SubItems.Add(item.NOICAP);
                LVBH.Items[i].SubItems.Add(item.THOIGIAN.Value.ToShortDateString());
                LVBH.Items[i].SubItems.Add(item.SOTIENDONG.ToString());
                i++;
            }
        }

        public int? ID;
        public string Manv;
        public void Clear()
        {
            cboManv.SelectedIndex = -1;
            txtTennv.Text = "";
            dtpThoiGian.Text = "";
            txtNoicap.Text = "";
            txtMaBH.Text = "";
            txtSotien.Text = "0";
            txtBaohiem.Text = "";
            txtTongtienBH.Text = "0";
            ID = null;
            Manv = null;
        }

        private void fmBaohiem_Load(object sender, EventArgs e)
        {
            Clear();
            LVADD();
            KKey(true);
        }

        private void cboManv_SelectedIndexChanged(object sender, EventArgs e)
        {
            string TK;
            if (cboManv.SelectedIndex != -1)
            {
                float tong = 0;
                TK = cboManv.Text;
                NHANVIEN NV = db.NHANVIENs.Find(TK);
                txtTennv.Text = NV.HOTEN;
                var tien = db.BAOHIEMs.ToList();
                foreach(var item in tien)
                {
                    if (item.MANV == cboManv.Text)
                    {
                        tong += float.Parse(item.SOTIENDONG.ToString());
                    }
                }
                txtTongtienBH.Text = Convert.ToString(tong);
            }
        }

        private void btnTiemkiem_Click(object sender, EventArgs e)
        {
            if(txtTiemkiemNV.Text=="")
            {
                MessageBox.Show("Bạn cần nhập Mã nhân viên để tiềm kiếm.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            LVBH.Items.Clear();
            var TK = db.BAOHIEMs.Where(x => x.MANV.Equals(txtTiemkiemNV.Text)).ToList();
            if (TK != null)
            {
                int i = 0;
                foreach (var item in TK)
                {
                    LVBH.Items.Add(item.MASOBH.ToString());
                    LVBH.Items[i].SubItems.Add(item.MANV);
                    NHANVIEN NV = db.NHANVIENs.Find(item.MANV);
                    LVBH.Items[i].SubItems.Add(NV.HOTEN);
                    LVBH.Items[i].SubItems.Add(item.TENBH);
                    LVBH.Items[i].SubItems.Add(item.NOICAP);
                    LVBH.Items[i].SubItems.Add(item.THOIGIAN.Value.ToShortDateString());
                    LVBH.Items[i].SubItems.Add(item.SOTIENDONG.ToString());
                    i++;
                }
            }
        }

        private void btnHuytimkiem_Click(object sender, EventArgs e)
        {
            LVADD();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
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
                else cbo.SelectedIndex = -1;
            }
        }

        private void LVBH_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView lv = sender as ListView;
            if (lv.SelectedItems.Count == 1)
            {
                ID = int.Parse(lv.SelectedItems[0].SubItems[0].Text);
                txtMaBH.Text = lv.SelectedItems[0].SubItems[0].Text;
                Manv = lv.SelectedItems[0].SubItems[1].Text;
                SelectComboBox(cboManv, Manv);
                txtBaohiem.Text = lv.SelectedItems[0].SubItems[3].Text;
                dtpThoiGian.Text = lv.SelectedItems[0].SubItems[5].Text;
                txtNoicap.Text = lv.SelectedItems[0].SubItems[4].Text;
                txtSotien.Text = lv.SelectedItems[0].SubItems[6].Text;
                KKey(false);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            fmBaohiem_Load(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(ID==null)
            {
                MessageBox.Show("Bạn cần chọn dữ liệu.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            BAOHIEM BH = db.BAOHIEMs.Find(ID);
            db.BAOHIEMs.Remove(BH);
            db.SaveChanges();
            MessageBox.Show("Xóa thành công.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            fmBaohiem_Load(sender, e);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaBH.Text == "" || cboManv.SelectedIndex == -1 || txtNoicap.Text == "" || txtSotien.Text == "" || txtBaohiem.Text == "")
            {
                MessageBox.Show("Bạn cần nhập đầy đủ thông tin.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            BAOHIEM TK = db.BAOHIEMs.Find(int.Parse(txtMaBH.Text));
            if (TK != null)
            {
                MessageBox.Show("Mã bảo hiểm đã được dùng.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            BAOHIEM BH = new BAOHIEM();
            BH.MASOBH = int.Parse(txtMaBH.Text);
            BH.MANV = cboManv.Text;
            BH.NOICAP = txtNoicap.Text;
            BH.TENBH = txtBaohiem.Text;
            BH.SOTIENDONG = float.Parse(txtSotien.Text);
            BH.THOIGIAN = dtpThoiGian.Value;
            db.BAOHIEMs.Add(BH);
            db.SaveChanges();
            MessageBox.Show("Thêm thành công.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            fmBaohiem_Load(sender, e);
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            if (txtMaBH.Text == "" || cboManv.SelectedIndex == -1 || txtNoicap.Text == "" || txtSotien.Text == "" || txtBaohiem.Text == "")
            {
                MessageBox.Show("Bạn cần nhập đầy đủ thông tin.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            BAOHIEM BH = db.BAOHIEMs.Find(int.Parse(txtMaBH.Text));
            if (BH != null)
            {
                BH.MASOBH = int.Parse(txtMaBH.Text);
                BH.MANV = cboManv.Text;
                BH.NOICAP = txtNoicap.Text;
                BH.TENBH = txtBaohiem.Text;
                BH.SOTIENDONG = float.Parse(txtSotien.Text);
                BH.THOIGIAN = dtpThoiGian.Value;
                db.SaveChanges();
                MessageBox.Show("Cập nhật thành công.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fmBaohiem_Load(sender, e);
            }
        }
    }
}