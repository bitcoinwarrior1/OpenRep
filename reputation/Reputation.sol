contract Reputation {

  address owner;

  modifier paid() {
    if(msg.value != 0.0001 ether) throw;
    else{ owner.send(msg.value / 100); } //1% fee
     _
  } //prevents spam and pays a small fee

  struct profile {
    uint positive;
    uint negative;
    uint total;
    string username;
    string location;
    string [] messages;
    address [] traders;
    bool [] givenReputation;
    uint burnedCoins;
  }

  mapping (address => profile) users;

  event _positiveReputation(address indexed user, string indexed message);
  event _negativeReputation(address indexed user, string indexed message);
  event _addUser(string indexed username, string indexed location, address indexed user);
  event _newTrade(address indexed vendor, address indexed buyer);
  event _viewedReputation(address indexed user, uint indexed positive, uint indexed negative, uint total);

  function(){ if(msg.value != 0.0001 ether) throw; } //if not paying the fee then throw and refund

  function Reputation(){ owner = msg.sender; }

  function addUser(string username, string location) returns (string) {
    users[msg.sender].positive = 0;
    users[msg.sender].negative = 0;
    users[msg.sender].total = 0;
    users[msg.sender].username = username;
    users[msg.sender].location = location;
    _addUser(username,location,msg.sender);
    return username;
  }

  function trade(address vendor, address recipient) paid {
      if(msg.sender == vendor && vendor != recipient){
          users[vendor].traders.push(recipient);
          users[vendor].givenReputation.push(false);
          _newTrade(vendor,recipient);
      }
  }

  function giveReputation(address vendor, bool isPositive, string message) paid {
    for(uint i = 0; i < users[vendor].traders.length; i++){
      if(users[vendor].traders[i] == msg.sender
      && users[vendor].givenReputation[i] == false){
        if(isPositive){
          users[vendor].positive ++;
          users[vendor].messages.push(message);
           _positiveReputation(vendor,message);
        }
        else{
          users[vendor].negative ++;
          users[vendor].messages.push(message);
          _negativeReputation(vendor,message);
        }
      }
    }
  }

  function viewReputation(address user) returns (uint, uint, uint, [] string){
    _viewedReputation(user,users[user].positive, users[user].negative, users[user].total, users[user].messages);
    return(users[user].positive, users[user].negative, users[user].total, users[user].messages);
  }

}
