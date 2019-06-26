namespace LearningApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class P : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Student", "BirthDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Student", "BirthDate", c => c.DateTime(nullable: false));
        }
    }
}
