using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogAppPro.Entities.Concrete;
using BlogAppPro.Shared.Entities.Abstract;

namespace BlogAppPro.Entities.Dtos
{
    public class CategoryListDto:DtoGetBase
    {
        public IList<Category> Categories { get; set; }
    }
}
