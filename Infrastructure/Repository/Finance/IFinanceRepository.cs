namespace Infrastructure.Repository.Finance;

public interface IFinanceRepository
{
    Task<decimal> GetIncome();
    Task<decimal> GetExpense();
}