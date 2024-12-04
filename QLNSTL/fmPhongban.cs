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
    public partial class fmPhongban : DevExpress.XtraEditors.XtraForm
    {
        QLNSTLEntities db = new QLNSTLEntities();
        public fmPhongban()
        {
            InitializeComponent();
        }
        //Gọi biến
        public string IDNV;
        public bool keyNV;
        public string IDPB;
        public bool key;

        //Làm mới Toollbox nhân viên
        public void clearNV()
        {
            txtManv.Text = "";
            txtManv.Enabled = false;
            txtTennv.Text = "";
            txtTennv.Enabled = false;
            txtTenPBPC.Text = "";
            txtTenPBPC.Enabled = false;
            IDNV = null;
        }
        //Làm mới Toolbox phòng ban
        public void clearpb()
        {
            txtMapb.Text = "";
            txtTenpb.Text = "";
            txtSoluong.Text = "0";
            txtSDT.Text = "";
            IDPB = null;
        }

        public void Key(bool e)
        {
            txtMapb.Enabled = e;
            btnAdd.Enabled = e;
            btnClear.Enabled = !e;
            btnEdit.Enabled = !e;
            btnDelete.Enabled = !e;
        }
        public void KeyNV(bool e)
        {
            btnSuaTT.Enabled = e;
            btnLuuTT.Enabled = !e;
            btnHuyTT.Enabled = !e;
        }


        //Load ListView Phòng ban
        public void LVPhongBan()
        {
            var pb = db.PHONGBANs.ToList();
            LVPB.Items.Clear();
            int i = 0;
            foreach (var item in pb)
            {
                LVPB.Items.Add(item.MAPB);
                LVPB.Items[i].SubItems.Add(item.TENPB);
                var NV = db.NHANVIENs.Where(x => x.MAPB.Equals(item.MAPB)).ToList();
                LVPB.Items[i].SubItems.Add(NV.Count.ToString());
                LVPB.Items[i].SubItems.Add(item.SODIENTHOAIPB);
                i++;
            }
        }

        //Load ListView Nhân viên
        public void LVNhanVien()
        {
            var NV2 = db.NHANVIENs.ToList();
            LVPCPB.Items.Clear();
            int i = 0;
            foreach (var item in NV2)
            {
                LVPCPB.Items.Add(item.MANV);
                LVPCPB.Items[i].SubItems.Add(item.HOTEN);
                LVPCPB.Items[i].SubItems.Add(item.MAPB);
                i++;
            }
        }
        private void fmPhongban_Load(object sender, EventArgs e)
        {
            clearNV();
            clearpb();
            LVPhongBan();
            LVNhanVien();
            keyNV = true;
            KeyNV(keyNV);
        }

        private void btnTimkiemNV_Click(object sender, EventArgs e)
        {
            if(txtTimkiemNV.Text=="")
            {
                MessageBox.Show("Bạn cần nhập mã nhân viên cần tìm", "Thông báo!"); return;
            }
            string Manv = txtTimkiemNV.Text;
            LVPCPB.Items.Clear();
            NHANVIEN NV = db.NHANVIENs.Find(Manv);
            if(NV!=null)
            {
                LVPCPB.Items.Add(NV.MANV);
                LVPCPB.Items[0].SubItems.Add(NV.HOTEN);
                LVPCPB.Items[0].SubItems.Add(NV.MAPB);
            }
            else
            {
                MessageBox.Show("Không tìm thấy dữ liệu.", "Thông báo!"); return;
            }
        }

        private void btnTimkiemPB_Click(object sender, EventArgs e)
        {
            if (txtTimkiemPB.Text == "")
            {
                MessageBox.Show("Bạn cần nhập mã phòng ban cần tìm", "Thông báo!"); return;
            }
            string Mapb = txtTimkiemPB.Text;
            LVPB.Items.Clear();
            PHONGBAN pb = db.PHONGBANs.Find(Mapb);
            if (pb != null)
            {
                LVPB.Items.Add(pb.MAPB);
                LVPB.Items[0].SubItems.Add(pb.TENPB);
                var nv = db.NHANVIENs.Where(x=>x.MAPB.Equals(pb.MAPB)).ToList();
                LVPB.Items[0].SubItems.Add(nv.Count.ToString());
                LVPB.Items[0].SubItems.Add(pb.SODIENTHOAIPB);
            }
            else
            {
                MessageBox.Show("Không tìm thấy dữ liệu.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
        }

        private void btnHTKNV_Click(object sender, EventArgs e)
        {
            LVNhanVien();
        }

        private void btnHTKPB_Click(object sender, EventArgs e)
        {
            LVPhongBan();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LVPCPB_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView lv = sender as ListView;
            if (lv.SelectedItems.Count == 1)
            {
                txtManv.Text = lv.SelectedItems[0].SubItems[0].Text;
                IDNV = txtManv.Text;
                txtTennv.Text = lv.SelectedItems[0].SubItems[1].Text;
                txtTenPBPC.Text = lv.SelectedItems[0].SubItems[2].Text;
            }
        }

        private void btnHuyTT_Click(object sender, EventArgs e)
        {
            keyNV = true;
            KeyNV(keyNV);
        }

        private void btnSuaTT_Click(object sender, EventArgs e)
        {
            keyNV = false;
            KeyNV(keyNV);
            txtTenPBPC.Enabled = true;
        }

        private void btnLuuTT_Click(object sender, EventArgs e)
        {
            NHANVIEN NV = db.NHANVIENs.Find(IDNV);
            PHONGBAN PB = db.PHONGBANs.Find(Convert.ToString(txtTenPBPC.Text));
            if(PB==null)
            {
                MessageBox.Show("Mã phòng ban không đúng.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            NV.MAPB = PB.MAPB;
            db.SaveChanges();
            MessageBox.Show("Lưu thành công.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            fmPhongban_Load(sender, e);
        }

        private void LVPB_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView lv = sender as ListView;
            if (lv.SelectedItems.Count == 1)
            {
                txtMapb.Text = lv.SelectedItems[0].SubItems[0].Text;
                IDPB = txtMapb.Text;
                txtTenpb.Text = lv.SelectedItems[0].SubItems[1].Text;
                txtSoluong.Text = lv.SelectedItems[0].SubItems[2].Text;
                txtSDT.Text = lv.SelectedItems[0].SubItems[3].Text;
                key = false;
                Key(key);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearpb();
            key = true;
            Key(key);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                PHONGBAN pb = db.PHONGBANs.Find(IDPB);
                db.PHONGBANs.Remove(pb);
                db.SaveChanges();
                MessageBox.Show("Bạn đã xóa thành công.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fmPhongban_Load(sender, e);
            }
            catch
            {
                MessageBox.Show("Bạn cần xóa những không tin liên quan trước khi xóa thông tin này.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtTenpb.Text == "" || txtSDT.Text == "")
            {

                db.SaveChanges(); MessageBox.Show("Bạn cần điền đầy đủ thông tin.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            PHONGBAN pb = db.PHONGBANs.Find(IDPB);
            pb.TENPB = txtTenpb.Text;
            pb.SODIENTHOAIPB = txtSDT.Text;
            db.SaveChanges();

            db.SaveChanges(); MessageBox.Show("Bạn đã sửa thành công.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LVPhongBan();
            clearpb();
            key = true;
            Key(key);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtMapb.Text == "" || txtTenpb.Text == "" || txtSDT.Text == "")
            {
                XtraMessageBox.Show("Bạn cần điền đầy đủ thông tin!"); return;
            }
            string Mapb = txtMapb.Text;
            List<PHONGBAN> ktpb = db.PHONGBANs.Where(x => x.MAPB.Equals(Mapb)).ToList();
            if (ktpb.Count != 0)
            {
                XtraMessageBox.Show("Mã này đã được sử dụng ở phòng ban khác!"); return;
            }
            PHONGBAN pb = new PHONGBAN();
            pb.MAPB = txtMapb.Text;
            pb.TENPB = txtTenpb.Text;
            pb.SODIENTHOAIPB = txtSDT.Text;
            db.PHONGBANs.Add(pb);
            db.SaveChanges();
            XtraMessageBox.Show("Bạn đã thêm thành công.");
            LVPhongBan();
            clearpb();
        }

        private void btnTimkiemNVPB_Click(object sender, EventArgs e)
        {
            if (IDPB == null)
            {
                MessageBox.Show("Bạn cần chọn phòng ban", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            var NV = db.NHANVIENs.Where(x=>x.MAPB.Equals(IDPB));
            if(NV==null)
            {
                MessageBox.Show("Hiện tại phòng ban chưa có nhân viên.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            LVPCPB.Items.Clear();
            int i = 0;
            foreach (var item in NV)
            {
                LVPCPB.Items.Add(item.MANV);
                LVPCPB.Items[i].SubItems.Add(item.HOTEN);
                LVPCPB.Items[i].SubItems.Add(item.MAPB);
                i++;
            }
        }
    }
}