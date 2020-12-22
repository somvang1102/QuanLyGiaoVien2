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
    public partial class ThongKeGiaoVien : Form
    {
        Bus_GiaoVien giaoVien2 = new Bus_GiaoVien();
        DataTable dt = new DataTable();
        public ThongKeGiaoVien()
        {
            InitializeComponent();
        }

        private void ThongKeGiaoVien_Load(object sender, EventArgs e)
        {
            loadMa_Khoa();
            loadBoMon(cmbKhoa.Text);
            cmbChucVu.Items.Add("Giáo Viên");
            cmbChucVu.Items.Add("Chủ nhiệm bộ môn");
            cmbChucVu.Items.Add("Chủ nhiệm Khoa");
            cmbChucVu.Items.Add("Phó Chủ nhiệm");
        }
        void loadMa_Khoa()
        {
            cmbKhoa.DataSource = giaoVien2.getMa_Khoa();
            cmbKhoa.DisplayMember = "Ten_Khoa";
            cmbKhoa.ValueMember = "Ma_Khoa";
        }
        void loadBoMon(string s)
        {
            cmbBoMon.DataSource = giaoVien2.getTen_BoMon(s);
            cmbBoMon.DisplayMember = "TenBoMon";
            cmbBoMon.ValueMember = "";
        }

        private void cmbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadBoMon(cmbKhoa.Text);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (cmbKhoa.Text != "" && cmbBoMon.Text == "" && cmbChucVu.Text == "")
            {
                dt = giaoVien2.ThongKe1(cmbKhoa.Text);
            }
            else if (cmbKhoa.Text != "" && cmbBoMon.Text != "" && cmbChucVu.Text == "")
            {
                dt = giaoVien2.ThongKe2(cmbBoMon.Text);
            }
            else if (cmbKhoa.Text != "" && cmbBoMon.Text == "" && cmbChucVu.Text != "")
            {
                dt = giaoVien2.ThongKe3(cmbKhoa.Text, cmbChucVu.Text);
            }
            else if (cmbKhoa.Text == "" && cmbBoMon.Text == "" && cmbChucVu.Text != "")
            {
                dt = giaoVien2.ThongKe4(cmbChucVu.Text);
            }

            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "Mã Giáo Viên";
            dataGridView1.Columns[1].HeaderText = "Họ Tên";
            dataGridView1.Columns[2].HeaderText = "Ngày sinh";
            dataGridView1.Columns[3].HeaderText = "Địa chỉ";
            dataGridView1.Columns[4].HeaderText = "Chức vụ";
        }
    }
}
