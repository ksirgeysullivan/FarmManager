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
    public partial class Vendors : System.Web.UI.Page
    {
        private FarmContext context;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Create context to access the database
            context = new FarmContext();

            Add_Vendors_To_PlaceHolder();

        }

        private void Add_Vendors_To_PlaceHolder()
        {
            // Pull the list of vendors and display them
            var vendors = context.Vendors.OrderBy(v => v.Name);

            // Step through each vendor
            foreach (Vendor thisVendor in vendors)
            {
                // Create new label for this vendor
                Label vendorLabel = new Label();
                vendorLabel.Text = $"{thisVendor.Name} ( {thisVendor.Location} ) ";

                // Add link for details
                HyperLink vendorLink = new HyperLink();
                vendorLink.Text = "( details )";
                vendorLink.NavigateUrl = "VendorDetails.aspx?id=" + thisVendor.ID;

                // Add a new line break
                Literal breakLabel = new Literal();
                breakLabel.Text = "<br />";

                // Add this label to the placeholder
                ExistingVendorsPlaceHolder.Controls.Add(vendorLabel);
                ExistingVendorsPlaceHolder.Controls.Add(vendorLink);
                ExistingVendorsPlaceHolder.Controls.Add(breakLabel);

            }
        }

        protected void VendorSaveButton_Click(object sender, EventArgs e)
        {
            // Get user's entries
            string name = NameTextBox.Text.Trim();
            string type = TypeTextBox.Text.Trim();
            string location = LocationTextBox.Text.Trim();

            // Basic validation
            bool valid = true;
            if ( name.Length == 0 )
            {
                NameLabel.Text = "Name is required";
                valid = false;
            }
            else
            {
                NameLabel.Text = "";
            }

            if (type.Length == 0)
            {
                TypeLabel.Text = "Type is required";
                valid = false;
            }
            else
            {
                TypeLabel.Text = "";
            }

            if (location.Length == 0)
            {
                LocationLabel.Text = "Location is required";
                valid = false;
            }
            else
            {
                LocationLabel.Text = "";
            }

            // If invalid, return
            if (!valid)
                return;

            // Add the vendor
            context.AddVendor(name, type, location);

            // Save to the database
            context.SaveChanges();

            // Reload this page, by redirecting to self
            Response.Redirect("Vendors.aspx", false);
        }
    }
}