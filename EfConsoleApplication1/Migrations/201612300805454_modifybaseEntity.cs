namespace EfConsoleApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifybaseEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Grades", "CreateDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Students", "CreateDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Teachers", "CreateDateTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Grades", "CreateDate");
            DropColumn("dbo.Students", "CreateDate");
            DropColumn("dbo.Teachers", "CreateDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Teachers", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Students", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Grades", "CreateDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Teachers", "CreateDateTime");
            DropColumn("dbo.Students", "CreateDateTime");
            DropColumn("dbo.Grades", "CreateDateTime");
        }
    }
}
