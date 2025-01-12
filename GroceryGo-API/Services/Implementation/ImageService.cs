using GroceryGo_API.Repositories.Interface;
using GroceryGo_API.Services.Interface;

namespace GroceryGo_API.Services.Implementation
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository ImageRepository;

        public ImageService(IImageRepository imageRepository)
        {
            this.ImageRepository = imageRepository;
        }

        public async Task SaveImageDetails(string fileName, int itemId, int imageTypeId)
        {
            await ImageRepository.SaveImageDetails(fileName, itemId, imageTypeId);
        }
    }
}
