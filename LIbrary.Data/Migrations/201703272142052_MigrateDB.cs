namespace LIbrary.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Author", c => c.String());
            DropColumn("dbo.Books", "Category");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "Category", c => c.String());
            DropColumn("dbo.Books", "Author");
        }
    }
}
