using System;
using NBitcoin;
using QBitNinja.Client;
using Nethereum.Hex.HexTypes;

public partial class btcRelay : System.Web.UI.Page
{
    dynamic btcRelayContract;
    dynamic web3;
    dynamic Reputation;

    protected void Page_Load(object sender, EventArgs e)
    {
        web3 = new Nethereum.Web3.Web3();
        relay();
        string abi = @"[{'constant':false,'inputs':[{'name':'vendor','type':'address'}],'name':'trade','outputs':[],'type':'function'},{'constant':false,'inputs':[{'name':'username','type':'string'},{'name':'location','type':'string'}],'name':'addUser','outputs':[{'name':'','type':'string'}],'type':'function'},{'constant':false,'inputs':[],'name':'burnCoins','outputs':[{'name':'','type':'uint256'}],'type':'function'},{'constant':false,'inputs':[{'name':'vendor','type':'address'},{'name':'isPositive','type':'bool'},{'name':'message','type':'string'}],'name':'giveReputation','outputs':[],'type':'function'},{'constant':false,'inputs':[{'name':'user','type':'address'}],'name':'showBurnedCoins','outputs':[{'name':'','type':'uint256'}],'type':'function'},{'constant':false,'inputs':[{'name':'burner','type':'address'},{'name':'value','type':'uint256'}],'name':'burnedBitcoin','outputs':[{'name':'','type':'uint256'}],'type':'function'},{'constant':false,'inputs':[{'name':'user','type':'address'}],'name':'viewReputation','outputs':[{'name':'','type':'uint256'},{'name':'','type':'uint256'},{'name':'','type':'uint256'}],'type':'function'},{'anonymous':false,'inputs':[{'indexed':true,'name':'user','type':'address'},{'indexed':true,'name':'amountBurned','type':'uint256'}],'name':'_coinsBurned','type':'event'},{'anonymous':false,'inputs':[{'indexed':true,'name':'user','type':'address'},{'indexed':true,'name':'message','type':'string'}],'name':'_positiveReputation','type':'event'},{'anonymous':false,'inputs':[{'indexed':true,'name':'user','type':'address'},{'indexed':true,'name':'message','type':'string'}],'name':'_negativeReputation','type':'event'},{'anonymous':false,'inputs':[{'indexed':true,'name':'username','type':'string'},{'indexed':true,'name':'location','type':'string'},{'indexed':true,'name':'user','type':'address'}],'name':'_addUser','type':'event'},{'anonymous':false,'inputs':[{'indexed':true,'name':'vendor','type':'address'},{'indexed':true,'name':'buyer','type':'address'}],'name':'_newTrade','type':'event'},{'anonymous':false,'inputs':[{'indexed':true,'name':'user','type':'address'},{'indexed':true,'name':'positive','type':'uint256'},{'indexed':true,'name':'negative','type':'uint256'},{'indexed':false,'name':'total','type':'uint256'}],'name':'_viewedReputation','type':'event'}]";
        string contractAddress = "0x565d1c9d207ba610eeaa6295ab6e7f619e69f265";
        Reputation = web3.Eth.GetContract(abi, contractAddress);
    }

    protected void relay()
    {
        var relayAbi = @"[{'constant': false, 'type': 'function', 'name': 'bulkStoreHeader(bytes, int256)', 'outputs': [{'type': 'int256', 'name': 'out'}], 'inputs': [{'type': 'bytes', 'name': 'headersBytes'}, {'type': 'int256', 'name': 'count'}]}, {'constant': false, 'type': 'function', 'name': 'changeFeeRecipient(int256, int256, int256)', 'outputs': [{'type': 'int256', 'name': 'out'}], 'inputs': [{'type': 'int256', 'name': 'blockHash'}, {'type': 'int256', 'name': 'feeWei'}, {'type': 'int256', 'name': 'feeRecipient'}]}, {'constant': false, 'type': 'function', 'name': 'computeMerkle(int256, int256, int256[])', 'outputs': [{'type': 'uint256', 'name': 'out'}], 'inputs': [{'type': 'int256', 'name': 'txHash'}, {'type': 'int256', 'name': 'txIndex'},
        {'type': 'int256[]', 'name': 'sibling'}]}, {'constant': false, 'type': 'function', 'name': 'depthCheck(int256)', 'outputs': [{'type': 'int256', 'name': 'out'}], 'inputs': [{'type': 'int256', 'name': 'n'}]}, {'constant': false, 'type': 'function', 'name': 'feePaid(int256, int256)', 'outputs': [{'type': 'int256', 'name': 'out'}], 'inputs': [{'type': 'int256', 'name': 'txBlockHash'},
        {'type': 'int256', 'name': 'amountWei'}]}, {'constant': false, 'type': 'function', 'name': 'getAverageChainWork()', 'outputs': [{'type': 'int256', 'name': 'out'}], 'inputs': []}, {'constant': false, 'type': 'function', 'name': 'getBlockHeader(int256)', 'outputs': [{'type': 'bytes', 'name': 'out'}], 'inputs': [{'type': 'int256', 'name': 'blockHash'}]}, {'constant': false, 'type': 'function', 'name': 'getBlockchainHead()', 'outputs': [{'type': 'int256', 'name': 'out'}], 'inputs': []}, {'constant': false, 'type': 'function', 'name': 'getChainWork()', 'outputs': [{'type': 'int256', 'name': 'out'}], 'inputs': []}, {'constant': false, 'type': 'function', 'name': 'getChangeRecipientFee()', 'outputs': [{'type': 'int256', 'name': 'out'}
        ], 'inputs': []}, {'constant': false, 'type': 'function', 'name': 'getFeeAmount(int256)', 'outputs': [{'type': 'int256', 'name': 'out'}], 'inputs': [{'type': 'int256', 'name': 'blockHash'}]}, {'constant': false, 'type': 'function', 'name': 'getFeeRecipient(int256)', 'outputs': [{'type': 'int256', 'name': 'out'}], 'inputs': [{'type': 'int256', 'name': 'blockHash'}]}, {'constant': false, 'type': 'function', 'name': 'getLastBlockHeight()', 'outputs': [{'type': 'int256', 'name': 'out'}], 'inputs': []}, {'constant': false, 'type': 'function', 'name': 'helperVerifyHash__(uint256, int256, int256[], int256)', 'outputs': [{'type': 'int256', 'name': 'out'}], 'inputs': [{'type': 'uint256', 'name': 'txHash'}, {'type': 'int256', 'name': 'txIndex'},
        {'type': 'int256[]', 'name': 'sibling'}, {'type': 'int256', 'name': 'txBlockHash'}]}, {'constant': false, 'type': 'function', 'name': 'priv_fastGetBlockHash__(int256)', 'outputs': [{'type': 'int256', 'name': 'out'}],
        'inputs': [{'type': 'int256', 'name': 'blockHeight'}]}, {'constant': false, 'type': 'function', 'name': 'priv_inMainChain__(int256)', 'outputs': [{'type': 'int256', 'name': 'out'}], 'inputs': [{'type': 'int256', 'name': 'txBlockHash'}]}, {'constant': false, 'type': 'function', 'name': 'relayTx(bytes, int256, int256[], int256, int256)', 'outputs': [{'type': 'int256', 'name': 'out'}], 'inputs': [{'type': 'bytes', 'name': 'txBytes'}, {'type': 'int256', 'name': 'txIndex'}, {'type': 'int256[]', 'name': 'sibling'}, {'type': 'int256', 'name': 'txBlockHash'}, {'type': 'int256', 'name': 'contract'}]}, {'constant': false, 'type': 'function', 'name': 'setInitialParent(int256, int256, int256)', 'outputs': [{'type': 'int256', 'name': 'out'}],
        'inputs': [{'type': 'int256', 'name': 'blockHash'}, {'type': 'int256', 'name': 'height'}, {'type': 'int256', 'name': 'chainWork'}]}, {'constant': false, 'type': 'function', 'name': 'storeBlockHeader(bytes)', 'outputs': [{'type': 'int256', 'name': 'out'}], 'inputs': [{'type': 'bytes', 'name': 'blockHeaderBytes'}]}, {'constant': false, 'type': 'function', 'name': 'storeBlockWithFee(bytes, int256)', 'outputs': [{'type': 'int256', 'name': 'out'}], 'inputs': [{'type': 'bytes', 'name': 'blockHeaderBytes'}, {'type': 'int256', 'name': 'feeWei'}]}, {'constant': false, 'type': 'function', 'name': 'storeBlockWithFeeAndRecipient(bytes, int256, int256)', 'outputs': [{'type': 'int256', 'name': 'out'}], 'inputs': [{'type': 'bytes', 'name': 'blockHeaderBytes'},
        {'type': 'int256', 'name': 'feeWei'}, {'type': 'int256', 'name': 'feeRecipient'}]}, {'constant': false, 'type': 'function', 'name': 'verifyTx(bytes, int256, int256[], int256)', 'outputs': [{'type': 'uint256', 'name': 'out'}], 'inputs': [{'type': 'bytes', 'name': 'txBytes'}, {'type': 'int256', 'name': 'txIndex'}, {'type': 'int256[]', 'name': 'sibling'}, {'type': 'int256', 'name': 'txBlockHash'}]}, {'constant': false, 'type': 'function', 'name': 'within6Confirms(int256)', 'outputs': [{'type': 'int256', 'name': 'out'}], 'inputs': [{'type': 'int256', 'name': 'txBlockHash'}]}, {'inputs': [{'indexed': true, 'type': 'int256', 'name': 'recipient'}, {'indexed': false, 'type': 'int256', 'name': 'amount'}], 'type': 'event', 'name': 'EthPayment(int256,int256)'},
        {'inputs': [{'indexed': true, 'type': 'uint256', 'name': 'blockHash'}, {'indexed': true, 'type': 'int256', 'name': 'returnCode'}], 'type': 'event', 'name': 'GetHeader(uint256,int256)'}, {'inputs': [{'indexed': true, 'type': 'uint256', 'name': 'txHash'}, {'indexed': true, 'type': 'int256', 'name': 'returnCode'}], 'type': 'event', 'name': 'RelayTransaction(uint256,int256)'}, {'inputs': [{'indexed': true, 'type': 'uint256', 'name': 'blockHash'}, {'indexed': true, 'type': 'int256', 'name': 'returnCode'}], 'type': 'event', 'name': 'StoreHeader(uint256,int256)'}, {'inputs': [{'indexed': true, 'type': 'uint256', 'name': 'txHash'}, {'indexed': true, 'type': 'int256', 'name': 'returnCode'}], 'type': 'event', 'name': 'VerifyTransaction(uint256,int256)'}]";

        var relayAddr = "0x5770345100a27b15f5b40bec86a701f888e8c601";
        btcRelayContract = web3.Eth.GetContract(relayAbi, relayAddr);
    }

    protected bool verifySig()
    {
        var address = new BitcoinPubKeyAddress(btcAddrTextBox.Text.Trim());
        bool isValidSig = address.VerifyMessage("relay", sigTextBox.Text.Trim());
        return isValidSig;
    }

    protected void relayProofOfBurn(string txBytes, string txIndex, string merkleSibling,
    string txBlockHash, string objParam, decimal value)
    {
        var result = btcRelayContract.verifyTx.call(txBytes, txIndex, merkleSibling, txBlockHash, objParam);
        if(result == true)
        {
            //call reputation contract and add btc proof of burn
        }
    }

    protected void getTxInfo(string address, string txId)
    {
        var client = new QBitNinjaClient(Network.Main);
        var transactionId = uint256.Parse(txId);
        var transactionResponse = client.GetTransaction(transactionId).Result;
    }

    protected void submitButton_Click(object sender, EventArgs e)
    {
        if (verifySig())
        {
            getTxInfo(btcAddrTextBox.Text.Trim(), txIdTextBox.Text.Trim());
        }
        else
        {
            Console.WriteLine("Signature is invalid");
        }
    }

    protected async void ethpobButton_Click(object sender, EventArgs e)
    {

        var gas = new HexBigInteger("60000");
        var value = new HexBigInteger(ethAmountTextBox.Text.Trim());

        var proofOfBurn = Reputation.GetFunction("burnCoins");
        var result = await proofOfBurn.SendTransactionAsync(ethAddrTextBox.Text.Trim(), gas ,value);

    }
}
