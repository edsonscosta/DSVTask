using AutoMapper;
using DSVSwapi.Repository;
using DSVSwapi.Repository.Domain.DTOs;
using DSVSwapi.Repository.Model;

namespace DSVSwapi.Service;

public class PlanetService: IPlanetService
{
    private readonly IRepository<PlanetDTO> _planetRepository; 
    public PlanetService(IRepository<PlanetDTO> planetRepository )
    {
        _planetRepository = planetRepository; 
    }
    
    public async Task<IEnumerable<PlanetDTO>> GetAll()
    {
        return  await _planetRepository.GetAll();
    }

    public async Task<PlanetDTO?> GetById(int id)
    {
        return await _planetRepository.GetById(id);
    }

    public async Task Add(PlanetDTO planet)
    {
        await _planetRepository.Save(planet);
    }

    public async Task Update(PlanetDTO planet)
    {
        await _planetRepository.Update(planet);
    }

    public async Task Delete(int id)
    { 
        await _planetRepository.Delete(id);
    }
}