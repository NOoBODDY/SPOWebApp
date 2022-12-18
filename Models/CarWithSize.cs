using System.ComponentModel.DataAnnotations;
using CarShowRoom.DbModel;

namespace CarShowRoom.Models;

public class CarWithSize
{
    [Required (ErrorMessage = "Не указано имя модели")]
    public string ModelName { get; set; } = string.Empty;
    [Required (ErrorMessage = "Не выбран производитель")]
    public int ManufactureId { get; set; }
    [Required (ErrorMessage = "Не указано высота")]
    public int Height { get; set; }
    [Required (ErrorMessage = "Не указано количество колес")]
    public int WheelBase { get; set; }
    [Required (ErrorMessage = "Не указано количество дверей")]
    public int Doors { get; set; }
    [Required (ErrorMessage = "Не указано количество пассажиров")]
    public int Passengers { get; set; }
    [Required (ErrorMessage = "Не указан объем багажника")]
    public int TrunkVolume { get; set; }
    [Required (ErrorMessage = "Не указана масса модели")]
    public int Weight { get; set; }
    [Required (ErrorMessage = "Не указана ширина")]
    public int Width { get; set; }
    public List<int> ColorsId { get; set; }

    public Car ToDbModel(CarDbContext context)
    {
        var size = new CarSize()
        {
            Height = Height,
            WheelBase = WheelBase,
            Doors = Doors,
            Passengers = Passengers,
            TrunkVolume = TrunkVolume,
            Weight = Weight,
            Width = Width
        };
        var colors = context.Colors.Where(c => ColorsId.Contains(c.Id)).ToList();
        
        return new Car() { ModelName = ModelName, ManufactureId = ManufactureId, Size = size, Colors = colors};
    }
}

public class ColorTip
{
    public Color Color { get; set; }
    public bool IsChecked { get; set; }
}