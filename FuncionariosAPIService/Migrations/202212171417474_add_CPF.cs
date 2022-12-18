namespace Locadora.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_CPF : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Funcionarios", "CPF", c => c.Int(nullable: false));
            CreateIndex("dbo.Funcionarios", "CPF", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Funcionarios", new[] { "CPF" });
            DropColumn("dbo.Funcionarios", "CPF");
        }
    }
}
