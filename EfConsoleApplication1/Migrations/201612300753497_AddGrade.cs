namespace EfConsoleApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGrade : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        GradeName = c.String(),
                        StuGrade = c.Int(nullable: false),
                        StuClass = c.Int(nullable: false),
                        StuNum = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Grades");
        }
    }
}
