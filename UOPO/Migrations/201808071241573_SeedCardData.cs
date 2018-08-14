namespace UOPO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedCardData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GroupCards", "CardType", c => c.String());
            AddColumn("dbo.SoloCards", "CardType", c => c.String());
            DropColumn("dbo.GroupCards", "Type");
            DropColumn("dbo.SoloCards", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SoloCards", "Type", c => c.String());
            AddColumn("dbo.GroupCards", "Type", c => c.String());
            DropColumn("dbo.SoloCards", "CardType");
            DropColumn("dbo.GroupCards", "CardType");
        }
    }
}
