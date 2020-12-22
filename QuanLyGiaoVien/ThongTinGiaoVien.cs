using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLGV;
using DTO;

namespace QuanLyGiaoVien
{
    public partial class ThongTinGiaoVien : Form
    {
        Bus_GiaoVien giaovien2 = new Bus_GiaoVien();
        private string maGiaVien;
        public ThongTinGiaoVien()
        {
            InitializeComponent();
        }

        private void ThongTinGiaoVien_Load(object sender, EventArgs e)
        {
            DataTable dt2 = new DataTable();
            dt2 = giaovien2.getGiaoVien(maGiaVien);
           
            txtmagv.Text = dt2.Rows[0]["HoTen"].ToString();
            txtNS.Text = dt2.Rows[0]["NgaySinh"].ToString();
            txtMaBM.Text = dt2.Rows[0]["TenBoMon"].ToString();
            txtmaKhoa.Text = dt2.Rows[0]["TenKhoa"].ToString();
            txtEmail.Text = dt2.Rows[0]["Email"].ToString();
            txthoc.Text = dt2.Rows[0]["TenHocHam"].ToString();
            txthocvi.Text = dt2.Rows[0]["TenHocVi"].ToString();
        }
    }
}
