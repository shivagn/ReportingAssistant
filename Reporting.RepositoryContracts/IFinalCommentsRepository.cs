using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reporting.DomainModels;

namespace Reporting.RepositoryContracts
{
    public interface IFinalCommentsRepository
    {
        FinalComment Get(long id);
        List<FinalComment> GetAll();
        List<FinalComment> GetAll(string UserID);
        List<FinalComment> GetAll(string userID, string AdminID, DateTime datetime);
        List<FinalComment> GetAll(string userID, DateTime datetime);
        List<FinalComment> GetAll(long projectID);
        long Insert(FinalComment Comment);
        void Update(FinalComment Comment);
        void Remove(long id);
    }
}
