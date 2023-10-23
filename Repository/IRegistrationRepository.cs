using SampleAPI.Model;

namespace SampleAPI.Repository
{
    public interface IRegistrationRepository
    {
        public Task<Registration> CreateUserAsync(Registration registration);

        public Task<Registration> UpdateUserAsync(Registration registration);

        public Task<dynamic> DeleteUserAsync(int id);

        public Task<Registration> GetUserByIDAsync(int id);

        public Task<IEnumerable<Registration>> GetUsersAsync();
    }
}
