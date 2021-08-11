<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddExpenses.aspx.cs" Inherits="FarmFinanceWeb.AddExpenses" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Expenses</title>
    <link rel="stylesheet" href="css/farm.css">
</head>
<body>
    <header>
        Keep 'em coming!
        <br /><br />
    </header>

    <a href="Expenses.aspx">Expenses</a> &gt;&gt; Add Expenses <br /><br />

    <h1>Add an expense</h1>
    <form id="form1" runat="server">
        <div>
            Name: <asp:TextBox ID="NameTextBox" runat="server"></asp:TextBox>
                  <asp:Label ID="NameLabel" runat="server" Text=""></asp:Label>
                  <br />

            Purchase Date: <asp:TextBox ID="DateTextBox" runat="server"></asp:TextBox>
                  <asp:Label ID="DateLabel" runat="server" Text=""></asp:Label>
                  <br />

            Purchase Amount: <asp:TextBox ID="AmountTextBox" runat="server"></asp:TextBox>
                      <asp:Label ID="AmountLabel" runat="server" Text=""></asp:Label>
                      <br />

            Vendor: <asp:DropDownList ID="VendorDropDownList" runat="server"></asp:DropDownList>
                  <asp:Label ID="VendorLabel" runat="server" Text=""></asp:Label>
                  <br />

            Category: <asp:DropDownList ID="CategoryDropDownList" runat="server"></asp:DropDownList>
                  <asp:Label ID="ParentLabel" runat="server" Text=""></asp:Label>
                  <br />


            Description: <asp:TextBox ID="DescriptionTextBox" runat="server"></asp:TextBox>
                      <asp:Label ID="DescriptionLabel" runat="server" Text=""></asp:Label>
                      <br />

            <asp:Button ID="ExpenseSaveButton" runat="server" Text="Save" style="margin-top: 0px" OnClick="ExpenseSaveButton_Click" />
        </div>
    </form>
</body>
</html>
