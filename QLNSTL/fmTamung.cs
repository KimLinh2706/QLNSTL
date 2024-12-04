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
    public partial class fmTamung : DevExpress.XtraEditors.XtraForm
    {
        QLNSTLEntities db = new QLNSTLEntities();
        public fmTamung()
        {
            InitializeComponent();
            cboMonth();
        }

        public void cboMonth()
        {
            for (int i = 1; i < 13; i++)
            {
                cboThang.Items.Add(i);
            }
            cboThang.SelectedIndex = 0;

            var NV = db.NHANVIENs.ToList();
            cboManv.Items.Clear();
            foreach (var itemNV in NV)
            {
                cboManv.Items.Add(itemNV.MANV);
            }
        }

        public void LVADD()
        {
            LVTU.Items.Clear();
            var TU = db.TAMUNGs.ToList();
            int i = 0;
            foreach(var itemTU in TU)
            {
                LVTU.Items.Add(itemTU.MANV);
                NHANVIEN NV = db.NHANVIENs.Find(itemTU.MANV);
                LVTU.Items[i].SubItems.Add(NV.HOTEN);
                LVTU.Items[i].SubItems.Add(NV.GIOITINH);
                LVTU.Items[i].SubItems.Add(itemTU.NGAYTU.ToShortDateString());
                LVTU.Items[i].SubItems.Add(itemTU.SOTIENTU.ToString());
                i++;
            }
        }

        public string Manv;
        public DateTime NgayTU;

        public void Clear()
        {
            cboManv.SelectedIndex = -1;
            txtTennv.Text = "";
            dtpNgayTU.Text = "";
            txtSotien.Text = "0";
            Manv = null;
            NgayTU = DateTime.Now;
        }

        public void KKey(bool e)
        {
            dtpNgayTU.Enabled = e;
            cboManv.Enabled = e;
            btnLuu.Enabled = e;
            btnThem.Enabled = !e;
            btnCapnhat.Enabled = !e;
            btnXoa.Enabled = !e;
        }

        private void fmTamung_Load(object sender, EventArgs e)
        {
            LVADD();
            Clear();
            KKey(true);
        }

        private void btnTiemkiem_Click(object sender, EventArgs e)
        {
            if (txtNam.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập năm tìm kiếm.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            else
            {
                var TU = db.TAMUNGs.ToList();
                if (txtTiemkiemNV.Text == "")
                {
                    LVTU.Items.Clear();
                    int i = 0;
                    foreach (var itemTU in TU)
                    {
                        if (cboThang.Text == itemTU.NGAYTU.Month.ToString() && txtNam.Text == itemTU.NGAYTU.Year.ToString())
                        {
                            LVTU.Items.Add(itemTU.MANV);
                            NHANVIEN NV = db.NHANVIENs.Find(itemTU.MANV);
                            LVTU.Items[i].SubItems.Add(NV.HOTEN);
                            LVTU.Items[i].SubItems.Add(NV.GIOITINH);
                            LVTU.Items[i].SubItems.Add(itemTU.NGAYTU.ToShortDateString());
                            LVTU.Items[i].SubItems.Add(itemTU.SOTIENTU.ToString());
                            i++;
                        }
                    }
                }
                else
                {
                    LVTU.Items.Clear();
                    int i = 0;
                    foreach (var itemTU in TU)
                    {
                        if (cboThang.Text == itemTU.NGAYTU.Month.ToString() && txtNam.Text == itemTU.NGAYTU.Year.ToString() && txtTiemkiemNV.Text == itemTU.MANV)
                        {
                            LVTU.Items.Add(itemTU.MANV);
                            NHANVIEN NV = db.NHANVIENs.Find(itemTU.MANV);
                            LVTU.Items[i].SubItems.Add(NV.HOTEN);
                            LVTU.Items[i].SubItems.Add(NV.GIOITINH);
                            LVTU.Items[i].SubItems.Add(itemTU.NGAYTU.ToShortDateString());
                            LVTU.Items[i].SubItems.Add(itemTU.SOTIENTU.ToString());
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

        private void LVTU_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView lv = sender as ListView;
            if (lv.SelectedItems.Count == 1)
            {
                Manv = lv.SelectedItems[0].SubItems[0].Text;
                SelectComboBox(cboManv, Manv);
                dtpNgayTU.Text = lv.SelectedItems[0].SubItems[3].Text;
                NgayTU = dtpNgayTU.Value;
                txtSotien.Text = lv.SelectedItems[0].SubItems[4].Text;
                KKey(false);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            fmTamung_Load(sender, e);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (cboManv.SelectedIndex == -1 || txtSotien.Text == "")
            {
                MessageBox.Show("Bạn cần điền đầy đủ thông tin.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            var TKTU = db.TAMUNGs.ToList();
            foreach(var item in TKTU)
            {
                if (item.NGAYTU.Month == dtpNgayTU.Value.Month && item.NGAYTU.Year == dtpNgayTU.Value.Year && item.MANV == cboManv.Text)
                {
                    MessageBox.Show("Bạn đã ứng một khoản tiền trong tháng này", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
                }
            }
            TAMUNG TU = new TAMUNG();
            TU.MANV = cboManv.Text;
            TU.NGAYTU = dtpNgayTU.Value;
            TU.SOTIENTU = float.Parse(txtSotien.Text);
            db.TAMUNGs.Add(TU);
            db.SaveChanges();
            MessageBox.Show("Bạn đã thêm thành công.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            fmTamung_Load(sender, e);
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (Manv == null)
            {
                MessageBox.Show("Bạn chưa chọn dữ liệu.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            TAMUNG TU = db.TAMUNGs.Find(Manv, NgayTU);
            db.TAMUNGs.Remove(TU);
            db.SaveChanges();
            MessageBox.Show("Xóa dữ liệu thành công.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            fmTamung_Load(sender, e);
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            if (Manv == null)
            {
                MessageBox.Show("Bạn chưa chọn dữ liệu.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            TAMUNG TU = db.TAMUNGs.Find(Manv, NgayTU);
            TU.SOTIENTU = int.Parse(txtSotien.Text);
            db.SaveChanges();
            MessageBox.Show("Cập nhật dữ liệu thành công.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            fmTamung_Load(sender, e);
        }
    }
}