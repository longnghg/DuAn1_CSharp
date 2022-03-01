using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLSQA
{
   public class DTO_Doanhthu
    {
        private int madon;
        private string ngaymua;
        private double tongtien;
        public DTO_Doanhthu()
        {

        }
        public DTO_Doanhthu(DataRow rows)
        {
            this.Madon = (int)rows["MaDonMua"];
            this.Ngaymua = rows["NgayMua"].ToString();
            this.Tongtien = double.Parse(rows["TongTien"].ToString());
        }

        public int Madon { get => madon; set => madon = value; }
        public string Ngaymua { get => ngaymua; set => ngaymua = value; }
        public double Tongtien { get => tongtien; set => tongtien = value; }
    }
}
