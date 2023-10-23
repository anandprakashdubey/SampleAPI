using Microsoft.EntityFrameworkCore;
using SampleAPI.Db;
using SampleAPI.Model;

namespace SampleAPI.Repository
{
    public class CityMasterRepository : ICityMasterRepository
    {
        private readonly ApiContext _dbContext;

        public CityMasterRepository(ApiContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<CityMaster> CreateCity(CityMaster city)
        {
            await _dbContext.Cities.AddAsync(city);
            await _dbContext.SaveChangesAsync();

            return city;
        }

        public async Task<IEnumerable<CityMaster>> GetCities()
        {
            return await _dbContext.Cities.ToListAsync();
        }
    }
}
