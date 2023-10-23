using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleAPI.Db;
using SampleAPI.Model;

namespace SampleAPI.Repository
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly ApiContext _dbContext;

        public RegistrationRepository(ApiContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Registration> CreateUserAsync(Registration registration)
        {
            await _dbContext.Registrations.AddAsync(registration);
            await _dbContext.SaveChangesAsync();

            return registration;
        }

        public async Task<dynamic> DeleteUserAsync(int id)
        {
            var userToDelete = await _dbContext.Registrations.Where(x => x.Id == id).Select(x => x).FirstOrDefaultAsync();

            if (userToDelete != null)
            {
                _dbContext.Registrations.Remove(userToDelete);
                await _dbContext.SaveChangesAsync(true);

                return new { isDeleted = true };
            }

            return new { isDeleted = false };
        }

        public async Task<Registration> GetUserByIDAsync(int id)
        {
            return await _dbContext.Registrations.Where(x => x.Id == id).Select(x => x).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Registration>> GetUsersAsync()
        {
            return await _dbContext.Registrations.ToListAsync();
        }

        public async Task<Registration> UpdateUserAsync(Registration registration)
        {
             _dbContext.Entry<Registration>(registration).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return registration;
        }
    }
}
