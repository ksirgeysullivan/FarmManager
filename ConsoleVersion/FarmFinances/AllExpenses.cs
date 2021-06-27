using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FarmFinances.Models;

namespace FarmFinances
{
    class AllExpenses
    {
        private List<Expense> allExpenses;
        private List<Category> allCategories;
        private List<Vendor> allVendors;
        
        public ReadOnlyCollection<Category> Categories
        {
            get { return new ReadOnlyCollection<Category>(allCategories); }
        }
        
        public ReadOnlyCollection<Vendor> Vendors
        {
            get { return new ReadOnlyCollection<Vendor>(allVendors); }
        }

        public ReadOnlyCollection<Expense> Expenses
        {
            get { return new ReadOnlyCollection<Expense>(allExpenses); }
        }

        public AllExpenses()
        {
            allExpenses = new List<Expense>();
            allCategories = new List<Category>();
            allVendors = new List<Vendor>();
        }

        public Expense AddExpense(string name, Vendor vendor)
        {
            Expense newExpense = new Expense();
            newExpense.Name = name;
            newExpense.Vendor = vendor;

            allExpenses.Add(newExpense);

            return newExpense;
        }

        public Category AddCategory(string parentCategory, string childCategory)
        {
            Category newCategory = new Category();
            newCategory.ParentCategory = parentCategory;
            newCategory.ChildCategory = childCategory;

            allCategories.Add(newCategory);

            return newCategory;
        }

        public Vendor AddVendor(string name, string type, string location)
        {
            Vendor newVendor = new Vendor();
            newVendor.Name = name;
            newVendor.Type = type;
            newVendor.Location = location;

            allVendors.Add(newVendor);

            return newVendor;
        }
    }
}
