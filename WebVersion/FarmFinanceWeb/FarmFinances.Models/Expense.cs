using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmFinances.Models
{
    public class Expense
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Vendor Vendor { get; set; }

        [Required]
        public Category Category { get; set; }
        public string Description { get; set; }

        [Required]
        public DateTime PurchaseDate { get; set; }

        [Required]
        public decimal PurchaseAmount { get; set; }


    }
}
