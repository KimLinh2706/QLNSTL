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
    public partial class fmLuongcanhan : DevExpress.XtraEditors.XtraForm
    {
        QLNSTLEntities db = new QLNSTLEntities();
        public fmLuongcanhan()
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

        public string Manv;

        public void Clear()
        {
            cboManv.SelectedIndex = -1;
            txtTennv.Text = "";
            txtLuongcoban.Text = "0";
            txtHeso.Text = "1";
            txtTienphucap.Text = "0";
            Manv = null;
        }

        public void LVADD()
        {
            LVLCN.Items.Clear();
            var LCN = db.LUONGCANHANs.ToList();
            int i = 0;
            foreach (var item in LCN)
            {
                LVLCN.Items.Add(item.MANV);
                NHANVIEN NV = db.NHANVIENs.Find(item.MANV);
                LVLCN.Items[i].SubItems.Add(NV.HOTEN);
                LVLCN.Items[i].SubItems.Add(item.LUONGCB.ToString());
                LVLCN.Items[i].SubItems.Add(item.HESO.ToString());
                LVLCN.Items[i].SubItems.Add(item.TIENPHUCAP.ToString());
                i++;
            }
        }

        public void KKey(bool e)
        {
            cboManv.Enabled = e;
            btnLuu.Enabled = e;
            btnThem.Enabled = !e;
            btnCapnhat.Enabled = !e;
            btnXoa.Enabled = !e;
        }

        private void fmLuongcanhan_Load(object sender, EventArgs e)
        {
            LVADD();
            Clear();
            KKey(true);
        }

        private void btnTiemkiem_Click(object sender, EventArgs e)
        {
            if (txtTiemkiemNV.Text == "")
            {
                MessageBox.Show("Bạn cần nhập Mã nhân viên để tìm kiếm.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            LVLCN.Items.Clear();
            LUONGCANHAN LCN = db.LUONGCANHANs.Find(Convert.ToString(txtTiemkiemNV.Text));
            if (LCN != null)
            {
                LVLCN.Items.Add(LCN.MANV);
                NHANVIEN NV = db.NHANVIENs.Find(LCN.MANV);
                LVLCN.Items[0].SubItems.Add(NV.HOTEN);
                LVLCN.Items[0].SubItems.Add(LCN.LUONGCB.ToString());
                LVLCN.Items[0].SubItems.Add(LCN.HESO.ToString());
                LVLCN.Items[0].SubItems.Add(LCN.TIENPHUCAP.ToString());
            }
        }

        private void btnHuytimkiem_Click(object sender, EventArgs e)
        {
            LVADD();
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

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            fmLuongcanhan_Load(sender, e);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (cboManv.SelectedIndex == -1 || txtLuongcoban.Text == "" || txtHeso.Text == "" || txtTienphucap.Text == "")
            {
                MessageBox.Show("Bạn cần điền đầy đủ thông tin.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            if (float.Parse(txtHeso.Text) > 10)
            {
                MessageBox.Show("Hệ số lương chỉ tối đa là 10", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            if (float.Parse(txtHeso.Text) < 1)
            {
                MessageBox.Show("Hệ số lương nhỏ nhất là 1", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            LUONGCANHAN TK = db.LUONGCANHANs.Find(Convert.ToString(cboManv.Text));
            if (TK != null)
            {
                MessageBox.Show("Nhân viên đã có bản lương cơ bản của mình.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            LUONGCANHAN LCB = new LUONGCANHAN();
            LCB.MANV = cboManv.Text;
            LCB.LUONGCB = float.Parse(txtLuongcoban.Text);
            LCB.HESO = float.Parse(txtHeso.Text);
            LCB.TIENPHUCAP = float.Parse(txtTienphucap.Text);
            db.LUONGCANHANs.Add(LCB);
            db.SaveChanges();
            MessageBox.Show("Thêm thành công.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            fmLuongcanhan_Load(sender, e);
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

        private void LVLCN_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView lv = sender as ListView;
            if (lv.SelectedItems.Count == 1)
            {
                Manv = lv.SelectedItems[0].SubItems[0].Text;
                SelectComboBox(cboManv, Manv);
                txtLuongcoban.Text = lv.SelectedItems[0].SubItems[2].Text;
                txtHeso.Text = lv.SelectedItems[0].SubItems[3].Text;
                txtTienphucap.Text = lv.SelectedItems[0].SubItems[4].Text;
                KKey(false);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (Manv == null)
            {
                MessageBox.Show("Bạn chưa chọn dữ liệu.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            LUONGCANHAN LCB = db.LUONGCANHANs.Find(Manv);
            db.LUONGCANHANs.Remove(LCB);
            db.SaveChanges();
            MessageBox.Show("Xóa dữ liệu thành công.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            fmLuongcanhan_Load(sender, e);
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            if (Manv == null)
            {
                MessageBox.Show("Bạn chưa chọn dữ liệu.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            if (float.Parse(txtHeso.Text) > 10)
            {
                MessageBox.Show("Hệ số lương chỉ tối đa là 10", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            if (float.Parse(txtHeso.Text) < 1)
            {
                MessageBox.Show("Hệ số lương nhỏ nhất là 1", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            LUONGCANHAN LCB = db.LUONGCANHANs.Find(Manv);
            LCB.LUONGCB = float.Parse(txtLuongcoban.Text);
            LCB.HESO = float.Parse(txtHeso.Text);
            LCB.TIENPHUCAP = float.Parse(txtTienphucap.Text);
            db.SaveChanges();
            MessageBox.Show("Cập nhật dữ liệu thành công.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            fmLuongcanhan_Load(sender, e);
        }
    }
}