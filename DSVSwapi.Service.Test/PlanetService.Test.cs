using DSVSwapi.Repository;
using DSVSwapi.Repository.Model;

using AutoFixture;
using AutoFixture.AutoMoq;
using DSVSwapi.Repository.Domain.DTOs;
using Moq; 

namespace DSVSwapi.Service.Test;

public class PlanetServiceTests
{ 
    private readonly IFixture _fixture;
    private readonly Mock<IRepository<PlanetDTO>> _mockPlanetRepository;
    private readonly PlanetService _planetService;

    public PlanetServiceTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
            .ForEach(b => _fixture.Behaviors.Remove(b));
        _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        _mockPlanetRepository = _fixture.Freeze<Mock<IRepository<PlanetDTO>>>();
        _planetService = new PlanetService(_mockPlanetRepository.Object);
    }

    [Fact]
    public async Task GetAll_ShouldReturnAllPlanets()
    { 
        var planets = _fixture.CreateMany<PlanetDTO>(3).ToList();
        _mockPlanetRepository.Setup(repo => repo.GetAll()).ReturnsAsync(planets);
 
        var result = await _planetService.GetAll();
 
        Assert.Equal(planets.Count, result.Count());
        Assert.Equal(planets, result);
        _mockPlanetRepository.Verify(repo => repo.GetAll(), Times.Once);
    }

    [Fact]
    public async Task GetById_ShouldReturnCorrectPlanet_WhenPlanetExists()
    {
        var planet = _fixture.Create<PlanetDTO>();
        _mockPlanetRepository.Setup(repo => repo.GetById(planet.Id)).ReturnsAsync(planet);
        
        var result = await _planetService.GetById(planet.Id);
        
        Assert.NotNull(result);
        Assert.Equal(planet, result);
        _mockPlanetRepository.Verify(repo => repo.GetById(planet.Id), Times.Once);
    }

    [Fact]
    public async Task GetById_ShouldReturnNull_WhenPlanetDoesNotExist()
    {
        int planetId = _fixture.Create<int>();
        _mockPlanetRepository.Setup(repo => repo.GetById(planetId)).ReturnsAsync((PlanetDTO?)null);
        
        var result = await _planetService.GetById(planetId);
        
        Assert.Null(result);
        _mockPlanetRepository.Verify(repo => repo.GetById(planetId), Times.Once);
    }

    [Fact]
    public async Task Add_ShouldCallSaveMethodOnce()
    {
        var planet = _fixture.Create<PlanetDTO>();
        
        await _planetService.Add(planet);
        
        _mockPlanetRepository.Verify(repo => repo.Save(planet), Times.Once);
    }

    [Fact]
    public async Task Update_ShouldCallUpdateMethodOnce()
    {
        var planet = _fixture.Create<PlanetDTO>();
        
        await _planetService.Update(planet);
        
        _mockPlanetRepository.Verify(repo => repo.Update(planet), Times.Once);
    }

    [Fact]
    public async Task Delete_ShouldCallDeleteMethodOnce()
    {
        int planetId = _fixture.Create<int>();
        
        await _planetService.Delete(planetId);
        
        _mockPlanetRepository.Verify(repo => repo.Delete(planetId), Times.Once);
    }
}