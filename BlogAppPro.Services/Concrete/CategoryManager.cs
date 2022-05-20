﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public CategoryManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IDataResult<Category>> Get(int categoryId)
        {
            var category =await _unitOfWork.Categories.GetAsync(c=>c.ID==categoryId,
                c=>c.Articles);

            if (category != null)
            {
                return new DataResult<Category>(ResultStatus.Success, category);
            }
            return new DataResult<Category>(ResultStatus.Error,  "Böyle bir kategori bulunamadı",null);
        }

        public async Task<IDataResult<IList<Category>>> GetAll()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(null, c => c.Articles);
            if (categories.Count>-1)
            {
                return new DataResult<IList<Category>>(ResultStatus.Success, categories);
            }
            return new DataResult<IList<Category>>(ResultStatus.Error, "Kategori bulunamadı", null);
        }

        public async Task<IDataResult<IList<Category>>> GetAllByNonDeleted()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(c => !c.IsDeleted, c => c.Articles);
            if (categories.Count > -1)
            {
                return new DataResult<IList<Category>>(ResultStatus.Success, categories);
            }
            return new DataResult<IList<Category>>(ResultStatus.Error, "Kategori bulunamadı", null);
        }

        public async Task<IResult> Add(CategoryAddDto categoryAddDto, string createdByName)
        {
           await _unitOfWork.Categories.
               AddAsync(new Category
               {
                   Name = categoryAddDto.Name,
                   Description = categoryAddDto.Description,
                   Note = categoryAddDto.Note,
                   IsActive = categoryAddDto.IsActive,
                   CreatedByName =  createdByName,
                   CreatedDate = DateTime.Now,
                   
                   IsDeleted = false
               }).ContinueWith(t => _unitOfWork.SaveAsync());
            //await _unitOfWork.SaveAsync();
            return new Result(ResultStatus.Success,
                $"{categoryAddDto.Name} adlı kategori başarıyla eklendi");
        }

        public async Task<IResult> Update(CategoryUpdateDto categoryUpdateDto, string modifiedByName)
        {
            var category = await _unitOfWork.Categories.GetAsync(c => c.ID == categoryUpdateDto.ID,
                c => c.Articles);
            if (category != null)
            {
                category.Name = categoryUpdateDto.Name;
                category.Description = categoryUpdateDto.Description;
                category.Note = categoryUpdateDto.Note;
                category.IsActive = categoryUpdateDto.IsActive;
                category.IsDeleted = categoryUpdateDto.IsDeleted;
                category.ModifiedByName = modifiedByName;
                category.ModifiedDate = DateTime.Now;
                await _unitOfWork.Categories.UpdateAsync(category)
                     .ContinueWith(t => _unitOfWork.SaveAsync());
                return new Result(ResultStatus.Success,
                    $"{categoryUpdateDto.Name} adlı kategori başarıyla güncellendi");
            }
            return new Result(ResultStatus.Error, "Kategori bulunamadı");
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
