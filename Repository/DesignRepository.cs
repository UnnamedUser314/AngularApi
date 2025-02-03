using ApiPelicula.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using RestAPI.Models.Entity;
using RestAPI.Repository.IRepository;

namespace RestAPI.Repository
{
    public class DesignRepository : IDesignRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMemoryCache _cache;
        private readonly string DesignEntityCacheKey = "DesignEntityCacheKey"; //cambiadmelo lokos
        private readonly int CacheExpirationTime = 3600;
        public DesignRepository(ApplicationDbContext context, IMemoryCache cache)
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
            _cache.Remove(DesignEntityCacheKey);
        }

        public async Task<ICollection<DesignEntity>> GetAllAsync()
        {
            if (_cache.TryGetValue(DesignEntityCacheKey, out ICollection<DesignEntity> DesignsCached))
                return DesignsCached;

            var DesignsFromDb = await _context.Designs.OrderBy(c => c.Name).ToListAsync();
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                  .SetAbsoluteExpiration(TimeSpan.FromSeconds(CacheExpirationTime));

            _cache.Set(DesignEntityCacheKey, DesignsFromDb, cacheEntryOptions);
            return DesignsFromDb;
        }

        public async Task<DesignEntity> GetAsync(int id)
        {
            if (_cache.TryGetValue(DesignEntityCacheKey, out ICollection<DesignEntity> DesignsCached))
            {
                var DesignEntity = DesignsCached.FirstOrDefault(c => c.Id == id);
                if (DesignEntity != null)
                    return DesignEntity;
            }

            return await _context.Designs.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Designs.AnyAsync(c => c.Id == id);
        }

        public async Task<bool> CreateAsync(DesignEntity DesignEntity)
        {
            _context.Designs.Add(DesignEntity);
            return await Save();
        }

        public async Task<bool> UpdateAsync(DesignEntity DesignEntity)
        {
            DesignEntity.CreatedDate = DateTime.Now;
            _context.Update(DesignEntity);
            return await Save();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var DesignEntity = await GetAsync(id);
            if (DesignEntity == null)
                return false;

            _context.Designs.Remove(DesignEntity);
            return await Save();
        }
    }
}
