namespace UOPO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedGroupCards : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GroupCards", "Reward", c => c.String());
            AddColumn("dbo.GroupCards", "Set", c => c.String());
            AddColumn("dbo.GroupCards", "Type", c => c.String());
            AddColumn("dbo.SoloCards", "Reward", c => c.String());
            AddColumn("dbo.SoloCards", "Set", c => c.String());
            AddColumn("dbo.SoloCards", "Type", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SoloCards", "Type");
            DropColumn("dbo.SoloCards", "Set");
            DropColumn("dbo.SoloCards", "Reward");
            DropColumn("dbo.GroupCards", "Type");
            DropColumn("dbo.GroupCards", "Set");
            DropColumn("dbo.GroupCards", "Reward");
        }
    }
}
