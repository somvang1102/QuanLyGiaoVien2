using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Data;

namespace BUS
{
   public class BUS_HocSinh
    {
        DAL_HocSinh dAL = new DAL_HocSinh();
        public List<DTO_HocSinh> load_GV()
        {
            return dAL.load_GV();
        }
        public bool Them(DTO_HocSinh hs)
        {
            return dAL.Them(hs);
        }

        public bool xoa(string s)
        {
            return dAL.xoaThongTin(s);
        }
        public bool sua(DTO_HocSinh a)
        {
            return dAL.SuaThongTin(a);
        }
        public DataTable getGiaoVien2()
        {
            return dAL.getGiaoVien2();
        }

    }
}
