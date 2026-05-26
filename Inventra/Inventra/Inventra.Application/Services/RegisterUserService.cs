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
        private readonly IPasswordService _passwordService;
        public RegisterUserService(IUserRepository userRepository,IPasswordService passwordService)
        {
            _userRepository = userRepository;
            _passwordService = passwordService;
        }

        public async Task RegisterUserAsync(RegisterUserDTO registerUserDTO)
        {
            //check if the email is already taken or not
            //var emailTaken = await _userRepository.IsEmailTakenAsync(registerUserDTO.Email);
            //if(emailTaken)
            //{
            //    throw new Exception("Email is already taken.");
            //}
            var phoneRegistered = await _userRepository.IsPhoneRegistered(registerUserDTO.Phone);
            if(phoneRegistered)
            {
                throw new Exception("Phone number is already registered.");
            }
            //now we can hash the password and create a new user entity

//            var passwordHash = HashPassword(registerUserDTO.Password);

            User user=new User(registerUserDTO.FullName, registerUserDTO.Phone, registerUserDTO.Address);


            var passwordHash = _passwordService.HashPassword(user, registerUserDTO.Password);
//            var newUser= new User(registerUserDTO.FullName, passwordHash,registerUserDTO.Phone, registerUserDTO.Address);
            user.SetPasswordHash(passwordHash);
            //save the new user to the database
            await _userRepository.AddUserAsync(user);
        }

        public async Task<UserDTO> LoginUserAsync(LoginDTO loginDTO)
        {
            var phoneRegistered = await _userRepository.IsPhoneRegistered(loginDTO.Phone);
            var passwordHash = HashPassword(loginDTO.Password);
            var passwordMatch = await _userRepository.IsPasswordMatchAsync(loginDTO.Phone, passwordHash);
            if (phoneRegistered && passwordMatch)
            {
               var userDetails= await _userRepository.GetUserByPhoneAsync(loginDTO.Phone);
                return new UserDTO
                {
                    FullName = userDetails.FullName,
                    Phone = userDetails.Phone,
                   
                };
            }
            else
            {
                throw new Exception("Invalid phone number or password.");
            }
        }

        #region Helper Methods
        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }

        

        #endregion Helper Methods

    }
}
