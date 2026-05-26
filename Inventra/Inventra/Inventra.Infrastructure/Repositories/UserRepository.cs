using Inventra.Application.Interfaces;
using Inventra.Domain.Entities;
using Inventra.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventra.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;
        public UserRepository(AppDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task AddUserAsync(User user)
        {
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User?> GetUserByPhoneAsync(string phone)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Phone == phone);
        }

        //public async Task<bool> IsEmailTakenAsync(string email)
        //{
        //    return await _dbContext.Users.AnyAsync(u => u.Email == email);
        //}

        public async Task<bool> IsPhoneRegistered(string phone)
        {
            return await _dbContext.Users.AnyAsync(u => u.Phone == phone);
        }

        public async Task<bool> IsPasswordMatchAsync(string phone, string password)
        {
            var user = await GetUserByPhoneAsync(phone);
            if (user == null) return false;
            return user.PasswordHash == password;
        }
    }
}
