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
    public class ArticleProfile:Profile
    {
        public ArticleProfile()
        {
            CreateMap<ArticleAddDto, Article>()
                .ForMember(x => x.CreatedDate,
                    opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<ArticleUpdateDto, Article>()
                .ForMember(x => x.ModifiedDate,
                    opt => opt.MapFrom(x => DateTime.Now));
            

        }
        
    }
}
