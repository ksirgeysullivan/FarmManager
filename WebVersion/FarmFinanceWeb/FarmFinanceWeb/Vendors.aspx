<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Vendors.aspx.cs" Inherits="FarmFinanceWeb.Vendors" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Vendors</title>
    <link rel="stylesheet" href="css/farm.css">
</head>
<body>
    <header>
        Farm finances are awesome!
        <br /><br />
    </header>

    <a href="Default.aspx">Home</a> &gt;&gt; Vendors <br /><br />

    <h1>Vendors</h1>

    <form id="form1" runat="server">
        <div>
            <h2>Existing Vendors</h2>
            <asp:PlaceHolder ID="ExistingVendorsPlaceHolder" runat="server"></asp:PlaceHolder>

            <h2>New Vendor</h2>
            Name: <asp:TextBox ID="NameTextBox" runat="server"></asp:TextBox>
                  <asp:Label ID="NameLabel" runat="server" Text=""></asp:Label>
                  <br />

            Type: <asp:TextBox ID="TypeTextBox" runat="server"></asp:TextBox>
                  <asp:Label ID="TypeLabel" runat="server" Text=""></asp:Label>
                  <br />

            Location: <asp:TextBox ID="LocationTextBox" runat="server"></asp:TextBox>
                      <asp:Label ID="LocationLabel" runat="server" Text=""></asp:Label>
                      <br />

            <asp:Button ID="VendorSaveButton" runat="server" Text="Save" OnClick="VendorSaveButton_Click" style="margin-top: 0px" />

            

        </div>
    </form>
</body>
</html>
