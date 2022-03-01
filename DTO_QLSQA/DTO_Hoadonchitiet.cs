using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLSQA
{
    public class DTO_Hoadonchitiet
    {
       private int madonmua;
        private string masp;
        private string tensp;
        private string tenmau;
        private string tensize;
        private string manv;
        private string sdt;
        private int soluong;
        private float dongia;
        private float vat;
        private float tongtien;
        private string ngay;
        private string gio;
        private int giamgia;
        public DTO_Hoadonchitiet()
        {

        }
        public DTO_Hoadonchitiet(DataRow rows)
        {
            this.Madonmua = (int)rows["MaDonMua"];
            this.Masp     = rows["MaSP"].ToString();
            this.Tensp = rows["TenSP"].ToString();
            this.Tenmau = rows["TenMau"].ToString(); 
            this.Tensize = rows["TenSize"].ToString(); 
            this.Manv     = rows["MaNV"].ToString();
            this.Sdt      = rows["SDT"].ToString();
            this.Soluong   = (int)rows["SoLuong"];
            this.Dongia   = float.Parse(rows["DonGia"].ToString());
            this.Vat      = float.Parse(rows["ThueVAT"].ToString());
            this.Tongtien = float.Parse(rows["TongTien"].ToString());
            this.Ngay     = rows["Ngay"].ToString();
            this.Gio = rows["Gio"].ToString();
            this.Giamgia = (int)rows["GiamGia"];
        }
    

        public int Madonmua { get => madonmua; set => madonmua = value; }
        public string Masp { get => masp; set => masp = value; }
        public string Tensp { get => tensp; set => tensp = value; }
        public string Tensize { get => tensize; set => tensize = value; }
        public string Tenmau { get => tenmau; set => tenmau = value; }
        public int Soluong { get => soluong; set => soluong = value; }
        public float Dongia { get => dongia; set => dongia = value; }
        public float Tongtien { get => tongtien; set => tongtien = value; }
        public int Giamgia { get => giamgia; set => giamgia = value; }
        public string Manv { get => manv; set => manv = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public float Vat { get => vat; set => vat = value; }     
        public string Ngay { get => ngay; set => ngay = value; }
        public string Gio { get => gio; set => gio = value; }



    }
}
