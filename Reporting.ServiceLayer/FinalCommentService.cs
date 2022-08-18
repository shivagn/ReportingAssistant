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
    public class FinalCommentService : IFinalCommentsService
    {
        IFinalCommentsRepository repFinalCm;
        public FinalCommentService(IFinalCommentsRepository repFinalCm)
        {
            this.repFinalCm = repFinalCm;
        }
        public List<FinalComment> GetAllComments()
        {
            return repFinalCm.GetAll();
        }

        public List<FinalComment> GetAllComments(string UserID)
        {
            return repFinalCm.GetAll(UserID);
        }

        public List<FinalComment> GetAllComments(string userID, string AdminID, DateTime datetime)
        {
            return repFinalCm.GetAll(userID, AdminID, datetime);
        }


        public List<FinalComment> GetAllCommentsByProject(long ProjectID)
        {
            List<FinalComment> comments = repFinalCm.GetAll(ProjectID);
            return comments;
        }

        public FinalComment GetFinal(long commentId)
        {
            return repFinalCm.Get(commentId);
        }

        public long InsertComment(FinalComment Comment)
        {
            return repFinalCm.Insert(Comment);
        }

        public void RemoveComment(long finalCommentId)
        {
            repFinalCm.Remove(finalCommentId);
        }

        public void UpdateComment(FinalComment Comment)
        {
            repFinalCm.Update(Comment);
        }

        List<FinalComment> IFinalCommentsService.GetAllComments(string userID, DateTime datetime)
        {
            List<FinalComment> Comments = repFinalCm.GetAll(userID, datetime);
            return Comments;
        }
    }
}
