using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogAppPro.Entities.Concrete;
using BlogAppPro.Entities.Dtos;
using BlogAppPro.Shared.Utilities.Results.Abstract;

namespace BlogAppPro.Services.Abstract
{
    public interface IArticleService
    {
        Task<IDataResult<ArticleDto>> Get(int ArticleId);

        Task<IDataResult<IList<ArticleListDto>>> GetAll();

        Task<IDataResult<IList<ArticleListDto>>> GetAllByNonDeleted();
        Task<IDataResult<IList<ArticleListDto>>> GetAllByNonDeletedAndActive();

        Task<IDataResult<ArticleListDto>> GetAllByCategory(int categoryID);

        Task<IResult> Add(ArticleAddDto articleAddDto, string createdByName);

        Task<IResult> Update(ArticleUpdateDto articleUpdateDto, string modifiedByName);

        Task<IResult> Delete(int articleId, string modifiedByName);
        Task<IResult> HardDelete(int articleId);

    }
}
