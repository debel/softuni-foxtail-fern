namespace SupermarketChain.Data.Data
{
    using Contexts;

    public class SupermarketChainMssqlData : SupermarketsChainData
    {
        public SupermarketChainMssqlData()
            : base(new SupermarketsChainMssqlContext())
        {
        }
    }
}
