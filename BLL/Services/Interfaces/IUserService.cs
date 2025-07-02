using BLL.DTO.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
	public interface IUserService
	{
		Task<IEnumerable<UserResponseDto>> GetAllUsersAsync(CancellationToken cancellationToken = default);
		Task<UserResponseDto> GetUserByIdAsync(string id);
		Task<UserResponseDto> GetUserByUsernameAsync(string username);
		Task<UserResponseDto> CreateUserAsync(UserCreateDto userCreateDto);
		Task UpdateUserAsync(string id, UserUpdateDto userUpdateDto);
		Task DeleteUserAsync(string id);
		Task<IEnumerable<UserResponseDto>> GetFilteredAsync(UserFilterDto filter);
	}
}
