using System;

public partial class _Default : System.Web.UI.Page
{
    dynamic web3;
    dynamic Reputation;
    string myAddress = "0xdc85a8429998bd4eef79307e556f70bb70d8caf1"; //testnet
    string myPrivateAddr = "0x9d1475887d66cb8c86dfdefcca95373370c6fa23";
    dynamic btcRelay;

    /*
     *Private testnet network:
     * 
     * PS C:\Users\sangalli\Desktop> 
     * geth --genesis UTSGenesis.json --networkid "1100" --rpc --unlock 0,1 console
     * 
     * account 0 with feedback = 0x9d1475887d66cb8c86dfdefcca95373370c6fa23"
     */


    protected void Page_Load(object sender, EventArgs e)
    {
        init();
        //var contractAddress = "0xc8f097018fbb454cbf4dce974d985467ae146061";
    }

    protected void init()
    {
        web3 = new Nethereum.Web3.Web3("http://localhost:8545/");
        string abi = @"[{'constant':false,'inputs':[{'name':'username','type':'string'},{'name':'location','type':'string'}],'name':'addUser','outputs':[{'name':'','type':'string'}],'type':'function'},{'constant':false,'inputs':[{'name':'vendor','type':'address'},{'name':'recipient','type':'address'}],'name':'trade','outputs':[],'type':'function'},{'constant':false,'inputs':[{'name':'vendor','type':'address'},{'name':'isPositive','type':'bool'},{'name':'message','type':'string'}],'name':'giveReputation','outputs':[],'type':'function'},{'constant':false,'inputs':[{'name':'user','type':'address'}],'name':'viewReputation','outputs':[{'name':'','type':'uint256'},{'name':'','type':'uint256'},{'name':'','type':'uint256'}],'type':'function'},{'inputs':[],'type':'constructor'},{'anonymous':false,'inputs':[{'indexed':true,'name':'user','type':'address'},{'indexed':true,'name':'message','type':'string'}],'name':'_positiveReputation','type':'event'},{'anonymous':false,'inputs':[{'indexed':true,'name':'user','type':'address'},{'indexed':true,'name':'message','type':'string'}],'name':'_negativeReputation','type':'event'},{'anonymous':false,'inputs':[{'indexed':true,'name':'username','type':'string'},{'indexed':true,'name':'location','type':'string'},{'indexed':true,'name':'user','type':'address'}],'name':'_addUser','type':'event'},{'anonymous':false,'inputs':[{'indexed':true,'name':'vendor','type':'address'},{'indexed':true,'name':'buyer','type':'address'}],'name':'_newTrade','type':'event'},{'anonymous':false,'inputs':[{'indexed':true,'name':'user','type':'address'},{'indexed':true,'name':'positive','type':'uint256'},{'indexed':true,'name':'negative','type':'uint256'},{'indexed':false,'name':'total','type':'uint256'}],'name':'_viewedReputation','type':'event'}]";
        string contractAddress = "0xc327030a2eb9b680ffe2ac5ac1f234eecdcec346";
        Reputation = web3.Eth.GetContract(abi, contractAddress);
    }

    protected async void getReputation(string address)
    {
        var getRep = Reputation.GetFunction("viewReputation"); 
        var result = await getRep.CallAsync<int>(address);
        Session["views"] = result;
        Console.WriteLine(result);
        Response.Redirect("views.aspx", false);
    }

    protected async void placeFeedback(string address, bool isPositive, string message)
    {
        var setRep = Reputation.GetFunction("giveReputation");
        var result = await setRep.SendTransactionAsync(myPrivateAddr, address, isPositive, message);
        Session["feedback"] = result;
    }

    protected void submitButton_Click(object sender, EventArgs e)
    {
        if (feedbackOptions.Equals("positive"))
        {
            placeFeedback(placeFeedbackTextBox.Text, true, messageTextBox.Text);
        }
        else
        {
            placeFeedback(placeFeedbackTextBox.Text, false, messageTextBox.Text);
        }

        getReputation(placeFeedbackTextBox.Text);
    }

    protected void viewButton_Click(object sender, EventArgs e)
    {
        getReputation(viewFeedbackTextBox.Text);
    }
}