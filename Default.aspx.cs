using Nethereum.ABI.FunctionEncoding.Attributes;
using System;

public partial class _Default : System.Web.UI.Page
{
    dynamic web3;
    dynamic Reputation;
    //string myAddress = "0x8344a845b76c02797fbf3185cc852957d148b8c3"; //livenet

    protected void Page_Load(object sender, EventArgs e)
    {
        web3 = new Nethereum.Web3.Web3();
        string abi = @"[{'constant':false,'inputs':[{'name':'vendor','type':'address'}],'name':'trade','outputs':[],'payable':false,'type':'function'},{'constant':false,'inputs':[{'name':'username','type':'string'},{'name':'location','type':'string'}],'name':'addUser','outputs':[{'name':'','type':'string'}],'payable':false,'type':'function'},{'constant':false,'inputs':[{'name':'vendor','type':'address'},{'name':'isPositive','type':'bool'},{'name':'message','type':'string'}],'name':'giveReputation','outputs':[],'payable':false,'type':'function'},{'constant':false,'inputs':[{'name':'user','type':'address'}],'name':'viewReputation','outputs':[{'name':'','type':'uint256'},{'name':'','type':'uint256'},{'name':'','type':'uint256'},{'name':'','type':'uint256'},{'name':'','type':'uint256'}],'payable':false,'type':'function'},{'payable':false,'type':'fallback'},{'anonymous':false,'inputs':[{'indexed':true,'name':'user','type':'address'},{'indexed':true,'name':'message','type':'string'}],'name':'_positiveReputation','type':'event'},{'anonymous':false,'inputs':[{'indexed':true,'name':'user','type':'address'},{'indexed':true,'name':'message','type':'string'}],'name':'_negativeReputation','type':'event'},{'anonymous':false,'inputs':[{'indexed':true,'name':'username','type':'string'},{'indexed':true,'name':'location','type':'string'},{'indexed':true,'name':'user','type':'address'}],'name':'_addUser','type':'event'},{'anonymous':false,'inputs':[{'indexed':true,'name':'vendor','type':'address'},{'indexed':true,'name':'buyer','type':'address'}],'name':'_newTrade','type':'event'},{'anonymous':false,'inputs':[{'indexed':true,'name':'user','type':'address'},{'indexed':true,'name':'positive','type':'uint256'},{'indexed':true,'name':'negative','type':'uint256'},{'indexed':false,'name':'total','type':'uint256'},{'indexed':false,'name':'burnedEth','type':'uint256'},{'indexed':false,'name':'burnedCoins','type':'uint256'}],'name':'_viewedReputation','type':'event'}]";
        string contractAddress = "0x706af303364dc89a6b8dba265947442b05e84776";
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

        [Parameter("uint", "burnedCoins", 4)]
        public uint burnedCoins { get; set; }

        [Parameter("uint", "burnedBitcoin", 5)]
        public uint burnedBitcoin { get; set; }
    }
}
