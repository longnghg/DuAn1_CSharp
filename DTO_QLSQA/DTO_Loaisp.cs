using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLSQA
{
    public class DTO_Loaisp
    {
        private string maLoai;
        private string tenLoai;
        public DTO_Loaisp(DataRow rows)
        {
            this.maLoai = rows["maloai"].ToString();
        }
        public string MaLoai { get => maLoai; set => maLoai = value; }
        public string TenLoai { get => tenLoai; set => tenLoai = value; }
    }
}
