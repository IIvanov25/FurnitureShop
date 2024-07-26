using FurnitureShopNew.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
                await _userService.HandleSignUpAsync(
                    userSignUpDTO.UserName,
                    userSignUpDTO.FirstName,
                    userSignUpDTO.LastName,
                    userSignUpDTO.Email,
                    userSignUpDTO.PhoneNumber,
                    userSignUpDTO.Password
                );

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
                var token = await _userService.AuthenticateUserAsync(userLoginDTO.UserName, userLoginDTO.Password);

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

        [HttpGet("getAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _userService.GetAllUsersAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("me")]
        [Authorize]
        public async Task<IActionResult> GetCurrentUser()
        {
            var token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized("Token is missing");
            }

            try
            {
                var user = await _userService.GetCurrentUserAsync(token);

                if (user == null)
                {
                    return Unauthorized("Token expired or invalid");
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("deleteUser")]
        public async Task<IActionResult> DeleteUser([FromBody] UserDeleteDTO deleteUserDTO)
        {
            if (deleteUserDTO == null || deleteUserDTO.UserId <= 0)
            {
                return BadRequest("Invalid user ID");
            }

            try
            {
                var result = await _userService.DeleteUserAsync(deleteUserDTO.UserId);

                if (!result)
                {
                    return NotFound("User not found");
                }

                return Ok("User deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}