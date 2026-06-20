using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myCityLogin.HospitalService.API.Models;
using myCityLogin.HospitalService.API.Services;
using System.Text.Json;

namespace myCityLogin.HospitalService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProviderController : ControllerBase
    {
        private readonly IProviderService _providerService;

        public ProviderController(IProviderService providerService)
        {
            _providerService = providerService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] ProviderRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var provider = await _providerService.CreateAsync(request);

            return Ok(new
            {
                Success = true,
                Message = "Provider created successfully.",
                Data = provider
            });
        }
    }
}
