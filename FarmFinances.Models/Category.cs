using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmFinances.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string ParentCategory { get; set; }
        public string ChildCategory { get; set; }

    }
}
