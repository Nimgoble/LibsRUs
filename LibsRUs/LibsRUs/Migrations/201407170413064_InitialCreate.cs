namespace LibsRUs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
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
                        TagText = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
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
                        UserName = c.String(),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.LoginProvider, t.ProviderKey })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserFavoriteLibs", "User_Id", "dbo.Users");
            DropForeignKey("dbo.AspNetUserClaims", "User_Id", "dbo.Users");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserFavoriteLibs", "LibID", "dbo.Libs");
            DropForeignKey("dbo.LibTagLibs", "Lib_ID", "dbo.Libs");
            DropForeignKey("dbo.LibTagLibs", "LibTag_ID", "dbo.LibTags");
            DropIndex("dbo.UserFavoriteLibs", new[] { "User_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "User_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.UserFavoriteLibs", new[] { "LibID" });
            DropIndex("dbo.LibTagLibs", new[] { "Lib_ID" });
            DropIndex("dbo.LibTagLibs", new[] { "LibTag_ID" });
            DropTable("dbo.LibTagLibs");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.Users");
            DropTable("dbo.UserFavoriteLibs");
            DropTable("dbo.LibTags");
            DropTable("dbo.Libs");
        }
    }
}
