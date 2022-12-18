using System.ComponentModel.DataAnnotations;

namespace CarShowRoom.DbModel;

public class Manufacture
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Не введено имя производителя")]
    public string Name { get; set; } = null!;
    [Required(ErrorMessage = "Не введена страна производителя")]
    public string Country { get; set; } = null!;

    public List<Car> Cars { get; set; } = null!;
}