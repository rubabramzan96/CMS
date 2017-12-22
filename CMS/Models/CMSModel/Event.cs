using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CMS.Models.CMSModel
{
    [Table("Event")]
    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventID { get; set; }

        [ForeignKey("associatedEvent")]
        public int EventCatID { get; set; }

        [ForeignKey("associatedLocation")]
        public int LocationID { get; set; }

        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int OrganiserID { get; set; }

    
        public virtual EventCategory associatedEvent { get; set; }

        public virtual Location associatedLocation { get; set; }
    }
}