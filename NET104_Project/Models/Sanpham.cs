using System;
using System.Collections.Generic;

namespace NET104_Project.Models
{
    public class Sanpham
    {
        public Guid Id { get; set; }
        public string Ten { get; set; }
        public bool TrangThai { get; set; }
        public virtual List<SanphamChitiet>? SanphamChitiets { get; set; }
    }
}
