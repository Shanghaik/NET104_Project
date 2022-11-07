using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NET104_Project.Models;
namespace NET104_Project.Configurations
{
    public class SanphamChitietConfigurations : IEntityTypeConfiguration<SanphamChitiet>
    {
        public void Configure(EntityTypeBuilder<SanphamChitiet> builder)
        {
            builder.ToTable("SanphamChitiet");
            builder.HasKey(c => c.IdChitietSp);
            builder.Property(c => c.Ten).HasColumnType("nvarchar(100)").
                IsRequired();
            builder.Property(c => c.Trangthai).HasColumnType("bit").
                IsRequired();
            builder.Property(c => c.Giaban).HasColumnType("int").
                IsRequired();
            builder.Property(c => c.Gianhap).HasColumnType("int").
                IsRequired();
            builder.Property(c => c.Soluong).HasColumnType("int").
                IsRequired();
            builder.HasOne(x => x.Sanpham)
            .WithMany(g => g.SanphamChitiets).HasForeignKey(p => p.IdSp);
        }
    }
}
