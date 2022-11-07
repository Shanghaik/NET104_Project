using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NET104_Project.Models;

namespace NET104_Project.Configurations
{
    public class SanphamConfigurations : IEntityTypeConfiguration<Sanpham>
    {
        public void Configure(EntityTypeBuilder<Sanpham> builder)
        {
            // Đặt tên bảng
            builder.ToTable("Sanpham");
            // Set khóa chính
            builder.HasKey(x => x.Id);
            // Set các ràng buộc cho thuộc tính
            builder.Property(x => x.Ten).HasColumnName("Ten")
                .IsRequired().HasColumnType("nvarchar(100)");
            builder.Property(x => x.TrangThai).HasColumnName("Trangthai")
                .IsRequired().HasColumnType("bit");
        }
    }
}
