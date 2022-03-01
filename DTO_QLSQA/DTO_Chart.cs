using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLSQA
{
    public class DTO_Chart
    {
        private int thang;
        private int nam;
        private double tongtien;
        public DTO_Chart()
        {

        }

        public int Thang { get => thang; set => thang = value; }
        public int Nam { get => nam; set => nam = value; }
        public double Tongtien { get => tongtien; set => tongtien = value; }
    }
}
