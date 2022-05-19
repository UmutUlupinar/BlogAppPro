using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogAppPro.Data.Abstract;
using BlogAppPro.Data.Concrete.EntityFramework.Contexts;
using BlogAppPro.Data.Concrete.EntityFramework.Repositories;

namespace BlogAppPro.Data.Concrete
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly BlogAppProContext _context;
        private EfArticleRepository _articleRepository;
        private EfCategoryRepository _categoryRepository;
        private EfCommentRepository _commentRepository;
        private EfUserRepository _userRepository;
        private EfRoleRepository _roleRepository;

        public UnitOfWork(BlogAppProContext context)
        {
            _context = context;
        }
      

        public IArticleRepository Articles => _articleRepository ??  new EfArticleRepository(_context);
        public ICategoryRepository Categories { get; }
        public ICommentRepository Comments { get; }
        public IUserRepository Users { get; }
        public IRoleRepository Roles { get; }
        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }
    }
}
