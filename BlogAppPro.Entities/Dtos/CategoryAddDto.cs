using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppPro.Entities.Dtos
{
    public class CategoryAddDto
    {
        [DisplayName("Category Name")]
        [Required(ErrorMessage = "Category Name is required")]
        [MaxLength(70 ,ErrorMessage="{0} can not be more than {1} characters")]
        [MinLength(3, ErrorMessage = "{0} can not be less than {1} characters")]
        public string Name { get; set; }
        [DisplayName("Description")]
        [Required(ErrorMessage = "Category Name is required")]
        public string Description { get; set; }
        [DisplayName("Note")]
        [Required(ErrorMessage = "Category Name is required")]
        public string Note { get; set; }
        [DisplayName("Is Active?")]
        [Required(ErrorMessage = "Category Name is required")]
        public bool IsActive { get; set; }
        
    }
}
