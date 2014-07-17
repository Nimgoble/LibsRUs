namespace LibsRUs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlatformsAndProgrammingLanguages : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Platforms",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProgrammingLanguages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Abbreviation = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PlatformLibs",
                c => new
                    {
                        Platform_ID = c.Int(nullable: false),
                        Lib_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Platform_ID, t.Lib_ID })
                .ForeignKey("dbo.Platforms", t => t.Platform_ID, cascadeDelete: true)
                .ForeignKey("dbo.Libs", t => t.Lib_ID, cascadeDelete: true)
                .Index(t => t.Platform_ID)
                .Index(t => t.Lib_ID);
            
            CreateTable(
                "dbo.ProgrammingLanguageLibs",
                c => new
                    {
                        ProgrammingLanguage_ID = c.Int(nullable: false),
                        Lib_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProgrammingLanguage_ID, t.Lib_ID })
                .ForeignKey("dbo.ProgrammingLanguages", t => t.ProgrammingLanguage_ID, cascadeDelete: true)
                .ForeignKey("dbo.Libs", t => t.Lib_ID, cascadeDelete: true)
                .Index(t => t.ProgrammingLanguage_ID)
                .Index(t => t.Lib_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProgrammingLanguageLibs", "Lib_ID", "dbo.Libs");
            DropForeignKey("dbo.ProgrammingLanguageLibs", "ProgrammingLanguage_ID", "dbo.ProgrammingLanguages");
            DropForeignKey("dbo.PlatformLibs", "Lib_ID", "dbo.Libs");
            DropForeignKey("dbo.PlatformLibs", "Platform_ID", "dbo.Platforms");
            DropIndex("dbo.ProgrammingLanguageLibs", new[] { "Lib_ID" });
            DropIndex("dbo.ProgrammingLanguageLibs", new[] { "ProgrammingLanguage_ID" });
            DropIndex("dbo.PlatformLibs", new[] { "Lib_ID" });
            DropIndex("dbo.PlatformLibs", new[] { "Platform_ID" });
            DropTable("dbo.ProgrammingLanguageLibs");
            DropTable("dbo.PlatformLibs");
            DropTable("dbo.ProgrammingLanguages");
            DropTable("dbo.Platforms");
        }
    }
}
