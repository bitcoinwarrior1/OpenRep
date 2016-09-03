using Nethereum.ABI.FunctionEncoding.Attributes;
using System;

public partial class _Default : System.Web.UI.Page
{
    dynamic web3;
    dynamic Reputation;
    string myAddress = "0xdc85a8429998bd4eef79307e556f70bb70d8caf1"; //testnet

    /*
     *Private testnet network:
     * 
     * PS C:\Users\sangalli\Desktop> 
     * geth --genesis UTSGenesis.json --networkid "1100" --rpc --unlock 0,1 console
     * 
     */

    protected void Page_Load(object sender, EventArgs e)
    {
        web3 = new Nethereum.Web3.Web3("http://localhost:8545/");
        string abi = @"[{'constant':false,'inputs':[{'name':'vendor','type':'address'}],'name':'trade','outputs':[],'type':'function'},{'constant':false,'inputs':[{'name':'username','type':'string'},{'name':'location','type':'string'}],'name':'addUser','outputs':[{'name':'','type':'string'}],'type':'function'},{'constant':false,'inputs':[],'name':'burnCoins','outputs':[{'name':'','type':'uint256'}],'type':'function'},{'constant':false,'inputs':[{'name':'vendor','type':'address'},{'name':'isPositive','type':'bool'},{'name':'message','type':'string'}],'name':'giveReputation','outputs':[],'type':'function'},{'constant':false,'inputs':[{'name':'user','type':'address'}],'name':'showBurnedCoins','outputs':[{'name':'','type':'uint256'}],'type':'function'},{'constant':false,'inputs':[{'name':'burner','type':'address'},{'name':'value','type':'uint256'}],'name':'burnedBitcoin','outputs':[{'name':'','type':'uint256'}],'type':'function'},{'constant':false,'inputs':[{'name':'user','type':'address'}],'name':'viewReputation','outputs':[{'name':'','type':'uint256'},{'name':'','type':'uint256'},{'name':'','type':'uint256'}],'type':'function'},{'anonymous':false,'inputs':[{'indexed':true,'name':'user','type':'address'},{'indexed':true,'name':'amountBurned','type':'uint256'}],'name':'_coinsBurned','type':'event'},{'anonymous':false,'inputs':[{'indexed':true,'name':'user','type':'address'},{'indexed':true,'name':'message','type':'string'}],'name':'_positiveReputation','type':'event'},{'anonymous':false,'inputs':[{'indexed':true,'name':'user','type':'address'},{'indexed':true,'name':'message','type':'string'}],'name':'_negativeReputation','type':'event'},{'anonymous':false,'inputs':[{'indexed':true,'name':'username','type':'string'},{'indexed':true,'name':'location','type':'string'},{'indexed':true,'name':'user','type':'address'}],'name':'_addUser','type':'event'},{'anonymous':false,'inputs':[{'indexed':true,'name':'vendor','type':'address'},{'indexed':true,'name':'buyer','type':'address'}],'name':'_newTrade','type':'event'},{'anonymous':false,'inputs':[{'indexed':true,'name':'user','type':'address'},{'indexed':true,'name':'positive','type':'uint256'},{'indexed':true,'name':'negative','type':'uint256'},{'indexed':false,'name':'total','type':'uint256'}],'name':'_viewedReputation','type':'event'}]";
        string contractAddress = "0x2DF0e16b4122Cc14dABE5D6ecB2ae24bC9d48DC1"; 
        Reputation = web3.Eth.GetContract(abi, contractAddress);
    }

    protected async void getReputation(string address)
    {
        var getRep = Reputation.GetFunction("viewReputation");
        var result = await getRep.CallDeserializingToObjectAsync<reputation>(address);
        Session["views"] = result;
        Response.Redirect("views.aspx", false);
    }

    protected async void enterTrade(string myAddress, string vendor)
    {
        var trade = Reputation.GetFunction("trade");
        var result = await trade.SendTransactionAsync(myAddress, vendor);
        statusLabel.Text = "trade entered, thank you!";
    }

    protected async void placeFeedback(string myAddress, string address, bool isPositive, string message)
    {
        var setRep = Reputation.GetFunction("giveReputation");
        var result = await setRep.SendTransactionAsync(myAddress,address, isPositive, message); 
        Session["feedback"] = result;
    }

    protected void submitButton_Click(object sender, EventArgs e)
    {
        if (feedbackOptions.Equals("positive"))
        {
            placeFeedback(myAddressTextBox.Text.Trim() ,placeFeedbackTextBox.Text.Trim(), true, messageTextBox.Text.Trim());
        }
        else
        {
            placeFeedback(myAddressTextBox.Text.Trim(), placeFeedbackTextBox.Text.Trim(), false, messageTextBox.Text.Trim());
        }

        getReputation(placeFeedbackTextBox.Text.Trim());
    }

    protected void viewButton_Click(object sender, EventArgs e)
    {
        getReputation(viewFeedbackTextBox.Text.Trim());
    }

    protected void tradeButton_Click(object sender, EventArgs e)
    {
        enterTrade(myAddressTextBox.Text.Trim(), vendorTextBox.Text.Trim());
    }

    [FunctionOutput]

    public class reputation
    {
        [Parameter("uint", "positive", 1)]

        public uint positive { get; set; }

        [Parameter("uint", "negative", 2)]

        public uint negative { get; set; }

        [Parameter("uint", "total", 3)]

        public uint total { get; set; }
    }
}