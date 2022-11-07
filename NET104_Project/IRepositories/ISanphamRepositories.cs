using NET104_Project.Models;
using System;
using System.Collections.Generic;

namespace NET104_Project.IRepositories
{
    public interface ISanphamRepositories
    {
        IEnumerable<Sanpham> GetAll();
        Sanpham GetById(Guid id);
        bool AddSanpham(Sanpham sanpham);
        bool RemoveSanpham(Sanpham sanpham);
        bool UpdateSanpham(Sanpham sanpham);

    }
}
