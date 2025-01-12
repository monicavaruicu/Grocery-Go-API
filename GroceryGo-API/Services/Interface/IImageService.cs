namespace GroceryGo_API.Services.Interface
{
    public interface IImageService
    {
        Task SaveImageDetails(string fileName, int itemId, int imageTypeId);
    }
}
