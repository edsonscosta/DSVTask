namespace DSVSwapi.Repository.Model;
public class Resident
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Gender { get; set; }
    public int PlanetId { get; set; }
    public Planet? Planet { get; set; }
}