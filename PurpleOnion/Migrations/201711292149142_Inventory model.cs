namespace PurpleOnion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inventorymodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Inventories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Brand = c.String(),
                        Type = c.Int(nullable: false),
                        Stock = c.Int(nullable: false),
                        Price = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Inventories");
        }
    }
}
