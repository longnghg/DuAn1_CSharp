using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DTO_QLSQA
{
    public class DTO_CTSanPham
    {
        private string maSP;
        private string tenmau;
        private string tensize;
        private int soLuong;
        private int size;
        private int maMau;
        public DTO_CTSanPham()
        {

        }
        public DTO_CTSanPham(DataRow row, bool size1, bool size2,bool size3)
        {
            this.MaSP = row["MaSP"].ToString();
            this.MaMau = int.Parse(row["MaMau"].ToString());
            this.Size = int.Parse(row["Size"].ToString());
            this.Tenmau = row["TenMau"].ToString();
            this.SoLuong = int.Parse(row["SoLuong"].ToString());
        }
        public DTO_CTSanPham(DataRow row, bool size1, bool size2, bool size3,bool size4)
        {
            this.MaSP = row["MaSP"].ToString();
            this.Size = int.Parse(row["Size"].ToString());
            this.Tensize = row["TenSize"].ToString();
        }
        public DTO_CTSanPham(DataRow row)
        {
            this.MaSP = row["MaSP"].ToString();
            this.Size = int.Parse(row["Size"].ToString());
            this.MaMau = int.Parse(row["MaMau"].ToString());
            this.SoLuong = int.Parse(row["SoLuong"].ToString());
        }
        public DTO_CTSanPham(DataRow row, bool size)
        {
                this.MaSP = row["MaSP"].ToString();
                this.Size = int.Parse(row["Size"].ToString());
                this.MaMau = int.Parse(row["MaMau"].ToString());
                this.SoLuong = int.Parse(row["SoLuong"].ToString());
        }
        public DTO_CTSanPham(DataRow row,bool color, bool size)
        {
            this.MaSP = row["MaSP"].ToString();
            if(color && size)
            {
                this.MaMau = int.Parse(row["MaMau"].ToString());
                this.Size = int.Parse(row["Size"].ToString());
            }
            else if(color && !size)
                this.MaMau = int.Parse(row["MaMau"].ToString());
            else if(!color && size)
                this.Size = int.Parse(row["Size"].ToString());
            else
            {
                this.MaSP = row["MaSP"].ToString();
                this.SoLuong = int.Parse(row["SoLuong"].ToString());
                this.Size = int.Parse(row["Size"].ToString());
                this.MaMau = int.Parse(row["MaMau"].ToString());
            }
        }
        public string MaSP { get => maSP; set => maSP = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public int Size { get => size; set => size = value; }
        public int MaMau { get => maMau; set => maMau = value; }
        public string Tenmau { get => tenmau; set => tenmau = value; }
        public string Tensize { get => tensize; set => tensize = value; }
    }
}
