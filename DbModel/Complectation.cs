namespace CarShowRoom.DbModel;

public class Complectation
{
    public  int Id { get; set; }
    public string Name { get; set; } = null!;
    public string EngineName { get; set; } = null!;
    public float EngineForce { get; set; }
    public DriveType DriveType { get;set; }
    public FuelType FuelType { get; set; } = null!;
    public int FuelTypeId { get; set; }
    public Car Car { get; set; } = null!;
    public int CarId { get; set; }
    
    public int DeliveryTime { get; set; }
    public List<Contract> Contracts { get; set; }
    
}

public enum DriveType
{
    FrontWheel,
    BackWheel,
    FullWheel
}