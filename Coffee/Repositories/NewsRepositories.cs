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
        private ApplicationDbContext _context;

        public NewsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<List<News>> GetNewsAsync()
        {
            return await _context.News.ToListAsync();
        }
    }
}
