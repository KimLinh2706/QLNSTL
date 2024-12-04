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
    public partial class fmChamcong : DevExpress.XtraEditors.XtraForm
    {
        QLNSTLEntities db = new QLNSTLEntities();
        public fmChamcong()
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
        }

        public string Manv;
        public DateTime NgayLV;

        public void Clear()
        {
            cboManv.SelectedIndex = -1;
            txtTennv.Text = "";
            dtpNgayLV.Text = "";
            cboTinhtrang.SelectedIndex = -1;
            txtGhichu.Text = "";
            Manv = null;
            NgayLV = DateTime.Now;
        }

        public void KKey(bool e)
        {
            dtpNgayLV.Enabled = e;
            cboManv.Enabled = e;
            btnLuu.Enabled = e;
            btnThem.Enabled = !e;
            btnCapnhat.Enabled = !e;
            btnXoa.Enabled = !e;
        }

        public void cbo()
        {
            var NV = db.NHANVIENs.ToList();
            cboManv.Items.Clear();
            foreach(var itemNV in NV)
            {
                cboManv.Items.Add(itemNV.MANV);
            }

            var TT = db.TINHTRANGs.ToList();
            cboTinhtrang.Items.Clear();
            foreach (var itemTT in TT)
            {
                cboTinhtrang.Items.Add(itemTT.TINHTRANG1);
            }
        }

        private void fmChamcong_Load(object sender, EventArgs e)
        {
            Clear();
            cbo();
            LVCC.Items.Clear();
            var CC = db.CHAMCONGs.ToList();
            int i = 0;
            foreach(var itemCC in CC)
            {
                LVCC.Items.Add(itemCC.MANV);
                NHANVIEN NV = db.NHANVIENs.Find(itemCC.MANV);
                LVCC.Items[i].SubItems.Add(NV.HOTEN);
                LVCC.Items[i].SubItems.Add(itemCC.NGAYLAMVIEC.Date.ToShortDateString());
                TINHTRANG TT = db.TINHTRANGs.Find(itemCC.MATT);
                LVCC.Items[i].SubItems.Add(TT.TINHTRANG1);
                LVCC.Items[i].SubItems.Add(itemCC.GHICHU);
                i++;
            }
            KKey(true);
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
            if(Manv==null)
            {
                MessageBox.Show("Bạn chưa chọn thông tin chấm công.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            CHAMCONG CC = db.CHAMCONGs.Find(Manv, NgayLV);
            db.CHAMCONGs.Remove(CC);
            db.SaveChanges();
            fmChamcong_Load(sender, e);
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            try
            {
                if(Manv==null)
                {
                    MessageBox.Show("Bạn chưa chọn thông tin chấm công.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
                }
                CHAMCONG CC = db.CHAMCONGs.Find(Manv, NgayLV);
                CC.NGAYLAMVIEC = dtpNgayLV.Value;
                CC.GHICHU = txtGhichu.Text;
                TINHTRANG TT = db.TINHTRANGs.Single(x => x.TINHTRANG1.Equals(cboTinhtrang.Text));
                CC.MATT = TT.MATT;
                db.SaveChanges();
                fmChamcong_Load(sender, e);
            }
            catch
            {
                MessageBox.Show("Đã có lỗi xảy ra.","Thông báo!", MessageBoxButtons.OK,MessageBoxIcon.Information);
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
                else cbo.SelectedIndex = -1;
            }
        }

        private void LVCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView lv = sender as ListView;
            if (lv.SelectedItems.Count == 1)
            {
                Manv = lv.SelectedItems[0].SubItems[0].Text;
                SelectComboBox(cboManv, Manv);
                dtpNgayLV.Text = lv.SelectedItems[0].SubItems[2].Text;
                NgayLV = dtpNgayLV.Value;
                string TenTT = lv.SelectedItems[0].SubItems[3].Text;
                SelectComboBox(cboTinhtrang, TenTT);
                txtGhichu.Text = lv.SelectedItems[0].SubItems[4].Text;
                KKey(false);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            fmChamcong_Load(sender, e);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (cboManv.SelectedIndex == -1 || cboTinhtrang.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn cần chọn Nhân Viên và Tình Trạng làm việc hôm nay.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            CHAMCONG TKCC = db.CHAMCONGs.Find(Convert.ToString(cboManv.Text),DateTime.Parse(dtpNgayLV.Value.ToShortDateString()));
            if(TKCC!=null)
            {
                MessageBox.Show("Ngày làm việc "+TKCC.NGAYLAMVIEC.ToShortDateString()+" nhân viên này đã được chấm công.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            CHAMCONG CC = new CHAMCONG();
            CC.MANV = cboManv.Text;
            CC.NGAYLAMVIEC = dtpNgayLV.Value;
            TINHTRANG TT = db.TINHTRANGs.Single(x => x.TINHTRANG1.Equals(cboTinhtrang.Text));
            CC.MATT = TT.MATT;
            CC.GHICHU = txtGhichu.Text;
            db.CHAMCONGs.Add(CC);
            db.SaveChanges();
            fmChamcong_Load(sender, e);
        }

        private void btnTiemkiem_Click(object sender, EventArgs e)
        {
            if(txtNam.Text=="")
            {
                MessageBox.Show("Bạn chưa nhập năm tìm kiếm.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            else
            {
                var CC = db.CHAMCONGs.ToList();
                if (txtTiemkiemNV.Text == "")
                {
                    LVCC.Items.Clear();
                    int i = 0;
                    foreach (var itemCC in CC)
                    {
                        if (cboThang.Text == itemCC.NGAYLAMVIEC.Month.ToString() && txtNam.Text == itemCC.NGAYLAMVIEC.Year.ToString())
                        {
                            LVCC.Items.Add(itemCC.MANV);
                            NHANVIEN NV = db.NHANVIENs.Find(itemCC.MANV);
                            LVCC.Items[i].SubItems.Add(NV.HOTEN);
                            LVCC.Items[i].SubItems.Add(itemCC.NGAYLAMVIEC.Date.ToShortDateString());
                            TINHTRANG TT = db.TINHTRANGs.Find(itemCC.MATT);
                            LVCC.Items[i].SubItems.Add(TT.TINHTRANG1);
                            LVCC.Items[i].SubItems.Add(itemCC.GHICHU);
                            i++;
                        }
                    }
                }
                else
                {
                    LVCC.Items.Clear();
                    int i = 0;
                    foreach (var itemCC in CC)
                    {
                        if (cboThang.Text == itemCC.NGAYLAMVIEC.Month.ToString() && txtNam.Text == itemCC.NGAYLAMVIEC.Year.ToString() && txtTiemkiemNV.Text==itemCC.MANV)
                        {
                            LVCC.Items.Add(itemCC.MANV);
                            NHANVIEN NV = db.NHANVIENs.Find(itemCC.MANV);
                            LVCC.Items[i].SubItems.Add(NV.HOTEN);
                            LVCC.Items[i].SubItems.Add(itemCC.NGAYLAMVIEC.Date.ToShortDateString());
                            TINHTRANG TT = db.TINHTRANGs.Find(itemCC.MATT);
                            LVCC.Items[i].SubItems.Add(TT.TINHTRANG1);
                            LVCC.Items[i].SubItems.Add(itemCC.GHICHU);
                            i++;
                        }
                    }
                }
            }
        }

        private void btnHuytimkiem_Click(object sender, EventArgs e)
        {
            fmChamcong_Load(sender, e);
        }
    }
}