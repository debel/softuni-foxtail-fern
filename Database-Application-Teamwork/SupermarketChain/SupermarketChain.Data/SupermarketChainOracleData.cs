namespace SupermarketChain.Data
{
    using Contracts;

    public class SupermarketChainOracleData : SupermarketsChainData
    {
        public SupermarketChainOracleData() 
            : base(new SupermarketChainOracleContext())
        {
        }

       
    }
}
