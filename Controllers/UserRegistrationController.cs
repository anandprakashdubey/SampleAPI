using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleAPI.Model;
using SampleAPI.Repository;

namespace SampleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRegistrationController : ControllerBase
    {
        private readonly IRegistrationRepository _registrationRepository;
        public UserRegistrationController(IRegistrationRepository registrationRepository)
        {
            _registrationRepository = registrationRepository;
        }

        [HttpPost]
        [Route("createUser")]
        public async Task<ActionResult<Registration>> userRegister(Registration registration)
        {
            registration = await _registrationRepository.CreateUserAsync(registration);

            return registration;
        }

        [HttpPost]
        [Route("updateUser")]
        public async Task<ActionResult<Registration>> updateRegister(Registration registration)
        {
            registration = await _registrationRepository.UpdateUserAsync(registration);

            return registration;
        }

        [HttpPost]
        [Route("deleteUser/{id}")]
        public async Task<ActionResult<dynamic>> deleteRegister(int id)
        {
             return await _registrationRepository.DeleteUserAsync(id);
          
        }

        [HttpGet]
        [Route("getUser/{id}")]
        public async Task<ActionResult<Registration>> getRegister(int id)
        {
            return await _registrationRepository.GetUserByIDAsync(id);

        }

        [HttpGet]
        [Route("getUsers")]
        public async Task<IEnumerable<Registration>> getRegister()
        {
            return await _registrationRepository.GetUsersAsync();

        }

    }
}
