namespace Reporting.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Long(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.FinalComments",
                c => new
                    {
                        FinalCommentID = c.Long(nullable: false, identity: true),
                        Screen = c.String(maxLength: 50),
                        Description = c.String(),
                        AdminUserID = c.String(nullable: false, maxLength: 128),
                        UserID = c.String(nullable: false, maxLength: 128),
                        DateOfFinalComment = c.DateTime(nullable: false),
                        Attachment = c.String(),
                        ProjectID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.FinalCommentID)
                .ForeignKey("dbo.AspNetUsers", t => t.AdminUserID, cascadeDelete: false)
                .ForeignKey("dbo.Projects", t => t.ProjectID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID, cascadeDelete: false)
                .Index(t => t.AdminUserID)
                .Index(t => t.UserID)
                .Index(t => t.ProjectID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Birthday = c.DateTime(),
                        Address = c.String(),
                        City = c.String(),
                        Country = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectID = c.Long(nullable: false, identity: true),
                        ProjectName = c.String(nullable: false),
                        DateOfStart = c.DateTime(),
                        AvailabilityStatus = c.String(),
                        CategoryID = c.Long(nullable: false),
                        Photo = c.String(),
                    })
                .PrimaryKey(t => t.ProjectID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        TaskID = c.Long(nullable: false, identity: true),
                        Screen = c.String(maxLength: 50),
                        Description = c.String(),
                        AdminUserID = c.String(nullable: false, maxLength: 128),
                        UserID = c.String(nullable: false, maxLength: 128),
                        DateOfTask = c.DateTime(nullable: false),
                        Attachment = c.String(),
                        ProjectID = c.Long(),
                    })
                .PrimaryKey(t => t.TaskID)
                .ForeignKey("dbo.AspNetUsers", t => t.AdminUserID, cascadeDelete: false)
                .ForeignKey("dbo.Projects", t => t.ProjectID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID, cascadeDelete: false)
                .Index(t => t.AdminUserID)
                .Index(t => t.UserID)
                .Index(t => t.ProjectID);
            
            CreateTable(
                "dbo.TaskDones",
                c => new
                    {
                        TaskDoneID = c.Long(nullable: false, identity: true),
                        Screen = c.String(maxLength: 50),
                        Description = c.String(),
                        UserID = c.String(nullable: false, maxLength: 128),
                        DateOfTaskDone = c.DateTime(nullable: false),
                        Attachment = c.String(),
                        ProjectID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.TaskDoneID)
                .ForeignKey("dbo.Projects", t => t.ProjectID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID, cascadeDelete: false)
                .Index(t => t.UserID)
                .Index(t => t.ProjectID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TaskDones", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.TaskDones", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.Tasks", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Tasks", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.Tasks", "AdminUserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.FinalComments", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.FinalComments", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.Projects", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.FinalComments", "AdminUserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.TaskDones", new[] { "ProjectID" });
            DropIndex("dbo.TaskDones", new[] { "UserID" });
            DropIndex("dbo.Tasks", new[] { "ProjectID" });
            DropIndex("dbo.Tasks", new[] { "UserID" });
            DropIndex("dbo.Tasks", new[] { "AdminUserID" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Projects", new[] { "CategoryID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.FinalComments", new[] { "ProjectID" });
            DropIndex("dbo.FinalComments", new[] { "UserID" });
            DropIndex("dbo.FinalComments", new[] { "AdminUserID" });
            DropTable("dbo.TaskDones");
            DropTable("dbo.Tasks");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Projects");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.FinalComments");
            DropTable("dbo.Categories");
        }
    }
}
