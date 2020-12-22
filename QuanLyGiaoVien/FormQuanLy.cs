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
    public partial class FormQuanLy : Form
    {
        Bus_GiaoVien giaoVien = new Bus_GiaoVien();
        string s;
        OpenFileDialog op = new OpenFileDialog();
        private int loaiTaiKhoan;

        public int LoaiTaiKhoan { get => loaiTaiKhoan; set => loaiTaiKhoan = value; }
        public FormQuanLy()
        {
            InitializeComponent();
        }
        void loadDtgvGV2()
        {
            dgvgiaovien.DataSource = giaoVien.getGiaoVien2();
            dgvgiaovien.Columns[0].HeaderText = "Mã giáo viên";
            dgvgiaovien.Columns[1].HeaderText = "Họ tên";
            dgvgiaovien.Columns[2].HeaderText = "Ngày sinh";
            dgvgiaovien.Columns[3].HeaderText = "Giới tính";
            dgvgiaovien.Columns[4].HeaderText = "Email";
            dgvgiaovien.Columns[5].HeaderText = "Mã Học vị";
            dgvgiaovien.Columns[6].HeaderText = "Mã Học Hàm";
            dgvgiaovien.Columns[7].HeaderText = "Mã Khoa";
            dgvgiaovien.Columns[8].HeaderText = "Mã Bộ Môn";
            dgvgiaovien.Columns[9].HeaderText = "Mã Môn Học";

            dgvgiaovien.Columns[11].HeaderText = "Dịa Chỉ";
            dgvgiaovien.Columns[10].HeaderText = "Chức Vụ";


        }
        void loadMa_Khoa()
        {
            cmbkhoa.DataSource = giaoVien.getMa_Khoa();
            cmbkhoa.DisplayMember = "Ten_Khoa";
            cmbkhoa.ValueMember = "Ma_Khoa";
        }
        void loadHocHam()
        {
            cmbHocHam.DataSource = giaoVien.getHocHam();
            cmbHocHam.DisplayMember = "Ma_HocHam";
            cmbHocHam.ValueMember = "";
        }
        void loadHocVi()
        {
            cmbHocVi.DataSource = giaoVien.getHocVi();
            cmbHocVi.DisplayMember = "Ma_HocVi";
            cmbHocVi.ValueMember = "";
        }
        // lấy hết giáo viên lưu vào 1 list
        public List<DTO_GiaoVien> loadGiaoVien()
        {
            return giaoVien.load_GV();
        }
        // check mã giáo viên
        bool checkMaGV()
        {
            bool kq = true;
            for (int i = 0; i < loadGiaoVien().Count; i++)
            {
                if (txtmagv.Text == loadGiaoVien()[i].Ma_GiaoVien)
                {
                    kq = false;
                }


            }
            return kq;
        }
        void loadBoMon(string s)
        {
            cmbbomon.DataSource = giaoVien.getMa_BoMon(s);
            cmbbomon.DisplayMember = "Ma_BoMon";
            cmbbomon.ValueMember = "";
        }
        void getMonHoc(string s)
        {
            cmbMaMonHoc.DataSource = giaoVien.getMonHoc(s);
            cmbMaMonHoc.DisplayMember = "Ma_MonHoc";
            cmbMaMonHoc.ValueMember = "";
        }
    }
}
