namespace CarShowRoom.DbModel;

public class Car
{
    public int Id { get; set; }
    public string ModelName { get; set; } = null!;
    
    public CarSize? Size { get; set; }
    public int? SizeId { get; set; }
    public Manufacture Manufacture { get; set; } = null!;
    public int ManufactureId { get; set; }

    public List<Color> Colors { get; set; } = null!;
    public List<Complectation> Complectations { get; set; } = null!;
}

public class CarSize
{
    public int Id { get; set; }
    public int Height { get; set; }
    public int WheelBase { get; set; }
    public int Doors { get; set; }
    public int Passengers { get; set; }
    public int TrunkVolume { get; set; }
    public int Weight { get; set; }
    public int Width { get; set; }

    public Car Car { get; set; } = null!;
    public int CarId { get; set; }
    
    
    
}