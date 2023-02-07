using BethanysPieShopHRM.Shared;

using System.Threading.Tasks;

namespace BethanysPieShopHRM.UI.Interfaces
{
    public interface IExpenseApprovalService
    {
        Task<ExpenseStatus> GetExpenseStatusAsync(Expense expense);
    }
}