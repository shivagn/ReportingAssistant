using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reporting.DomainModels;
using Reporting.ServiceContracts;
using Reporting.RepositoryContracts;

namespace Reporting.ServiceLayer
{
    
    public class CategoryService : ICategoriesService
    {
        ICategoriesRepository repCat;
        public CategoryService(ICategoriesRepository repCat)
        {
            this.repCat = repCat;
        }

        public void DeleteCategory(long id)
        {
            repCat.Delete(id);
        }

        public List<Category> GetAllCategories()
        {
            List<Category> all = repCat.GetAll();
            return all;
        }

        public Category GetCategoy(long id)
        {
            Category category = repCat.Get(id);
            return category;
        }

        public Category GetCategoy(string CategoryName)
        {
            Category category = repCat.Get(CategoryName);
            return category;
        }

        public void InsertCategory(Category category)
        {
            repCat.Insert(category);
        }

        public List<Category> SerachCategories(string categoryName)
        {
            List<Category> result = repCat.Serach(categoryName);
            return result;
        }

        public void UpdateCategory(Category category)
        {
            repCat.Update(category);
        }
    }
}
