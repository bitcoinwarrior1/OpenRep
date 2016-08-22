import './Reputation.sol';

contract proofOfBurn is Reputation{

  address proofOfBurnAddr = 0x0000000000000000000000000000000000000000;
  event _coinsBurned(address indexed user, uint indexed amountBurned);
  address btcRelay = "0x41f274c0023f83391de4e0733c609df5a124c3d4"; //mainnet

  function showBurnedCoins(address user) returns (uint){
    return users[user].burnedCoins;
  }

  function burnCoins() returns (uint){
    if(proofOfBurnAddr.send(msg.value)){
      users[msg.sender].burnedCoins += msg.value;
      _coinsBurned(msg.sender, msg.value);
      return users[msg.sender].burnedCoins;
    }
    else throw;
  }

  function bitcoinProofOfBurn(uint amount, address user){
    if(msg.sender == btcRelay){
      users[user].burnedBitcoin = amount;
      return users[user].burnedBitcoin;
    }
    else throw;
  }

}
