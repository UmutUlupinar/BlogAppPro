using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogAppPro.Entities.Concrete;
using BlogAppPro.Shared.Entities.Abstract;
using BlogAppPro.Shared.Utilities.Results.Abstract.ComplexTypes;

namespace BlogAppPro.Entities.Dtos
{
    public class ArticleDto:DtoGetBase
    {
        public Article Article { get; set; }

        
    }
}
