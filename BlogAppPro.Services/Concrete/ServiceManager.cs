using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogAppPro.Entities.Dtos;
using BlogAppPro.Services.Abstract;
using BlogAppPro.Shared.Utilities.Results.Abstract;

namespace BlogAppPro.Services.Concrete
{
    public class ArticleManager:IArticleService
    {
        public Task<IDataResult<ArticleDto>> Get(int ArticleId)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<IList<ArticleListDto>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<IList<ArticleListDto>>> GetAllByNonDeleted()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<IList<ArticleListDto>>> GetAllByNonDeletedAndActive()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<ArticleListDto>> GetAllByCategory(int categoryID)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Add(ArticleAddDto articleAddDto, string createdByName)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Update(ArticleUpdateDto articleUpdateDto, string modifiedByName)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Delete(int articleId, string modifiedByName)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> HardDelete(int articleId)
        {
            throw new NotImplementedException();
        }
    }
}
