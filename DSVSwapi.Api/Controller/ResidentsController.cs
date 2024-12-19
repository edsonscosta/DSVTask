using DSVSwapi.Repository.Domain.DTOs;
using DSVSwapi.Repository.Model;
using DSVSwapi.Service; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("v1/[controller]")]
public class ResidentsController : ControllerBase
{
    private readonly IResidentService _residentService;

    public ResidentsController(IResidentService residentService)
    {
        _residentService = residentService;
    }

    [HttpGet]
    public async Task<IActionResult> GetResidents()
    {
        var residents = await _residentService.GetAll();
        return Ok(residents);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetResident(int id)
    {
        var resident = await _residentService.GetById(id);
        if (resident == null) return NotFound();
        return Ok(resident);
    }

    [HttpPost]
    public async Task<IActionResult> CreateResident([FromBody] ResidentDTO resident)
    {
        await _residentService.Add(resident);
        return CreatedAtAction(nameof(GetResident), new { id = resident.Id }, resident);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateResident(int id, [FromBody] ResidentDTO resident)
    {
        if (id != resident.Id) return BadRequest();

        await _residentService.Update(resident);
         return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteResident(int id)
    {
        var resident = await _residentService.GetById(id);
        if (resident == null) return NotFound();

        await _residentService.Delete(id); 
        return NoContent();
    }
}