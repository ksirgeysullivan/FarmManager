using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmFinances
{
    class Expense
    {
        public string Name { get; set; }
        public Vendor Vendor { get; set; }
        public Category Category { get; set; }
        public string Description { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal PurchaseAmount { get; set; }


    }
}
