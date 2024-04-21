using Coffee.Data;
using Coffee.Model;
using Coffee.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Coffee.Repositories;

public class DataRepository
{
    private readonly ApplicationDbContext _context;

    public DataRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<User>> GetUserAsync()
    {
        return await _context.Users.ToListAsync();
    }


}
