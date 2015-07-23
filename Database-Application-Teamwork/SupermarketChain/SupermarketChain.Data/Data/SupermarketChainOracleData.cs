namespace SupermarketChain.Data.Data
{
    using Contexts;

    public class SupermarketChainOracleData : SupermarketsChainData
    {
        public SupermarketChainOracleData() 
            : base(new SupermarketChainOracleContext())
        {
        }
    }
}
