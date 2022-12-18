namespace CarShowRoom.DbModel;

public class FuelType
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public List<Complectation> Complectations { get; set; } = null!;
}