using DSVSwapi.Repository.Domain.DTOs;

namespace DSVSwapi.Service;

using DSVSwapi.Repository.Model;

public interface IPlanetService
{
    Task<IEnumerable<PlanetDTO>> GetAll();
    Task<PlanetDTO?> GetById(int id);
    Task Add(PlanetDTO resident);
    Task Update(PlanetDTO resident);
    Task Delete(int id); 
}