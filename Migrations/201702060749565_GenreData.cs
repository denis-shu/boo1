namespace boo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GenreData : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Genres ON");
            Sql("INSERT INTO Genres(Id, Name) VALUES (1, 'Science')");
            Sql("INSERT INTO Genres(Id, Name) VALUES (2, 'Documentary')");
            Sql("INSERT INTO Genres(Id, Name) VALUES (3, 'Fantasy')");
            Sql("INSERT INTO Genres(Id, Name) VALUES (4, 'Mystic')");
            Sql("SET IDENTITY_INSERT Genres OFF");

        }

        public override void Down()
        {
        }
    }
}
