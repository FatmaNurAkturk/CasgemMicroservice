using CasgemMicroservice.PhotoStockk.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CasgemMicroservice.PhotoStockk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoStockController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> SavePhtot(IFormFile formFile, CancellationToken cancellationToken)
        {
            if(formFile != null && formFile.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/photo", formFile.FileName);
                using var stream = new FileStream(path, FileMode.Create);
                await formFile.CopyToAsync(stream, cancellationToken);
                var returnPath = formFile.FileName;
                PhotoDto photo = new PhotoDto()
                {
                    URL = returnPath
                };
                return Ok("Fotoğraf başarıyla kaydedildi.");

            }
            return Ok();
        }
    }
}
