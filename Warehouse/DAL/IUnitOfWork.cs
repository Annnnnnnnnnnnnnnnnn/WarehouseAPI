using Entities;
using System;

namespace DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Category> Categories { get; }
        IRepository<Product> Products { get; }
        IRepository<Supplier> Suppliers { get; }
        IRepository<Customer> Customers { get; }
        IRepository<Order> Orders { get; }

        void Save();

    }
}