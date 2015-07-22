namespace SupermarketChain.Data
{
    using Contracts;

    public class SupermarketChainOracleData : SupermarketsChainData
    {
        public SupermarketChainOracleData(ISupermarketsChainDbContext supermarketsChainDbContext) 
            : base(supermarketsChainDbContext)
        {
        }
    }
}
