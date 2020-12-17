using DAL;
using System;
using Entities;
using BLL.SortEnums;
using BLL.Services.Interfaces;
using System.Collections.Generic;
using PL.Models;
using System.Reflection;
using AutoMapper;
using System.Linq;

namespace BLL.Services.Implementations
{
    public class ProductService :  IProductService
    {

        IUnitOfWork Database { get; set; }

        public ProductService(IUnitOfWork unitOfWork)
        {
            Database = unitOfWork;
        }
        public void Add(ProductDTO product)
        {
            try
            {
                var categoryService = new CategoryService();
                var supplierService = new SupplierService();

                Product productEntity = new Product
                {
                    Id = product.Id,
                    Name = product.Name,
                    Brand = product.Brand,
                    Cost = product.Cost,
                    CategoryId = product.CategoryId,
                    Category = Database.Categories.Get((int)product.CategoryId),
                    SupplierId = product.SupplierId,
                    Supplier = Database.Suppliers.Get((int)product.SupplierId)
                };
 
                Database.Products.Add(productEntity);
            }
            catch (Exception)
            {
                throw;
            }
        }

       
        public void AddToCategory(int productId, int categoryId)
        {
            try
            {
                var product = Database.Products.Get(productId);

                if (product.CategoryId != null)
                {
                    throw new Exception();
                }

                product.CategoryId = categoryId;
                Database.Products.Update(product, product.Id);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public ProductDTO Get(int id)
        {
            var product = Database.Products.Get(id);
            ProductDTO productDTO = new ProductDTO()
            {
                Id = product.Id,
                Name = product.Name,
                Brand = product.Brand,
                Cost = product.Cost,
                CategoryId = product.CategoryId,
                SupplierId = product.SupplierId,

            };
            return productDTO;
        }

        public List<ProductDTO> GetAllBy(string orderOption)
        {
            PropertyInfo pi = typeof(Product).GetProperty(orderOption);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Product>, List<ProductDTO>>(Database.Products.GetAll().OrderBy(x => pi.GetValue(x, null)).ToList());
        }

        public void Remove(int id)
        {
            Database.Products.Remove(id);
        }

        public void RemoveFromCategory(int productId)
        {
            try
            {
                var product = Database.Products.Get(productId);

                product.Category = null;
                product.CategoryId = null;
                Database.Products.Update(product, product.Id);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public void Update(ProductDTO entity, int id)
        {
            Product product = new Product()
            {
                Id = entity.Id,
                Name = entity.Name,
                Brand = entity.Brand,
                Cost = entity.Cost,
                CategoryId = entity.CategoryId,
                Category = Database.Categories.Get((int)entity.CategoryId),
                SupplierId = entity.SupplierId,
                Supplier = Database.Suppliers.Get((int)entity.SupplierId)
            };
            Database.Products.Update(product, id);
        }

        List<ProductDTO> IProductService.GetAllOrderBy(ProductSort sort)
        {
            return GetAllBy(sort.ToString());
        }
    }
}
