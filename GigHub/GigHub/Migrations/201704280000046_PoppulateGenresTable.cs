namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PoppulateGenresTable : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Genres (id, name) values (1, 'Jazz')");
            Sql("insert into Genres (id, name) values (2, 'Blues')");
            Sql("insert into Genres (id, name) values (3, 'Rock')");
            Sql("insert into Genres (id, name) values (4, 'Country')");
        }
        
        public override void Down()
        {
            Sql("Delete from Genre where id in (1, 2, 3, 4)");
        }
    }
}
