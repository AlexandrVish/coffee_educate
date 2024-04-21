using Coffee.Data;
using Coffee.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee.Repositories
{
    public class NewsRepository
    {
        private readonly ApplicationDbContext _context;

        public NewsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<News>> GetNewsAsync()
        {
            return await _context.News.ToListAsync();
        }

        public async Task<News> CreateNewsAsync(News news)
        {
            _context.News.Add(news);
            var result = await _context.SaveChangesAsync();
            return news;
        }

        public async Task<News> GetOneNewsAsync(int id)
        {
            return await _context.News.Where(x => x.Id == id).FirstAsync();
        }

        public async Task<News>UpdateNewsAsync(News news)
        {
            var item = _context.News.Where(x => x.Id == news.Id).First();

            item.Title = news.Title;
            item.Text = news.Text;
            item.IsActive = news.IsActive;

            var result = await _context.SaveChangesAsync();
            return item;
        }

        public async Task DeleteNewsAsync(int id)
        {
            var item = await _context.News.Where(x => x.Id == id).FirstAsync();
            _context.News.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}
