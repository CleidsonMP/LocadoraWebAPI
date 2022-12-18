namespace Locadora.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_RegAtivo_Locacao : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Locacao", "RegAtivo", c => c.String(maxLength: 1, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Locacao", "RegAtivo");
        }
    }
}
