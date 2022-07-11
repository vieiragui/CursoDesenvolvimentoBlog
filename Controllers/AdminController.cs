using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CursoDesenvolvimentoWeb.Models;
using CursoDesenvolvimentoWeb.Repository.Interfaces;
using CursoDesenvolvimentoWeb.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CursoDesenvolvimentoWeb.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly IRepositoryBase<User> _userRepository;

        public AdminController(
            ILogger<AdminController> logger,
            IRepositoryBase<User> userRepository
        )
        {
            _logger = logger;
            _userRepository = userRepository;
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
    }
}
