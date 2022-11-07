using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace NET104_Project.Models
{
    public class CuahangDbContext : DbContext
    {
        public CuahangDbContext(){}
        public CuahangDbContext(DbContextOptions options):base(options)
        {
        }
        public DbSet<Sanpham> Sanphams { get; set; }
        public DbSet<SanphamChitiet> SanphamChitiets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
           // Thực hiện các ràng buộc kết nối
           base.OnConfiguring(optionsBuilder.
               UseSqlServer("Data Source=SHANGHAIK\\SQLEXPRESS;Initial Catalog=CSharp4;" +
               "Persist Security Info=True;User ID=shanghaik;Password=123"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply cac config cho cac model
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            // Phương thức này sẽ áp dụng tất cả các config hiện có
        }
    }
}
