using ASI.Basecode.Data.Interfaces;
using ASI.Basecode.Data.Models;
using Basecode.Data.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace ASI.Basecode.Data.Repositories
{
    public class ExpenseRepository : BaseRepository, IExpenseRepository
    {
        private readonly AsiBasecodeDBContext _dbContext;

        public ExpenseRepository(AsiBasecodeDBContext dbContext, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Expense> ViewExpenses()
        {
            return this.GetDbSet<Expense>().Where(e => !e.IsDeleted).ToList();
        }

        public void AddExpense(Expense expense)
        {
            this.GetDbSet<Expense>().Add(expense);
            UnitOfWork.SaveChanges();
        }

        public void UpdateExpense(Expense expense)
        {
            this.GetDbSet<Expense>().Update(expense);
            UnitOfWork.SaveChanges();
        }

        public void DeleteExpense(Expense expense)
        {
            SoftDeleteExpense(expense); // Use soft delete for consistency
        }

        public IEnumerable<Category> GetCategories()
        {
            return _dbContext.Set<Category>().Where(c => !c.IsDeleted).ToList();
        }

        // Implementation of SoftDeleteExpense
        public void SoftDeleteExpense(Expense expense)
        {
            expense.IsDeleted = true;
            UnitOfWork.SaveChanges();
        }
    }
}
