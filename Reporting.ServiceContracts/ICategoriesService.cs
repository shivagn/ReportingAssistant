using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reporting.DomainModels;

namespace Reporting.ServiceContracts
{
    public interface ICategoriesService
    {
        List<Category> GetAllCategories();
        List<Category> SerachCategories(string categoryName);
        Category GetCategoy(long id);
        Category GetCategoy(string CategoryName);
        void DeleteCategory(long id);
        void InsertCategory(Category category);
        void UpdateCategory(Category category);
    }
}
