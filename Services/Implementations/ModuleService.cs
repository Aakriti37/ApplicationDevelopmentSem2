using Microsoft.AspNetCore.Http.HttpResults;
using Sem2FirstProject.Data;
using Sem2FirstProject.Data.Entities;
using Sem2FirstProject.DTOs.Request;
using Sem2FirstProject.Services.Interfaces;

namespace Sem2FirstProject.Services.Implementations
{
    public class ModuleService(AppDbContext dbContext) : IModuleService
    {
        public async Task<string> AddModuleAsync(ModuleCreateDto moduleDto)
        {
            Module module = new Module
            {
                Title = moduleDto.Title,
                Credits = moduleDto.Credits,
                CourseId = moduleDto.CourseId
            };

            dbContext.Modules.Add(module);
            await dbContext.SaveChangesAsync();

            return "Module added successfully.";
        }
    }
}
