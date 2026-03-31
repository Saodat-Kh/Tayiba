namespace Domain.Entities;

public class Financy : BaseEntities
{
    public decimal Amount { get; set; }
    public decimal Income  { get; set; }
    public decimal Expenses { get; set; }
    public decimal Profit   { get; set; }
}