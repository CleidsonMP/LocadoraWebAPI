namespace Locadora.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_Disponivel_Filme : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Filme", "Disponivel", c => c.String(maxLength: 1, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Filme", "Disponivel");
        }
    }
}
