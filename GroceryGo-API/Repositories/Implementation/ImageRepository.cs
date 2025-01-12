using api.Repositories.Implementations;
using GroceryGo_API.Data;
using GroceryGo_API.Entities;
using GroceryGo_API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace GroceryGo_API.Repositories.Implementation
{
    public class ImageRepository(IConfiguration configuration, ApplicationDbContext dbContext) : BaseRepository(configuration), IImageRepository
    {
        public required ApplicationDbContext DbContext { get; set; } = dbContext;

        public async Task SaveImageDetails(string fileName, int itemId, int imageTypeId)
        {
            var image = new Image
            {
                FileName = fileName,
                ItemId = itemId,
                ImageTypeId = imageTypeId
            };

            DbContext.Image.Add(image);
            await DbContext.SaveChangesAsync();
        }
    }
}
