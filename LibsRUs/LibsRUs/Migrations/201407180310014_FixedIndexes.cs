namespace LibsRUs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedIndexes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LibTags", "TagText", c => c.String(nullable: false, maxLength: 75));
            AlterColumn("dbo.Platforms", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.ProgrammingLanguages", "Name", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.LibTags", "TagText", unique: true, name: "TagTextIndex");
            CreateIndex("dbo.Platforms", "Name", unique: true, name: "NameIndex");
            CreateIndex("dbo.ProgrammingLanguages", "Name", unique: true, name: "NameIndex");
        }
        
        public override void Down()
        {
            DropIndex("dbo.ProgrammingLanguages", "NameIndex");
            DropIndex("dbo.Platforms", "NameIndex");
            DropIndex("dbo.LibTags", "TagTextIndex");
            AlterColumn("dbo.ProgrammingLanguages", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Platforms", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.LibTags", "TagText", c => c.String(nullable: false));
        }
    }
}
