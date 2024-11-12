using ASI.Basecode.Data.Models;
using System.Collections.Generic;

namespace ASI.Basecode.Data.Interfaces
{
    public interface ICategoryRepository
    {
        List<Category> ViewCategories();
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);
        void SoftDeleteCategory(Category category); // Add this method
    }
}
