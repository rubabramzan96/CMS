using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CMS.Models.CMSModel
{
    [Table("Device")]
    public class Device
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DeviceID { get; set; }
        public int LocationID { get; set; }
        public int Build { get; set; }

    }
}