using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CMS.Models.CMSModel
{
    public class CMSContext : DbContext
    {
        public DbSet<Device> Devices { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventCategory> EventCategories { get; set; }
        public DbSet<Location> Locations { get; set; }
        public CMSContext()
            : base("DefaultConnection")
        {
        }

        public static CMSContext Create()
        {
            return new CMSContext();
        }
    }
}