namespace UOPO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedEncounterListModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EncounterListModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Day1 = c.Int(nullable: false),
                        Day2 = c.Int(nullable: false),
                        Day3 = c.Int(nullable: false),
                        Day4 = c.Int(nullable: false),
                        Day5 = c.Int(nullable: false),
                        Day6 = c.Int(nullable: false),
                        Day7 = c.Int(nullable: false),
                        Day8 = c.Int(nullable: false),
                        Day9 = c.Int(),
                        Day10 = c.Int(),
                        Day11 = c.Int(),
                        Day12 = c.Int(),
                        Day13 = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EncounterListModels");
        }
    }
}
