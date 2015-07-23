namespace SupermarketChain.Data
{
    public class SupermarketChainMssqlData : SupermarketsChainData
    {
        public SupermarketChainMssqlData()
            : base(new SupermarketsChainDbContext())
        {
        }
    }
}
