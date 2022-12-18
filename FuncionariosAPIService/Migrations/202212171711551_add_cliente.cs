namespace Locadora.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_cliente : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CPF = c.String(maxLength: 14, storeType: "nvarchar"),
                        Nome = c.String(unicode: false),
                        Telefone = c.String(maxLength: 14, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cliente");
        }
    }
}
