using SampleAPI.Model;

namespace SampleAPI.Repository
{
    public interface ICityMasterRepository
    {
        public Task<CityMaster> CreateCity(CityMaster city);
        public Task<IEnumerable<CityMaster>> GetCities();
    }
}
