using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reporting.DomainModels;
using Reporting.RepositoryContracts;
using Reporting.DataLayer;

namespace Reporting.RepositoryLayer
{
    public class CategoryRepository : ICategoriesRepository
    {
        ReportingDBContext db;
        public CategoryRepository()
        {
            this.db = new ReportingDBContext();
        }

        public void Delete(long id)
        {
            db.Categories.Remove(Get(id));
            db.SaveChanges();
        }

        public Category Get(long id)
        {
            Category category = db.Categories.FirstOrDefault(temp => temp.CategoryID == id);
            return category;
        }

        public Category Get(string CategoryName)
        {
            Category category = db.Categories.FirstOrDefault(temp=> temp.CategoryName == CategoryName);
            return category;
        }

        public List<Category> GetAll()
        {
            List<Category> categories = db.Categories.ToList();
            return categories;
        }

        public void Insert(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
        }

        public List<Category> Serach(string categoryName)
        {
            List<Category> result = db.Categories.Where(temp => temp.CategoryName.Contains(categoryName)).ToList();
            return result;  
        }

        public void Update(Category category)
        {
            Category toBeEdited = Get(category.CategoryID);
            toBeEdited.CategoryName = category.CategoryName;
            db.SaveChanges();
        }


    }
}
