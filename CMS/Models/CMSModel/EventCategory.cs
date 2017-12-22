using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CMS.Models.CMSModel
{
    [Table("EventCategory")]
    public class EventCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventCatID { get; set; }
        public string Name { get; set; }
        public bool Outdoor { get; set; }
        public bool Family { get; set; }

        public virtual ICollection<Event> events { get; set; }
    }
}