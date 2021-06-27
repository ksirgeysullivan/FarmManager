using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmFinances.Models
{
    public class Vendor
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Type { get; set; }

        public string Location { get; set; }
    }
}
