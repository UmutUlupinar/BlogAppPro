using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogAppPro.Entities.Concrete;

namespace BlogAppPro.Entities.Dtos
{
    public class ArticleUpdateDto
    {
        [Required]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Thumbnail { get; set; }
        public string SeoDescription { get; set; }
        public string SeoTags { get; set; }

        public string SeoAuthor { get; set; }

        public string CategoryId { get; set; }

        public Category Category { get; set; }

        public int Userıd { get; set; }

        public User User { get; set; }


        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }
        

    }
}
