using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogAppPro.Data.Abstract;
using BlogAppPro.Data.Concrete;
using BlogAppPro.Data.Concrete.EntityFramework.Contexts;
using BlogAppPro.Services.Abstract;
using BlogAppPro.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace BlogAppPro.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyServices
            (this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<BlogAppProContext>();
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped<ICategoryService,CategoryManager>();
            serviceCollection.AddScoped<IArticleService, ArticleManager>();
            return serviceCollection;
           
        }

    }
}
