using api.Repositories.Implementations;
using GroceryGo_API.Data;
using GroceryGo_API.DTOs;
using GroceryGo_API.Entities;
using Microsoft.EntityFrameworkCore;
using Shop_API.Models.Product;
using Shop_API.Repository.Interface;
using System.Data;

namespace Shop_API.Repository.Implementation
{
    public class ProductRepository(IConfiguration configuration, ApplicationDbContext dbContext) : BaseRepository(configuration), IProductRepository
    {
        public required ApplicationDbContext DbContext { get; set; } = dbContext;

        public async Task<List<Category>> GetCategoriesAsync()
        {
           return await DbContext.Category.ToListAsync();
        }

        //public async Task<List<Product>> GetProductsAsync(ProductRequestDTO productRequestDTO)
        //{
        //    return await DbContext.Category.ToListAsync();
        //}

        //public async Task<List<CategoryModel>> GetSubCategoriesAsync(int categroyId)
        //{
        //    using (var connection = ConnectionFactory(_configuration))
        //    {
        //        return (await connection.QueryAsync<CategoryModel>(GetSubCategoriesSP,
        //            param: new
        //            {
        //                categroyId
        //            },
        //            commandType: CommandType.StoredProcedure)).ToList();
        //    }
        //}

        //public async Task SaveProductsAsync(SaveProductRequest request)
        //{
        //    using (var connection = ConnectionFactory(_configuration))
        //    {
        //        await connection.ExecuteAsync(SaveProductSP,
        //        param: new
        //        {
        //            request.Name,
        //            request.Description,
        //            request.Price,
        //            request.IsAvailable,
        //            request.SubCategoryId,
        //            request.ProviderId,
        //            request.Picture
        //        },
        //        commandType: CommandType.StoredProcedure);
        //    }
        //}

        //public async Task UpdateProductsAsync(ProductModel request)
        //{
        //    using (var connection = ConnectionFactory(_configuration))
        //    {
        //        await connection.ExecuteAsync(UpdateProductSP,
        //        param: new
        //        {
        //            request.Id,
        //            request.Name,
        //            request.Description,
        //            request.Price,
        //            request.IsAvailable,
        //            request.SubCategoryId,
        //            request.ProviderId,
        //            request.Picture
        //        },
        //        commandType: CommandType.StoredProcedure);
        //    }
        //}

        //public async Task DeleteProductsAsync(int productId)
        //{
        //    using (var connection = ConnectionFactory(_configuration))
        //    {
        //        await connection.ExecuteAsync(DeleteProductSP,
        //        param: new
        //        {
        //            productId
        //        },
        //        commandType: CommandType.StoredProcedure);
        //    }
        //}

        //public async Task<ProductModel> GetProductByIdAsync(int productId)
        //{
        //    using (var connection = ConnectionFactory(_configuration))
        //    {
        //        return (await connection.QueryFirstOrDefaultAsync<ProductModel>(GetProductSP,
        //            param: new
        //            {
        //                productId
        //            },
        //            commandType: CommandType.StoredProcedure));
        //    }
        //}

        //public async Task<CategoryModel> GetCategoryBySubcategory(int subCategoryId)
        //{
        //    using (var connection = ConnectionFactory(_configuration))
        //    {
        //        return (await connection.QueryFirstOrDefaultAsync<CategoryModel>(GetCategoryBySubcategorySP,
        //            param: new
        //            {
        //                subCategoryId
        //            },
        //            commandType: CommandType.StoredProcedure));
        //    }
        //}

        //public async Task<SubcategoryModel> GetSubcategoryById(int subCategoryId)
        //{
        //    using (var connection = ConnectionFactory(_configuration))
        //    {
        //        return (await connection.QueryFirstOrDefaultAsync<SubcategoryModel>(GetSubcategoryByIdSP,
        //            param: new
        //            {
        //                subCategoryId
        //            },
        //            commandType: CommandType.StoredProcedure));
        //    }
        //}
    }
}