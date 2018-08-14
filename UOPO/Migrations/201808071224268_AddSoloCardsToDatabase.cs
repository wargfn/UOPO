namespace UOPO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSoloCardsToDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SoloCards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FrontText = c.String(),
                        BackTextOption1 = c.String(),
                        BackTextOption2 = c.String(),
                        RewardsOption1 = c.String(),
                        RewardsOption2 = c.String(),
                        CardNum = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SoloCards");
        }
    }
}
