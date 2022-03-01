using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLSQA
{
    public class DTO_Nhanvien
    {
        private int sTT;
        private string maNV;
        private string hoTen;
        private string diaChi;
        private string sDT;
        private string email;
        private bool gioitinh;
        private bool vaiTro;
        private string hinhAnh;
        private string matKhau;
        public DTO_Nhanvien()
        {

        }
        public DTO_Nhanvien(DataRow rows)
        {
            this.MaNV = rows["manv"].ToString();
            this.HoTen = rows["tennv"].ToString();
            this.DiaChi = rows["Diachi"].ToString();
            this.Email = rows["email"].ToString();
            this.SDT = rows["sdt"].ToString();
            this.Gioitinh = (bool)rows["gioitinh"];
            this.VaiTro = (bool)rows["vaitro"];
            this.HinhAnh = rows["hinhanh"].ToString();
        }
        public int STT { get => sTT; set => sTT = value; }
        public string MaNV { get => maNV; set => maNV = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string SDT { get => sDT; set => sDT = value; }
        public string Email { get => email; set => email = value; }
        public bool Gioitinh { get => gioitinh; set => gioitinh = value; }
        public bool VaiTro { get => vaiTro; set => vaiTro = value; }
        public string HinhAnh { get => hinhAnh; set => hinhAnh = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
    }
}
