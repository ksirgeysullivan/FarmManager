using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FarmFinances.Models;
using FarmFinances.Database;

namespace FarmFinances
{
    class FarmFinances_Manager
    {
        //private AllExpenses allExpenses;
        private FarmContext allExpenses;

        public FarmFinances_Manager()
        {
            //allExpenses = new AllExpenses();
            allExpenses = new FarmContext();
        }
        public void showMenu()
        {
            char menuOption;

            do
            {
                Console.WriteLine("1. Add a Farm Expense.");
                Console.WriteLine("2. View All Expenses.");
                Console.WriteLine("3. Add a Vendor.");
                Console.WriteLine("4. Add a Category.");
                Console.WriteLine("5. Exit App.");

                menuOption = Console.ReadKey().KeyChar;

                switch (menuOption)
                {
                    case '1':
                        AddExpenseUI();
                        break;
                    case '2':
                        ViewAllExpensesUI();
                        break;
                    case '3':
                        AddVendorUI();
                        break;
                    case '4':
                        AddCategoryUI();
                        break;
                }

            } while (menuOption != '5');
        }

        private void AddExpenseUI()
        {
            Category selectedCategory = null;
            Vendor selectedVendor = null;

            Console.Write("\n\nEnter purchase name: ");
            string name = Console.ReadLine();

            int vendorCounter = 1;
            Console.WriteLine();
            Console.WriteLine("Vendors:");

            List<Vendor> vendors = allExpenses.Vendors.ToList<Vendor>();
            foreach (Vendor vendor in vendors)
            {
                Console.WriteLine((vendorCounter++) + " " + vendor.Name + "(" + vendor.Type + ")");
                Console.WriteLine("\t" + vendor.Location);
            }

            Console.Write("\nEnter index for vendor: ");
            string vendorIndex = Console.ReadLine();

            if (Int32.TryParse(vendorIndex, out int vindex))
            {
                if ((vindex < 1) || (vindex > allExpenses.Vendors.Count()))
                {
                    Console.WriteLine("Invalid entry");
                    return;
                }

                selectedVendor = vendors[vindex - 1];
            }
            else
            {
                Console.WriteLine("Non-numeric value entered");
                return;
            }

            int categoryCounter = 1;
            Console.WriteLine();
            Console.WriteLine("Categories:");

            List<Category> categories = allExpenses.Categories.ToList<Category>();
            foreach(Category category in categories)
            {
                Console.WriteLine((categoryCounter++) + " " + category.ChildCategory + "(" + category.ParentCategory + ")");
            }

            Console.Write("\nEnter index for category: ");
            string categoryIndex = Console.ReadLine();
            if ( Int32.TryParse(categoryIndex, out int index ))
            {
                if (( index < 1 ) || ( index > allExpenses.Categories.Count()))
                {
                    Console.WriteLine("Invalid entry");
                    return;
                }

               selectedCategory = categories[index - 1];
            }
            else
            {
                Console.WriteLine("Non-numeric value entered");
                return;
            }

            Console.Write("Enter purchase description: ");
            string description = Console.ReadLine();

            Console.Write("Enter purchase date: ");
            string purchaseDate = Console.ReadLine();

            Console.Write("Enter purchase amount: ");
            string purchaseAmount = Console.ReadLine();

            //Add new expense with bare minimum.
            Expense newExpense = allExpenses.AddExpense(name, selectedVendor);

            //Set additional properties.
            newExpense.Category = selectedCategory;
            newExpense.Description = description;
            newExpense.PurchaseDate = Convert.ToDateTime(purchaseDate);
            newExpense.PurchaseAmount = Convert.ToDecimal(purchaseAmount);

            //Save to database
            allExpenses.SaveChanges();
        }

        private void ViewAllExpensesUI()
        {
            Console.WriteLine();

            foreach(Expense expense in allExpenses.Expenses)
            {
                Console.WriteLine(expense.Name + ", $" + expense.PurchaseAmount + ", " + expense.PurchaseDate);
                Console.WriteLine("\t" + expense.Vendor.Name + " (" + expense.Vendor.Type + ", " + expense.Vendor.Location + ")");
                Console.WriteLine("\t" + expense.Category.ChildCategory + " (" + expense.Category.ParentCategory + ")");
                Console.WriteLine("\t" + expense.Description);
                Console.WriteLine();
            }
        }

        private void AddVendorUI()
        {
            Console.WriteLine("\n\nExisting vendors");
            foreach( Vendor thisVendor in allExpenses.Vendors)
            {
                Console.WriteLine("\t" + thisVendor.Name + " (" + thisVendor.Type + ", " + thisVendor.Location + ")  [ " + thisVendor.ID + " ]");
            }

            Console.Write("\nAdd vendor name: ");
            string name = Console.ReadLine();

            if (name.Trim().Length == 0)
            {
                Console.WriteLine("Vendor name is required!\n\n");
                return;
            }

            Console.Write("Add vendor type: ");
            string type = Console.ReadLine();

            Console.Write("Add vendor location: ");
            string location = Console.ReadLine();

            Vendor newVendor = allExpenses.AddVendor(name, type, location);

            allExpenses.SaveChanges();
        }

        private void AddCategoryUI()
        {
            Console.WriteLine("\n\nExisting categories");
            foreach (Category thisCategory in allExpenses.Categories)
            {
                Console.WriteLine("\t" + thisCategory.ChildCategory + " (" + thisCategory.ParentCategory + ")");
            }

            Console.Write("\nAdd parent category: ");
            string parentCategory = Console.ReadLine();

            if (parentCategory.Trim().Length == 0)
            {
                Console.WriteLine("Parent category is required!\n\n");
                return;
            }

            Console.Write("Add child category: ");
            string childCategory = Console.ReadLine();

            if (childCategory.Trim().Length == 0)
            {
                Console.WriteLine("Child category is required!\n\n");
                return;
            }

            Category newCategory = allExpenses.AddCategory(parentCategory, childCategory);

            allExpenses.SaveChanges();
        }
    }
}
