using Microsoft.AspNetCore.Mvc;
using TaskTracker.Application.Interfaces;
using TaskTracker.Domain;

namespace TaskTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            var all = await _userService.GetAll();
            return all.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            var entity = await _userService.Get(id);
            if (entity == null)
            {
                return NotFound();
            }
            return entity;
        }

        [HttpPost]
        public async Task<ActionResult<User>> Post(User entity)
        {
            await _userService.Add(entity);
            return CreatedAtAction("Get", new { id = entity.Id }, entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, User entity)
        {
            if (id != entity.Id)
            {
                return BadRequest();
            }
            await _userService.Update(entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(int id)
        {
            var entity = await _userService.Delete(id);
            if (entity == null)
            {
                return NotFound();
            }
            return entity;
        }
    }
}