using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;
using HackathonHardhat.Contracts.Auction.ContractDefinition;

namespace HackathonHardhat.Contracts.Auction
{
    public partial class AuctionService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, AuctionDeployment auctionDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<AuctionDeployment>().SendRequestAndWaitForReceiptAsync(auctionDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, AuctionDeployment auctionDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<AuctionDeployment>().SendRequestAsync(auctionDeployment);
        }

        public static async Task<AuctionService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, AuctionDeployment auctionDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, auctionDeployment, cancellationTokenSource);
            return new AuctionService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public AuctionService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<BigInteger> ActiveAuctionsQueryAsync(ActiveAuctionsFunction activeAuctionsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ActiveAuctionsFunction, BigInteger>(activeAuctionsFunction, blockParameter);
        }

        
        public Task<BigInteger> ActiveAuctionsQueryAsync(BigInteger returnValue1, BlockParameter blockParameter = null)
        {
            var activeAuctionsFunction = new ActiveAuctionsFunction();
                activeAuctionsFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryAsync<ActiveAuctionsFunction, BigInteger>(activeAuctionsFunction, blockParameter);
        }

        public Task<AuctionDetailsOutputDTO> AuctionDetailsQueryAsync(AuctionDetailsFunction auctionDetailsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<AuctionDetailsFunction, AuctionDetailsOutputDTO>(auctionDetailsFunction, blockParameter);
        }

        public Task<AuctionDetailsOutputDTO> AuctionDetailsQueryAsync(BigInteger returnValue1, BlockParameter blockParameter = null)
        {
            var auctionDetailsFunction = new AuctionDetailsFunction();
                auctionDetailsFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryDeserializingToObjectAsync<AuctionDetailsFunction, AuctionDetailsOutputDTO>(auctionDetailsFunction, blockParameter);
        }

        public Task<bool> CheckAccountQueryAsync(CheckAccountFunction checkAccountFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CheckAccountFunction, bool>(checkAccountFunction, blockParameter);
        }

        
        public Task<bool> CheckAccountQueryAsync(string account, BlockParameter blockParameter = null)
        {
            var checkAccountFunction = new CheckAccountFunction();
                checkAccountFunction.Account = account;
            
            return ContractHandler.QueryAsync<CheckAccountFunction, bool>(checkAccountFunction, blockParameter);
        }

        public Task<string> CheckCompleteRequestAsync(CheckCompleteFunction checkCompleteFunction)
        {
             return ContractHandler.SendRequestAsync(checkCompleteFunction);
        }

        public Task<TransactionReceipt> CheckCompleteRequestAndWaitForReceiptAsync(CheckCompleteFunction checkCompleteFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(checkCompleteFunction, cancellationToken);
        }

        public Task<string> CheckCompleteRequestAsync(BigInteger datetime, BigInteger auction)
        {
            var checkCompleteFunction = new CheckCompleteFunction();
                checkCompleteFunction.Datetime = datetime;
                checkCompleteFunction.Auction = auction;
            
             return ContractHandler.SendRequestAsync(checkCompleteFunction);
        }

        public Task<TransactionReceipt> CheckCompleteRequestAndWaitForReceiptAsync(BigInteger datetime, BigInteger auction, CancellationTokenSource cancellationToken = null)
        {
            var checkCompleteFunction = new CheckCompleteFunction();
                checkCompleteFunction.Datetime = datetime;
                checkCompleteFunction.Auction = auction;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(checkCompleteFunction, cancellationToken);
        }

        public Task<BigInteger> GetAccountCountQueryAsync(GetAccountCountFunction getAccountCountFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetAccountCountFunction, BigInteger>(getAccountCountFunction, blockParameter);
        }

        
        public Task<BigInteger> GetAccountCountQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetAccountCountFunction, BigInteger>(null, blockParameter);
        }

        public Task<BigInteger> GetBalanceQueryAsync(GetBalanceFunction getBalanceFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetBalanceFunction, BigInteger>(getBalanceFunction, blockParameter);
        }

        
        public Task<BigInteger> GetBalanceQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetBalanceFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> NewAccountRequestAsync(NewAccountFunction newAccountFunction)
        {
             return ContractHandler.SendRequestAsync(newAccountFunction);
        }

        public Task<string> NewAccountRequestAsync()
        {
             return ContractHandler.SendRequestAsync<NewAccountFunction>();
        }

        public Task<TransactionReceipt> NewAccountRequestAndWaitForReceiptAsync(NewAccountFunction newAccountFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(newAccountFunction, cancellationToken);
        }

        public Task<TransactionReceipt> NewAccountRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<NewAccountFunction>(null, cancellationToken);
        }

        public Task<string> NewAuctionRequestAsync(NewAuctionFunction newAuctionFunction)
        {
             return ContractHandler.SendRequestAsync(newAuctionFunction);
        }

        public Task<TransactionReceipt> NewAuctionRequestAndWaitForReceiptAsync(NewAuctionFunction newAuctionFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(newAuctionFunction, cancellationToken);
        }

        public Task<string> NewAuctionRequestAsync(BigInteger auction, BigInteger datetime, BigInteger reservePrice)
        {
            var newAuctionFunction = new NewAuctionFunction();
                newAuctionFunction.Auction = auction;
                newAuctionFunction.Datetime = datetime;
                newAuctionFunction.ReservePrice = reservePrice;
            
             return ContractHandler.SendRequestAsync(newAuctionFunction);
        }

        public Task<TransactionReceipt> NewAuctionRequestAndWaitForReceiptAsync(BigInteger auction, BigInteger datetime, BigInteger reservePrice, CancellationTokenSource cancellationToken = null)
        {
            var newAuctionFunction = new NewAuctionFunction();
                newAuctionFunction.Auction = auction;
                newAuctionFunction.Datetime = datetime;
                newAuctionFunction.ReservePrice = reservePrice;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(newAuctionFunction, cancellationToken);
        }

        public Task<string> NewBidRequestAsync(NewBidFunction newBidFunction)
        {
             return ContractHandler.SendRequestAsync(newBidFunction);
        }

        public Task<TransactionReceipt> NewBidRequestAndWaitForReceiptAsync(NewBidFunction newBidFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(newBidFunction, cancellationToken);
        }

        public Task<string> NewBidRequestAsync(BigInteger auction, BigInteger amount)
        {
            var newBidFunction = new NewBidFunction();
                newBidFunction.Auction = auction;
                newBidFunction.Amount = amount;
            
             return ContractHandler.SendRequestAsync(newBidFunction);
        }

        public Task<TransactionReceipt> NewBidRequestAndWaitForReceiptAsync(BigInteger auction, BigInteger amount, CancellationTokenSource cancellationToken = null)
        {
            var newBidFunction = new NewBidFunction();
                newBidFunction.Auction = auction;
                newBidFunction.Amount = amount;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(newBidFunction, cancellationToken);
        }
    }
}
