namespace Identity.Domain.RechargeAggregate;

public class Recharge
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public int RechargerId { get; set; }
    public DateTime RechargeTime { get; set; }
}