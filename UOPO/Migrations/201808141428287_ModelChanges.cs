namespace UOPO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelChanges : DbMigration
    {
        public override void Up()
        {
            
        }
        
        public override void Down()
        {
            DropColumn("dbo.EncounterListModels", "Name");
        }
    }
}
