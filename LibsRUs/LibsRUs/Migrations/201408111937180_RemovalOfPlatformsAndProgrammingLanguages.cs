namespace LibsRUs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovalOfPlatformsAndProgrammingLanguages : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PlatformLibs", "Platform_ID", "dbo.Platforms");
            DropForeignKey("dbo.PlatformLibs", "Lib_ID", "dbo.Libs");
            DropForeignKey("dbo.ProgrammingLanguageLibs", "ProgrammingLanguage_ID", "dbo.ProgrammingLanguages");
            DropForeignKey("dbo.ProgrammingLanguageLibs", "Lib_ID", "dbo.Libs");
            DropIndex("dbo.Platforms", "NameIndex");
            DropIndex("dbo.ProgrammingLanguages", "NameIndex");
            DropIndex("dbo.PlatformLibs", new[] { "Platform_ID" });
            DropIndex("dbo.PlatformLibs", new[] { "Lib_ID" });
            DropIndex("dbo.ProgrammingLanguageLibs", new[] { "ProgrammingLanguage_ID" });
            DropIndex("dbo.ProgrammingLanguageLibs", new[] { "Lib_ID" });
            CreateTable(
                "dbo.LibTagTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.LibTags", "LibTagType_ID", c => c.Int());
            CreateIndex("dbo.LibTags", "LibTagType_ID");
            AddForeignKey("dbo.LibTags", "LibTagType_ID", "dbo.LibTagTypes", "ID");
            DropTable("dbo.Platforms");
            DropTable("dbo.ProgrammingLanguages");
            DropTable("dbo.PlatformLibs");
            DropTable("dbo.ProgrammingLanguageLibs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProgrammingLanguageLibs",
                c => new
                    {
                        ProgrammingLanguage_ID = c.Int(nullable: false),
                        Lib_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProgrammingLanguage_ID, t.Lib_ID });
            
            CreateTable(
                "dbo.PlatformLibs",
                c => new
                    {
                        Platform_ID = c.Int(nullable: false),
                        Lib_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Platform_ID, t.Lib_ID });
            
            CreateTable(
                "dbo.ProgrammingLanguages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Abbreviation = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Platforms",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            DropForeignKey("dbo.LibTags", "LibTagType_ID", "dbo.LibTagTypes");
            DropIndex("dbo.LibTags", new[] { "LibTagType_ID" });
            DropColumn("dbo.LibTags", "LibTagType_ID");
            DropTable("dbo.LibTagTypes");
            CreateIndex("dbo.ProgrammingLanguageLibs", "Lib_ID");
            CreateIndex("dbo.ProgrammingLanguageLibs", "ProgrammingLanguage_ID");
            CreateIndex("dbo.PlatformLibs", "Lib_ID");
            CreateIndex("dbo.PlatformLibs", "Platform_ID");
            CreateIndex("dbo.ProgrammingLanguages", "Name", unique: true, name: "NameIndex");
            CreateIndex("dbo.Platforms", "Name", unique: true, name: "NameIndex");
            AddForeignKey("dbo.ProgrammingLanguageLibs", "Lib_ID", "dbo.Libs", "ID", cascadeDelete: true);
            AddForeignKey("dbo.ProgrammingLanguageLibs", "ProgrammingLanguage_ID", "dbo.ProgrammingLanguages", "ID", cascadeDelete: true);
            AddForeignKey("dbo.PlatformLibs", "Lib_ID", "dbo.Libs", "ID", cascadeDelete: true);
            AddForeignKey("dbo.PlatformLibs", "Platform_ID", "dbo.Platforms", "ID", cascadeDelete: true);
        }
    }
}
