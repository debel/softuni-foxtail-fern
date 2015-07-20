﻿namespace SupermarketChain.Data.Contracts
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using Models;

    public interface ISupermarketsChainDbContext : IDisposable
    {
         IDbSet<Measure> Measures { get; set; }

         IDbSet<Product> Products { get; set; }
         
         IDbSet<Vendor> Vendors { get; set; }

         IDbSet<TEntity> Set<TEntity>() where TEntity : class;

         DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

         int SaveChanges();
    }
}
