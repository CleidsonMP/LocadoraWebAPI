namespace Locadora.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_RegAtivo_Cliente : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cliente", "RegAtivo", c => c.String(maxLength: 1, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cliente", "RegAtivo");
        }
    }
}
