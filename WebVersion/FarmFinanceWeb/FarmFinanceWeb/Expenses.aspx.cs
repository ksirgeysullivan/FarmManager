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
    public partial class Expenses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FarmContext farmContext = new FarmContext();
            
            foreach(Expense expense in farmContext.Expenses)
            {
                TableRow expenseRow = new TableRow();

                TableCell idCell = new TableCell();
                idCell.Text = "<a href=\"AddExpenses.aspx?id=" +expense.ID + "\">" + expense.ID + "</a>";
                expenseRow.Cells.Add(idCell);

                TableCell purchaseDateCell = new TableCell();
                purchaseDateCell.Text = expense.PurchaseDate.ToShortDateString();
                expenseRow.Cells.Add(purchaseDateCell);

                TableCell purchaseAmountCell = new TableCell();
                purchaseAmountCell.Text = "$" + expense.PurchaseAmount.ToString();
                expenseRow.Cells.Add(purchaseAmountCell);

                TableCell nameCell = new TableCell();
                nameCell.Text = expense.Name;
                expenseRow.Cells.Add(nameCell);

                TableCell vendorCell = new TableCell();
                if (expense.Vendor != null)
                {
                    vendorCell.Text = expense.Vendor.Name;
                }
                expenseRow.Cells.Add(vendorCell);

                TableCell categoryCell = new TableCell();
                if (expense.Category != null)
                {
                    categoryCell.Text = expense.Category.ParentCategory + " C" + expense.Category.ChildCategory + ")";
                }
                expenseRow.Cells.Add(categoryCell);

                TableCell descriptionCell = new TableCell();
                descriptionCell.Text = expense.Description;
                expenseRow.Cells.Add(descriptionCell);

                ExpenseTable.Rows.Add(expenseRow);

            }

            //<asp:TableHeaderRow>
            //    <asp:TableHeaderCell>ID</asp:TableHeaderCell>
            //    <asp:TableHeaderCell>Name</asp:TableHeaderCell>
            //    <asp:TableHeaderCell>Vendor</asp:TableHeaderCell>
            //    <asp:TableHeaderCell>Category</asp:TableHeaderCell>
            //    <asp:TableHeaderCell>Description</asp:TableHeaderCell>
            //    <asp:TableHeaderCell>Purchase Date</asp:TableHeaderCell>
            //    <asp:TableHeaderCell>Purchase Amount</asp:TableHeaderCell>
            //</asp:TableHeaderRow>
        }

        protected void AddExpenseButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddExpenses.aspx");
        }
    }
}