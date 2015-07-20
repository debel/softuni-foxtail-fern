using System.IO;
using System.Linq;
using StupermarketChainContext;

public class SupermarketChain
{
    static void Main()
    {
        
        var db = new SupermarketChainContext();
        db.Products.Count();
    }
}
