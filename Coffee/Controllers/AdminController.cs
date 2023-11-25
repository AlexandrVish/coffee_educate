using Coffee.Model.Entities;
using Coffee.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Coffee.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        private NewsRepository _newsRepository;

        public AdminController(NewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Users()
        {
            var ListUsers = new List<string>();

            return View(ListUsers);
        }

        public async Task<IActionResult> News()
        {
            var ListNews = await _newsRepository.GetNewsAsync();

            return View(ListNews);
        }
    }
}
