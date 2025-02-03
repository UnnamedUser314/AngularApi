using ApiPelicula.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using RestAPI.Models.Entity;
using RestAPI.Repository.IRepository;

namespace RestAPI.Repository
{
    public class PujaRepository : IPujaRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMemoryCache _cache;
        private readonly string PujaEntityCacheKey = "PujaEntityCacheKey"; //cambiadmelo lokos
        private readonly int CacheExpirationTime = 3600;
        public PujaRepository(ApplicationDbContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task<bool> Save()
        {
            var result = await _context.SaveChangesAsync() >= 0;
            if (result)
            {
                ClearCache();
            }
            return result;
        }

        public void ClearCache()
        {
            _cache.Remove(PujaEntityCacheKey);
        }

        public async Task<ICollection<PujaEntity>> GetAllAsync()
        {
            if (_cache.TryGetValue(PujaEntityCacheKey, out ICollection<PujaEntity> PujasCached))
                return PujasCached;

            var PujasFromDb = await _context.Pujas.OrderBy(c => c.FirstName).ToListAsync();
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                  .SetAbsoluteExpiration(TimeSpan.FromSeconds(CacheExpirationTime));

            _cache.Set(PujaEntityCacheKey, PujasFromDb, cacheEntryOptions);
            return PujasFromDb;
        }

        public async Task<PujaEntity> GetAsync(int id)
        {
            if (_cache.TryGetValue(PujaEntityCacheKey, out ICollection<PujaEntity> PujasCached))
            {
                var PujaEntity = PujasCached.FirstOrDefault(c => c.Id == id);
                if (PujaEntity != null)
                    return PujaEntity;
            }

            return await _context.Pujas.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Pujas.AnyAsync(c => c.Id == id);
        }

        public async Task<bool> CreateAsync(PujaEntity PujaEntity)
        {
            _context.Pujas.Add(PujaEntity);
            return await Save();
        }

        public async Task<bool> UpdateAsync(PujaEntity PujaEntity)
        {
            PujaEntity.CreatedDate = DateTime.Now;
            _context.Update(PujaEntity);
            return await Save();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var PujaEntity = await GetAsync(id);
            if (PujaEntity == null)
                return false;

            _context.Pujas.Remove(PujaEntity);
            return await Save();
        }
    }
}
