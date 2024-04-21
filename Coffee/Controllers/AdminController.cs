using System.Security.Claims;
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
        private readonly NewsRepository _newsRepository;
        private readonly DataRepository _dataRepository;


        public AdminController(NewsRepository newsRepository, DataRepository dataRepository)
        {
            _newsRepository = newsRepository;
            _dataRepository = dataRepository;
            
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Users()
        {
            var ListUsers = await _dataRepository.GetUserAsync();

            return View(ListUsers);
        }

        public async Task<IActionResult> News()
        {
            var ListNews = await _newsRepository.GetNewsAsync();

            return View(ListNews);
        }

        [Route("/admin/news/createNews")]
        [HttpGet]
        public IActionResult CreateNews()
        {
            return View();
        }

        [Route("/admin/news/createNews")]
        [HttpPost]
        public async Task<IActionResult> CreateNews(News news)
        {
            news.Date = DateTime.SpecifyKind(news.Date, DateTimeKind.Utc);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!string.IsNullOrEmpty(userId))
            {
                news.AuthorId = userId;
                await _newsRepository.CreateNewsAsync(news);
            }
            return Redirect("/admin/news");
        }

        [Route("/admin/news/edit/{id}")]
        [HttpGet]
        public async Task<IActionResult> EditOneNews(int id)
        {
            var news = await _newsRepository.GetOneNewsAsync(id);
            return View(news);
        }

        [Route("/admin/news/edit/{id}")]
        [HttpPost]
        public async Task<IActionResult> EditOneNews(News news)
        {
            news.Date = DateTime.SpecifyKind(news.Date, DateTimeKind.Utc);

            var result = await _newsRepository.UpdateNewsAsync(news);

            return Redirect("/admin/news");
        }

        [Route("/admin/news/delete/{id}")]
        [HttpGet]
        public async Task<IActionResult> DeleteNews(int id)
        {
             await _newsRepository.DeleteNewsAsync(id);

            return Redirect("/admin/news");
        }


    }
}
