using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QLSQA;
using DAO_QLSQA;
namespace BUS_QLSQA
{
    public class BUS_CTSanPham
    {
        DAO_CTSanPham daoctsp = new DAO_CTSanPham();
        // Load số lượng màu mà sản phẩm có
        public List<DTO_CTSanPham> ShowColorofImage(string masp)
        {
            return daoctsp.ShowColorofImage(masp);
        }
        // Load  size của sp
        public List<DTO_CTSanPham> ShowSizeofItem(string masp)
        {
            return daoctsp.ShowSizeofItem(masp);
        }
        // Load màu theo size
        public List<DTO_CTSanPham> ShowColorBySize(string masp, int masize)
        {
            return daoctsp.ShowColorBySize(masp,masize);
        }
        // Load số lượng sau khi đã chọn màu và size
        public List<DTO_CTSanPham> LoadQuantityBySizeAndColor(string masp, int masize, int mamau)
        {
            return daoctsp.LoadQuantityBySizeAndColor(masp, masize, mamau);
        }
        // hàm định dạng lại giá tiền
        public string GiaTien(string text)
        {
            string output = "";
            foreach (char item in text)
            {
                output += item;
                switch (text.Length)
                {
                    case 4:
                        if (output.Length == 1)
                            output += "."; break;
                    case 5:
                        if (output.Length == 2)
                            output += "."; break;
                    case 6:
                        if (output.Length == 3)
                            output += "."; break;
                    case 7:
                        if (output.Length == 1 || output.Length == 5)
                            output += "."; break;
                    case 8:
                        if (output.Length == 2 || output.Length == 6)
                            output += "."; break;
                    case 9:
                        if (output.Length == 3 || output.Length == 7)
                            output += "."; break;
                    case 10:
                        if (output.Length == 1 || output.Length == 5|| output.Length == 9)
                            output += "."; break;

                }
            }
            return output;

        }
        // DỮ LIỆU CHO BẢNG  THANHTOAN
        public List<DTO_CTSanPham> ShowSizeofItem1(string masp)
        {
            return daoctsp.ShowSizeofItem1(masp);
        }
        public List<DTO_CTSanPham> ShowColorBySize1(string masp, int masize)
        {
            return daoctsp.ShowColorBySize1(masp, masize);
        }
    }
}
