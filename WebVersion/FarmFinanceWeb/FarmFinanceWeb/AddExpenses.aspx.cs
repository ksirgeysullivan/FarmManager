using FarmFinances.Database;
using FarmFinances.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FarmFinanceWeb
{
    public partial class AddExpenses : System.Web.UI.Page
    {
        private int expense_id;
        private Expense expense;

        private FarmContext context;
        protected void Page_Load(object sender, EventArgs e)
        {
            context = new FarmContext();

            // Get the id from the url
            string id_string = Request.QueryString["id"];
            string kat_string = Request.QueryString["kat"];

            Add_Vendors_To_DropDownList();
            Add_Categories_To_DropDownList();

            if (Int32.TryParse(id_string, out expense_id))
            {
                // Get the indicated category
                expense = context.Expenses.SingleOrDefault<Expense>(x => x.ID == expense_id);

                // If we have a category, show it
                if (expense != null)
                {
                    NameTextBox.Text = expense.Name;
                    DateTextBox.Text = expense.PurchaseDate.ToString();
                    AmountTextBox.Text = "$" + expense.PurchaseAmount.ToString();
                    VendorDropDownList.SelectedValue = expense.Vendor.ID.ToString();
                    CategoryDropDownList.SelectedValue = expense.Category.ID.ToString();
                    DescriptionTextBox.Text = expense.Description;

                    return;
                }
            }

        }

        private void Add_Vendors_To_DropDownList()
        {
            var vendors = context.Vendors.OrderBy(v => v.Name);

            ListItem noVendorItem = new ListItem();
            noVendorItem.Text = String.Empty;
            noVendorItem.Value = "-1";
            VendorDropDownList.Items.Add(noVendorItem);

            foreach (Vendor thisVendor in vendors)
            {
                ListItem vendorItem = new ListItem();
                vendorItem.Text = thisVendor.Name + " (" + thisVendor.Location + ")";
                vendorItem.Value = thisVendor.ID.ToString();
                VendorDropDownList.Items.Add(vendorItem);
            }
        }

        private void Add_Categories_To_DropDownList()
        {
            var categories = context.Categories.OrderBy(c => c.ParentCategory);

            ListItem noCategoryItem = new ListItem();
            noCategoryItem.Text = String.Empty;
            noCategoryItem.Value = "-1";
            CategoryDropDownList.Items.Add(noCategoryItem);

            foreach (Category thisCategory in categories)
            {
                ListItem categoryItem = new ListItem();
                categoryItem.Text = thisCategory.ParentCategory + " (" + thisCategory.ChildCategory + ")";
                categoryItem.Value = thisCategory.ID.ToString();
                CategoryDropDownList.Items.Add(categoryItem);
            }
        }

        protected void ExpenseSaveButton_Click(object sender, EventArgs e)
        {
            //Get user's entries
            string name = NameTextBox.Text.Trim();
            string date = DateTextBox.Text.Trim();
            string amount = AmountTextBox.Text.Replace("$","").Trim();
            int vendorId = Int32.Parse(VendorDropDownList.SelectedItem.Value);
            int categoryId = Int32.Parse(CategoryDropDownList.SelectedItem.Value);
            // Category below
            string description = DescriptionTextBox.Text.Trim();

            // Basic validation
            bool valid = true;

            if (name.Length == 0)
            {
                NameLabel.Text = "Name is required";
                valid = false;
            }
            else
            {
                NameLabel.Text = "";
            }

            DateTime date_dateTime = DateTime.Today;

            if (date.Length == 0)
            {
                DateLabel.Text = "Date is required";
                valid = false;
            }
            else if(!DateTime.TryParse(date, out date_dateTime))
            {
                DateLabel.Text = "Date format is not valid";
                valid = false;
            }
            else
            {
                DateLabel.Text = "";
            }

            decimal amount_decimal = 0;
            if (amount.Length == 0)
            {
                AmountLabel.Text = "Purchase amount is required";
                valid = false;
            }
            else if(!Decimal.TryParse(amount, out amount_decimal))
            {
                AmountLabel.Text = "Purchase amount is not valid";
                valid = false;
            }
            else
            {
                AmountLabel.Text = "";
            }

            if (vendorId == -1)
            {
                VendorLabel.Text = "Vendor is required";
                valid = false;
            }

            if (categoryId == -1)
            {
                ParentLabel.Text = "Category is required";
                valid = false;
            }
            // If invalid, return
            if (!valid)
            {
                return;
            }

            // New or edit?
            if (expense == null)
            {
                // Add the expense information
                context.AddExpense(name, date_dateTime, amount_decimal, vendorId, categoryId, description);
            }
            else
            {
                // Update existing
                expense.Name = name;
                expense.PurchaseDate = date_dateTime;
                expense.PurchaseAmount = amount_decimal;
                expense.Vendor.ID = vendorId;
                expense.Category.ID = categoryId;
                expense.Description = description;
                context.Entry(expense).State = System.Data.Entity.EntityState.Modified;
            }

            // Save to the database
            context.SaveChanges();

            // Clear out one of the textboxes to prevent double entry;
            AmountTextBox.Text = String.Empty;

            // Reload this page by redirecting to self
            Response.Redirect("Expenses.aspx", false);

        }
    }
}