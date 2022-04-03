using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using quiz_manager.Models;
using quiz_manager.Services.Interfaces;

namespace quiz_manager.Controllers
{
    /// <summary>
    /// Controller responsible for managing user
    /// </summary>
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserDataRepository _userDataRepository;

        public UsersController(IUserDataRepository userDataRepository)
        {
            _userDataRepository = userDataRepository;
        }

        /// <summary>
        /// Endpoint responsible for creating new user
        /// </summary>
        /// <param name="item">User data</param>
        /// <response code="201">Empty response signaling the user was succesfully saved.</response>
        [ProducesErrorResponseType(typeof(void))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            User newUser;
            newUser = await _userDataRepository.AddUser(user);
            if (newUser == null) return BadRequest();
            return CreatedAtAction(nameof(GetUsers), new
            {
                id = newUser.Id
            }, newUser);
        }


        /// <summary>
        /// Endpoint responsible for receiving list of users 
        /// </summary>
        /// <response code="200">List of users.</response>
        [ProducesErrorResponseType(typeof(void))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            string userId = Request.Headers["userId"];
            //if (!await UserHasPermissionForRequest(userId))
            //{
            //    return Unauthorized();
            //}
            List<User> users = await _userDataRepository.GetUsers();

            return Ok(users);
        }

        //private async Task<bool> UserHasPermissionForRequest(string userId)
        //{
        //    List<User> users = await _userDataRepository.GetUsers();
        //    try
        //    {
        //        User user = users.Where(i => i = i.Id).firstOrDefault();

        //    }
        //}
    }
}
