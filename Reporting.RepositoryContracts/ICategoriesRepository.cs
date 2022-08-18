using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reporting.DomainModels;

namespace Reporting.RepositoryContracts
{
    public interface ICategoriesRepository
    {
        List<Category> GetAll();
        List<Category> Serach(string categoryName);
        Category Get(long id);
        Category Get(string CategoryName);
        void Delete(long id);
        void Insert(Category category);
        void Update(Category category);

    }
}
