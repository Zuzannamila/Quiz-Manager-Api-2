using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using quiz_manager.ViewModels;

namespace quiz_manager.Controllers
{
    public class IdentityController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public IdentityController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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
            return Ok(new
            {
                result = result,
                username = userFromDb.UserName,
                useremail = userFromDb.Email,
                token = "Token goes here"
            }); 
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
        public async Task<IActionResult> Register(RegisterModel model)
        {
            var userToCreate = new IdentityUser
            {
                Email = model.Email,
                UserName = model.UserName
            };
            var result = await _userManager.CreateAsync(userToCreate, model.Password);
            if (result.Succeeded)
            {
                return Ok(result);
            }
            return BadRequest(result);
            
        }
    }
}
