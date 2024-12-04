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
    public partial class fmChucvu : DevExpress.XtraEditors.XtraForm
    {
        QLNSTLEntities db = new QLNSTLEntities();
        public fmChucvu()
        {
            InitializeComponent();
        }

        public string Macv;
        public bool key;
        public void Key(bool e)
        {
            txtMacv.Enabled = e;
            btnAdd.Enabled = e;
            btnClear.Enabled = !e;
            btnEdit.Enabled = !e;
            btnDelete.Enabled = !e;
        }

        public void clear()
        {
            txtMacv.Text = "";
            txtTencv.Text = "";
            txtSoluong.Text = "0";
            Macv = null;
        }

        private void fmChucvu_Load(object sender, EventArgs e)
        {
            clear();
            var pb = db.CHUCVUs.ToList();
            LVCV.Items.Clear();
            int i = 0;
            foreach (var item in pb)
            {
                LVCV.Items.Add(item.MACV.ToString());
                LVCV.Items[i].SubItems.Add(item.TENCV.ToString());
                var NV = db.NHANVIENs.Where(x => x.MACV.Equals(item.MACV)).ToList();
                LVCV.Items[i].SubItems.Add(NV.Count.ToString());
                i++;
            }
            key = true;
            Key(key);
        }

        private void LVCV_SelectedIndexChanged(object sender, EventArgs e)
        {
            key = false;
            ListView lv = sender as ListView;
            if (lv.SelectedItems.Count == 1)
            {
                txtMacv.Text = lv.SelectedItems[0].SubItems[0].Text;
                Macv = txtMacv.Text;
                txtTencv.Text = lv.SelectedItems[0].SubItems[1].Text;
                txtSoluong.Text = lv.SelectedItems[0].SubItems[2].Text;
            }
            Key(key);
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            fmChucvu_Load(sender, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                CHUCVU cv = db.CHUCVUs.Find(Macv);
                db.CHUCVUs.Remove(cv);
                db.SaveChanges();
                XtraMessageBox.Show("Bạn đã xóa thành công.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fmChucvu_Load(sender, e);
            }
            catch
            {
                XtraMessageBox.Show("Bạn cần xóa những không tin liên quan trước khi xóa thông tin này.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtTencv.Text == "")
            {
                XtraMessageBox.Show("Bạn cần điền đầy đủ thông tin!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            CHUCVU cv = db.CHUCVUs.Single(x => x.MACV.Equals(Macv));
            if (cv != null)
            {
                MessageBox.Show("Mã chức vụ được sử dụng.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            cv.MACV = txtMacv.Text;
            cv.TENCV = txtTencv.Text;
            db.SaveChanges();
            XtraMessageBox.Show("Bạn đã sửa thành công");
            fmChucvu_Load(sender, e);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtMacv.Text == "" || txtTencv.Text == "")
            {
                XtraMessageBox.Show("Bạn cần điền đầy đủ thông tin.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            Macv = txtMacv.Text;
            List<CHUCVU> ktcv = db.CHUCVUs.Where(x => x.MACV.Equals(Macv)).ToList();
            if (ktcv.Count != 0)
            {
                XtraMessageBox.Show("Mã này đã được sử dụng ở chức vụ khác.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            CHUCVU cv = new CHUCVU();
            cv.MACV = txtMacv.Text;
            cv.TENCV = txtTencv.Text;
            db.CHUCVUs.Add(cv);
            db.SaveChanges();
            XtraMessageBox.Show("Bạn đã thêm thành công.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            fmChucvu_Load(sender, e);
        }

        private void btnTimkem_Click(object sender, EventArgs e)
        {
            fmChucvu_Load(sender, e);
            if (txtMaCVTK.Text == "")
            {
                MessageBox.Show("Bạn cần nhập mã chức vụ cần tìm", "Thông báo!",MessageBoxButtons.OK,MessageBoxIcon.Information); return;
            }
            CHUCVU CV = db.CHUCVUs.Find(Convert.ToString(txtMaCVTK.Text));
            if(CV==null)
            {
                XtraMessageBox.Show("Không có chức vụ này", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            LVCV.Items.Clear();
            LVCV.Items.Add(CV.MACV);
            LVCV.Items[0].SubItems.Add(CV.TENCV);
            var NV = db.NHANVIENs.Where(x => x.MACV.Equals(CV.MACV)).ToList();
            LVCV.Items[0].SubItems.Add(NV.Count.ToString());
        }

        private void btnHuyTKCV_Click(object sender, EventArgs e)
        {
            fmChucvu_Load(sender, e);
        }

        private void btnTimkiemNVCV_Click(object sender, EventArgs e)
        {
            if(Macv==null)
            {
                XtraMessageBox.Show("Cần chọn chức vụ", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            var NV = db.NHANVIENs.Where(x => x.MACV.Equals(Macv)).ToList();
            LVPCCV.Items.Clear();
            int i = 0;
            foreach (var item in NV)
            {
                LVPCCV.Items.Add(item.MANV);
                LVPCCV.Items[i].SubItems.Add(item.HOTEN);
                LVPCCV.Items[i].SubItems.Add(Macv);
                i++;
            }
        }

        private void btnHuytimkiem_Click(object sender, EventArgs e)
        {
            fmChucvu_Load(sender, e);
            LVPCCV.Items.Clear();
        }
    }
}