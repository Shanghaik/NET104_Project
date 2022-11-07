using System;

namespace NET104_Project.Models
{
    public class SanphamChitiet
    {
        public Guid IdChitietSp { get; set; }
        public Guid IdSp { get; set; }
        public string Ten { get; set; }
        public double Gianhap { get; set; }
        public double Giaban { get; set; }
        public int Soluong { get; set; }
        public bool Trangthai { get; set; }
        public Sanpham Sanpham { get; set; }
    }
}
