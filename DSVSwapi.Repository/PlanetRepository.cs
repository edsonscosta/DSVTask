using System.Linq.Expressions;
using DSVSwapi.Repository.Domain.DTOs;
using DSVSwapi.Repository.Model;
using Microsoft.EntityFrameworkCore;

namespace DSVSwapi.Repository;

public class PlanetRepository : IRepository<PlanetDTO>
{
    private readonly DSVSwapiDBContext _context;

    public PlanetRepository(DSVSwapiDBContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<PlanetDTO>> GetAll()
    {
        return await _context.Planets.Select(
            planet => new PlanetDTO
            {
                Id = planet.Id,
                Name = planet.Name,
                Terrain = planet.Terrain,
                Climate = planet.Climate
            }) .ToListAsync();
    }
 
    public async Task<PlanetDTO?> GetById(int id)
    {
        return await _context.Planets.Select(
            planet => new PlanetDTO
            {
                Id = planet.Id,
                Name = planet.Name,
                Terrain = planet.Terrain,
                Climate = planet.Climate
            }).FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task Save(PlanetDTO entity)
    {
        var planet = new Planet
        {
            Name = entity.Name,
            Terrain = entity.Terrain,
            Climate = entity.Climate
        };
        await _context.Planets.AddAsync(planet);  
        await _context.SaveChangesAsync();

        entity.Id = planet.Id;
    }

    public async Task Update(PlanetDTO entity)
    {
        _context.Planets.Update(new Planet
        {
            Name = entity.Name,
            Terrain = entity.Terrain,
            Climate = entity.Climate
        });
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var entity = await _context.Planets.FindAsync(id);
        if (entity != null)
        {
            _context.Planets.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}