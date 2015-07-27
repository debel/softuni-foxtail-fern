using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketChain.Data.Data
{
    using Contracts;
    using Contexts;

    public class SupermarketChainMySqlData : SupermarketsChainData
    {
        public SupermarketChainMySqlData() : base(new SupermarketChainMySqlContext())
        {
        }
    }
}
