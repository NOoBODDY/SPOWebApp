using System.ComponentModel.DataAnnotations;
using CarShowRoom.DbModel;

namespace CarShowRoom.Models;

public class ColorModel
{
    
    [Required(ErrorMessage = "Имя не введено")]
    public string Name { get; set; } = null!;
    [Required(ErrorMessage = "HEX значение не введено")]
    [RegularExpression( "^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$", ErrorMessage = "Это не HEX")]
    public string HexString { get; set; } = null!;

    public Color ToDbModel()
    {
        return new Color() { Name = Name, HexString = HexString };
    }
}