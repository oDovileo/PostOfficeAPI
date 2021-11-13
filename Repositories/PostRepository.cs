using Microsoft.EntityFrameworkCore;
using PostOfficeAPI.Data;
using PostOfficeAPI.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostOfficeAPI.Repositories
{
    public class PostRepository
    {
        private readonly DataContext _context;

        public PostRepository(DataContext context)
        {
            _context = context;
        }

        internal async Task<List<PostModel>> GetAllAsync()
        {
            return await _context.Posts.OrderBy(h => h.Town).ToListAsync();
        }

        public async Task<PostModel> GetByIdAsync(int id)
        {
            return await _context.Posts.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task CreateAsync(PostModel post)
        {
            _context.Add(post);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(PostModel post)
        {
            _context.Remove(post);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PostModel post)
        {
            _context.Update(post);
            await _context.SaveChangesAsync();
        }
    }
}
