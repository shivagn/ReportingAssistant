namespace Reporting.DataLayer.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<Reporting.DataLayer.ReportingDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Reporting.DataLayer.ReportingDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Categories.AddOrUpdate(new DomainModels.Category() { CategoryID = 1, CategoryName = "Learning" }, new DomainModels.Category() {CategoryID = 2, CategoryName = "Practicing" });
            context.Projects.AddOrUpdate(new DomainModels.Project() { ProjectID = 1, ProjectName = "Learn Programming", AvailabilityStatus = "Available", DateOfStart = DateTime.Today, CategoryID = 2 }, new DomainModels.Project() { ProjectID = 2, ProjectName = "Learn English", AvailabilityStatus = "Available", DateOfStart = DateTime.Today , CategoryID = 1 });
            context.Tasks.AddOrUpdate(new DomainModels.Task() { TaskID =1,  Screen = "Project", Description = "Complete 30 minutes project in 2 days", UserID = "7c80072c-4bfc-47be-aac3-475a99ee0d69", AdminUserID = "824e8cf2-01dc-48f1-8d5b-8ef6d9c1f3a1", DateOfTask = DateTime.Today, ProjectID = 1 }, new DomainModels.Task() { TaskID = 2, Screen = "Practice Writing", Description = "Practice writing Everyday for the next 1 month starting from today", UserID = "7c80072c-4bfc-47be-aac3-475a99ee0d69", AdminUserID = "99c80b94-322d-46d6-9518-9224c810891d", DateOfTask = DateTime.Today, ProjectID = 2 }, new DomainModels.Task() { TaskID = 3, Screen = "Speaking", Description = "Practice speaking every other day", UserID = "7c80072c-4bfc-47be-aac3-475a99ee0d69", AdminUserID = "cfbe6bbc-9752-401e-9236-f68d13193658", DateOfTask = DateTime.Today , ProjectID = 2 });
            context.Tasks.AddOrUpdate(new DomainModels.Task() { TaskID = 4, Screen = "Learn C#", Description = "Study C# till you become a junior developer", UserID = "7c80072c-4bfc-47be-aac3-475a99ee0d69", AdminUserID = "824e8cf2-01dc-48f1-8d5b-8ef6d9c1f3a1", DateOfTask = DateTime.Today, ProjectID = 1 }, new DomainModels.Task() { TaskID = 5, Screen = "Practice Listening", Description = "Take a listening test every other day for the next 1 month", UserID = "7c80072c-4bfc-47be-aac3-475a99ee0d69", AdminUserID = "99c80b94-322d-46d6-9518-9224c810891d", DateOfTask = DateTime.Today, ProjectID = 2 });
            context.TasksDone.AddOrUpdate(new DomainModels.TaskDone() { TaskDoneID = 1, Screen = "Watch C# videos", Description = "Watched 20 sessions of Udemy C# Videos", UserID = "7c80072c-4bfc-47be-aac3-475a99ee0d69", DateOfTaskDone = DateTime.Today, ProjectID = 1 }, new DomainModels.TaskDone() { TaskDoneID = 2, Screen = "Watch youtube", Description = "Watched youtube inspirational videos during work", UserID = "7c80072c-4bfc-47be-aac3-475a99ee0d69", DateOfTaskDone = DateTime.Today, ProjectID = 2 });
            context.FinalComments.AddOrUpdate(new DomainModels.FinalComment() { FinalCommentID = 1, Screen = "Login Page", Description = "With invalid Username and password it doesn't show a proper message", UserID = "7c80072c-4bfc-47be-aac3-475a99ee0d69", AdminUserID = "824e8cf2-01dc-48f1-8d5b-8ef6d9c1f3a1", DateOfFinalComment = DateTime.Today, ProjectID = 1 }, new DomainModels.FinalComment() { FinalCommentID = 2, Screen = "Register", Description = "user can still login with the use of wrong Email", UserID = "7c80072c-4bfc-47be-aac3-475a99ee0d69", AdminUserID = "99c80b94-322d-46d6-9518-9224c810891d", DateOfFinalComment = DateTime.Today, ProjectID = 2 }, new DomainModels.FinalComment() { FinalCommentID = 3, Screen = "Save Info", Description = "Save button does not add new information to th database", UserID = "7c80072c-4bfc-47be-aac3-475a99ee0d69", AdminUserID = "cfbe6bbc-9752-401e-9236-f68d13193658", DateOfFinalComment = DateTime.Today, ProjectID = 2 });

            //Yesterday
            context.Tasks.AddOrUpdate(new DomainModels.Task() { TaskID = 6, Screen = "yesterday task1", Description = "Study C# start from yesterday", UserID = "7c80072c-4bfc-47be-aac3-475a99ee0d69", AdminUserID = "824e8cf2-01dc-48f1-8d5b-8ef6d9c1f3a1", DateOfTask = DateTime.Today.AddDays(-1), ProjectID = 1 }, new DomainModels.Task() { TaskID = 7, Screen = "Create Forget Pass", Description = "Create forget password page", UserID = "7c80072c-4bfc-47be-aac3-475a99ee0d69", AdminUserID = "99c80b94-322d-46d6-9518-9224c810891d", DateOfTask = DateTime.Today.AddDays(-1), ProjectID = 2 });
            context.TasksDone.AddOrUpdate(new DomainModels.TaskDone() { TaskDoneID = 3, Screen = "Login page", Description = "Completed Login page", UserID = "7c80072c-4bfc-47be-aac3-475a99ee0d69", DateOfTaskDone = DateTime.Today.AddDays(-1), ProjectID = 1 }, new DomainModels.TaskDone() { TaskDoneID = 4, Screen = "Register a user", Description = "Registered shi successfully", UserID = "7c80072c-4bfc-47be-aac3-475a99ee0d69", DateOfTaskDone = DateTime.Today.AddDays(-1), ProjectID = 2 });
            context.FinalComments.AddOrUpdate(new DomainModels.FinalComment() { FinalCommentID = 4, Screen = "Login Page", Description = "show proper messages in case of invalid data", UserID = "7c80072c-4bfc-47be-aac3-475a99ee0d69", AdminUserID = "824e8cf2-01dc-48f1-8d5b-8ef6d9c1f3a1", DateOfFinalComment = DateTime.Today.AddDays(-1), ProjectID = 1 }, new DomainModels.FinalComment() { FinalCommentID = 5, Screen = "Project", Description = "Update project with real data", UserID = "7c80072c-4bfc-47be-aac3-475a99ee0d69", AdminUserID = "99c80b94-322d-46d6-9518-9224c810891d", DateOfFinalComment = DateTime.Today.AddDays(-1), ProjectID = 2 }, new DomainModels.FinalComment() { FinalCommentID = 6, Screen = "Save Info", Description = "Save button does not add new information to th database", UserID = "7c80072c-4bfc-47be-aac3-475a99ee0d69", AdminUserID = "cfbe6bbc-9752-401e-9236-f68d13193658", DateOfFinalComment = DateTime.Today.AddDays(-1), ProjectID = 2 });

        }
    }
}
