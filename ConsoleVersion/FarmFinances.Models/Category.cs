using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmFinances.Models
{
    public class Category
    {
        public int ID { get; set; }

        [Required]
        public string ParentCategory { get; set; }

        [Required]
        public string ChildCategory { get; set; }

    }
}
