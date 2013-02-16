namespace orgnet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Nodes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Parent_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Nodes", t => t.Parent_Id)
                .Index(t => t.Parent_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Nodes", new[] { "Parent_Id" });
            DropForeignKey("dbo.Nodes", "Parent_Id", "dbo.Nodes");
            DropTable("dbo.Nodes");
        }
    }
}
