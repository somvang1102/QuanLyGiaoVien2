﻿using System;
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
        public FormMain()
        {
            InitializeComponent();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DoiMatKhau f = new DoiMatKhau();
            f.TenTK = textBox1.Text;
            this.Close();
            this.Hide();
            f.ShowDialog();

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
    }
}
