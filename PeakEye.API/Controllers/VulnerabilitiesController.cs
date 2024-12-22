using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeakEye.Service.Vulnerabilities;
using PeakEye.Service.Vulnerabilities.Dtos;

namespace PeakEye.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class VulnerabilitiesController(IVulnerabilityService vulnerabilityService) : CustomBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetVulnerability() => CreateActionResult(await vulnerabilityService.GetAllAsync());

        [HttpPost]
        public async Task<IActionResult> SaveVulnerability(CreateVulnerabilityDto request) => CreateActionResult(await vulnerabilityService.CreateAsync(request));

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetVulnerabilityById(int id) => CreateActionResult(await vulnerabilityService.GetByIdAsync(id));

        [HttpPut]
        public async Task<IActionResult> UpdateVulnerability(UpdateVulnerabilityDto request) => CreateActionResult(await vulnerabilityService.UpdateAsync(request));

        [HttpDelete]
        public async Task<IActionResult> DeleteVulnerability(int id) => CreateActionResult(await vulnerabilityService.DeleteAsync(id));

        [HttpGet]
        [Route("GetVulnerabilitiesByStatus")]
        public async Task<IActionResult> GetVulnerabilitiesByStatus(bool status) => CreateActionResult(await vulnerabilityService.GetVulnerabilitiesByStatusAsync(status));

        [HttpGet]
        [Route("GetVulnerabilitiesByName")]
        public async Task<IActionResult> GetVulnerabilitiesByName(string name) => CreateActionResult(await vulnerabilityService.GetVulnerabilitiesByNameAsync(name));

        [HttpGet]
        [Route("GetVulnerabilitiesBySeverity")]
        public async Task<IActionResult> GetVulnerabilitiesBySeverityAsync(int severity) => CreateActionResult(await vulnerabilityService.GetVulnerabilitiesBySeverityAsync(severity));
    }
}
