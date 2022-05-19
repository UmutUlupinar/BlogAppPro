﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogAppPro.Entities.Concrete;
using BlogAppPro.Entities.Dtos;
using BlogAppPro.Shared.Utilities.Results.Abstract;

namespace BlogAppPro.Services.Abstract
{
    public interface ICategoryService
    {
        Task<IDataResult<Category>> Get(int categoryId);

        Task<IDataResult<IList<Category>>> GetAll();

        Task<IResult> Add(CategoryAddDto categoryAddDto, string createdByName);

        Task<IResult> Update(CategoryUpdateDto categoryUpdateDto,string modifiedByName);

        Task<IResult> Delete(int categoryId);
        Task<IResult> HardDelete(int categoryId);
    }
}
