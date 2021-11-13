using Microsoft.EntityFrameworkCore;
using PostOfficeAPI.Data;
using PostOfficeAPI.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostOfficeAPI.Repositories
{
    public class ParcelRepository
    {
        private readonly DataContext _context;

        public ParcelRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<List<ParcelModel>> GetAsync()
        {
            return await _context.Parcels.OrderByDescending(b => b.Weight).ToListAsync();
        }

        public async Task<ParcelModel> GetByIdAsync(int id)
        {
            var parcel = await _context.Parcels.FirstOrDefaultAsync(e => e.Id == id);
            return parcel;
        }

        public async Task<ParcelModel> AddAsync(ParcelModel parcel)
        {
            _context.Add(parcel);
            await _context.SaveChangesAsync();
            return parcel;
        }

        public async Task DeleteAsync(ParcelModel parcel)
        {
            _context.Remove(parcel);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ParcelModel parcel)
        {
            _context.Update(parcel);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ParcelModel>> FilterByPostId(int id)
        {
            return await _context.Parcels.Where(b => b.PostId == id).ToListAsync();
        }
    }
}
