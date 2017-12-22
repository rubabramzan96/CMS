namespace CMS.Migrations.CMSContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class longlatchangedtofloat : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Location", "LAT", c => c.Single(nullable: false));
            AlterColumn("dbo.Location", "LONG", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Location", "LONG", c => c.Int(nullable: false));
            AlterColumn("dbo.Location", "LAT", c => c.Int(nullable: false));
        }
    }
}
