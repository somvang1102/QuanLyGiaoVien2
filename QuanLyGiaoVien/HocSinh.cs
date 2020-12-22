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
using BUS;

namespace QuanLyGiaoVien
{
    public partial class HocSinh : Form
    {
        BUS_HocSinh bus = new BUS_HocSinh();
        DTO_HocSinh a = new DTO_HocSinh();
        public HocSinh()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DTO_HocSinh gv = new DTO_HocSinh();
            gv.MaHocSinh = txtMa.Text;
            gv.HoTen = txtHoten.Text;

            gv.NgaySinh = DateTime.Parse(dateTimePicker1.Text);

            gv.Email = txtEmail.Text;
            gv.Lop = txtLop.Text;
            gv.GioiTinh = txtGioiTinh.Text;
            if (bus.sua(gv))
            {
                MessageBox.Show("Thay đổi thông tin giáo viên thành công", "Thông báo");
            }
            else
            {
                MessageBox.Show("Thay đổi thông tin giáo viên That bai", "Thông báo");
            }
            loadHocSinh();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DTO_HocSinh gv = new DTO_HocSinh();
            gv.MaHocSinh = txtMa.Text;
            gv.HoTen = txtHoten.Text;

            gv.NgaySinh = DateTime.Parse(dateTimePicker1.Text);

            gv.Email = txtEmail.Text;
            gv.Lop =  txtLop.Text;
            gv.GioiTinh = txtGioiTinh.Text;


            if (gv.MaHocSinh != "" && gv.HoTen != "" && gv.Email != "" && gv.GioiTinh != "")
            {

                if (bus.Them(gv) == true)
                {
                    MessageBox.Show("thêm thành công", "thông báo");
                    loadHocSinh();

                }
                else
                {
                    MessageBox.Show("thêm thất bại", "thông báo");
                }
            }
            else
            {
                MessageBox.Show("thêm thất bại", "thông báo");
            }    

        }
           

          
      
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMa.Text != "")
            {
                if (bus.xoa(txtMa.Text))
                {
                    MessageBox.Show("Xoa thanh cong");
                }
                else
                {
                    MessageBox.Show("Xoa that bai");
                }
            }
            else
            {
                MessageBox.Show("Xoa that bai");
            }
            loadHocSinh();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtmagv2_TextChanged(object sender, EventArgs e)
        {

        }

        private void HocSinh_Load(object sender, EventArgs e)
        {
            loadHocSinh();
        }
        void loadHocSinh()
        {
            dataGridView1.DataSource = bus.getGiaoVien2();
            dataGridView1.Columns[0].HeaderText = "Mã Học Sinh";
            dataGridView1.Columns[1].HeaderText = "Họ tên";
            


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMa.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
            txtHoten.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
            txtLop.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
            txtGioiTinh.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value);
            txtEmail.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value);
            dateTimePicker1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[5].Value);
        }
    }
}
