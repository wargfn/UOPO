namespace UOPO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyAnnotationsGroupCardsName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GroupCards", "BackTextOption3", c => c.String());
            AddColumn("dbo.GroupCards", "RewardsOption3", c => c.String());
            AlterColumn("dbo.GroupCards", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GroupCards", "Name", c => c.String());
            DropColumn("dbo.GroupCards", "RewardsOption3");
            DropColumn("dbo.GroupCards", "BackTextOption3");
        }
    }
}
