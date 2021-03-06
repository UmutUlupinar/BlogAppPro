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
    public class CategoryManager: ICategoryService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<IDataResult<CategoryDto>> Get(int categoryId)
        {
            var category =await _unitOfWork.Categories.GetAsync(c=>c.ID==categoryId,
                c=>c.Articles);

            if (category != null)
            {
                return new DataResult<CategoryDto>(ResultStatus.Success,new CategoryDto
                {
                    Category = category,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<CategoryDto>(ResultStatus.Error,  "Böyle bir kategori bulunamadı",null);
        }

        public async Task<IDataResult<CategoryListDto>> GetAll()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(null, c => c.Articles);
            if (categories.Count>-1)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto
                {
                    Categories = categories,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<CategoryListDto>(ResultStatus.Error, "Kategori bulunamadı", null);
        }

        public async Task<IDataResult<CategoryListDto>> GetAllByNonDeleted()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(c => !c.IsDeleted, c => c.Articles);
            if (categories.Count > -1)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto
                {
                    Categories = categories,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<CategoryListDto>(ResultStatus.Error, "Kategori bulunamadı", null);
        }

        public async Task<IDataResult<CategoryListDto>> GetAllByNonDeletedAndActive()
        {

            var categories = await _unitOfWork.Categories.GetAllAsync(c => !c.IsDeleted&&c.IsActive, c => c.Articles);
            if (categories.Count > -1)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto
                {
                    Categories = categories,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<CategoryListDto>(ResultStatus.Error, "Kategori bulunamadı", null);

        }

        public async Task<IResult> Add(CategoryAddDto categoryAddDto, string createdByName)
        {
            var category
                = _mapper.Map<Category>(categoryAddDto);
            category.CreatedByName = createdByName;
            category.ModifiedByName = createdByName;


            await _unitOfWork.Categories.
               AddAsync(category)
               .ContinueWith(t => _unitOfWork.SaveAsync());
            //await _unitOfWork.SaveAsync();
            return new Result(ResultStatus.Success,
                $"{categoryAddDto.Name} adlı kategori başarıyla eklendi");
        }

        public async Task<IResult> Update(CategoryUpdateDto categoryUpdateDto, string modifiedByName)
        {
            var category = _mapper.Map<Category>(categoryUpdateDto);
            category.ModifiedByName = modifiedByName;
            
            await _unitOfWork.Categories.UpdateAsync(category)
                     .ContinueWith(t => _unitOfWork.SaveAsync());
                return new Result(ResultStatus.Success,
                    $"{categoryUpdateDto.Name} adlı kategori başarıyla güncellendi");
        }
        
        

        public async Task<IResult> Delete(int categoryId, string modifiedByName)
        {
            var category = await _unitOfWork.Categories.GetAsync(c => c.ID == categoryId);
            if (category != null)
            {
                category.IsDeleted = true;
                category.ModifiedByName = modifiedByName;
                category.ModifiedDate = DateTime.Now;
                await _unitOfWork.Categories.UpdateAsync(category)
                    .ContinueWith(t => _unitOfWork.SaveAsync());
                return new Result(ResultStatus.Success,
                    $"{category.Name} adlı kategori başarıyla silindi");
            }

            return new Result(ResultStatus.Error, "Kategori bulunamadı");
        }

        public async Task<IResult> HardDelete(int categoryId)
        {
            var category = await _unitOfWork.Categories.GetAsync(c => c.ID == categoryId);
            if (category != null)
            {
                await _unitOfWork.Categories.DeleteAsync(category).
                    ContinueWith(t => _unitOfWork.SaveAsync());
                return new Result(ResultStatus.Success,
                    $"{category.Name} adlı kategori veritabından tamamen başarıyla silindi");
            }
            return new Result(ResultStatus.Error, "Kategori bulunamadı");
        }
    }
}
