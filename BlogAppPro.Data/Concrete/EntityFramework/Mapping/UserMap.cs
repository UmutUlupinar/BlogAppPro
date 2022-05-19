using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogAppPro.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogAppPro.Data.Concrete.EntityFramework.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(a => a.ID);
            builder.Property(a => a.ID).ValueGeneratedOnAdd();
            builder.Property(a => a.RoleID).IsRequired();
            builder.Property(a => a.UserName).HasMaxLength(50).IsRequired();
            builder.Property(a => a.PasswordHash).HasMaxLength(50).IsRequired();
            builder.Property(a => a.IsDeleted).IsRequired();
            builder.HasOne<Role>(a => a.Role).WithMany(a => a.Users).HasForeignKey(a => a.RoleID);
            builder.ToTable("Users");
            builder.HasData(
                new User
                {
                    ID = 1,
                    UserName = "Admin",
                    RoleID = 1,
                    PasswordHash = Encoding.ASCII.GetBytes("202cb962ac59075b964b07152d234b70"),
                    IsDeleted = false,
                });
        }
    }
}
