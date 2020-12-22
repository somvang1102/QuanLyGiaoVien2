using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class DAL_HocSinh: DAL_con
    {
        public List<DTO_HocSinh> load_GV()
        {
            string query = "select * from HocSinh";
            conn.Open();
            DataTable data = base.GetDataTable(query);
            if (data.Rows.Count == 0)
            {
                return null;
            }
            List<DTO_HocSinh> listGV = new List<DTO_HocSinh>();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                DTO_HocSinh gv = new DTO_HocSinh();
                gv.MaHocSinh = data.Rows[i]["Ma_GiaoVien"].ToString();
                gv.HoTen = data.Rows[i]["HoTen"].ToString();
                gv.GioiTinh = data.Rows[i]["GioiTinh"].ToString();
                gv.NgaySinh = DateTime.Parse(data.Rows[i]["NgaySinh"].ToString());
                gv.Email = data.Rows[i]["Email"].ToString();
                gv.Lop = data.Rows[i]["Lop"].ToString();
                
                listGV.Add(gv);

            }
            conn.Close();
            return listGV;
        }
        public bool Them(DTO_HocSinh gv)
        {
            string query = "INSERT INTO dbo.HocSinh( MaHocSinh , HoTen ,NgaySinh ,GioiTinh , Email ,Lop )VALUES  ( '" + gv.MaHocSinh + "' , N'" + gv.HoTen + "' , '" + gv.NgaySinh + "',N'" + gv.GioiTinh + "' , '" + gv.Email + "' ,  '" + gv.Lop + "'  )";

            conn.Open();
            try
            {
                base.executeQuery(query);
                conn.Close();
                return true;


            }
            catch (Exception ex)
            {
                conn.Close();
                return false;
            }
        }
        public bool xoaThongTin(string s)
        {
            string query = "DELETE dbo.HocSinh WHERE MaHocSinh ='" + s + "' ";
            conn.Open();
            try
            {
                base.executeQuery(query);
                conn.Close();
                return true;


            }
            catch (Exception ex)
            {
                conn.Close();
                return false;
            }
        }
        public bool SuaThongTin(DTO_HocSinh a)
        {
            conn.Open();
            string SQL = "UPDATE dbo.GiaoVien SET MaHocSinh='" + a.MaHocSinh + "',HoTen=N'" + a.HoTen + "',NgaySinh='" + a.NgaySinh.ToString() + "',GioiTinh=N'" + a.GioiTinh + "',Email='" + a.Email + "',Lop='"+a.Lop+"')";
            try
            {
                SqlCommand cmd = new SqlCommand(SQL, conn);

                // Query và kiểm tra
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                conn.Close();
                return false;
            }
        }
    }
}
