using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FarmFinances.Models;

namespace FarmFinances.Database
{
    public class FarmContext : DbContext
    {
        public FarmContext() : base("KatConnection")
        {

        }

        public DbSet<Expense> Expenses { get; set; }

        public DbSet<Vendor> Vendors { get; set; }

        public DbSet<Category> Categories { get; set; }

        public Expense AddExpense(string name, Vendor vendor)
        {
            Expense newExpense = new Expense();
            newExpense.Name = name;
            newExpense.Vendor = vendor;

            Expenses.Add(newExpense);

            return newExpense;
        }

        public Category AddCategory(string parentCategory, string childCategory)
        {
            Category newCategory = new Category();
            newCategory.ParentCategory = parentCategory;
            newCategory.ChildCategory = childCategory;

            Categories.Add(newCategory);

            return newCategory;
        }

        public Vendor AddVendor(string name, string type, string location)
        {
            Vendor newVendor = new Vendor();
            newVendor.Name = name;
            newVendor.Type = type;
            newVendor.Location = location;

            Vendors.Add(newVendor);

            return newVendor;
        }
    }
}
