const { expect } = require("chai");

describe("Auction contract", function () {
  it("Deployment should create an account with 1 token", async function () {
    const [owner, buyer] = await ethers.getSigners();

    const Auction = await ethers.getContractFactory("Auction");

    const hardhatAuction = await Auction.deploy();

    const status = await hardhatAuction.newAccount();

    expect (await hardhatAuction.checkAccount(owner.address)).to.equal(true);

    expect (await hardhatAuction.getBalance()).to.equal(1);

    await hardhatAuction.newAuction(1,1500,500);

    auctions = await hardhatAuction.auctionDetails(1);
    console.log(auctions);

    const result = await hardhatAuction.connect(buyer).newBid(1,2000);

    auctions = await hardhatAuction.auctionDetails(1);
    console.log(auctions);
    
  });
});