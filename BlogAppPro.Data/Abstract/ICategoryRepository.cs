using BlogAppPro.Entities.Concrete;
using BlogAppPro.Shared.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppPro.Data.Abstract
{
    public interface ICategoryRepository : IEntityRepository<Category>
    {
    }
}
