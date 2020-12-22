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
            loadDtgvGV2();
            loadMa_Khoa();

            loadHocHam();
            loadHocVi();
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            DTO_GiaoVien gv = new DTO_GiaoVien();
            gv.Ma_GiaoVien = txtmagv.Text;
            gv.HoTen = txthoten.Text;
            gv.HocVi = cmbHocVi.Text;
            gv.HocHam = cmbHocHam.Text;
            gv.NgaySinh = DateTime.Parse(dateNS.Text);
            gv.Ma_BoMon = cmbbomon.Text;
            gv.Ma_Khoa = cmbkhoa.Text;
            gv.DiaChi1 = txtdiachi.Text;
            gv.Email = txtEmail.Text;
            gv.ChucVu = txtchucvu.Text;
            gv.GioiTinh = txtGioiTin.Text;
            gv.Ma_MonHoc1 = cmbMaMonHoc.Text;
            gv.DuongDanAnh = s;
            if (gv.Ma_GiaoVien != "" && gv.HoTen != "" && gv.HocVi != "" && gv.HocHam != "" && gv.Ma_BoMon != "" && gv.Ma_Khoa != "" && gv.Ma_MonHoc1 != "" && gv.ChucVu != "" && gv.DiaChi1 != "" && gv.Email != "" && gv.GioiTinh != "")
            {
                if (checkMaGV() == true)
                {
                    if (giaoVien.Them(gv) == true)
                    {
                        MessageBox.Show("thêm thành công", "thông báo");
                        loadDtgvGV2();

                    }
                    else
                    {
                        MessageBox.Show("thêm thất bại", "thông báo");
                    }
                }
                else
                {
                    MessageBox.Show("thêm thất bại,mã giáo viên trùng ", "thông báo");
                }
            }
            else if (gv.Ma_GiaoVien == "")
            {
                MessageBox.Show("Thiếu mã giáo viên", "Thông báo");

            }
            else if (gv.HoTen == "") MessageBox.Show("Thiếu tên giáo viên", "Thông báo");
            else if (gv.ChucVu == "") MessageBox.Show("Thiếu chức vụ ", "Thông báo");
            else if (gv.GioiTinh == "") MessageBox.Show("Nhập thiếu giới tính giáo viên", "Thông báo");
            else if (gv.DiaChi1 == "") MessageBox.Show("Thiếu địa chỉ giáo viên", "Thông báo");
            else if (gv.Email == "") MessageBox.Show("Thiếu email giáo viên", "Thông báo");
            else if (gv.NgaySinh.ToString() == "") MessageBox.Show("Ngay sinh giáo viên trống", "Thông báo");

            else MessageBox.Show("Thiếu thông tin giáo viên", "Thông báo");
        }

        private void FormQuanLy_Load(object sender, EventArgs e)
        {
            btnThem.Visible = false;
            btnSua.Visible = false;
            btnXoa.Visible = false;
            if (loaiTaiKhoan == 0)
            {
                btnThem.Visible = true;
                btnSua.Visible = true;
                btnXoa.Visible = true;
            }

            cmbLuaChonTimKiem.Items.Add("Theo mã giáo viên");
            cmbLuaChonTimKiem.Items.Add("Theo họ tên giáo viên");
        }

        private void dgvgiaovien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmagv.Text = Convert.ToString(dgvgiaovien.CurrentRow.Cells[0].Value);
            txthoten.Text = Convert.ToString(dgvgiaovien.CurrentRow.Cells[1].Value);
            dateNS.Text = Convert.ToString(dgvgiaovien.CurrentRow.Cells[2].Value);
            txtGioiTin.Text = Convert.ToString(dgvgiaovien.CurrentRow.Cells[3].Value);
            txtEmail.Text = Convert.ToString(dgvgiaovien.CurrentRow.Cells[4].Value);
            cmbHocVi.Text = Convert.ToString(dgvgiaovien.CurrentRow.Cells[5].Value);
            cmbHocHam.Text = Convert.ToString(dgvgiaovien.CurrentRow.Cells[6].Value);
            cmbkhoa.Text = Convert.ToString(dgvgiaovien.CurrentRow.Cells[7].Value);
            cmbbomon.Text = Convert.ToString(dgvgiaovien.CurrentRow.Cells[8].Value);
            cmbMaMonHoc.Text = Convert.ToString(dgvgiaovien.CurrentRow.Cells[9].Value);
            txtdiachi.Text = Convert.ToString(dgvgiaovien.CurrentRow.Cells[11].Value);
            txtchucvu.Text = Convert.ToString(dgvgiaovien.CurrentRow.Cells[10].Value);


            ThongTinGiaoVien f = new ThongTinGiaoVien();
            f.MaGiaVien = Convert.ToString(dgvgiaovien.CurrentRow.Cells[0].Value);
        }
    }
}
