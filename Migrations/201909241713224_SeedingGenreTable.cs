namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedingGenreTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO GENRES(ID, NAME) VALUES (1, 'Action')");
            Sql("INSERT INTO GENRES(ID, NAME) VALUES (2, 'Documentary')");
            Sql("INSERT INTO GENRES(ID, NAME) VALUES (3, 'Horror')");
        }

        public override void Down()
        {
            Sql("TRUNCATE TABLE GENRES");
        }
    }
}
