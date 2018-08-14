namespace UOPO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedCardData1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GroupCards", "CardSet", c => c.String());
            AddColumn("dbo.SoloCards", "CardSet", c => c.String());
            DropColumn("dbo.GroupCards", "Set");
            DropColumn("dbo.SoloCards", "Set");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SoloCards", "Set", c => c.String());
            AddColumn("dbo.GroupCards", "Set", c => c.String());
            DropColumn("dbo.SoloCards", "CardSet");
            DropColumn("dbo.GroupCards", "CardSet");
        }
    }
}
