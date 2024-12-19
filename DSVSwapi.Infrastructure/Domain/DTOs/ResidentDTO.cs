namespace DSVSwapi.Repository.Domain.DTOs;
public class ResidentDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Gender { get; set; }
    public int PlanetId { get; set; }
    public PlanetDTO? Planet { get; set; }
}