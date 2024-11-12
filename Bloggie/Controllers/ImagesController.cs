using Microsoft.AspNetCore.Mvc;

namespace Bloggie.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImagesController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> UploadAsync(IFormFile file)
        {

            return Ok("this is images get method");
        }
    }
}
