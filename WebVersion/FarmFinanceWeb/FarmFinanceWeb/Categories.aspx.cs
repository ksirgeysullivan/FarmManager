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
    public partial class Categories : System.Web.UI.Page
    {
        private FarmContext context;
        protected void Page_Load(object sender, EventArgs e)
        {
            // Create context to access the database
            context = new FarmContext();

            Add_Categories_To_Placeholder();
        }

        private void Add_Categories_To_Placeholder()
        {
            // Pull the list of categories and display them
            var categories = context.Categories.OrderBy(c => c.ParentCategory);

            // Step through each category
            foreach (Category thisCategory in categories)
            {
                //Create new label for this category
                Literal htmlLiteral = new Literal();
                htmlLiteral.Text = $"{thisCategory.ParentCategory}: {thisCategory.ChildCategory} ( <a href=\"CategoryDetails.aspx?id={thisCategory.ID}\">details</a> ) <br />";

                ExistingCategoriesPlaceholder.Controls.Add(htmlLiteral);

            }

        }

        protected void CategorySaveButton_Click(object sender, EventArgs e)
        {
            // Get user's entries
            string parent = ParentTextBox.Text.Trim();
            string child = ChildTextBox.Text.Trim();

            // Basic validation
            bool valid = true;

            if (parent.Length == 0)
            {
                ParentLabel.Text = "Parent Category is required";
                valid = false;
            }
            else
            {
                ParentLabel.Text = "";
            }

            if (child.Length == 0)
            {
                ChildLabel.Text = "Child Category is required";
                valid = false;
            }
            else
            {
                ChildLabel.Text = "";
            }

            // If invalid, return
            if (!valid)
            {
                return;
            }

            // Add the category
            var category = context.AddCategory(parent, child);
            category.Description = DescriptionTextBox.Text.Trim();

            // Save to the database
            context.SaveChanges();

            // Reload this page by redirecting to self
            Response.Redirect("Categories.aspx", false);
        }
    }
}