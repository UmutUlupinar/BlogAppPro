using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BlogAppPro.Data.Abstract;
using BlogAppPro.Entities.Concrete;
using BlogAppPro.Entities.Dtos;
using BlogAppPro.Services.Abstract;
using BlogAppPro.Shared.Utilities.Results.Abstract;
using BlogAppPro.Shared.Utilities.Results.Abstract.ComplexTypes;
using BlogAppPro.Shared.Utilities.Results.Concrete;

namespace BlogAppPro.Services.Concrete
{
    public class ArticleManager:IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ArticleManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IDataResult<ArticleDto>> Get(int ArticleId)
        {
            var article = await _unitOfWork.Articles.GetAsync(
                a => a.ID == ArticleId, a => a.User, a => a.Category);
            if (article != null)
            {
                return new DataResult<ArticleDto>(ResultStatus.Success,
                    new ArticleDto
                    {
                        Article = article,
                        ResultStatus = ResultStatus.Success
                    });
            }
            else
                return new DataResult<ArticleDto>(ResultStatus.Error,"Article not Found", null);
        }

        public async Task<IDataResult<ArticleListDto>> GetAll()
        {
            var articles = await _unitOfWork.Articles.GetAllAsync(null,
                a => a.User, a => a.Category);
            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success,
                    new ArticleListDto
                    {
                        Articles = articles,
                        ResultStatus = ResultStatus.Success
                    });
            }
            else
                return new DataResult<ArticleListDto>(ResultStatus.Error, "Article not Found", null);

        }

        public async Task<IDataResult<ArticleListDto>> GetAllByNonDeleted()
        {
            var articles = await _unitOfWork.Articles.GetAllAsync(
                a => !a.IsDeleted,
                a => a.User, a => a.Category);
            
            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success,
                    new ArticleListDto
                    {
                        Articles = articles,
                        ResultStatus = ResultStatus.Success
                    });
            }
            else
                return new DataResult<ArticleListDto>(ResultStatus.Error, "Article not Found", null);

        }

        public async Task<IDataResult<ArticleListDto>> GetAllByNonDeletedAndActive()
        {
            var articles = await _unitOfWork.Articles.GetAllAsync(
                a => !a.IsDeleted && a.IsActive,
                a => a.User, a => a.Category);
            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success,
                    new ArticleListDto
                    {
                        Articles = articles,
                        ResultStatus = ResultStatus.Success
                    });
            }
            else
                return new DataResult<ArticleListDto>(ResultStatus.Error, "Article not Found", null);

        }

        public async Task<IDataResult<ArticleListDto>> GetAllByCategory(int categoryID)
        {
            var result = await _unitOfWork.Categories.AnyAsync(c => c.ID == categoryID);
            if (result)
            {
                var articles = await _unitOfWork.Articles.GetAllAsync(
                    a => a.CategoryID == categoryID && !a.IsDeleted && a.IsActive,
                    a => a.User, a => a.Category);

                if (articles.Count > -1)
                {
                    return new DataResult<ArticleListDto>(ResultStatus.Success,
                        new ArticleListDto
                        {
                            Articles = articles,
                            ResultStatus = ResultStatus.Success
                        });
                }
                else
                    return new DataResult<ArticleListDto>(ResultStatus.Error, "Article not Found", null);

            }

            return new DataResult<ArticleListDto>(ResultStatus.Error, "Categori not Found", null);

        }

        public async Task<IResult> Add(ArticleAddDto articleAddDto, string createdByName)
        {
            var article = _mapper.Map<Article>(articleAddDto);
            article.CreatedByName = createdByName;
            article.ModifiedByName = createdByName;
            article.UserID = 1;
            await _unitOfWork.Articles.AddAsync(article).ContinueWith(
                    t => _unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, $"{articleAddDto.Title} added");


        }

        public async Task<IResult> Update(ArticleUpdateDto articleUpdateDto, string modifiedByName)
        {
            var article = _mapper.Map<Article>(articleUpdateDto);
            article.ModifiedByName = modifiedByName;
            await _unitOfWork.Articles.UpdateAsync(article).ContinueWith(
                    t => _unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, $"{articleUpdateDto.Title} updated");
        }

        public async Task<IResult> Delete(int articleId, string modifiedByName)
        {
            var result = await _unitOfWork.Articles.AnyAsync(a => a.ID == articleId);
            if (result)
            {
                var article = await _unitOfWork.Articles.GetAsync(a => a.ID == articleId);
                article.ModifiedByName = modifiedByName;
                article.IsDeleted = true;
                article.ModifiedDate = DateTime.Now;
                await _unitOfWork.Articles.UpdateAsync(article).ContinueWith(
                    t => _unitOfWork.SaveAsync());
                return new Result(ResultStatus.Success, $"{article.Title} deleted");
            }
            return new Result(ResultStatus.Error, "Article not Found");
        }

        public async Task<IResult> HardDelete(int articleId)
        {
            var result = await _unitOfWork.Articles.AnyAsync(a => a.ID == articleId);
            if (result)
            {
                var article = await _unitOfWork.Articles.GetAsync(a => a.ID == articleId);
                await _unitOfWork.Articles.DeleteAsync(article).ContinueWith(
                    t => _unitOfWork.SaveAsync());
                return new Result(ResultStatus.Success, $"{article.Title} deleted from database");
            }
            return new Result(ResultStatus.Error, "Article not Found");
        }
    }
}
