using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CursoDesenvolvimentoWeb.Models;
using CursoDesenvolvimentoWeb.Repository.Interfaces;
using CursoDesenvolvimentoWeb.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CursoDesenvolvimentoWeb.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly IRepositoryBase<User> _userRepository;
        private readonly IRepositoryBase<Post> _postRepository;

        public AdminController(
            ILogger<AdminController> logger,
            IRepositoryBase<User> userRepository,
            IRepositoryBase<Post> postRepository
        )
        {
            _logger = logger;
            _userRepository = userRepository;
            _postRepository = postRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }

        public async Task<IActionResult> Register(UserViewModel model)
        {
            var newUser = new User(Guid.NewGuid(), model.Name, model.Password, model.Email);

            await _userRepository.AddAsync(newUser);
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logged(UserViewModel model)
        {
            var users = await _userRepository.All();
            var userExist = users
                .Where(a => a.Password == model.Password && a.Email == model.Email)
                .Count();

            if (userExist > 0)
                return View();

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> NewPost()
        {
            await Task.Yield();
            return View();
        }

        public async Task<IActionResult> SavePost(PostViewModel model)
        {
            var id = Guid.NewGuid();
            var imageToByte = ConvertToBytes(model.Image);

            var newPost = new Post(id, model.Title, model.Resume, model.Content, imageToByte);
            await _postRepository.AddAsync(newPost);

            return RedirectToAction("NewPost", "Admin");
        }

        public async Task<IActionResult> AllPosts()
        {
            var allPosts = await _postRepository.All();
            return View(allPosts);
        }

        public async Task<IActionResult> UpdatePost(
            string id,
            string title,
            string resume,
            string content,
            IFormFile image
        )
        {
            var convertId = Guid.Parse(id);
            var imageToBytes = ConvertToBytes(image);
            var getPosts = await _postRepository.All();

            var post = getPosts.Where(p => p.Id == convertId).FirstOrDefault();

            post.Title = title;
            post.Resume = resume;
            post.Content = content;

            if (imageToBytes != null)
                post.Image = imageToBytes;

            await _postRepository.UpdateAsync(post);
            return RedirectToAction(nameof(AllPosts));
        }

        public async Task<IActionResult> DeletePost(PostViewModel post)
        {
            await _postRepository.Remove(post.Id);
            return RedirectToAction(nameof(AllPosts));
        }

        private byte[] ConvertToBytes(IFormFile image)
        {
            if (image == null)
                return null;

            using (var inputStream = image.OpenReadStream())
            using (var stream = new MemoryStream())
            {
                inputStream.CopyTo(stream);
                return stream.ToArray();
            }
        }
    }
}
