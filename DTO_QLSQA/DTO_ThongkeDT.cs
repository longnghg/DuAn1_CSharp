using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLSQA
{
    public class DTO_ThongkeDT
    {
        private int madonmua;
        private float tongtien;
        private string ngay;
        private string gio;
        public DTO_ThongkeDT()
        {

        }
        public DTO_ThongkeDT(DataRow rows)
        {
            this.Madonmua = (int)rows["MaDonMua"];
            this.Tongtien = float.Parse(rows["TongTien"].ToString());
            this.Ngay = rows["Ngay"].ToString();
            this.Gio = rows["Gio"].ToString();
        }


        public int Madonmua { get => madonmua; set => madonmua = value; }
        public float Tongtien { get => tongtien; set => tongtien = value; }
        public string Ngay { get => ngay; set => ngay = value; }
        public string Gio { get => gio; set => gio = value; }

    }
}
