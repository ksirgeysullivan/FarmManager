<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="FarmFinanceWeb.Categories" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <header>
        So many categories! <br /><br />
    </header>

    <a href="Default.aspx">Home</a> &gt;&gt; Categories <br /><br />

    <h1>Categories</h1>

    <form id="form1" runat="server">
        <div>
            <h2>Existing Categories</h2>
            <asp:PlaceHolder ID="ExistingCategoriesPlaceholder" runat="server"></asp:PlaceHolder>

            <h2>New Category</h2>
            Parent Category: <asp:TextBox ID="ParentTextBox" runat="server"></asp:TextBox>
                             <asp:Label ID="ParentLabel" runat="server" Text=""></asp:Label>
                             <br /><br />

            Child Category: <asp:TextBox ID="ChildTextBox" runat="server"></asp:TextBox>
                            <asp:Label ID="ChildLabel" runat="server" Text=""></asp:Label>
                            <br /><br />

            Description: <asp:TextBox ID="DescriptionTextBox" runat="server" TextMode="MultiLine" Height="30px"></asp:TextBox>
                         <br /><br />

            <asp:Button ID="CategorySaveButton" runat="server" Text="Save" OnClick="CategorySaveButton_Click" />
        </div>
    </form>
</body>
</html>
