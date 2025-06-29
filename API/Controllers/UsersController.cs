using BLL.DTO.Users;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UsersController : ControllerBase
	{
		private readonly IUserService _userService;

		public UsersController(IUserService userService)
		{
			_userService = userService;
		}

		[HttpGet]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
		{
			var users = await _userService.GetAllUsersAsync(cancellationToken);
			return Ok(users);
		}

		[HttpGet("{id}")]
		[Authorize]
		public async Task<IActionResult> GetById(int id)
		{
			var user = await _userService.GetUserByIdAsync(id);
			return Ok(user);
		}

		[HttpGet("username/{username}")]
		[Authorize]
		public async Task<IActionResult> GetByUsername(string username)
		{
			var user = await _userService.GetUserByUsernameAsync(username);
			return Ok(user);
		}

		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> Create([FromBody] UserCreateDto dto)
		{
			var createdUser = await _userService.CreateUserAsync(dto);
			return CreatedAtAction(nameof(GetById), new { id = createdUser.Id }, createdUser);
		}

		[HttpPut("{id}")]
		[Authorize]
		public async Task<IActionResult> Update(int id, [FromBody] UserUpdateDto dto)
		{
			await _userService.UpdateUserAsync(id, dto);
			return NoContent();
		}

		[HttpDelete("{id}")]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Delete(int id)
		{
			await _userService.DeleteUserAsync(id);
			return NoContent();
		}

		[HttpPost("filter")]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Filter([FromBody] UserFilterDto filter)
		{
			var result = await _userService.GetFilteredAsync(filter);
			return Ok(result);
		}
	}
}
