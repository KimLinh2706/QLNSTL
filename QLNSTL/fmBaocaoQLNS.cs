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
using DevExpress.XtraReports.UI;

namespace QLNSTL
{
    public partial class fmBaocaoQLNS : DevExpress.XtraEditors.XtraForm
    {
        QLNSTLEntities db = new QLNSTLEntities();
        public fmBaocaoQLNS()
        {
            InitializeComponent();
        }

        public void cbo()
        {
            cboTenpb.Items.Clear();
            var pb = db.PHONGBANs.ToList();
            foreach(var item in pb)
            {
                cboTenpb.Items.Add(item.TENPB);
            }
            cboTenpb.SelectedIndex = 0;
            cboThang.Items.Clear();
            for (int i = 1; i < 13; i++)
            {
                cboThang.Items.Add(i);
            }
            cboThang.SelectedIndex = 0;
        }

        private void btnDSNV_Click(object sender, EventArgs e)
        {
            var QueryDSNV = (from a in db.NHANVIENs select a).ToList();
            DSNV Report = new DSNV();
            Report.DataSource = QueryDSNV.ToList();
            Report.ShowPreviewDialog();
        }

        private void fmBaocaoQLNS_Load(object sender, EventArgs e)
        {
            cbo();
        }

        private void btnDSNVPB_Click(object sender, EventArgs e)
        {
            PHONGBAN Tenpb = db.PHONGBANs.Single(x => x.TENPB == cboTenpb.Text);
            var QueryDSNVPB = (from a in db.NHANVIENs where a.MAPB==Tenpb.MAPB select a).ToList();
            DSNVPB Report = new DSNVPB();
            Report.DataSource = QueryDSNVPB.ToList();
            Report.ShowPreviewDialog();
        }

        private void btnDSNVBD_Click(object sender, EventArgs e)
        {
            var QueryLUONGTHANG = (from a in db.LUONGTHANGs where a.THANG.ToString() == cboThang.Text &&a.NAM.ToString()==txtNam.Text select a).ToList();
            fmTHANGLUONG Report = new fmTHANGLUONG();
            Report.DataSource = QueryLUONGTHANG.ToList();
            Report.ShowPreviewDialog();
        }
    }
}