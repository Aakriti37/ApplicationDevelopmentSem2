using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Sem2FirstProject.Data;
using Sem2FirstProject.Data.Entities;
using Sem2FirstProject.DTOs.Request;
using Sem2FirstProject.DTOs.Response;
using Sem2FirstProject.Services.Interfaces;
using System.Threading.Tasks;

namespace Sem2FirstProject.Services.Implementations
{
    public class AuthService(UserManager<User> userManager, AppDbContext dbContext, SignInManager<User> signInManager) : IAuthService
    {
        public async Task<RegistrationResponse> RegisterUserAsync(RegisterUserDto registerUserDto)
        {
            var transaction = await dbContext.Database.BeginTransactionAsync();

            try
            {
                User user = new User
                {
                    FirstName = registerUserDto.FirstName,
                    LastName = registerUserDto.LastName,
                    Email = registerUserDto.Email,
                    Age = registerUserDto.Age,
                    PhoneNumber = registerUserDto.Phone
                };

                var registerResult = await userManager.CreateAsync(user, registerUserDto.Password);

                if (!registerResult.Succeeded)
                {
                    return new RegistrationResponse
                    {
                        Success = false,
                        Message = registerResult.ToString()
                    };
                }

                var roleResult = await userManager.AddToRoleAsync(user, "Student");

                if (!roleResult.Succeeded)
                {
                    await transaction.RollbackAsync();
                    return new RegistrationResponse
                    {
                        Success = false,
                        Message = roleResult.ToString()
                    };
                }



                await transaction.CommitAsync();
                return new RegistrationResponse
                {
                    Success = true,
                    Message = "Registration Success"
                };

            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
            
 
        }


        public async Task<LoginResponse> Login(LoginDto loginDto)
        {
            User? user = await userManager.FindByEmailAsync(loginDto.Email);

            if(user is null)
            {
                return new LoginResponse
                {
                    Success = false,
                    Message =  "User not found"
                };
            }

            var signInResult = await signInManager.CheckPasswordSignInAsync(user, loginDto.Password, lockoutOnFailure: true);

            if (!signInResult.Succeeded)
            {
                return new LoginResponse
                {
                    Success = false,
                    Message = "Password didn't match"
                };
            }

        }




    }
}
