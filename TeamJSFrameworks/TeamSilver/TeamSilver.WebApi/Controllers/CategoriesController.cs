using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ValueProviders;
using TeamSilver.DataLayer;
using TeamSilver.Models;
using TeamSilver.WebApi.Models;
using TeamSilver.WebAPI.Attributes;

namespace TeamSilver.WebApi.Controllers
{
    public class CategoriesController : BaseApiController
    {
        [HttpGet]
        public IQueryable<CategoryModel> GetCategories(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var context = new StoreContext();
            using (context)
            {
                var user = UsersController.GetUserBySessionKey(sessionKey);
                if (user == null)
                {   
                    throw new ArgumentException("There is no user with such sessionKey!");
                }

                var newCategoryModel =
                    (from category in context.Categories
                     select new CategoryModel()
                     {
                         CategoryId=category.CategoryId,
                         CategoryName=category.CategoryName
                     }).ToList();

                return newCategoryModel.AsQueryable();
            }
             
        }



        [ActionName("products")]
        [HttpGet]
        public IQueryable<ProductModel> GetByIdCategories(
           [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey, int id)
        {
            var context = new StoreContext();
            using (context)
            {
                var user = UsersController.GetUserBySessionKey(sessionKey);
                if (user == null)
                {
                    throw new ArgumentException("There is no user with such sessionKey!");
                }

                var newProductModel =
                    (from product in context.Products
                     where product.Category.CategoryId==id
                     select new ProductModel()
                     {
                         ProductId=product.ProductId,
                         ProductsName=product.ProductName
                     }).ToList();

                return newProductModel.AsQueryable();
            }

        }
            
    }
}
