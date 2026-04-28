using Sem2FirstProject.DTOs.Request;

namespace Sem2FirstProject.Services.Interfaces
{
    public interface IModuleService
    {
        public Task<string> AddModuleAsync(ModuleCreateDto moduleDto);
    }
}
