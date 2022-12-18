

using System.ComponentModel.DataAnnotations;

namespace CarShowRoom.DbModel;

public class Color
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string HexString { get; set; } = null!;
    
    public List<Car> Cars { get; set; } = null!;
}