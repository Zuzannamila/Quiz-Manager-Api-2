using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using quiz_manager.Services.Interfaces;
using quiz_manager.ViewModels;

namespace quiz_manager.Controllers
{
    public class IdentityController : ControllerBase
    {
        private readonly IJWTTokenGenerator _jwtToken;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public IdentityController(
            UserManager<IdentityUser> userManager, 
            SignInManager<IdentityUser> signInManager, 
            IJWTTokenGenerator jwtToken,
            RoleManager<IdentityRole> roleManager)
        {
            _jwtToken = jwtToken;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        /// <summary>
        /// Endpoint responsible for registering new user
        /// </summary>
        /// <param name="item">User data</param>
        /// <response code="201">Empty response signaling the user was succesfully saved.</response>
        [ProducesErrorResponseType(typeof(void))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var userFromDb = await _userManager.FindByEmailAsync(model.Email);
            if (userFromDb == null)
            {
                return BadRequest();
            }

            var result = await _signInManager.CheckPasswordSignInAsync(userFromDb, model.Password, false);
            if (!result.Succeeded)
            {
                return BadRequest();
            }
            var roles = await _userManager.GetRolesAsync(userFromDb);
            return Ok(new
            {
                result = result,
                username = userFromDb.UserName,
                useremail = userFromDb.Email,
                token = _jwtToken.GenerateToken(userFromDb, roles)
            }); ; 
        }


        /// <summary>
        /// Endpoint responsible for registering new user
        /// </summary>
        /// <param name="item">User data</param>
        /// <response code="201">Empty response signaling the user was succesfully saved.</response>
        [ProducesErrorResponseType(typeof(void))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("register")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!(await _roleManager.RoleExistsAsync(model.Role)))
            {
                await _roleManager.CreateAsync(new IdentityRole(model.Role));
            }
            var userToCreate = new IdentityUser
            {
                Email = model.Email,
                UserName = model.UserName
            };
            var result = await _userManager.CreateAsync(userToCreate, model.Password);
            if (result.Succeeded)
            {
                var userFromDb = await _userManager.FindByNameAsync(model.UserName);
                await _userManager.AddToRoleAsync(userFromDb, model.Role);
                return Ok(result);
            }
            return BadRequest(result);
            
        }
    }
}
