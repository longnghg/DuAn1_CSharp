using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLSQA
{
    public class DTO_Sanpham
    {
        private string maSP;
        private string tenSP;
        private int soLuong;
        private float dongiaNhap;
        private float dongiaBan;
        private string hinhAnhtrc;
        private string hinhAnhsau;
        private string maLoai;
        private int doiTuong;
        private int size;
        private int mamau;
        private int giamGia;
        public DTO_Sanpham()
        {

        }
        //public DTO_Sanpham(DataRow rows , bool fulltable)
        //{
        //    this.MaSP = rows["masp"].ToString();
        //    this.TenSP = rows["tensp"].ToString();
        //    this.DongiaNhap = float.Parse((rows["dongianhap"].ToString()));
        //    this.DongiaBan = float.Parse((rows["DonGiaBan"].ToString()));
        //    this.SoLuong = (int)rows["tongsoluong"];
        //    this.DoiTuong = (int)rows["doituong"];
        //    this.HinhAnhtrc = rows["hinhanhtrc"].ToString();
        //    this.HinhAnhsau = rows["hinhanhsau"].ToString();
        //    this.GiamGia = (int)rows["giamgia"];
        //    this.MaLoai = rows["maloai"].ToString();
        //}
        public DTO_Sanpham(DataRow rows)
        {
            this.MaSP = rows["masp"].ToString();
            this.TenSP = rows["tensp"].ToString();
            this.DongiaNhap = float.Parse((rows["DonGiaNhap"].ToString()));
            this.DongiaBan =float.Parse((rows["DonGiaBan"].ToString()));
            this.DoiTuong = (int)rows["doituong"];
            this.HinhAnhtrc = rows["hinhanhtrc"].ToString();
            this.HinhAnhsau = rows["hinhanhsau"].ToString();
            this.GiamGia = (int)rows["giamgia"];
            this.MaLoai = rows["MaLoai"].ToString();
        }
        public string MaSP { get => maSP; set => maSP = value; }
        public string TenSP { get => tenSP; set => tenSP = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public float DongiaNhap { get => dongiaNhap; set => dongiaNhap = value; }
        public float DongiaBan { get => dongiaBan; set => dongiaBan = value; }
        public int Size { get => size; set => size = value; }
        public int Mamau { get => mamau; set => mamau = value; }
        public string MaLoai { get => maLoai; set => maLoai = value; }
        public int DoiTuong { get => doiTuong; set => doiTuong = value; }
        public string HinhAnhtrc { get => hinhAnhtrc; set => hinhAnhtrc = value; }
        public string HinhAnhsau { get => hinhAnhsau; set => hinhAnhsau = value; }
       
        public int GiamGia { get => giamGia; set => giamGia = value; }
    }
}
