using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmFinances
{
    class FarmFinances_Manager
    {
        private AllExpenses allExpenses;

        public FarmFinances_Manager()
        {
            allExpenses = new AllExpenses();
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

            Console.Write("Enter purchase name: ");
            string name = Console.ReadLine();

            int vendorCounter = 1;
            Console.WriteLine();
            Console.WriteLine("Vendors:");
            foreach(Vendor vendor in allExpenses.Vendors)
            {
                Console.WriteLine((vendorCounter++) + " " + vendor.Name + "(" + vendor.Type + ")");
                Console.WriteLine("\t" + vendor.Location);
            }

            Console.Write("\nEnter index for vendor: ");
            string vendorIndex = Console.ReadLine();

            if (Int32.TryParse(vendorIndex, out int vindex))
            {
                if ((vindex < 1) || (vindex > allExpenses.Vendors.Count))
                {
                    Console.WriteLine("Invalid entry");
                    return;
                }

                selectedVendor = allExpenses.Vendors[vindex - 1];
            }
            else
            {
                Console.WriteLine("Non-numeric value entered");
                return;
            }

            int categoryCounter = 1;
            Console.WriteLine();
            Console.WriteLine("Categories:");
            foreach(Category category in allExpenses.Categories)
            {
                Console.WriteLine((categoryCounter++) + " " + category.ChildCategory + "(" + category.ParentCategory + ")");
            }

            Console.Write("\nEnter index for category: ");
            string categoryIndex = Console.ReadLine();
            if ( Int32.TryParse(categoryIndex, out int index ))
            {
                if (( index < 1 ) || ( index > allExpenses.Categories.Count ))
                {
                    Console.WriteLine("Invalid entry");
                    return;
                }

                selectedCategory = allExpenses.Categories[index - 1];
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

            //Save to database.
        }

        private void ViewAllExpensesUI()
        {
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
            Console.Write("Add vendor name: ");
            string name = Console.ReadLine();

            Console.Write("Add vendor type: ");
            string type = Console.ReadLine();

            Console.Write("Add vendor location: ");
            string location = Console.ReadLine();

            Vendor newVendor = allExpenses.AddVendor(name, type, location);
        }

        private void AddCategoryUI()
        {
            Console.Write("Add parent category: ");
            string parentCategory = Console.ReadLine();

            Console.Write("Add child category: ");
            string childCategory = Console.ReadLine();

            Category newCategory = allExpenses.AddCategory(parentCategory, childCategory);
        }
    }
}
