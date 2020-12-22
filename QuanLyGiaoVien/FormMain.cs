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
        public FormMain()
        {
            InitializeComponent();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void khoaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bộMônToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void họcHàmToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void họcVịToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void danhSáchGiáoViênToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void lịchGiảngDạyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnBoMon_Click(object sender, EventArgs e)
        {
            data1.DataSource = bus_Khoa.getAllBoMon();
        }
    }
}
