using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogAppPro.Data.Concrete.EntityFramework.Mapping;
using BlogAppPro.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BlogAppPro.Data.Concrete.EntityFramework.Contexts
{
    public class BlogAppProContext : DbContext
    {
        public BlogAppProContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Article> Articles { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=(localdb)\ProjectsV13;Database=BlogAppPro;Trusted_Connection=True;Connect Timeout=30;MultipleActiveResultSets=True;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleMap());
            modelBuilder.ApplyConfiguration(new CommentMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new RoleMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());
        }
    }
}
