namespace LibsRUs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LibTagDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LibTags", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.LibTags", "Description");
        }
    }
}
