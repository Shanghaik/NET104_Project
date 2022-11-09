using NET104_Project.Models;
using System;
using System.Collections.Generic;

namespace NET104_Project.IRepositories
{
    public interface ISanphamRepositories
    {
        IEnumerable<Sanpham> GetAll(); // Lấy tất cả các SP trong DB
        Sanpham GetById(Guid id); // Lấy sản phẩm theo ID
        bool AddSanpham(Sanpham sanpham); // Thêm Sản phẩm
        bool RemoveSanpham(Sanpham sanpham); // Xóa
        bool UpdateSanpham(Sanpham sanpham); // Sửa 1 sản phẩm

    }
}
