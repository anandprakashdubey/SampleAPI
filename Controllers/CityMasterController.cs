using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleAPI.Model;
using SampleAPI.Repository;

namespace SampleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityMasterController : ControllerBase
    {
        private readonly ICityMasterRepository _cityMasterRepo;
        public CityMasterController(ICityMasterRepository cityMasterRepo)
        {
            _cityMasterRepo = cityMasterRepo;
        }


        [HttpGet("cities")]
        public async Task<IEnumerable<CityMaster>> Get()
        {
             return await _cityMasterRepo.GetCities();
        }
    }
}
