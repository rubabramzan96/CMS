using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CMS.Models.CMSModel
{
    [Table("Location")]
    public class Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LocationID { get; set; }
        public int LAT { get; set; }
        public int LONG { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Event> events { get; set; }
        public virtual ICollection<Device> devices { get; set; }
    }
}