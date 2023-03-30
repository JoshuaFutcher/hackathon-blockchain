require("@nomicfoundation/hardhat-toolbox");

const INFURA_API_KEY = "acf3846e083e4e65b141fef939c5595e";

const SEPOLIA_PRIVATE_KEY = "f05e1c2395a9c547d3eaf8bd59839f11f3bb9e8be2bafedf898484b4be18ca3c"

/** @type import('hardhat/config').HardhatUserConfig */
module.exports = {
  solidity: "0.8.18",
  networks: {
    sepolia: {
      url: `https://sepolia.infura.io/v3/${INFURA_API_KEY}`,
      accounts: [SEPOLIA_PRIVATE_KEY]
    }
  }
};
