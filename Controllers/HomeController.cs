using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CursoDesenvolvimentoWeb.Models;
using CursoDesenvolvimentoWeb.Repository.Interfaces;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace CursoDesenvolvimentoWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositoryBase<Post> _postRepository;

        public HomeController(ILogger<HomeController> logger, IRepositoryBase<Post> postRepository)
        {
            _logger = logger;
            _postRepository = postRepository;
        }

        public async Task<IActionResult> Index()
        {
            var allPosts = await _postRepository.All();
            ViewBag.AllPosts = allPosts;
            return View(allPosts);
        }

        public async Task<IActionResult> Post(string postId)
        {
            var idFormated = Guid.Parse(postId);
            var getPost = await _postRepository.GetPerId(idFormated);

            var allPosts = await _postRepository.All();
            ViewBag.AllPosts = allPosts;

            return View(getPost);
        }

        public async Task<IActionResult> SearchPost(string title) { 
            var allPost = await _postRepository.All();
            var postSelected = allPost.Where(p => p.Title.ToUpper().Contains(title.ToUpper())).ToList();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(
                new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                }
            );
        }
    }
}
