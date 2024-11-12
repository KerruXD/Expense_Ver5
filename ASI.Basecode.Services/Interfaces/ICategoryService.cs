using ASI.Basecode.Data.Models;
using System.Collections.Generic;

namespace ASI.Basecode.Services.Interfaces
{
    public interface ICategoryService
    {
        List<Category> GetCategories();
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);
        void SoftDeleteCategory(Category category);
    }
}
