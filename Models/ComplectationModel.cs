using System.ComponentModel.DataAnnotations;
using CarShowRoom.DbModel;
using DriveType = CarShowRoom.DbModel.DriveType;

namespace CarShowRoom.Models;

public class ComplectationModel
{
    [Required(ErrorMessage = "Не введено название комплектации")]
    public string Name { get; set; } = null!;
    [Required(ErrorMessage = "Не введено название двигателя")]
    public string EngineName { get; set; } = null!;
    [Required(ErrorMessage = "Не введена мощность двигателя")]
    public float EngineForce { get; set; }
    [Required(ErrorMessage = "Не введен тип привода")]
    public DriveType DriveType { get;set; }
    [Required(ErrorMessage = "Не введен тип топлива")]
    public int FuelTypeId { get; set; }
    [Required(ErrorMessage = "Не выбрана модель")]    
    public int CarId { get; set; }
    [Required(ErrorMessage = "Не выбрана длительноть поставки")] 
    public int DeliveryDate { get; set; }

    public Complectation ToDbModel()
    {
        DateTime date = default;
        
        return new Complectation()
        {
            Name = Name,
            EngineName = EngineName,
            EngineForce = EngineForce,
            DriveType = DriveType,
            FuelTypeId = FuelTypeId,
            CarId = CarId,
            DeliveryTime = DeliveryDate
        };
    }
}