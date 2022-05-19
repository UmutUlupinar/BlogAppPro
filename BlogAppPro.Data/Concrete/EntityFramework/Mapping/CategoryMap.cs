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
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(a => a.ID);
            builder.Property(a => a.ID).ValueGeneratedOnAdd();
            builder.Property(a => a.Name).HasMaxLength(50).IsRequired();
            builder.Property(a => a.IsDeleted).IsRequired();
            builder.ToTable("Categories");
            builder.HasData(
                new Category()
                {
                    ID = 1,
                    Name = "C#",
                    IsDeleted = false,
                    Note = "C# is a general-purpose, object-oriented programming language developed",

                },
                new Category()
                {
                    ID = 2,
                    Name = "Java",
                    IsDeleted = false,
                    Note = "Java is a general-purpose, object-oriented programming language developed"
                }
                );
        }
    }
}
