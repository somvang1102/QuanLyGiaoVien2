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
    public partial class FormMain : Form
    {
        BUS_khoa bus_Khoa = new BUS_khoa();
        Bus_HocHam_HocVi bus_HocHam_HocVi = new Bus_HocHam_HocVi();
        //DataGridView data1 = new DataGridView();
        private string tenTaiKhoan;
        System.Data.DataTable dt;
        Bus_DangNhap bus_DangNhap = new Bus_DangNhap();
        public string TenTaiKhoan { get => tenTaiKhoan; set => tenTaiKhoan = value; }
        public FormMain()
        {
            InitializeComponent();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            this.Hide();
            f.ShowDialog();
            this.Close();
        }

        private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongTinTaiKhoan f = new ThongTinTaiKhoan();
            f.TenTaiKhoan = textBox1.Text;

            f.ShowDialog();
        }

        private void khoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            data1.Visible = true;
            button1.Visible = true;
            data1.DataSource = bus_Khoa.getKhoaALL();
            data1.Columns[0].HeaderText = "Mã Khoa";
            data1.Columns[1].HeaderText = "Tên Khoa";
        }

        private void bộMônToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            comboBoxKhoa.Visible = true;
            comboBoxKhoa.DataSource = bus_Khoa.getTenKhoa();
            comboBoxKhoa.DisplayMember = "Ma_Khoa";
            comboBoxKhoa.ValueMember = "";

            btnBoMon.Visible = true;
        }

        private void họcHàmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            data1.Visible = true;
            button1.Visible = true;
            btnBoMon.Visible = false;
            comboBoxKhoa.Visible = false;
            data1.DataSource = bus_HocHam_HocVi.thongkeHocHam("SELECT dbo.GiaoVien.HoTen,dbo.HocHam.Ma_HocHam,tenHocHam FROM dbo.HocHam,dbo.GiaoVien WHERE dbo.GiaoVien.Ma_HocHam = dbo.HocHam.Ma_HocHam");
            data1.Columns[0].HeaderText = "Giáo Viên";
            data1.Columns[1].HeaderText = "Mã Học Hàm";
            data1.Columns[2].HeaderText = "Tên Học Hàm";
        }

        private void họcVịToolStripMenuItem_Click(object sender, EventArgs e)
        {
            data1.Visible = true;
            button1.Visible = true;
            data1.DataSource = bus_HocHam_HocVi.thongkeHocHam("SELECT dbo.GiaoVien.HoTen,dbo.HocVi.Ma_HocVi,TenHocVi FROM dbo.HocVi,dbo.GiaoVien WHERE dbo.GiaoVien.Ma_HocVi = dbo.HocVi.Ma_HocVi");
            data1.Columns[0].HeaderText = "Giáo Viên";
            data1.Columns[1].HeaderText = "Mã Học Vị";
            data1.Columns[2].HeaderText = "Tên Học Vị";
        }

        private void danhSáchGiáoViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormQuanLy f = new FormQuanLy();
            dt = bus_DangNhap.getAccount(textBox1.Text);
            //f.LoaiTaiKhoan = Convert.ToInt32(dt.Rows[0]["Type"].ToString());
            f.ShowDialog();
        }

        private void lịchGiảngDạyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongKeGiaoVien f = new ThongKeGiaoVien();
            f.ShowDialog();
        }

        private void btnBoMon_Click(object sender, EventArgs e)
        {
            data1.DataSource = bus_Khoa.getAllBoMon();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            comboBoxKhoa.Visible = false;
            this.Controls.Add(data1);


            data1.Visible = false;
            //comboBoxKhoa.Visible = false;
            button1.Visible = false;
            btnBoMon.Visible = false;
        }

        private void comboBoxKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            data1.Visible = true;

            data1.DataSource = bus_Khoa.getBoMons(this.comboBoxKhoa.Text);
            data1.Columns[0].HeaderText = "Mã Bộ Môn";
            data1.Columns[1].HeaderText = "Tên Bộ Môn";
            data1.Columns[2].HeaderText = "Mã Khoa";
        }

        private void họcSinhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HocSinh f = new HocSinh();
            dt = bus_DangNhap.getAccount(textBox1.Text);
            //f.LoaiTaiKhoan = Convert.ToInt32(dt.Rows[0]["Type"].ToString());
            f.ShowDialog();
        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
