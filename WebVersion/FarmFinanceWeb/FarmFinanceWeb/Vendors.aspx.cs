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
            // Pull the list of vendors and display them
            context = new FarmContext();
            var vendors = context.Vendors;

            // Step through each vendor
            foreach( Vendor thisVendor in vendors )
            {
                // Create new label for this vendor
                Label vendorLabel = new Label();
                vendorLabel.Text = $"{thisVendor.Name} ( {thisVendor.Location} )<br />";

                // Add this label to the placeholder
                ExistingVendorsPlaceHolder.Controls.Add(vendorLabel);
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

            // Create the vendor object
            Vendor newVendor = new Vendor();
            newVendor.Name = name;
            newVendor.Location = location;
            newVendor.Type = type;

            // Add to the context and save to the database
            context.Vendors.Add(newVendor);
            context.SaveChanges();

            // Reload this page, by redirecting to self
            Response.Redirect("Vendors.aspx", false);
        }
    }
}