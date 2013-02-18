namespace orgnet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Nodes", "Text", c => c.String());
            AddColumn("dbo.Nodes", "LastEdited", c => c.DateTime());
            AddColumn("dbo.Nodes", "IsDone", c => c.Boolean());
            AddColumn("dbo.Nodes", "DateCreated", c => c.DateTime());
            AddColumn("dbo.Nodes", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Nodes", "Content_Id", c => c.Int());
            AddForeignKey("dbo.Nodes", "Content_Id", "dbo.Nodes", "Id");
            CreateIndex("dbo.Nodes", "Content_Id");
            DropColumn("dbo.Nodes", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Nodes", "Description", c => c.String());
            DropIndex("dbo.Nodes", new[] { "Content_Id" });
            DropForeignKey("dbo.Nodes", "Content_Id", "dbo.Nodes");
            DropColumn("dbo.Nodes", "Content_Id");
            DropColumn("dbo.Nodes", "Discriminator");
            DropColumn("dbo.Nodes", "DateCreated");
            DropColumn("dbo.Nodes", "IsDone");
            DropColumn("dbo.Nodes", "LastEdited");
            DropColumn("dbo.Nodes", "Text");
        }
    }
}
