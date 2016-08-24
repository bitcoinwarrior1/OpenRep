<%@ Page Language="C#" AutoEventWireup="true" CodeFile="views.aspx.cs" Inherits="views" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Views</title>
</head>
<body>

    <link rel="stylesheet" href="css/normalize.css"/>
    <link rel="stylesheet" href="css/skeleton.css"/>
    <link rel="stylesheet" href="css/main.css"/>
    <div>
        <ul>
            <li><a href ="./Default.aspx"> Home </a></li>
            <li><a href ="./btcRelay.aspx"> Bitcoin Proof Of Burn</a></li>
            <li><a href ="./newAccount.aspx"> create account</a></li>
        </ul>
    </div>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="displayResults" runat="server" ForeColor="#FF6600"></asp:Label>
    
    </div>
    </form>
</body>
</html>
