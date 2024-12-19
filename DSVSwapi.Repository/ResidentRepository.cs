using System.Linq.Expressions;
using DSVSwapi.Repository.Domain.DTOs;
using DSVSwapi.Repository.Model;
using Microsoft.EntityFrameworkCore;

namespace DSVSwapi.Repository;

public class ResidentRepository : IRepository<ResidentDTO>
{
    private readonly DSVSwapiDBContext _context;

    public ResidentRepository(DSVSwapiDBContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<ResidentDTO>> GetAll()
    {
        return await _context.Residents.Select(r => new ResidentDTO
        {
            Id = r.Id,
            Name = r.Name,
            Gender = r.Gender,
            PlanetId = r.PlanetId,
            Planet = new PlanetDTO
            {
                Id = r.Planet.Id,
                Name = r.Planet.Name,
                Terrain = r.Planet.Terrain,
                Climate = r.Planet.Climate
            }
        }).ToListAsync();
    }
 

    public async Task<ResidentDTO?> GetById(int id)
    {
        return await _context.Residents.Select(r => new ResidentDTO
        {
            Id = r.Id,
            Name = r.Name,
            Gender = r.Gender,
            PlanetId = r.PlanetId,
            Planet = new PlanetDTO
            {
                Id = r.Planet.Id,
                Name = r.Planet.Name,
                Terrain = r.Planet.Terrain,
                Climate = r.Planet.Climate
            }
        }).FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task Save(ResidentDTO entity)
    {
        var resident = new Resident
        {
            Name = entity.Name,
            Gender = entity.Gender,
            PlanetId = entity.PlanetId
        };
        await _context.Residents.AddAsync(resident);
        await _context.SaveChangesAsync();
        entity.Id = resident.Id;
    }

    public async Task Update(ResidentDTO entity)
    {
        _context.Residents.Update(new Resident
        {
            Name = entity.Name,
            Gender = entity.Gender,
            PlanetId = entity.PlanetId
        });
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var entity = await _context.Residents.FindAsync(id);
        if (entity != null)
        {
            _context.Residents.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}