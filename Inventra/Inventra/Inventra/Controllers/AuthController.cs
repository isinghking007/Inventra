using Inventra.Application.DTOs;
using Inventra.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Inventra.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        #region Variables

        private readonly RegisterUserService _registerUserService;
        #endregion Variables

        //defining the constructor and inject the register user service
        public AuthController(RegisterUserService registerUserService)
        {
            _registerUserService = registerUserService;
        }

        [HttpPost("registerUser")]
        public async Task<IActionResult> RegisterUser(RegisterUserDTO registerUserDTO)
        {
            try
            {
                await _registerUserService.RegisterUserAsync(registerUserDTO);
                return Ok(new { Message = "User registered successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            try
            {
                var userDetails=await _registerUserService.LoginUserAsync(loginDTO);
               return Ok(new { Message = "Login successful.", UserDetails = userDetails });

            }
            catch(Exception ex)
                {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpGet("AllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _registerUserService.GetAllUsersAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }


    }
}
