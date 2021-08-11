<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CategoryDetails.aspx.cs" Inherits="FarmFinanceWeb.CategoryDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <a href="Default.aspx">Home</a>&gt;&gt; <a href="Categories.aspx">Categories</a>&gt;&gt;Category Details<br /><br />
    <h1>Category Details</h1>
    <form id="form1" runat="server">
        <div>
            Parent Category: <asp:Textbox ID="ParentTextbox" runat="server" Text=""></asp:Textbox><br /><br />
            Child Category: <asp:Label ID="ChildLabel" runat="server" Text=""></asp:Label><br /><br />
            Description: <asp:Label ID="DescriptionLabel" runat="server" Text=""></asp:Label><br /><br />

            <asp:Button ID="DeleteButton" runat="server" Text="Delete" OnClick="DeleteButton_Click" />

        </div>
    </form>
</body>
</html>
