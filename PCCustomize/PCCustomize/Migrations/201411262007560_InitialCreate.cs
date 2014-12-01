namespace PCCustomize.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsDel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Components",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        price = c.Double(nullable: false),
                        IsDel = c.Int(nullable: false),
                        Description = c.String(),
                        CategoryId = c.Int(nullable: false),
                        Computer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Computers", t => t.Computer_Id)
                .Index(t => t.Computer_Id);
            
            CreateTable(
                "dbo.Computers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                        IsDel = c.Int(nullable: false),
                        Description = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Components", "Computer_Id", "dbo.Computers");
            DropIndex("dbo.Components", new[] { "Computer_Id" });
            DropTable("dbo.Computers");
            DropTable("dbo.Components");
            DropTable("dbo.Categories");
        }
    }
}
