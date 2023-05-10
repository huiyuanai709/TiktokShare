namespace Identity.Domain.ExpenseAggregate;

public class Expense
{
    public int Id { get; set; }
    public int Type { get; set; }
    public DateTime ExpenseTime { get; set; }
}