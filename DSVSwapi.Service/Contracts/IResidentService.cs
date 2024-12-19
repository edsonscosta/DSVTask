using DSVSwapi.Repository.Domain.DTOs;

namespace DSVSwapi.Service;

using DSVSwapi.Repository.Model;

public interface IResidentService
{
    Task<IEnumerable<ResidentDTO>> GetAll();
    Task<ResidentDTO?> GetById(int id);
    Task Add(ResidentDTO resident);
    Task Update(ResidentDTO resident);
    Task Delete(int id); 
}