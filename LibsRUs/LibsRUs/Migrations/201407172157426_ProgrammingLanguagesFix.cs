namespace LibsRUs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProgrammingLanguagesFix : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProgrammingLanguages", "Abbreviation", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProgrammingLanguages", "Abbreviation", c => c.String(nullable: false));
        }
    }
}
