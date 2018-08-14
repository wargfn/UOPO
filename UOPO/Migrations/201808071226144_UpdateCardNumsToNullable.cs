namespace UOPO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCardNumsToNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GroupCards", "CardNum", c => c.Int());
            AlterColumn("dbo.SoloCards", "CardNum", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SoloCards", "CardNum", c => c.Int(nullable: false));
            AlterColumn("dbo.GroupCards", "CardNum", c => c.Int(nullable: false));
        }
    }
}
