namespace Locadora.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_tabelas : DbMigration
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
                        RegAtivo = c.String(maxLength: 1, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Filme",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(unicode: false),
                        Categoria = c.String(unicode: false),
                        RegAtivo = c.String(maxLength: 1, storeType: "nvarchar"),
                        Disponivel = c.String(maxLength: 1, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Locacao",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataLocacao = c.DateTime(nullable: false, precision: 0),
                        DataDevolucao = c.DateTime(nullable: false, precision: 0),
                        DataDevolvido = c.DateTime(precision: 0),
                        ClienteId = c.Int(nullable: false),
                        FilmeId = c.Int(nullable: false),
                        RegAtivo = c.String(maxLength: 1, storeType: "nvarchar"),
                        StatusLocacao = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cliente", t => t.ClienteId, cascadeDelete: true)
                .ForeignKey("dbo.Filme", t => t.FilmeId, cascadeDelete: true)
                .Index(t => t.ClienteId)
                .Index(t => t.FilmeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Locacao", "FilmeId", "dbo.Filme");
            DropForeignKey("dbo.Locacao", "ClienteId", "dbo.Cliente");
            DropIndex("dbo.Locacao", new[] { "FilmeId" });
            DropIndex("dbo.Locacao", new[] { "ClienteId" });
            DropTable("dbo.Locacao");
            DropTable("dbo.Filme");
            DropTable("dbo.Cliente");
        }
    }
}
