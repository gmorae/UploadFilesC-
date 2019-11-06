using Microsoft.AspNetCore.Http;

namespace TesteImagens.Model
{
    public class StudenModel
    {
        public string Name { get; set; }
        public IFormFile Image { get; set; }
    }
}