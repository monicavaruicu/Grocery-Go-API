using GroceryGo_API.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("image")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageService ImageService;

        public ImageController(IImageService imageService)
        {
            this.ImageService = imageService;
        }

        private readonly string ImagesDirectory = "D:\\Facultate\\Proiecte\\GroceryGo\\GroceryGo-API\\GroceryGo-API\\Assets\\Images";

        //[HttpPost("upload")]
        //public async Task<IActionResult> UploadImage([FromQuery] int imageTypeId, [FromQuery] int itemId, [FromForm] IFormFile file)
        //{
        //    try
        //    {
        //        var directory = ImagesDirectory;

        //        if (file == null || file.Length == 0)
        //        {
        //            return BadRequest("No file uploaded");
        //        }

        //        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

        //        await ImageService.SaveImageDetails(fileName, itemId, imageTypeId);

        //        if (imageTypeId == 1)
        //        {
        //            directory = Path.Combine(ImagesDirectory, "Categories");
        //        }

        //        var filePath = Path.Combine(directory, fileName);

        //        using (var stream = new FileStream(filePath, FileMode.Create))
        //        {
        //            await file.CopyToAsync(stream);
        //        }

        //        return Ok(new { FileName = fileName });
                
        //    }
        //    catch (Exception)
        //    {
        //        return BadRequest();
        //    }
        //}
    }
}
