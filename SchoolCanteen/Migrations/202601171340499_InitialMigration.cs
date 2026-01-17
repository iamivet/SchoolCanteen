namespace SchoolCanteen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Calories = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FoodTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FoodTypes", t => t.FoodTypeId, cascadeDelete: true)
                .Index(t => t.FoodTypeId);
            
            CreateTable(
                "dbo.FoodTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Foods", "FoodTypeId", "dbo.FoodTypes");
            DropIndex("dbo.Foods", new[] { "FoodTypeId" });
            DropTable("dbo.FoodTypes");
            DropTable("dbo.Foods");
        }
    }
}
