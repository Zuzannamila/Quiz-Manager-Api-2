using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using quiz_manager.ViewModels;

namespace quiz_manager.Controllers
{
    public class IdentityController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        public IdentityController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
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
