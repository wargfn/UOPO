namespace UOPO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedCardData4 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO GroupCards(Name, CardNum, CardSet, CardType) VALUES ('Mercy of the Lost', 003, 'Base Set', 'Duster')");
        }
        
        public override void Down()
        {
        }
    }
}
