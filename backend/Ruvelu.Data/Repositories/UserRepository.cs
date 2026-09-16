using Microsoft.EntityFrameworkCore;
using Ruvelu.Core.Entities;
using Ruvelu.Core.Interfaces;

namespace Ruvelu.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly RuveluDbContext _context;

        public UserRepository(RuveluDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}