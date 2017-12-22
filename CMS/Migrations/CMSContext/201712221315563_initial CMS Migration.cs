namespace CMS.Migrations.CMSContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialCMSMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Device",
                c => new
                    {
                        DeviceID = c.Int(nullable: false, identity: true),
                        LocationID = c.Int(nullable: false),
                        Build = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DeviceID)
                .ForeignKey("dbo.Location", t => t.LocationID, cascadeDelete: true)
                .Index(t => t.LocationID);
            
            CreateTable(
                "dbo.Location",
                c => new
                    {
                        LocationID = c.Int(nullable: false, identity: true),
                        LAT = c.Int(nullable: false),
                        LONG = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.LocationID);
            
            CreateTable(
                "dbo.Event",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        EventCatID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        Name = c.String(),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        OrganiserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EventID)
                .ForeignKey("dbo.EventCategory", t => t.EventCatID, cascadeDelete: true)
                .ForeignKey("dbo.Location", t => t.LocationID, cascadeDelete: true)
                .Index(t => t.EventCatID)
                .Index(t => t.LocationID);
            
            CreateTable(
                "dbo.EventCategory",
                c => new
                    {
                        EventCatID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Outdoor = c.Boolean(nullable: false),
                        Family = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EventCatID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Device", "LocationID", "dbo.Location");
            DropForeignKey("dbo.Event", "LocationID", "dbo.Location");
            DropForeignKey("dbo.Event", "EventCatID", "dbo.EventCategory");
            DropIndex("dbo.Event", new[] { "LocationID" });
            DropIndex("dbo.Event", new[] { "EventCatID" });
            DropIndex("dbo.Device", new[] { "LocationID" });
            DropTable("dbo.EventCategory");
            DropTable("dbo.Event");
            DropTable("dbo.Location");
            DropTable("dbo.Device");
        }
    }
}
