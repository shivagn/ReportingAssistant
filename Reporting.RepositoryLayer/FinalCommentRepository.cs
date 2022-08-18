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
    public class FinalCommentRepository : IFinalCommentsRepository
    {
        ReportingDBContext db;
        public FinalCommentRepository()
        {
            db = new ReportingDBContext();
        }
        public FinalComment Get(long id)
        {
            FinalComment cm = db.FinalComments.FirstOrDefault(temp => temp.FinalCommentID == id);
            return cm;
        }

        public List<FinalComment> GetAll()
        {
            List<FinalComment> finalComments = db.FinalComments.ToList();
            return finalComments;
        }

        public List<FinalComment> GetAll(string UserID)
        {
            List<FinalComment> finalComments = db.FinalComments.Where(temp => temp.UserID == UserID).ToList();
            return finalComments;
        }

        public List<FinalComment> GetAll(string userID, string AdminID, DateTime datetime)
        {
            List<FinalComment> finalComments = db.FinalComments.Where(temp => temp.UserID == userID && temp.AdminUserID == AdminID && temp.DateOfFinalComment == datetime).ToList();
            return finalComments;
        }

        public List<FinalComment> GetAll(string userID, DateTime datetime)
        {
            List<FinalComment> finalComments = db.FinalComments.Where(temp => temp.UserID == userID &&  temp.DateOfFinalComment == datetime).ToList();
            return finalComments;
        }

        public List<FinalComment> GetAll(long projectID)
        {
            List<FinalComment> comments = db.FinalComments.Where(temp => temp.ProjectID == projectID).ToList();
            return comments;
        }

        public long Insert(FinalComment Comment)
        {
            FinalComment cm = db.FinalComments.Add(Comment);
            db.SaveChanges();
            return cm.FinalCommentID;
        }

        public void Remove(long id)
        {
            db.FinalComments.Remove(Get(id));
            db.SaveChanges();
        }

        public void Update(FinalComment Comment)
        {
            FinalComment toBeEdited = Get(Comment.FinalCommentID);
            toBeEdited.Attachment = Comment.Attachment;
            toBeEdited.Screen = Comment.Screen;
            toBeEdited.ProjectID = Comment.ProjectID;
            toBeEdited.Description = Comment.Description;
            toBeEdited.AdminUserID = Comment.AdminUserID;
            toBeEdited.DateOfFinalComment = Comment.DateOfFinalComment;
            toBeEdited.UserID = Comment.UserID;
            db.SaveChanges();
        }
    }
}
