namespace LearningApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Plans : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                SET IDENTITY_INSERT [dbo].[Plan] ON
                INSERT INTO [dbo].[Plan] ([Id], [Fee], [Duration], [Discount], [Name]) VALUES (1, 0, 0, 0, N'Free')
                INSERT INTO [dbo].[Plan] ([Id], [Fee], [Duration], [Discount], [Name]) VALUES (2, 19.99, 1, 0, N'Monthly Subscription')
                INSERT INTO [dbo].[Plan] ([Id], [Fee], [Duration], [Discount], [Name]) VALUES (3, 17.99, 6, 2, N'6 Month Subscription')
                INSERT INTO [dbo].[Plan] ([Id], [Fee], [Duration], [Discount], [Name]) VALUES (4, 15.99, 12, 4, N'Annual Subscription')
                SET IDENTITY_INSERT [dbo].[Plan] OFF




            ");
        }
        
        public override void Down()
        {
        }
    }
}
