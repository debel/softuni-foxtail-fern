using System;
using System.IO;
using System.Linq;
using StupermarketChainContext;

public class SupermarketChain
{
    static void Main()
    {

        var db = new SupermarketChainContext();
        Console.WriteLine(db.Products.Count());
    }
}
