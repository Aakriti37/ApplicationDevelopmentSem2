using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sem2FirstProject.Data;
using Sem2FirstProject.Data.Entities;
using Sem2FirstProject.DTOs.Request;
using Sem2FirstProject.Services.Interfaces;

namespace Sem2FirstProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModulesController(IModuleService moduleService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddModuleAsync(ModuleCreateDto moduleDto)
        {
            var response = await moduleService.AddModuleAsync(moduleDto);
            return Ok(response);
           
        }
    }
}
