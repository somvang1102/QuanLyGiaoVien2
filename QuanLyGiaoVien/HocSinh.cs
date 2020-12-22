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

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

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
    }
}
