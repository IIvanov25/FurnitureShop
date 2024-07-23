using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

using FurnitureShopNew.Services;

using System.Reflection.Metadata;
using System.ComponentModel;

namespace FurnitureShopNew.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] UserSignUpDTO userSignUpDTO)
        {
            if (userSignUpDTO == null)
            {
                return BadRequest("User data is null");
            }
            try
            {
                await _userService.HandleSignUpAsync(userSignUpDTO.UserName,
                    userSignUpDTO.Password,
                    userSignUpDTO.FirstName,
                    userSignUpDTO.LastName,
                    userSignUpDTO.Email,
                    userSignUpDTO.PhoneNumber);

                return Ok("User created successfully!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLogInDTO userLoginDTO)
        {
            if (userLoginDTO == null)
            {
                return BadRequest("User login data is null");
            }

            try
            {
                var token = await _userService.AuthenticateUser(userLoginDTO.UserName, userLoginDTO.Password);

                if (string.IsNullOrEmpty(token))
                {
                    return Unauthorized("Invalid username or password");
                }

                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }


    }
}
