using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reporting.DomainModels;


namespace Reporting.ServiceContracts
{
    public interface IFinalCommentsService
    {
        FinalComment GetFinal(long commentId);
        List<FinalComment> GetAllComments();
        List<FinalComment> GetAllComments(string UserID);
        List<FinalComment> GetAllComments(string userID, string AdminID, DateTime datetime);
        List<FinalComment> GetAllComments(string userID, DateTime datetime);
        List<FinalComment> GetAllCommentsByProject(long ProjectID);
        long InsertComment(FinalComment Comment);
        void UpdateComment(FinalComment Comment);
        void RemoveComment(long finalCommentId);
    }
}
