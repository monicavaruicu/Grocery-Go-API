namespace GroceryGo_API.Repositories.Interface
{
    public interface IImageRepository
    {
        Task SaveImageDetails(string fileName, int itemId, int imageTypeId);
    }
}
