namespace Locadora.Migrations
{
    using MySql.Data.Entity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Model;
    using System.Data.Entity.Migrations.Sql;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Locadora.Models.LocadoraDBContext>
    {
        public class FixedMySqlMigrationSqlGenerator : MySqlMigrationSqlGenerator
        {
            public FixedMySqlMigrationSqlGenerator()
                : base()
            {
            }

            protected override MigrationStatement Generate(CreateIndexOperation op)
            {
                MigrationStatement migrationStatement = base.Generate(op);
                System.Diagnostics.Trace.WriteLine(migrationStatement.Sql);
                string fubarSql = migrationStatement.Sql.TrimEnd();

                if (fubarSql.EndsWith("using HASH", StringComparison.OrdinalIgnoreCase))
                {
                    string modSql = fubarSql.Replace("using HASH", " using BTREE");
                    migrationStatement.Sql = modSql;
                }
                return migrationStatement;
            }


        }
        public Configuration()
        {
            //AutomaticMigrationsEnabled = false;
            //SetSqlGenerator("MySql.Data.MySqlClient", new MySql.Data.Entity.MySqlMigrationSqlGenerator());

            AutomaticMigrationsEnabled = false;
            SetSqlGenerator("MySql.Data.MySqlClient", new FixedMySqlMigrationSqlGenerator());
        }

        protected override void Seed(Locadora.Models.LocadoraDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
