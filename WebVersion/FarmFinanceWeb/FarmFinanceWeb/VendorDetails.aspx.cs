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
    public partial class VendorDetails : System.Web.UI.Page
    {
        private int vendor_id;
        private Vendor vendor;

        private FarmContext context;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Create context to access the database
            context = new FarmContext();

            // Get the id from the URL
            string id_string = Request.QueryString["id"];
            if (Int32.TryParse(id_string, out vendor_id))
            {
                // Get the indicated vendor
                vendor = context.Vendors.SingleOrDefault<Vendor>(v => v.ID == vendor_id);

                // if we got a vendor show it
                if (vendor != null)
                {
                    NameLabel.Text = vendor.Name;
                    TypeLabel.Text = vendor.Type;
                    LocationLabel.Text = vendor.Location;

                    return;
                }
            }

            Response.Redirect("Vendors.aspx");
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            context.Vendors.Remove(vendor);
            context.SaveChanges();

            Response.Redirect("Vendors.aspx");
        }
    }
}