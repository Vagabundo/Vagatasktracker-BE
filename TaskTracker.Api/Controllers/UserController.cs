// using Microsoft.AspNetCore.Mvc;
// using TaskTracker.API.DTOs;
// using TaskTracker.API.MappingProfiles;
// using TaskTracker.Application.Interfaces;
// using TaskTracker.Domain;

// namespace TaskTracker.Api.Controllers
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class UserController : ControllerBase
//     {
//         private IUserService _userService;
//         public UserController(IUserService userService)
//         {
//             _userService = userService;
//         }

//         [HttpGet]
//         public async Task<ActionResult<IEnumerable<UserDTO>>> Get()
//         {
//             return (await _userService.GetAll()).Select(Mapper.Map<User, UserDTO>).ToList();
//         }

//         [HttpGet("{id}")]
//         public async Task<ActionResult<UserDTO>> Get(Guid id)
//         {
//             var entity = await _userService.Get(id);
//             if (entity == null)
//             {
//                 return NotFound();
//             }
//             return Mapper.Map<User, UserDTO>(entity);
//         }

//         [HttpPost]
//         public async Task<ActionResult<UserDTO>> Post(UserDTO entity)
//         {
//             await _userService.Add(Mapper.Map<UserDTO, User>(entity));
//             return CreatedAtAction("Get", new { id = entity.Id }, entity);
//         }

//         [HttpPut("{id}")]
//         public async Task<IActionResult> Put(Guid id, UserDTO entity)
//         {
//             if (id != entity.Id)
//             {
//                 return BadRequest();
//             }
//             await _userService.Update(Mapper.Map<UserDTO, User>(entity));
//             return NoContent();
//         }

//         [HttpDelete("{id}")]
//         public async Task<ActionResult<UserDTO>> Delete(Guid id)
//         {
//             var entity = await _userService.Delete(id);
//             if (entity == null)
//             {
//                 return NotFound();
//             }
//             return Mapper.Map<User, UserDTO>(entity);
//         }
//     }
// }