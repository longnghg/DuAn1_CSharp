using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLSQA
{
    public class DTO_KhachHang
    {
        private string sDT;
        private string tEn;
        private int diemtichluy;
        public DTO_KhachHang()
        {

        }
        public DTO_KhachHang(DataRow rows)
        {
            this.SDT = rows["SDT"].ToString();
            this.tEn = rows["TenKH"].ToString();
            this.Diemtichluy = (int)rows["DiemTichLuy"];
        }
        public DTO_KhachHang(string sdt , string ten)
        {
            this.SDT = sdt;
            this.TEn = ten;
        }
        public string SDT { get => sDT; set => sDT = value; }
        public string TEn { get => tEn; set => tEn = value; }
        public int Diemtichluy { get => diemtichluy; set => diemtichluy = value; }
    }
}
