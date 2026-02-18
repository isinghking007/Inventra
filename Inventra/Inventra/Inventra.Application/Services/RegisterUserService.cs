using Inventra.Application.DTOs;
using Inventra.Application.Interfaces;
using Inventra.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Inventra.Application.Services
{
    public class RegisterUserService
    {
        private readonly IUserRepository _userRepository;
        public RegisterUserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task RegisterUserAsync(RegisterUserDTO registerUserDTO)
        {
            //check if the email is already taken or not
            var emailTaken = await _userRepository.IsEmailTakenAsync(registerUserDTO.Email);
            if(emailTaken)
            {
                throw new Exception("Email is already taken.");
            }
            //now we can hash the password and create a new user entity

            var passwordHash = HashPassword(registerUserDTO.Password);

            var newUser= new User(registerUserDTO.FullName, registerUserDTO.Email, passwordHash);

            //save the new user to the database
            await _userRepository.AddUserAsync(newUser);
        }
        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
    }
}
