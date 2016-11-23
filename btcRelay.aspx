<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeFile="btcRelay.aspx.cs" Inherits="btcRelay" Debug="true" %>

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
        .auto-style5 {
            width: 672px;
            margin-left: 40px;
            height: 39px;
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
                <td class="auto-style1" style="font-size: x-large; font-weight: bold;">&nbsp;&nbsp; Ethereum and Bitcoin Proof of Burn</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;&nbsp; Enter your Btc address which you used to burn coins</td>
            </tr>
            <tr>
                <td class="auto-style5">
                    &nbsp;&nbsp;
                    <asp:TextBox ID="btcAddrTextBox" runat="server" Width="624px"></asp:TextBox>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style5">
                    &nbsp;&nbsp; Sign the address with the message: &quot;relay&quot;&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">
                    &nbsp;&nbsp;
                    <asp:TextBox ID="sigTextBox" runat="server"></asp:TextBox>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;&nbsp; Enter the Tx ID</td>
            </tr>
            <tr>
                <td class="auto-style4">
                    &nbsp;&nbsp;
                    <asp:TextBox ID="txIdTextBox" runat="server" Width="624px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    &nbsp;&nbsp;
                    <asp:Button ID="submitButton" runat="server" OnClick="submitButton_Click" Text="Submit" Width="171px" />
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    &nbsp;&nbsp; Ethereum Proof Of Burn&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    &nbsp;&nbsp; Please enter your Ethereum Address&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    &nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="ethAddrTextBox" runat="server"></asp:TextBox>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    &nbsp;&nbsp; Please enter the amount you want to send&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    &nbsp;&nbsp; &nbsp;<asp:TextBox ID="ethAmountTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="ethpobButton" runat="server" OnClick="ethpobButton_Click" Text="Submit" />
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
