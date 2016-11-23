<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeFile="newAccount.aspx.cs" Inherits="reputation_newAccount" Debug="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 31px;
            width: 672px;
        }
        .auto-style3 {
            width: 672px;
        }
        .auto-style4 {
            width: 672px;
            height: 39px;
        }
        .auto-style6 {
            height: 31px;
            width: 672px;
            margin-left: 50px;
        }
    </style>
</head>
<body>

  <link rel="stylesheet" href="css/normalize.css"/>
  <link rel="stylesheet" href="css/skeleton.css"/>
  <link rel="stylesheet" href="css/main.css"/>

    <br />
    <div>
        <ul>
            <li><a href ="./Default.aspx"> Home </a></li>
            <li><a href ="./btcRelay.aspx">Proof Of Burn</a></li>
            <li><a href ="./newAccount.aspx"> create account</a></li>
        </ul>
    </div>

    <br />


    <form id="form1" runat="server">
    <div>
    
        <table class="center">
            <tr>
                <td class="auto-style6" style="font-size: x-large; font-weight: bold;">&nbsp;&nbsp; Create an account<br />
&nbsp;&nbsp;
                    <asp:Label ID="statusLabel" runat="server" ForeColor="#FF3300"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;&nbsp; Enter your username</td>
            </tr>
            <tr>
                <td class="auto-style4">
                    &nbsp;&nbsp;
                    <asp:TextBox ID="usernameTextBox" runat="server" Width="624px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    &nbsp;&nbsp; Enter your location</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    &nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="locationTextBox" runat="server" Height="75px" TextMode="MultiLine" Width="516px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    &nbsp;&nbsp; Enter your ethereum address&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    &nbsp;&nbsp;
                    <asp:TextBox ID="addressTextBox" runat="server" Width="624px"></asp:TextBox>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    &nbsp;&nbsp;
                    <asp:Button ID="createAccountButton" runat="server" OnClick="submitButton_Click" Text="Create account" Width="171px" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
