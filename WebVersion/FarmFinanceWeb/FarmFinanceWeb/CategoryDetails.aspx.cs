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
    public partial class CategoryDetails : System.Web.UI.Page
    {
        private int category_id;
        private Category category;

        private FarmContext context;
        protected void Page_Load(object sender, EventArgs e)
        {
            // Create context to access the database
            context = new FarmContext();

            // Get the id from the url
            string id_string = Request.QueryString["id"];
            if (Int32.TryParse(id_string, out category_id))
            {
                // Get the indicated category
                category = context.Categories.SingleOrDefault<Category>(c => c.ID == category_id);

                // If we have a category, show it
                if (category != null)
                {
                    ParentTextbox.Text = category.ParentCategory;
                    ChildLabel.Text = category.ChildCategory;
                    DescriptionLabel.Text = category.Description;

                    return;
                }
            }

            Response.Redirect("Categories.aspx", false);
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            context.Categories.Remove(category);
            context.SaveChanges();

            Response.Redirect("Categories.aspx");
        }
    }
}