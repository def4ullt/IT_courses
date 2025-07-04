﻿using BLL.DTO.Auth;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly UserManager<Users> _usersManager;
        private readonly SignInManager<Users> _signInManager;
        private readonly IConfiguration _configuration;

        public AuthService(
            IUsersRepository userRepository,
            UserManager<Users> userManager,
            SignInManager<Users> signInManager,
            IConfiguration configuration)
        {
            _usersRepository = userRepository;
            _usersManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

		public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
		{
			var user = await _usersManager.FindByNameAsync(loginRequestDto.UserName);
			if (user == null)
				throw new UnauthorizedAccessException("Invalid username or password.");

			var passwordValid = await _usersManager.CheckPasswordAsync(user, loginRequestDto.Password);
			if (!passwordValid)
				throw new UnauthorizedAccessException("Invalid username or password.");

			var accessToken = GenerateJwtToken(user);
			var refreshToken = GenerateRefreshToken();

			return new LoginResponseDto
			{
				UserId = user.Id,
				UserName = user.UserName,
				Email = user.Email,
				Role = user.Role,
				AccessToken = accessToken,
				RefreshToken = refreshToken
			};
		}

		public async Task<RefreshTokenResponseDto> RefreshTokenAsync(string refreshToken)
        {

            var dummyUser = new Users
            {
                Id = "1",
                UserName = "testuser",
                Role = "User"
            };

            var newAccessToken = GenerateJwtToken(dummyUser);
            var newRefreshToken = GenerateRefreshToken();

            return new RefreshTokenResponseDto
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken
            };
        }

        public async Task<bool> RegisterAsync(string username, string email, string password)
        {
            var existingUser = await _usersRepository.GetByUsernameAsync(username);
            if (existingUser != null)
                return false;

            var user = new Users
            {
                UserName = username,
                Email = email,
                Role = "User"
            };

            var result = await _usersManager.CreateAsync(user, password);
            return result.Succeeded;
        }

        public async Task<bool> ConfirmEmailAsync(string userId, string token)
        {
            var user = await _usersRepository.GetByIdAsync(int.Parse(userId));
            if (user == null)
                return false;

            var result = await _usersManager.ConfirmEmailAsync(user, token);
            return result.Succeeded;
        }

        public async Task<bool> ForgotPasswordAsync(string email)
        {
            var user = await _usersManager.FindByEmailAsync(email);
            if (user == null)
                return false;

            var token = await _usersManager.GeneratePasswordResetTokenAsync(user);

            return true;
        }

        public async Task<bool> ResetPasswordAsync(string email, string token, string newPassword)
        {
            var user = await _usersManager.FindByEmailAsync(email);
            if (user == null)
                return false;

            var result = await _usersManager.ResetPasswordAsync(user, token, newPassword);
            return result.Succeeded;
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

		private string GenerateJwtToken(Users user)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(_configuration["JwtConfig:Key"]);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Issuer = _configuration["JwtConfig:Issuer"],  
				Audience = _configuration["JwtConfig:Audience"],
                Subject = new ClaimsIdentity(new[]
				{
			new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
			new Claim(ClaimTypes.Name, user.UserName),
			new Claim(ClaimTypes.Role, user.Role)
		}),
				Expires = DateTime.UtcNow.AddMinutes(int.Parse(_configuration["JwtConfig:TokenValidityMins"])),
				SigningCredentials = new SigningCredentials(
					new SymmetricSecurityKey(key),
					SecurityAlgorithms.HmacSha256Signature)
			};

			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}

		private string GenerateRefreshToken()
        {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
        }
    }
}
