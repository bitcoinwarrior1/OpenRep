using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Test file for OpenRep webform methods
/// </summary>

namespace OpenRep
{
    public class Tests : System.Web.UI.Page
    {
        dynamic web3;
        dynamic Reputation;

        public Boolean testConnectionForEthereum()
        {
            if (etherConn())
            {
                Console.Write("Test passed for ethereum connection not being null");
                return true; //not null and thus passed
            }
            else
            {
                Console.Write("Test failed for ethereum connection as it is null");
                return false;
            }
        }

        protected dynamic etherConn()
        {
            web3 = new Nethereum.Web3.Web3();
            string abi = @"[{'constant':false,'inputs':[{'name':'vendor','type':'address'}],'name':'trade','outputs':[],'payable':false,'type':'function'},{'constant':false,'inputs':[{'name':'username','type':'string'},{'name':'location','type':'string'}],'name':'addUser','outputs':[{'name':'','type':'string'}],'payable':false,'type':'function'},{'constant':false,'inputs':[{'name':'vendor','type':'address'},{'name':'isPositive','type':'bool'},{'name':'message','type':'string'}],'name':'giveReputation','outputs':[],'payable':false,'type':'function'},{'constant':false,'inputs':[{'name':'user','type':'address'}],'name':'viewReputation','outputs':[{'name':'','type':'uint256'},{'name':'','type':'uint256'},{'name':'','type':'uint256'},{'name':'','type':'uint256'},{'name':'','type':'uint256'}],'payable':false,'type':'function'},{'payable':false,'type':'fallback'},{'anonymous':false,'inputs':[{'indexed':true,'name':'user','type':'address'},{'indexed':true,'name':'message','type':'string'}],'name':'_positiveReputation','type':'event'},{'anonymous':false,'inputs':[{'indexed':true,'name':'user','type':'address'},{'indexed':true,'name':'message','type':'string'}],'name':'_negativeReputation','type':'event'},{'anonymous':false,'inputs':[{'indexed':true,'name':'username','type':'string'},{'indexed':true,'name':'location','type':'string'},{'indexed':true,'name':'user','type':'address'}],'name':'_addUser','type':'event'},{'anonymous':false,'inputs':[{'indexed':true,'name':'vendor','type':'address'},{'indexed':true,'name':'buyer','type':'address'}],'name':'_newTrade','type':'event'},{'anonymous':false,'inputs':[{'indexed':true,'name':'user','type':'address'},{'indexed':true,'name':'positive','type':'uint256'},{'indexed':true,'name':'negative','type':'uint256'},{'indexed':false,'name':'total','type':'uint256'},{'indexed':false,'name':'burnedEth','type':'uint256'},{'indexed':false,'name':'burnedCoins','type':'uint256'}],'name':'_viewedReputation','type':'event'}]";
            string contractAddress = "0x706af303364dc89a6b8dba265947442b05e84776"; //livenet 
            Reputation = web3.Eth.GetContract(abi, contractAddress);
            return Reputation;
        }

    }
}
