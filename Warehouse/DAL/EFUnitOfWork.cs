using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace DAL
{
   public class EFUnitOfWork : IUnitOfWork
    {
        private WarehouseContext db;
        private Repository<Product> productRepository;
        private Repository<Category> categoryRepository;
        private Repository<Supplier> supplierRepository;
        private Repository<Customer> customerRepository;
        private Repository<Order> orderRepository;

        public EFUnitOfWork()
        {
            db = new WarehouseContext();
        }

        public IRepository<Category> Categories
        {
            get
            {
                if (categoryRepository == null) categoryRepository = new Repository<Category>(db);
                return categoryRepository;
            }
        }

        public IRepository<Product> Products
        {
            get
            {
                if (productRepository == null) productRepository = new Repository<Product>(db);
                return productRepository;
            }
        }

        public IRepository<Supplier> Suppliers
        {
            get
            {
                if (supplierRepository == null) supplierRepository = new Repository<Supplier>(db);
                return supplierRepository;
            }
        }

        public IRepository<Order> Orders
        {
            get
            {
                if (orderRepository == null) orderRepository = new Repository<Order>(db);
                return orderRepository;
            }
        }

        public IRepository<Customer> Customers
        {
            get
            {
                if (customerRepository == null) customerRepository = new Repository<Customer>(db);
                return customerRepository;
            }
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
