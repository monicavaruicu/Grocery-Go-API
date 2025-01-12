using GroceryGo_API.DTOs;
using GroceryGo_API.Entities;
using GroceryGo_API.Repositories.Interface;
using GroceryGo_API.Repository.Implementation;
using GroceryGo_API.Services.Interface;

namespace GroceryGo_API.Services.Implementation
{
    public class SubcategoryService: ISubcategoryService
    {
        public required ISubcategoryRepository SubcategoryRepository { get; set; }

        public SubcategoryService(ISubcategoryRepository subcategoryRepository)
        {
            this.SubcategoryRepository = subcategoryRepository;
        }

        public async Task<List<Subcategory>> GetAllSubcategoriesByCategoryIdAsync(int categoryId)
        {
            return await SubcategoryRepository.GetAllSubcategoriesByCategoryIdAsync(categoryId);
        }

        public async Task<int> AddSubcategoryAsync(SubcategoryDTO model)
        {
            return await SubcategoryRepository.AddSubcategoryAsync(model);
        }
    }
}
