namespace UOPO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedCardData2 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO GroupCards(Name, CardNum, CardSet, CardType) VALUES ('The Dreaded Bog', 001, 'Base Set', 'General')");
        }
        
        public override void Down()
        {
        }
    }
}
