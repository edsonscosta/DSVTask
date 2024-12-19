using System.Reflection.Metadata;
using DSVSwapi.Repository;
using DSVSwapi.Repository.Domain.DTOs;
using DSVSwapi.Repository.Model;

namespace DSVSwapi.Service;

public class ResidentService: IResidentService
{
    private readonly IRepository<ResidentDTO> _residentRepository;

    public ResidentService(IRepository<ResidentDTO> residentRepository)
    {
        _residentRepository = residentRepository;
    }

    public async Task<IEnumerable<ResidentDTO>> GetAll()
    {
        return await _residentRepository.GetAll();
    }

    public async Task<ResidentDTO?> GetById(int id)
    {
        return await _residentRepository.GetById(id);
    }

    public async Task Add(ResidentDTO resident)
    {
        await _residentRepository.Save(resident);
    }

    public async Task Update(ResidentDTO resident)
    {
        await _residentRepository.Update(resident);
    }

    public async Task Delete(int id)
    {
        await _residentRepository.Delete(id);
    }
}