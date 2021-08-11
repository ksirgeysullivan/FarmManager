<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Expenses.aspx.cs" Inherits="FarmFinanceWeb.Expenses" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Expenses</title>
    <link rel="stylesheet" href="css/farm.css">
</head>
<body>
    <header>
        Expenses Expenses Expenses
        <br /><br />
    </header>

    <a href="Default.aspx">Home</a> &gt;&gt; Expenses <br /><br />

    <h1>Expenses</h1>

    <form id="form1" runat="server">
        <asp:Button ID="AddExpenseButton" runat="server" Text="Add an expense" OnClick="AddExpenseButton_Click" />
        <asp:Table ID="ExpenseTable" runat="server">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>ID</asp:TableHeaderCell>
                <asp:TableHeaderCell>Purchase Date</asp:TableHeaderCell>
                <asp:TableHeaderCell>Purchase Amount</asp:TableHeaderCell>
                <asp:TableHeaderCell>Name</asp:TableHeaderCell>
                <asp:TableHeaderCell>Vendor</asp:TableHeaderCell>
                <asp:TableHeaderCell>Category</asp:TableHeaderCell>
                <asp:TableHeaderCell>Description</asp:TableHeaderCell>
                
            </asp:TableHeaderRow>
        </asp:Table>

    </form>
</body>
</html>
