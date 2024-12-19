using DSVSwapi.Repository.Domain.DTOs;
using DSVSwapi.Repository.Model;
using DSVSwapi.Service; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("v1/[controller]")]
public class PlanetsController : ControllerBase
{
    private readonly IPlanetService _planetService;

    public PlanetsController(IPlanetService planetService)
    {
        _planetService = planetService;
    }

    [HttpGet]
    public async Task<IActionResult> GetPlanets()
    {
        var planets = await _planetService.GetAll();
        return Ok(planets);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPlanet(int id)
    {
        var planet = await _planetService.GetById(id);
        if (planet == null) return NotFound();
        return Ok(planet);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePlanet([FromBody] PlanetDTO planet)
    {
        await _planetService.Add(planet);
        return CreatedAtAction(nameof(GetPlanet), new { id = planet.Id }, planet);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePlanet(int id, [FromBody] PlanetDTO planet)
    {
        if (id != planet.Id) return BadRequest();

        await _planetService.Update(planet);
         return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePlanet(int id)
    {
        var planet = await _planetService.GetById(id);
        if (planet == null) return NotFound();

        await _planetService.Delete(id); 
        return NoContent();
    }
}