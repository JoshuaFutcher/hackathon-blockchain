using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

namespace HackathonHardhat.Contracts.Auction.ContractDefinition
{


    public partial class AuctionDeployment : AuctionDeploymentBase
    {
        public AuctionDeployment() : base(BYTECODE) { }
        public AuctionDeployment(string byteCode) : base(byteCode) { }
    }

    public class AuctionDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "608060405234801561001057600080fd5b506105f8806100206000396000f3fe608060405234801561001057600080fd5b50600436106100935760003560e01c80636993e2e6116100665780636993e2e614610175578063790d8596146101885780638603d31a1461019b578063a98e4e7714610218578063bf335e621461022057600080fd5b80630bda14c31461009857806312065fe0146100ad578063290f000a146100d157806369921c2614610152575b600080fd5b6100ab6100a63660046104c0565b610228565b005b336000908152600260205260409020545b6040519081526020015b60405180910390f35b61013f6100df3660046104e2565b60008054600181810183557f290decd9548b62a8d60345a988386fc84ba6bc95484008f6362f93160ef3e5639091018590558482526020819052604082208481556003810180546001600160a01b03191633179055018290559392505050565b60405161ffff90911681526020016100c8565b61016561016036600461050e565b61033b565b60405190151581526020016100c8565b61013f6101833660046104c0565b610370565b6100be61019636600461053e565b6103f3565b6101e46101a936600461053e565b600160208190526000918252604090912080549181015460028201546003830154600490930154919290916001600160a01b03918216911685565b604080519586526020860194909452928401919091526001600160a01b03908116606084015216608082015260a0016100c8565b6000546100be565b610165610414565b60005b600054811015610336576102416103848461056d565b6001600080848154811061025757610257610580565b906000526020600020015481526020019081526020016000206000015411610324576103056001600080848154811061029257610292610580565b9060005260206000200154815260200190815260200160002060040160009054906101000a90046001600160a01b0316600160008085815481106102d8576102d8610580565b600091825260208083209091015483528201929092526040019020600301546001600160a01b0316610460565b6000818154811061031857610318610580565b60009182526020822001555b8061032e81610596565b91505061022b565b505050565b6001600160a01b03811660009081526003602052604081205460ff16151560010361036857506001919050565b506000919050565b6000828152600160208190526040822001543390831115806103a2575060008481526001602052604090206002015483105b156103b15760019150506103ed565b60008481526001602052604081206004810180546001600160a01b0319166001600160a01b039490941693909317909255600290910183905590505b92915050565b6000818154811061040357600080fd5b600091825260209091200154905081565b3360009081526003602052604081205460ff16156104325750600190565b5033600090815260026020908152604080832060019081905560039092528220805460ff1916909117905590565b6001600160a01b038116600090815260026020526040812080546001929061048990849061056d565b90915550506001600160a01b03821660009081526002602052604081208054600192906104b79084906105af565b90915550505050565b600080604083850312156104d357600080fd5b50508035926020909101359150565b6000806000606084860312156104f757600080fd5b505081359360208301359350604090920135919050565b60006020828403121561052057600080fd5b81356001600160a01b038116811461053757600080fd5b9392505050565b60006020828403121561055057600080fd5b5035919050565b634e487b7160e01b600052601160045260246000fd5b818103818111156103ed576103ed610557565b634e487b7160e01b600052603260045260246000fd5b6000600182016105a8576105a8610557565b5060010190565b808201808211156103ed576103ed61055756fea26469706673582212205e7ee3901172f6b8cac0de84f785eabb7d289ef96513c7b0de14e54379dc6bf964736f6c63430008130033";
        public AuctionDeploymentBase() : base(BYTECODE) { }
        public AuctionDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class ActiveAuctionsFunction : ActiveAuctionsFunctionBase { }

    [Function("activeAuctions", "uint256")]
    public class ActiveAuctionsFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class AuctionDetailsFunction : AuctionDetailsFunctionBase { }

    [Function("auctionDetails", typeof(AuctionDetailsOutputDTO))]
    public class AuctionDetailsFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class CheckAccountFunction : CheckAccountFunctionBase { }

    [Function("checkAccount", "bool")]
    public class CheckAccountFunctionBase : FunctionMessage
    {
        [Parameter("address", "account", 1)]
        public virtual string Account { get; set; }
    }

    public partial class CheckCompleteFunction : CheckCompleteFunctionBase { }

    [Function("checkComplete")]
    public class CheckCompleteFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "datetime", 1)]
        public virtual BigInteger Datetime { get; set; }
        [Parameter("uint256", "auction", 2)]
        public virtual BigInteger Auction { get; set; }
    }

    public partial class GetAccountCountFunction : GetAccountCountFunctionBase { }

    [Function("getAccountCount", "uint256")]
    public class GetAccountCountFunctionBase : FunctionMessage
    {

    }

    public partial class GetBalanceFunction : GetBalanceFunctionBase { }

    [Function("getBalance", "uint256")]
    public class GetBalanceFunctionBase : FunctionMessage
    {

    }

    public partial class NewAccountFunction : NewAccountFunctionBase { }

    [Function("newAccount", "bool")]
    public class NewAccountFunctionBase : FunctionMessage
    {

    }

    public partial class NewAuctionFunction : NewAuctionFunctionBase { }

    [Function("newAuction", "uint16")]
    public class NewAuctionFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "auction", 1)]
        public virtual BigInteger Auction { get; set; }
        [Parameter("uint256", "datetime", 2)]
        public virtual BigInteger Datetime { get; set; }
        [Parameter("uint256", "reservePrice", 3)]
        public virtual BigInteger ReservePrice { get; set; }
    }

    public partial class NewBidFunction : NewBidFunctionBase { }

    [Function("newBid", "uint16")]
    public class NewBidFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "auction", 1)]
        public virtual BigInteger Auction { get; set; }
        [Parameter("uint256", "amount", 2)]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class ActiveAuctionsOutputDTO : ActiveAuctionsOutputDTOBase { }

    [FunctionOutput]
    public class ActiveAuctionsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class AuctionDetailsOutputDTO : AuctionDetailsOutputDTOBase { }

    [FunctionOutput]
    public class AuctionDetailsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "datetime", 1)]
        public virtual BigInteger Datetime { get; set; }
        [Parameter("uint256", "reservePrice", 2)]
        public virtual BigInteger ReservePrice { get; set; }
        [Parameter("uint256", "endPrice", 3)]
        public virtual BigInteger EndPrice { get; set; }
        [Parameter("address", "seller", 4)]
        public virtual string Seller { get; set; }
        [Parameter("address", "buyer", 5)]
        public virtual string Buyer { get; set; }
    }

    public partial class CheckAccountOutputDTO : CheckAccountOutputDTOBase { }

    [FunctionOutput]
    public class CheckAccountOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }



    public partial class GetAccountCountOutputDTO : GetAccountCountOutputDTOBase { }

    [FunctionOutput]
    public class GetAccountCountOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class GetBalanceOutputDTO : GetBalanceOutputDTOBase { }

    [FunctionOutput]
    public class GetBalanceOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }






}
