using Sem2FirstProject.DTOs.Request;
using Sem2FirstProject.DTOs.Response;

namespace Sem2FirstProject.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<RegistrationResponse> RegisterUserAsync(RegisterUserDto registerUserDto);

        public Task<LoginResponse> Login(LoginDto loginDto);
    }
}
