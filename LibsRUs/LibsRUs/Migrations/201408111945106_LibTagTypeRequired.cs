namespace LibsRUs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LibTagTypeRequired : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LibTags", "LibTagType_ID", "dbo.LibTagTypes");
            DropIndex("dbo.LibTags", new[] { "LibTagType_ID" });
            AlterColumn("dbo.LibTags", "LibTagType_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.LibTags", "LibTagType_ID");
            AddForeignKey("dbo.LibTags", "LibTagType_ID", "dbo.LibTagTypes", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LibTags", "LibTagType_ID", "dbo.LibTagTypes");
            DropIndex("dbo.LibTags", new[] { "LibTagType_ID" });
            AlterColumn("dbo.LibTags", "LibTagType_ID", c => c.Int());
            CreateIndex("dbo.LibTags", "LibTagType_ID");
            AddForeignKey("dbo.LibTags", "LibTagType_ID", "dbo.LibTagTypes", "ID");
        }
    }
}
