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
    public partial class fmBoiduong : DevExpress.XtraEditors.XtraForm
    {
        QLNSTLEntities db = new QLNSTLEntities();
        public fmBoiduong()
        {
            InitializeComponent();
        }

        public string TK;
        public int? ID;
        public void cbo()
        {
            cboManv.Items.Clear();
            var NV = db.NHANVIENs.ToList();
            foreach (var item in NV)
            {
                cboManv.Items.Add(item.MANV);
            }
        }

        public void clear()
        {
            cboManv.SelectedIndex = -1;
            txtChucvu.Text = "";
            txtTennv.Text = "";
            txtNoiBD.Text = "";
            dtpNgaydi.Text = "";
            dtpNgayve.Text = "";
            TK = null;
            ID = null;
        }

        public bool key;
        public void Key(bool e)
        {
            btnAdd.Enabled = e;
            btnClear.Enabled = !e;
            btnEdit.Enabled = !e;
            btnDelete.Enabled = !e;
        }

        private void fmBoiDuong_Load(object sender, EventArgs e)
        {
            key = true;
            cbo();
            LVBD.Items.Clear();
            clear();
            var BD = db.BOIDUONGs.ToList();
            int i = 0;
            foreach (var item in BD)
            {
                NHANVIEN NV = db.NHANVIENs.Find(item.MANV);
                LVBD.Items.Add(item.MANV);
                LVBD.Items[i].SubItems.Add(NV.HOTEN);
                CHUCVU CV = db.CHUCVUs.Find(NV.MACV);
                LVBD.Items[i].SubItems.Add(CV.TENCV);
                LVBD.Items[i].SubItems.Add(item.NOIBOIDUONG);
                LVBD.Items[i].SubItems.Add(item.THOIGIANDI.Date.ToShortDateString());
                LVBD.Items[i].SubItems.Add(item.THOIGIANKETTHUC.Date.ToShortDateString());
                LVBD.Items[i].SubItems.Add(item.MABD.ToString());
                i++;
            }
            Key(key);
        }

        private void LVBD_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView lv = sender as ListView;
            if (lv.SelectedItems.Count == 1)
            {
                key = false;
                TK = lv.SelectedItems[0].SubItems[0].Text;
                SelectComboBox(cboManv, TK);
                txtTennv.Text = lv.SelectedItems[0].SubItems[1].Text;
                txtChucvu.Text = lv.SelectedItems[0].SubItems[2].Text;
                txtNoiBD.Text = lv.SelectedItems[0].SubItems[3].Text;
                dtpNgaydi.Text = lv.SelectedItems[0].SubItems[4].Text;
                dtpNgayve.Text = lv.SelectedItems[0].SubItems[5].Text;
                ID = int.Parse(lv.SelectedItems[0].SubItems[6].Text);
                Key(key);
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

        private void btnOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ID == null)
            {
                XtraMessageBox.Show("Bạn chưa chọn dữ liệu để xóa."); return;
            }
            BOIDUONG BD = db.BOIDUONGs.Find(ID);
            db.BOIDUONGs.Remove(BD);
            db.SaveChanges();
            XtraMessageBox.Show("Xóa thành công.");
            fmBoiDuong_Load(sender, e);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cboManv.SelectedIndex == -1 || txtNoiBD.Text == "")
            {
                XtraMessageBox.Show("Bạn cần điền đầy đủ thông tin."); return;
            }
            BOIDUONG BD = new BOIDUONG();
            BD.MANV = cboManv.Text;
            BD.NOIBOIDUONG = txtNoiBD.Text;
            BD.THOIGIANDI = DateTime.Parse(dtpNgaydi.Text);
            BD.THOIGIANKETTHUC = DateTime.Parse(dtpNgayve.Text);
            db.BOIDUONGs.Add(BD);
            db.SaveChanges();
            XtraMessageBox.Show("Thêm thành công.");
            fmBoiDuong_Load(sender, e);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            fmBoiDuong_Load(sender, e);
        }

        private void cboManv_SelectedIndexChanged(object sender, EventArgs e)
        {
            TK = cboManv.Text;
            if (cboManv.SelectedIndex != -1)
            {
                NHANVIEN NV = db.NHANVIENs.Find(TK);
                CHUCVU CV = db.CHUCVUs.Find(NV.MACV);
                txtTennv.Text = NV.HOTEN;
                txtChucvu.Text = CV.TENCV;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (ID == null)
            {
                XtraMessageBox.Show("Bạn chưa chọn dữ liệu Sửa dữ liệu"); return;
            }
            BOIDUONG BD = db.BOIDUONGs.Find(ID);
            BD.MANV = cboManv.Text;
            BD.NOIBOIDUONG = txtNoiBD.Text;
            BD.THOIGIANDI = dtpNgaydi.Value;
            BD.THOIGIANKETTHUC = dtpNgayve.Value;
            db.SaveChanges();
            XtraMessageBox.Show("Sửa thành công.");
            fmBoiDuong_Load(sender, e);
        }
    }
}