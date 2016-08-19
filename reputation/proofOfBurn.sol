import './Reputation.sol';

contract proofOfBurn is Reputation{

  address proofOfBurnAddr = 0x0000000000000000000000000000000000000000;
  event _coinsBurned(address indexed user, uint indexed amountBurned);

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

}
