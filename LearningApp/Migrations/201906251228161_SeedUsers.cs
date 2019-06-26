namespace LearningApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2d14d665-db60-4d22-bf77-16864b37b1fa', N'guest@mail.com', 0, N'AMw2vsIawRsdUcB/WWDem8zlmk9UqIN7IjVH+hSpiwmohZwZmbCgJlzTGyguLRJh0A==', N'ec7f8ff6-3561-4ddd-a8a7-345821371209', NULL, 0, 0, NULL, 1, 0, N'guest@mail.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ca033b04-7657-4f37-a148-83b0eef4bc7f', N'admin@admin.rs', 0, N'AMbkuv3vJreNctKkfU+bqYG2PsCjWZipdecTXRDUi0k0+XbNrja4nRIw1Yl+ZqBS4w==', N'4a8f2125-9873-4125-a505-023c714df02c', NULL, 0, 0, NULL, 1, 0, N'admin@admin.rs')
                
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'25a9c3db-74f8-4f05-9f10-8c0a6e6c93ea', N'CanManageCourses')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ca033b04-7657-4f37-a148-83b0eef4bc7f', N'25a9c3db-74f8-4f05-9f10-8c0a6e6c93ea')

            ");

        }
        
        public override void Down()
        {
        }
    }
}
