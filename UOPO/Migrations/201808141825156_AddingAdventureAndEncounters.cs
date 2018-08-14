namespace UOPO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingAdventureAndEncounters : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdventuresModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                        EncounterId = c.Byte(nullable: false),
                        GetEncounterList_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EncounterListModels", t => t.GetEncounterList_Id)
                .Index(t => t.GetEncounterList_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AdventuresModels", "GetEncounterList_Id", "dbo.EncounterListModels");
            DropIndex("dbo.AdventuresModels", new[] { "GetEncounterList_Id" });
            DropTable("dbo.AdventuresModels");
        }
    }
}
