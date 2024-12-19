namespace DSVSwapi.Repository.Model;
public class Planet
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Climate { get; set; }
    public string Terrain { get; set; }
    public ICollection<Resident> Residents { get; set; } = new List<Resident>();
}