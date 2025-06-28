using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using MapsterMapper;
using BLL.DTO.Users;
using BLL.Exceptions;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
	public class UserService : IUserService
	{
		private readonly IUsersRepository _usersRepository;
		private readonly IMapper _mapper;

		public UserService(IUsersRepository usersRepository, IMapper mapper)
		{
			_usersRepository = usersRepository;
			_mapper = mapper;
		}

		public async Task<IEnumerable<UserResponseDto>> GetAllUsersAsync(CancellationToken cancellationToken = default)
		{
			var users = await _usersRepository.GetAllAsync(cancellationToken);
			return _mapper.Map<IEnumerable<UserResponseDto>>(users);
		}

		public async Task<UserResponseDto> GetUserByIdAsync(int userId)
		{
			var user = await _usersRepository.GetByIdAsync(userId) ?? throw new UserNotFoundException();
			return _mapper.Map<UserResponseDto>(user);
		}

		public async Task<UserResponseDto> GetUserByUsernameAsync(string username)
		{
			var user = await _usersRepository.GetByUsernameAsync(username) ?? throw new UserNotFoundException();
			return _mapper.Map<UserResponseDto>(user);
		}

		public async Task<UserResponseDto> CreateUserAsync(UserCreateDto userCreateDto)
		{
			var existingUser = await _usersRepository.GetByUsernameAsync(userCreateDto.UserName);

			if (existingUser != null)
			{
				throw new UserAlreadyExistsException();
			}

			var user = userCreateDto.Adapt<Users>();
			await _usersRepository.AddAsync(user);
			await _usersRepository.SaveChangesAsync();

			// Fixing CS0428: Invoking the BuildAdapter method to return the mapped UserResponseDto
			return _mapper.Map<UserResponseDto>(user);
		}

		public async Task UpdateUserAsync(int userId, UserUpdateDto userUpdateDto)
		{
			var user = await _usersRepository.GetByIdAsync(userId) ?? throw new UserNotFoundException();
			userUpdateDto.Adapt(user);
			_usersRepository.Update(user);
			await _usersRepository.SaveChangesAsync();
		}

		public async Task DeleteUserAsync(int userId)
		{
			var user = await _usersRepository.GetByIdAsync(userId) ?? throw new UserNotFoundException();
			_usersRepository.Delete(user);
			await _usersRepository.SaveChangesAsync();
		}

		public async Task<IEnumerable<UserResponseDto>> GetFilteredAsync(UserFilterDto filter)
		{
			var query = _usersRepository.GetAllQueryable();

			if (!string.IsNullOrEmpty(filter.UserName))
			{
				query = query.Where(u => u.UserName.Contains(filter.UserName));
			}

			if (!string.IsNullOrEmpty(filter.Role))
			{
				query = query.Where(u => u.Role == filter.Role);
			}

			if (!string.IsNullOrEmpty(filter.Email))
			{
				query = query.Where(u => u.Email.Contains(filter.Email));
			}

			if(!string.IsNullOrEmpty(filter.SortBy))
			{
				bool descending = string.Equals(filter.SortOrder, "desc", StringComparison.OrdinalIgnoreCase);

				query = filter.SortBy.ToLower() switch
				{
					"UserName" => descending ? query.OrderByDescending(u => u.UserName) : query.OrderBy(u => u.UserName),
					"Email" => descending ? query.OrderByDescending(u => u.Email) : query.OrderBy(u => u.Email),
					"Role" => descending ? query.OrderByDescending(u => u.Role) : query.OrderBy(u => u.Role),
					_ => query
				};
			}

			var users = await query.ToListAsync();

			return _mapper.Map<IEnumerable<UserResponseDto>>(users);
		}
	}
}
