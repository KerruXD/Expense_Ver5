using ASI.Basecode.Data.Models;
using System.Collections.Generic;

namespace ASI.Basecode.Data.Interfaces
{
    public interface IExpenseRepository
    {
        IEnumerable<Expense> ViewExpenses();
        void AddExpense(Expense expense);
        void UpdateExpense(Expense expense);
        void DeleteExpense(Expense expense);
        IEnumerable<Category> GetCategories();
        void SoftDeleteExpense(Expense expense); // Ensure this method is added
    }
}
