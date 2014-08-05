namespace LibsRUs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Libs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        LibURL = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.LibTags",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TagText = c.String(nullable: false, maxLength: 75),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.TagText, unique: true, name: "TagTextIndex");
            
            CreateTable(
                "dbo.Platforms",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.Name, unique: true, name: "NameIndex");
            
            CreateTable(
                "dbo.ProgrammingLanguages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Abbreviation = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.Name, unique: true, name: "NameIndex");
            
            CreateTable(
                "dbo.UserFavoriteLibs",
                c => new
                    {
                        LibID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LibID, t.UserID })
                .ForeignKey("dbo.Libs", t => t.LibID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.LibID)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.Users", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.IdentityUser_Id)
                .Index(t => t.RoleId)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.LibTagLibs",
                c => new
                    {
                        LibTag_ID = c.Int(nullable: false),
                        Lib_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LibTag_ID, t.Lib_ID })
                .ForeignKey("dbo.LibTags", t => t.LibTag_ID, cascadeDelete: true)
                .ForeignKey("dbo.Libs", t => t.Lib_ID, cascadeDelete: true)
                .Index(t => t.LibTag_ID)
                .Index(t => t.Lib_ID);
            
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
            DropForeignKey("dbo.AspNetUserRoles", "IdentityUser_Id", "dbo.Users");
            DropForeignKey("dbo.AspNetUserLogins", "IdentityUser_Id", "dbo.Users");
            DropForeignKey("dbo.AspNetUserClaims", "IdentityUser_Id", "dbo.Users");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.UserFavoriteLibs", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserFavoriteLibs", "LibID", "dbo.Libs");
            DropForeignKey("dbo.ProgrammingLanguageLibs", "Lib_ID", "dbo.Libs");
            DropForeignKey("dbo.ProgrammingLanguageLibs", "ProgrammingLanguage_ID", "dbo.ProgrammingLanguages");
            DropForeignKey("dbo.PlatformLibs", "Lib_ID", "dbo.Libs");
            DropForeignKey("dbo.PlatformLibs", "Platform_ID", "dbo.Platforms");
            DropForeignKey("dbo.LibTagLibs", "Lib_ID", "dbo.Libs");
            DropForeignKey("dbo.LibTagLibs", "LibTag_ID", "dbo.LibTags");
            DropIndex("dbo.ProgrammingLanguageLibs", new[] { "Lib_ID" });
            DropIndex("dbo.ProgrammingLanguageLibs", new[] { "ProgrammingLanguage_ID" });
            DropIndex("dbo.PlatformLibs", new[] { "Lib_ID" });
            DropIndex("dbo.PlatformLibs", new[] { "Platform_ID" });
            DropIndex("dbo.LibTagLibs", new[] { "Lib_ID" });
            DropIndex("dbo.LibTagLibs", new[] { "LibTag_ID" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "IdentityUser_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "IdentityUser_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "IdentityUser_Id" });
            DropIndex("dbo.UserFavoriteLibs", new[] { "User_Id" });
            DropIndex("dbo.UserFavoriteLibs", new[] { "LibID" });
            DropIndex("dbo.ProgrammingLanguages", "NameIndex");
            DropIndex("dbo.Platforms", "NameIndex");
            DropIndex("dbo.LibTags", "TagTextIndex");
            DropTable("dbo.ProgrammingLanguageLibs");
            DropTable("dbo.PlatformLibs");
            DropTable("dbo.LibTagLibs");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.Users");
            DropTable("dbo.UserFavoriteLibs");
            DropTable("dbo.ProgrammingLanguages");
            DropTable("dbo.Platforms");
            DropTable("dbo.LibTags");
            DropTable("dbo.Libs");
        }
    }
}
