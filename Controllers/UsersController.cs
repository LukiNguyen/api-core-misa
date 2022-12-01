using Employee.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Controllers {
    [ApiController]
    [Route("api/a/users")]
    public class UsersController : ControllerBase {
        private readonly IUserInterface repository;
        
        public UsersController(IUserInterface repository) {
            this.repository = repository;
        }

        // GET: /users
        [HttpGet()]
        public async Task<IActionResult> GetUsers(
            [FromQuery] string? keyword,
            [FromQuery] int? limit,
            [FromQuery] int? offset) {
            try
            {
                var users = await repository.GetUsers(keyword, limit, offset);
                if (users == null)
                    return NotFound();
                return Ok(users);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        // GET: /users/{UserId}
        [HttpGet("{UserId}")]
        public async Task<IActionResult> GetUserByID(string UserId) {
            try
            {
                var user = await repository.GetUserByID(UserId);
                if (user == null)
                    return NotFound();
                return Ok(user);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        // GET: /users/name/{FullName}
        [HttpGet("name/{FullName}")]
        public async Task<IActionResult> GetUserByFullName(string? FullName) {
            try
            {
                var user = await repository.GetUserByFullName(FullName);
                if (user == null)
                    return NotFound();
                return Ok(user);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        // GET: /users/phone/{NumberPhone}
        [HttpGet("phone/{NumberPhone}")]
        public async Task<IActionResult> GetUserByNumberPhone(string? NumberPhone) {
            try
            {
                var user = await repository.GetUserByNumberPhone(NumberPhone);
                if (user == null)
                    return NotFound();
                return Ok(user);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        // POST: /users
        [HttpPost]
        public async Task<IActionResult> CreateUser(UserCreateModel user) {
            try
            {
                var createdUser = await repository.CreateUser(user);
                return Ok(createdUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT: /users/{UserId}
        [HttpPut("{UserId}")]
        public async Task<IActionResult> UpdateUser(string UserId, UserUpdateModel user)
        {
            try
            {
                var userUpdated = await repository.GetUserByID(UserId);
                if (userUpdated == null)
                    return NotFound();
                await repository.UpdateUser(UserId, user);
                return Ok(userUpdated);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE: /users/{UserId}
        [HttpDelete("{UserId}")]
        public async Task<IActionResult> DeleteUser(string UserId) {
            try
            {
                var user = await repository.GetUserByID(UserId);
                if (user == null)
                    return NotFound();
                await repository.DeleteUser(UserId);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}