using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmFinances
{
    class Program
    {
        static void Main(string[] args)
        {
            FarmFinances_Manager firstManager = new FarmFinances_Manager();
            firstManager.showMenu();
        }
    }
}
