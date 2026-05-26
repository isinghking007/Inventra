using Inventra.Application.Interfaces;
using Inventra.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventra.Application.Services
{
    public   class PasswordService : IPasswordService
    {
        private readonly PasswordHasher<User> _passwordHasher;
        public PasswordService()
        {
            _passwordHasher = new PasswordHasher<User>();
        }

        public string HashPassword(User user, string password)
        {
            return _passwordHasher.HashPassword(user, password);
        }

        public bool VerifyPassword(User user, string storedHash, string enteredPassword)
        {
           var result = _passwordHasher.VerifyHashedPassword(user, storedHash, enteredPassword);
            return result == PasswordVerificationResult.Success;
        }
    }
}
