namespace Locadora.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_Status_DataDevolvido : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Locacao", "DataDevolvido", c => c.DateTime(precision: 0));
            AddColumn("dbo.Locacao", "StatusLocacao", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Locacao", "StatusLocacao");
            DropColumn("dbo.Locacao", "DataDevolvido");
        }
    }
}
