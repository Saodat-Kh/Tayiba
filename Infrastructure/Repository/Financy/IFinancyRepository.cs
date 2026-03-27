namespace Infrastructure.Repository.Financy;

public interface IFinancyRepository
{
    Task<decimal> GetIncome();
    Task<decimal> GetExpense();
}