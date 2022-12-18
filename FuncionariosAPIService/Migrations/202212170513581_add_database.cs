namespace Locadora.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_database : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Funcionarios",
                c => new
                    {
                        FuncionarioId = c.Int(nullable: false, identity: true),
                        Nome = c.String(unicode: false),
                        Email = c.String(unicode: false),
                        Sexo = c.String(unicode: false),
                        Salario = c.Int(nullable: false),
                        Setor = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.FuncionarioId);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        Login = c.String(unicode: false),
                        Senha = c.String(unicode: false),
                        Nome = c.String(unicode: false),
                        Email = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UsuarioId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Usuarios");
            DropTable("dbo.Funcionarios");
        }
    }
}
