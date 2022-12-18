using System.ComponentModel.DataAnnotations;
using CarShowRoom.DbModel;

namespace CarShowRoom.Models;

public class ContractModel
{
    [Required(ErrorMessage = "Не выбрана комплектация")]
    public int ComplectationId { get; set; }

    [Required(ErrorMessage = "Не заявлен покупатель")]
    public string Buyer { get; set; } = null!;

    public int SellerId { get; set; }
    public int CarId { get; set; }
    public Contract ToDbModel()
    {
        return new Contract()
        {
            ComplectationId = ComplectationId,
            Buyer = Buyer,
            SellerId = SellerId,
            Date = DateTime.Today
        };
    }
}