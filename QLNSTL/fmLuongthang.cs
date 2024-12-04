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
    public partial class fmLuongthang : DevExpress.XtraEditors.XtraForm
    {
        QLNSTLEntities db = new QLNSTLEntities();
        public fmLuongthang()
        {
            InitializeComponent();
            cbo();
        }

        public string Manv;
        public int? Thang;
        public int? Nam;

        public void Reset()
        {
            Manv = null;
            Thang = null;
            Nam = null;
        }

        public void ClearTien()
        {
            txtSongaycong.Text = "";
            txtTienBH.Text = "";
            txtTienKL.Text = "";
            txtTienKT.Text = "";
            txtLuongthang.Text = "";
            txtTamung.Text = "";
        }

        public void ClearTTNV()
        {
            cboManv.SelectedIndex = -1;
            txtLCB.Text = "";
            txtHeso.Text = "";
            txtTienphucap.Text = "";
            txtNam.Text = "";
            txtTennv.Text = "";
        }


        public void cbo()
        {
            var NV = db.NHANVIENs.ToList();
            cboManv.Items.Clear();
            foreach (var itemNV in NV)
            {
                cboManv.Items.Add(itemNV.MANV);
            }
            cboThang.Items.Clear();
            cboSthang.Items.Clear();
            for (int i = 1; i < 13; i++)
            {
                cboThang.Items.Add(i);
                cboSthang.Items.Add(i);
            }
            cboThang.SelectedIndex = 0;
            cboSthang.SelectedIndex = 0;
        }

        public void LVADD()
        {
            LVLTNV.Items.Clear();
            var LT = db.LUONGTHANGs.ToList();
            int i = 0;
            foreach(var item in LT)
            {
                LVLTNV.Items.Add(item.MANV);
                NHANVIEN NV = db.NHANVIENs.Find(item.MANV);
                LVLTNV.Items[i].SubItems.Add(NV.HOTEN);
                LVLTNV.Items[i].SubItems.Add(item.THANG.ToString());
                LVLTNV.Items[i].SubItems.Add(item.NAM.ToString());
                LVLTNV.Items[i].SubItems.Add(item.LUONGCB_LUCTINHLUONG.ToString());
                LVLTNV.Items[i].SubItems.Add(item.HESO_LUCTINHLUONG.ToString());
                LVLTNV.Items[i].SubItems.Add(item.TIENPHUCAP_LUCTINHLUONG.ToString());
                LVLTNV.Items[i].SubItems.Add(item.SONGAYCONG.ToString());
                LVLTNV.Items[i].SubItems.Add(item.TIENBAOHIEM_LUCTINHLUONG.ToString());
                LVLTNV.Items[i].SubItems.Add(item.TIENKHENTHUONG_LUCTINHLUONG.ToString());
                LVLTNV.Items[i].SubItems.Add(item.TIENKYLUAT_LUCTINHLUONG.ToString());
                LVLTNV.Items[i].SubItems.Add(item.TIENTAMUNG_LUCTHANGTINHLUONG.ToString());
                LVLTNV.Items[i].SubItems.Add(item.TONGLUONG.ToString());
                i++;
            }
        }

        private void fmLuongthang_Load(object sender, EventArgs e)
        {
            ClearTTNV();
            LVADD();
            Reset();
        }

        private void cboManv_SelectedIndexChanged(object sender, EventArgs e)
        {
            string TK;
            if(cboManv.SelectedIndex!=-1)
            {
                TK = cboManv.Text;
                NHANVIEN NV = db.NHANVIENs.Find(TK);
                txtTennv.Text = NV.HOTEN;
                LUONGCANHAN LCN = db.LUONGCANHANs.Find(NV.MANV);
                if (LCN == null)
                {
                    txtLCB.Text = "";
                    txtHeso.Text = "";
                    txtTienphucap.Text = "";
                    ClearTien();
                    MessageBox.Show("Bạn chưa thêm bản lương cho nhân viên này.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
                }
                txtLCB.Text = LCN.LUONGCB.ToString();
                txtHeso.Text = LCN.HESO.ToString();
                txtTienphucap.Text = LCN.TIENPHUCAP.ToString();
            }
            ClearTien();
            Reset();
        }

        private void btnThongtinLuong_Click(object sender, EventArgs e)
        {
            Reset();
            if (cboManv.SelectedIndex == -1 || txtNam.Text == "")
            {
                MessageBox.Show("Bạn cần nhập đủ thông tin nhân viên, tháng, năm để tìm kiếm.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            var CC = db.CHAMCONGs.ToList();
            int Ngaycong = 0;
            foreach(var itemcc in CC)
            {
                if (itemcc.MANV == cboManv.Text && itemcc.NGAYLAMVIEC.Month.ToString() == cboThang.Text && itemcc.NGAYLAMVIEC.Year.ToString() == txtNam.Text && itemcc.MATT.ToString() == "DL") 
                {
                    Ngaycong++;
                }
            }
            txtSongaycong.Text = Ngaycong.ToString();
            var BH = db.BAOHIEMs.ToList();
            float TienBH = 0;
            foreach (var itemBH in BH)
            {
                if (itemBH.MANV == cboManv.Text && itemBH.THOIGIAN.Value.Month.ToString() == cboThang.Text && itemBH.THOIGIAN.Value.Year.ToString() == txtNam.Text)
                {
                    TienBH+=float.Parse(itemBH.SOTIENDONG.ToString());
                }
            }
            txtTienBH.Text = TienBH.ToString();
            var KT = db.KHENTHUONG_KYLUAT.ToList();
            float TienKT = 0;
            float TienKL = 0;
            foreach (var item in KT)
            {
                if (item.MANV == cboManv.Text && item.THOIGIAN.Value.Month.ToString() == cboThang.Text && item.THOIGIAN.Value.Year.ToString() == txtNam.Text && item.HINHTHUC == "Khen thưởng")
                {
                    TienKT += float.Parse(item.SOTIEN.ToString());
                }
                else if (item.MANV == cboManv.Text && item.THOIGIAN.Value.Month.ToString() == cboThang.Text && item.THOIGIAN.Value.Year.ToString() == txtNam.Text && item.HINHTHUC == "Kỷ luật")
                {
                    TienKL += float.Parse(item.SOTIEN.ToString());
                }
            }
            txtTienKT.Text = TienKT.ToString();
            txtTienKL.Text = TienKL.ToString();
            var TU = db.TAMUNGs.ToList();
            float TienTU = 0;
            foreach (var item in TU)
            {
                if (item.MANV == cboManv.Text && item.NGAYTU.Month.ToString() == cboThang.Text && item.NGAYTU.Year.ToString() == txtNam.Text)
                {
                    TienTU += float.Parse(item.SOTIENTU.ToString());
                }
            }
            txtTamung.Text = TienTU.ToString();
        }

        private void cboThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearTien();
            Reset();
        }

        private void btnTinhluong_Click(object sender, EventArgs e)
        {
            Reset();
            if (txtSongaycong.Text == "" || txtTienBH.Text == "" || txtTienKL.Text == "" || txtTienKT.Text == "")
            {
                MessageBox.Show("Cần có đủ thông tin trước khi tính lương.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            float Luong = 0;
            Luong = ((float.Parse(txtLCB.Text) * float.Parse(txtHeso.Text) + float.Parse(txtTienphucap.Text)) / 26) * float.Parse(txtSongaycong.Text) - (float.Parse(txtTienBH.Text) * float.Parse("0.08")) + float.Parse(txtTienKT.Text) - float.Parse(txtTienKL.Text) - float.Parse(txtTamung.Text);
            txtLuongthang.Text = Luong.ToString();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            Reset();
            if (txtLuongthang.Text == "")
            {
                MessageBox.Show("Thông tin chưa đầy đủ để lưu vào.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            LUONGTHANG TK = db.LUONGTHANGs.Find(Convert.ToString(cboManv.Text), int.Parse(cboThang.Text), int.Parse(txtNam.Text));
            if (TK != null)
            {
                MessageBox.Show("Nhân viên đã được tính lương vào tháng này.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            LUONGTHANG LT = new LUONGTHANG();
            LT.MANV = cboManv.Text;
            LT.THANG = int.Parse(cboThang.Text);
            LT.NAM = int.Parse(txtNam.Text);
            LT.LUONGCB_LUCTINHLUONG = float.Parse(txtLCB.Text);
            LT.HESO_LUCTINHLUONG = float.Parse(txtHeso.Text);
            LT.TIENPHUCAP_LUCTINHLUONG = float.Parse(txtTienphucap.Text);
            LT.TIENBAOHIEM_LUCTINHLUONG = float.Parse(txtTienBH.Text);
            LT.TIENKHENTHUONG_LUCTINHLUONG = float.Parse(txtTienKT.Text);
            LT.TIENKYLUAT_LUCTINHLUONG = float.Parse(txtTienKL.Text);
            LT.SONGAYCONG = int.Parse(txtSongaycong.Text);
            LT.TONGLUONG = float.Parse(txtLuongthang.Text);
            LT.TIENTAMUNG_LUCTHANGTINHLUONG = float.Parse(txtTamung.Text);
            db.LUONGTHANGs.Add(LT);
            db.SaveChanges();
            MessageBox.Show("Lưu thông tin thành công", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            fmLuongthang_Load(sender, e);
        }

        private void LVLTNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView lv = sender as ListView;
            if(lv.SelectedItems.Count==1)
            {
                Manv = lv.Items[0].SubItems[0].Text;
                Thang = int.Parse(lv.Items[0].SubItems[2].Text);
                Nam = int.Parse(lv.Items[0].SubItems[3].Text);
            }
            ClearTTNV();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (Manv == null || Thang == null || Nam == null)
            {
                MessageBox.Show("Bạn chưa chọn dữ liệu để xóa.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            LUONGTHANG LT = db.LUONGTHANGs.Find(Manv,Thang,Nam);
            db.LUONGTHANGs.Remove(LT);
            db.SaveChanges();
            MessageBox.Show("Xóa dữ liệu thành công.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            fmLuongthang_Load(sender, e);
        }

        private void btnTiemkiem_Click(object sender, EventArgs e)
        {
            Reset();
            if (txtSnam.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập năm tìm kiếm.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            else
            {
                var LT = db.LUONGTHANGs.ToList();
                if (txtTiemkiemNV.Text == "")
                {
                    LVLTNV.Items.Clear();
                    int i = 0;
                    foreach (var item in LT)
                    {
                        if (cboSthang.Text == item.THANG.ToString() && txtSnam.Text == item.NAM.ToString())
                        {
                            LVLTNV.Items.Add(item.MANV);
                            NHANVIEN NV = db.NHANVIENs.Find(item.MANV);
                            LVLTNV.Items[i].SubItems.Add(NV.HOTEN);
                            LVLTNV.Items[i].SubItems.Add(item.THANG.ToString());
                            LVLTNV.Items[i].SubItems.Add(item.NAM.ToString());
                            LVLTNV.Items[i].SubItems.Add(item.LUONGCB_LUCTINHLUONG.ToString());
                            LVLTNV.Items[i].SubItems.Add(item.HESO_LUCTINHLUONG.ToString());
                            LVLTNV.Items[i].SubItems.Add(item.TIENPHUCAP_LUCTINHLUONG.ToString());
                            LVLTNV.Items[i].SubItems.Add(item.SONGAYCONG.ToString());
                            LVLTNV.Items[i].SubItems.Add(item.TIENBAOHIEM_LUCTINHLUONG.ToString());
                            LVLTNV.Items[i].SubItems.Add(item.TIENKHENTHUONG_LUCTINHLUONG.ToString());
                            LVLTNV.Items[i].SubItems.Add(item.TIENKYLUAT_LUCTINHLUONG.ToString());
                            LVLTNV.Items[i].SubItems.Add(item.TIENTAMUNG_LUCTHANGTINHLUONG.ToString());
                            LVLTNV.Items[i].SubItems.Add(item.TONGLUONG.ToString());
                            i++;
                        }
                    }
                }
                else
                {
                    LVLTNV.Items.Clear();
                    int i = 0;
                    foreach (var item in LT)
                    {
                        if (cboSthang.Text == item.THANG.ToString() && txtSnam.Text == item.NAM.ToString() && item.MANV == txtTiemkiemNV.Text)
                        {
                            LVLTNV.Items.Add(item.MANV);
                            NHANVIEN NV = db.NHANVIENs.Find(item.MANV);
                            LVLTNV.Items[i].SubItems.Add(NV.HOTEN);
                            LVLTNV.Items[i].SubItems.Add(item.THANG.ToString());
                            LVLTNV.Items[i].SubItems.Add(item.NAM.ToString());
                            LVLTNV.Items[i].SubItems.Add(item.LUONGCB_LUCTINHLUONG.ToString());
                            LVLTNV.Items[i].SubItems.Add(item.HESO_LUCTINHLUONG.ToString());
                            LVLTNV.Items[i].SubItems.Add(item.TIENPHUCAP_LUCTINHLUONG.ToString());
                            LVLTNV.Items[i].SubItems.Add(item.SONGAYCONG.ToString());
                            LVLTNV.Items[i].SubItems.Add(item.TIENBAOHIEM_LUCTINHLUONG.ToString());
                            LVLTNV.Items[i].SubItems.Add(item.TIENKHENTHUONG_LUCTINHLUONG.ToString());
                            LVLTNV.Items[i].SubItems.Add(item.TIENKYLUAT_LUCTINHLUONG.ToString());
                            LVLTNV.Items[i].SubItems.Add(item.TIENTAMUNG_LUCTHANGTINHLUONG.ToString());
                            LVLTNV.Items[i].SubItems.Add(item.TONGLUONG.ToString());
                            i++;
                        }
                    }
                }
            }
        }

        private void btnHuytimkiem_Click(object sender, EventArgs e)
        {
            fmLuongthang_Load(sender, e);
        }
    }
}