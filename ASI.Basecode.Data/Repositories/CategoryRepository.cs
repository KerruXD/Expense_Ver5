using ASI.Basecode.Data.Interfaces;
using ASI.Basecode.Data.Models;
using Basecode.Data.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace ASI.Basecode.Data.Repositories
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        private readonly AsiBasecodeDBContext _dbContext;

        public CategoryRepository(AsiBasecodeDBContext dbContext, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _dbContext = dbContext;
        }

        public List<Category> ViewCategories()
        {
            return this.GetDbSet<Category>().Where(c => !c.IsDeleted).ToList();
        }

        public void AddCategory(Category category)
        {
            this.GetDbSet<Category>().Add(category);
            UnitOfWork.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            this.GetDbSet<Category>().Update(category);
            UnitOfWork.SaveChanges();
        }

        public void DeleteCategory(Category category)
        {
            SoftDeleteCategory(category); // Use soft delete
        }

        public void SoftDeleteCategory(Category category)
        {
            category.IsDeleted = true;
            UnitOfWork.SaveChanges();
        }
    }
}
