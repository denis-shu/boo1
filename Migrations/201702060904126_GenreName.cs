namespace boo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GenreName : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Books", "GenreId");
            AddForeignKey("dbo.Books", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "GenreId", "dbo.Genres");
            DropIndex("dbo.Books", new[] { "GenreId" });
        }
    }
}
