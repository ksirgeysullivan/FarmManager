<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VendorDetails.aspx.cs" Inherits="FarmFinanceWeb.VendorDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Vendor Details</title>
    <link rel="stylesheet" href="css/farm.css">
</head>
<body>

    <header>
        <span id="vendordetails_header">Farm finances!</span>
        <br /><br />
    </header>

    <a href="Default.aspx">Home</a> &gt;&gt; <a href="Vendors.aspx">Vendors</a> &gt;&gt;Vendor Details <br /><br />


    <h1> Vendor Details </h1>
    <form id="form1" runat="server">
        <div>            
            Name: <asp:Label ID="NameLabel" runat="server" Text="Label"></asp:Label><br /><br />
            Type: <asp:Label ID="TypeLabel" runat="server" Text="Label"></asp:Label><br /><br />
            Location: <asp:Label ID="LocationLabel" runat="server" Text="Label"></asp:Label><br /><br />

            <asp:Button ID="DeleteButton" runat="server" Text="Delete" OnClick="DeleteButton_Click" />
        </div>


    </form>
</body>
</html>
