using api.Repositories.Implementations;
using AutoMapper;
using GroceryGo_API.Data;
using GroceryGo_API.DTOs;
using GroceryGo_API.Entities;
using GroceryGo_API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace GroceryGo_API.Repositories.Implementation
{
    public class ProductRepository(IConfiguration configuration, ApplicationDbContext dbContext, IMapper mapper) : BaseRepository(configuration), IProductRepository
    {
        public required ApplicationDbContext DbContext { get; set; } = dbContext;
        public required IMapper Mapper { get; set; } = mapper;

        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await DbContext.Category.ToListAsync();
        }

        public async Task<List<Product>> GetProductsAsync(int subcategoryId)
        {
            return await DbContext.Product.Where(p => p.SubcategoryId == subcategoryId).ToListAsync();
        }

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

        public async Task SaveProductAsync(ProductCreateDTO productCreateDTO)
        {
            var product = new Product
            {
                Name = productCreateDTO.Name,
                Description = productCreateDTO.Description,
                Price = productCreateDTO.Price,
                Stock = productCreateDTO.Stock,
                SubcategoryId = productCreateDTO.SubcategoryId,
                ProviderId = productCreateDTO.ProviderId,
                Picture = productCreateDTO.Picture
            };

            await DbContext.AddAsync(product);
            await DbContext.SaveChangesAsync();
        }


        public async Task UpdateProductAsync(ProductDTO productDTO)
        {
            var product = await DbContext.Product.FirstOrDefaultAsync(p => p.Id == productDTO.Id) ?? throw new KeyNotFoundException();
            Mapper.Map(productDTO, product);

            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int productId)
        {
            var product = await DbContext.Product.FirstOrDefaultAsync(p => p.Id == productId) ?? throw new KeyNotFoundException();

            DbContext.Product.Remove(product);
            await DbContext.SaveChangesAsync();
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            return await DbContext.Product.FindAsync(productId) ?? throw new KeyNotFoundException();
        }
    }

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