namespace Locadora.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_filme : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Filme",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(unicode: false),
                        Categoria = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Filme");
        }
    }
}
