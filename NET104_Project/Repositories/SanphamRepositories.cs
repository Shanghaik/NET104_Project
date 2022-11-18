using NET104_Project.IRepositories;
using NET104_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NET104_Project.Repositories
{
    public class SanphamRepositories : ISanphamRepositories
    {
        CuahangDbContext cuahangDbContext;
        public SanphamRepositories()
        {
            this.cuahangDbContext = new CuahangDbContext();
        }
        public SanphamRepositories(CuahangDbContext cuahangDbContext) 
            // Tạo constructor
        {
            this.cuahangDbContext = cuahangDbContext;
        }

        public bool AddSanpham(Sanpham sanpham)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Sanpham> GetAll() // Lấy tất cả SP
        {
            return cuahangDbContext.Sanphams.ToList();
        }

        public Sanpham GetById(Guid id)
        {
            var sanpham = cuahangDbContext.Sanphams.Find(id);
            // Find(param) chỉ dùng với id của sản phẩm
            var sanpham2 = cuahangDbContext.Sanphams.
                FirstOrDefault(p => p.Id == id);
            return sanpham; // sanpham2
           
        }

        public bool RemoveSanpham(Sanpham sanpham) // Xóa sản phẩm
        {
            try
            {
                cuahangDbContext.Sanphams.Remove(sanpham);
                cuahangDbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool UpdateSanpham(Sanpham sanpham)
        {
            try
            {
                cuahangDbContext.Sanphams.Update(sanpham);
                cuahangDbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
