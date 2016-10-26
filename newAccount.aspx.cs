using System;

public partial class reputation_newAccount : System.Web.UI.Page
{
    dynamic web3;
    dynamic Reputation;

    protected void Page_Load(object sender, EventArgs e)
    {
        web3 = new Nethereum.Web3.Web3("http://localhost:8545/");
        string abi = @"[{'constant':false,'inputs':[{'name':'vendor','type':'address'}],'name':'trade','outputs':[],'type':'function'},{'constant':false,'inputs':[{'name':'username','type':'string'},{'name':'location','type':'string'}],'name':'addUser','outputs':[{'name':'','type':'string'}],'type':'function'},{'constant':false,'inputs':[],'name':'burnCoins','outputs':[{'name':'','type':'uint256'}],'type':'function'},{'constant':false,'inputs':[{'name':'vendor','type':'address'},{'name':'isPositive','type':'bool'},{'name':'message','type':'string'}],'name':'giveReputation','outputs':[],'type':'function'},{'constant':false,'inputs':[{'name':'user','type':'address'}],'name':'showBurnedCoins','outputs':[{'name':'','type':'uint256'}],'type':'function'},{'constant':false,'inputs':[{'name':'burner','type':'address'},{'name':'value','type':'uint256'}],'name':'burnedBitcoin','outputs':[{'name':'','type':'uint256'}],'type':'function'},{'constant':false,'inputs':[{'name':'user','type':'address'}],'name':'viewReputation','outputs':[{'name':'','type':'uint256'},{'name':'','type':'uint256'},{'name':'','type':'uint256'}],'type':'function'},{'anonymous':false,'inputs':[{'indexed':true,'name':'user','type':'address'},{'indexed':true,'name':'amountBurned','type':'uint256'}],'name':'_coinsBurned','type':'event'},{'anonymous':false,'inputs':[{'indexed':true,'name':'user','type':'address'},{'indexed':true,'name':'message','type':'string'}],'name':'_positiveReputation','type':'event'},{'anonymous':false,'inputs':[{'indexed':true,'name':'user','type':'address'},{'indexed':true,'name':'message','type':'string'}],'name':'_negativeReputation','type':'event'},{'anonymous':false,'inputs':[{'indexed':true,'name':'username','type':'string'},{'indexed':true,'name':'location','type':'string'},{'indexed':true,'name':'user','type':'address'}],'name':'_addUser','type':'event'},{'anonymous':false,'inputs':[{'indexed':true,'name':'vendor','type':'address'},{'indexed':true,'name':'buyer','type':'address'}],'name':'_newTrade','type':'event'},{'anonymous':false,'inputs':[{'indexed':true,'name':'user','type':'address'},{'indexed':true,'name':'positive','type':'uint256'},{'indexed':true,'name':'negative','type':'uint256'},{'indexed':false,'name':'total','type':'uint256'}],'name':'_viewedReputation','type':'event'}]";
        string contractAddress = "0x565d1c9d207ba610eeaa6295ab6e7f619e69f265"; //livenet 
        Reputation = web3.Eth.GetContract(abi, contractAddress);
    }

    protected async void createAccount(string myAddress, string newUser, string location)
    {
        var createUser = Reputation.GetFunction("addUser");
        var result = await createUser.SendTransactionAsync(myAddress, newUser, location);
        statusLabel.Text = "Account created! " + result.toString();
    }

    protected void submitButton_Click(object sender, EventArgs e)
    {
        createAccount(addressTextBox.Text.Trim(), usernameTextBox.Text.Trim(), locationTextBox.Text.Trim());
    }
}
