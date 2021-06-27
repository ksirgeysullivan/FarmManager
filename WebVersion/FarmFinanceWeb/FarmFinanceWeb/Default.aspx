<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FarmFinanceWeb.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <header>
        Farm finances!
        <br /><br />
    </header>

    <a href="Vendors.aspx">Vendors</a><br /><br />


    <form id="form1" runat="server">
        <div>
            Phone:
            <asp:TextBox ID="PhoneTextBox" runat="server"></asp:TextBox>
            <asp:Label ID="ResponseLabel" runat="server" Text=""></asp:Label>
            <br /><br />
            <asp:Button ID="SubmitButton" runat="server" Text="Submit" OnClick="SubmitButton_Click" />
        </div>
    </form>

    <footer>
        <br /><br />
        Copyright Old Bellamy Farm
    </footer>

</body>
</html>
