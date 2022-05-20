using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogAppPro.Entities.Concrete;

namespace BlogAppPro.Entities.Dtos
{
    public class ArticleAddDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Thumbnail { get; set; }
        public string SeoDescription { get; set; }
        public string SeoTags { get; set; }

        public string SeoAuthor { get; set; }

        public string CategoryId { get; set; }

        public Category Category { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public bool IsDeleted { get; set; }
    }
}
