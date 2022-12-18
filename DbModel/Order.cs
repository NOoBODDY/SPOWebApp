namespace CarShowRoom.DbModel;

public class Order
{
    public int Id { get; set; }
    public DateTime DeliveryDate { get; set; }
    public Contract Contract { get; set; }
    public int ContractId { get; set; }
}