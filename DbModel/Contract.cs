namespace CarShowRoom.DbModel;

public class Contract
{
    public int Id { get; set; }
    public Complectation Complectation { get;set; }
    public int ComplectationId { get; set; }
    public DateTime Date { get; set; }
    public User Seller { get; set; }
    public int SellerId { get; set; }
    public string Buyer { get; set; }
    
    public Order Order { get; set; }
    public int OrderId { get; set; }
}