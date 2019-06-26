namespace LearningApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLanguages : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    SET IDENTITY_INSERT [dbo].[Language] ON
                    INSERT INTO [dbo].[Language] ([Id], [Name]) VALUES (1, N'HTML')
                    INSERT INTO [dbo].[Language] ([Id], [Name]) VALUES (2, N'CSS')
                    INSERT INTO [dbo].[Language] ([Id], [Name]) VALUES (3, N'JavaScript')
                    INSERT INTO [dbo].[Language] ([Id], [Name]) VALUES (4, N'Python')
                    INSERT INTO [dbo].[Language] ([Id], [Name]) VALUES (5, N'C#')
                    INSERT INTO [dbo].[Language] ([Id], [Name]) VALUES (6, N'React')
                    INSERT INTO [dbo].[Language] ([Id], [Name]) VALUES (7, N'NodeJS')
                    INSERT INTO [dbo].[Language] ([Id], [Name]) VALUES (8, N'Ruby')
                    INSERT INTO [dbo].[Language] ([Id], [Name]) VALUES (9, N'SQL')
                    SET IDENTITY_INSERT [dbo].[Language] OFF"

                );

        }
        
        public override void Down()
        {
        }
    }
}
