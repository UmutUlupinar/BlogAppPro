﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogAppPro.Data.Abstract;
using BlogAppPro.Entities.Concrete;
using BlogAppPro.Shared.Data.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace BlogAppPro.Data.Concrete.EntityFramework.Repositories
{
    public class CommentRepository : EfEntityRepositoryBase<Comment>, ICommentRepository
    {
        public CommentRepository(DbContext context) : base(context)
        {
        }

    }

}

