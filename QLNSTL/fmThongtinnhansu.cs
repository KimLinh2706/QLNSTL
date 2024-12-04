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
    public partial class fmThongtinnhansu : DevExpress.XtraEditors.XtraForm
    {
        QLNSTLEntities db = new QLNSTLEntities();
        public fmThongtinnhansu()
        {
            InitializeComponent();
        }
        //Gán biến
        public string ID;

        //Thêm Thông tin vào ComboBox
        public void cbo()
        {
            cboPhongban.Items.Clear();
            var pb = db.PHONGBANs.ToList();
            foreach (var itempb in pb)
            {
                cboPhongban.Items.Add(itempb.TENPB);
            }
            cboChucvu.Items.Clear();
            var cv = db.CHUCVUs.ToList();
            foreach (var itemcv in cv)
            {
                cboChucvu.Items.Add(itemcv.TENCV);
            }
            cboTrinhdo.Items.Clear();
            cboTrinhdo.Items.Add("Đại Học");
            cboTrinhdo.Items.Add("Cao Học");
            cboTrinhdo.Items.Add("Trung Học");
        }

        //Làm mới các ToolBox
        public void clear()
        {
            txtManv.Text = "";
            txtDantoc.Text = "";
            txtQuequan.Text = "";
            txtSDT.Text = "";
            txtTennv.Text = "";
            dtpNgaySinh.Text = "";
            dtpNgayvaolam.Text = "";
            rabtnNam.Checked = true;
            cboPhongban.SelectedIndex = -1;
            cboChucvu.SelectedIndex = -1;
            cboTrinhdo.SelectedIndex = -1;
            ID = null;
        }

        //Chọn ComboBox trùng với dữ liệu
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

        private void fmThongtinnhansu_Load(object sender, EventArgs e)
        {
            LVTTNV.Items.Clear();
            clear();
            cbo();
            var TTNV = db.NHANVIENs.ToList();
            int i = 0;
            foreach (var item in TTNV)
            {
                LVTTNV.Items.Add(item.MANV);
                LVTTNV.Items[i].SubItems.Add(item.HOTEN);
                LVTTNV.Items[i].SubItems.Add(item.DANTOC);
                LVTTNV.Items[i].SubItems.Add(item.GIOITINH);
                LVTTNV.Items[i].SubItems.Add(item.SODIENTHOAI);
                LVTTNV.Items[i].SubItems.Add(item.QUEQUAN);
                LVTTNV.Items[i].SubItems.Add(item.NGAYSINH.Value.ToShortDateString());
                LVTTNV.Items[i].SubItems.Add(item.NGAYVAOLAM.Value.ToShortDateString());
                PHONGBAN pb = db.PHONGBANs.Find(item.MAPB);
                if (pb != null) LVTTNV.Items[i].SubItems.Add(pb.TENPB);
                else LVTTNV.Items[i].SubItems.Add("");
                CHUCVU cv = db.CHUCVUs.Find(item.MACV);
                if (cv != null) LVTTNV.Items[i].SubItems.Add(cv.TENCV);
                else LVTTNV.Items[i].SubItems.Add("");
                LVTTNV.Items[i].SubItems.Add(item.TRINHDO);
                i++;
            }
            btnHuytimkiem.Enabled = false;
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string Search = txtTimkiem.Text;
            NHANVIEN SearchNV = db.NHANVIENs.Find(Search);
            if (SearchNV == null)
            {
                XtraMessageBox.Show("Không tìm thấy!"); return;
            }
            else
            {
                LVTTNV.Items.Clear();
                LVTTNV.Items.Add(SearchNV.MANV);
                LVTTNV.Items[0].SubItems.Add(SearchNV.HOTEN);
                LVTTNV.Items[0].SubItems.Add(SearchNV.DANTOC);
                LVTTNV.Items[0].SubItems.Add(SearchNV.GIOITINH);
                LVTTNV.Items[0].SubItems.Add(SearchNV.SODIENTHOAI);
                LVTTNV.Items[0].SubItems.Add(SearchNV.QUEQUAN);
                LVTTNV.Items[0].SubItems.Add(SearchNV.NGAYSINH.Value.ToShortDateString());
                LVTTNV.Items[0].SubItems.Add(SearchNV.NGAYVAOLAM.Value.ToShortDateString());
                PHONGBAN pb = db.PHONGBANs.Find(SearchNV.MAPB);
                LVTTNV.Items[0].SubItems.Add(pb.TENPB);
                CHUCVU cv = db.CHUCVUs.Find(SearchNV.MACV);
                LVTTNV.Items[0].SubItems.Add(cv.TENCV);
                LVTTNV.Items[0].SubItems.Add(SearchNV.TRINHDO);
                btnHuytimkiem.Enabled = true;
            }
        }

        private void btnHuytimkiem_Click(object sender, EventArgs e)
        {
            fmThongtinnhansu_Load(sender, e);
        }

        private void LVTTNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView lv = sender as ListView;
            if (lv.SelectedItems.Count == 1)
            {
                txtManv.Text = lv.SelectedItems[0].SubItems[0].Text;
                txtTennv.Text = lv.SelectedItems[0].SubItems[1].Text;
                txtDantoc.Text = lv.SelectedItems[0].SubItems[2].Text;
                if (lv.SelectedItems[0].SubItems[3].Text == "Nam")
                {
                    rabtnNam.Checked = true;
                }
                else
                {
                    rabtnNu.Checked = true;
                }
                txtSDT.Text = lv.SelectedItems[0].SubItems[4].Text;
                txtQuequan.Text = lv.SelectedItems[0].SubItems[5].Text;
                dtpNgaySinh.Text = lv.SelectedItems[0].SubItems[6].Text;
                dtpNgayvaolam.Text = lv.SelectedItems[0].SubItems[7].Text;
                string TK = lv.SelectedItems[0].SubItems[8].Text;
                SelectComboBox(cboPhongban, TK);
                TK = lv.SelectedItems[0].SubItems[9].Text;
                SelectComboBox(cboChucvu, TK);
                TK = lv.SelectedItems[0].SubItems[10].Text;
                SelectComboBox(cboTrinhdo, TK);
                ID = txtManv.Text;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(ID==null)
            {
                MessageBox.Show("Bạn chưa chọn dữ liệu.","Thông báo!",MessageBoxButtons.OK,MessageBoxIcon.Information); return;
            }
            NHANVIEN nv = db.NHANVIENs.Find(ID);
            db.NHANVIENs.Remove(nv);
            db.SaveChanges();
            MessageBox.Show("Xóa dữ liệu thành công", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            fmThongtinnhansu_Load(sender, e);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (ID == null)
            {
                MessageBox.Show("Bạn chưa chọn dữ liệu.", "Thông báo!"); return;
            }
            NHANVIEN nv = db.NHANVIENs.Find(ID);
            nv.HOTEN = txtTennv.Text;
            nv.DANTOC = txtDantoc.Text;
            if (rabtnNam.Checked == true) nv.GIOITINH = rabtnNam.Text;
            else nv.GIOITINH = rabtnNu.Text;
            nv.SODIENTHOAI = txtSDT.Text;
            nv.QUEQUAN = txtQuequan.Text;
            nv.NGAYSINH = dtpNgaySinh.Value;
            nv.NGAYVAOLAM = dtpNgayvaolam.Value;
            var pb = db.PHONGBANs.Single(x=>x.TENPB.Equals(cboPhongban.Text));
            nv.MAPB = pb.MAPB;
            var cv = db.CHUCVUs.Single(x => x.TENCV.Equals(cboChucvu.Text));
            nv.MACV = cv.MACV;
            nv.TRINHDO = cboTrinhdo.Text;
            db.SaveChanges();
            MessageBox.Show("Sửa thành công","Thông bao!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            fmThongtinnhansu_Load(sender, e);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            fmThemnhansu form = new fmThemnhansu();
            form.ShowDialog();
            fmThongtinnhansu_Load(sender, e);
        }

        private void dtpNgaySinh_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}