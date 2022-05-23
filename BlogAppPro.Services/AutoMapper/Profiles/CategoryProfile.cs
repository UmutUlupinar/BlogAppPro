using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BlogAppPro.Entities.Concrete;
using BlogAppPro.Entities.Dtos;

namespace BlogAppPro.Services.AutoMapper.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryAddDto, Category>()
                .ForMember(x => x.CreatedDate,
                    opt => opt
                        .MapFrom(x => DateTime.Now));
            CreateMap<CategoryUpdateDto, Category>()
                .ForMember(x => x.ModifiedDate,
                    opt => opt
                        .MapFrom(x => DateTime.Now));
        }
    }
    
    
}
