using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using TesteImagens.Model;

namespace TesteImagens.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class StudenController : ControllerBase
    {
    
    [HttpPost]
        public IActionResult Student([FromForm]StudenModel std)
        {
            // Getting Name
            string name = std.Name;
            // Getting Image
            var image = std.Image;

            var file = Request.Form.Files[0];
            // Saving Image on Server
            var filePath = Path.Combine("images", image.FileName);
            var pathToSave = Path.Combine (Directory.GetCurrentDirectory (), filePath);
            if (image.Length > 0) {
                using (var fileStream = new FileStream(pathToSave, FileMode.Create)) {
                    image.CopyTo(fileStream);}
            }

            return Ok(new { status = true, message = "Student Posted Successfully"});

        }
    }
}