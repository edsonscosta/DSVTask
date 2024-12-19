using DSVSwapi.Repository;
using DSVSwapi.Repository.Model;
 
using AutoFixture;
using AutoFixture.AutoMoq;
using DSVSwapi.Repository.Domain.DTOs;
using Moq; 

namespace DSVSwapi.Service.Test;

public class ResidentServiceTests
{ 
    private readonly IFixture _fixture;
    private readonly Mock<IRepository<ResidentDTO>> _mockResidentRepository;
    private readonly ResidentService _residentService;

    public ResidentServiceTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
            .ForEach(b => _fixture.Behaviors.Remove(b));
        _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        _mockResidentRepository = _fixture.Freeze<Mock<IRepository<ResidentDTO>>>();
        _residentService = new ResidentService(_mockResidentRepository.Object);
    }

    [Fact]
    public async Task GetAll_ShouldReturnAllResidents()
    { 
        var residents = _fixture.CreateMany<ResidentDTO>(3).ToList();
        _mockResidentRepository.Setup(repo => repo.GetAll()).ReturnsAsync(residents);
 
        var result = await _residentService.GetAll();
 
        Assert.Equal(residents.Count, result.Count());
        Assert.Equal(residents, result);
        _mockResidentRepository.Verify(repo => repo.GetAll(), Times.Once);
    }

    [Fact]
    public async Task GetById_ShouldReturnCorrectResident_WhenResidentExists()
    {
        var resident = _fixture.Create<ResidentDTO>();
        _mockResidentRepository.Setup(repo => repo.GetById(resident.Id)).ReturnsAsync(resident);

        var result = await _residentService.GetById(resident.Id);
        
        Assert.NotNull(result);
        Assert.Equal(resident, result);
        _mockResidentRepository.Verify(repo => repo.GetById(resident.Id), Times.Once);
    }

    [Fact]
    public async Task GetById_ShouldReturnNull_WhenResidentDoesNotExist()
    {
        int residentId = _fixture.Create<int>();
        _mockResidentRepository.Setup(repo => repo.GetById(residentId)).ReturnsAsync((ResidentDTO?)null);
        
        var result = await _residentService.GetById(residentId);
        
        Assert.Null(result);
        _mockResidentRepository.Verify(repo => repo.GetById(residentId), Times.Once);
    }

    [Fact]
    public async Task Add_ShouldCallSaveMethodOnce()
    {
        var resident = _fixture.Create<ResidentDTO>();
        
        await _residentService.Add(resident);
        
        _mockResidentRepository.Verify(repo => repo.Save(resident), Times.Once);
    }

    [Fact]
    public async Task Update_ShouldCallUpdateMethodOnce()
    {
        var resident = _fixture.Create<ResidentDTO>();
        
        await _residentService.Update(resident);
        
        _mockResidentRepository.Verify(repo => repo.Update(resident), Times.Once);
    }

    [Fact]
    public async Task Delete_ShouldCallDeleteMethodOnce()
    {
        int residentId = _fixture.Create<int>();
        
        await _residentService.Delete(residentId);
        
        _mockResidentRepository.Verify(repo => repo.Delete(residentId), Times.Once);
    }
}