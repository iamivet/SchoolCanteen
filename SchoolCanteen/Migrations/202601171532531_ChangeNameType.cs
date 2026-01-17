namespace SchoolCanteen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeNameType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FoodTypes", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FoodTypes", "Name", c => c.Int(nullable: false));
        }
    }
}
