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
    public class CommentMap : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(a => a.ID);
            builder.Property(a => a.ID).ValueGeneratedOnAdd();
            builder.Property(a => a.IsDeleted).IsRequired();
            builder.HasOne(a => a.Article).WithMany(a => a.Comments).HasForeignKey(a => a.ArticleID);
            builder.ToTable("Comments");
            builder.HasData(
                new Comment
                {
                    ID = 1,
                    ArticleID = 1,
                    IsDeleted = false,
                    Note = "C# is a general-purpose, object-oriented programming language developed",
                },
            new Comment
                {
                    ID = 2,
                    ArticleID = 2,
                    IsDeleted = false,
                Note = "C# is a general-purpose, object-oriented programming language developed",
            }

            );

        }
    }

}

