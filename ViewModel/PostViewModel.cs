using System;
using Microsoft.AspNetCore.Http;

namespace CursoDesenvolvimentoWeb.ViewModel
{
    public class PostViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Resume { get; set; }
        public string Content { get; set; }
        public IFormFile Image { get; set; }
    }
}