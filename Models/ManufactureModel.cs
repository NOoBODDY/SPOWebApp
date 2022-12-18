using System.ComponentModel.DataAnnotations;
using CarShowRoom.DbModel;

namespace CarShowRoom.Models;

public class ManufactureModel
{
    [Required(ErrorMessage = "Не введено имя производителя")]
    public string Name { get; set; } = null!;
    [Required(ErrorMessage = "Не введена страна производителя")]
    [RegularExpression("\\w+", ErrorMessage = "Только буквы")]
    public string Country { get; set; } = null!;

    public Manufacture ToDbModel()
    {
        return new Manufacture()
        {
            Name = Name,
            Country = Country
        };
    }
}