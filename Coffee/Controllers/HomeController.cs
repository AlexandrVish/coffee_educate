using Coffee.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee.Controllers
{
    public class HomeController: Controller
    {
        private NewsRepository _newsRepository;

        public HomeController(NewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> News()
        {
            var ListNews = await _newsRepository.GetNewsAsync();

            return View(ListNews.Where(x => x.IsActive).ToList());
        }
    }
}
