using DAL;
using Entities;
using System.Linq;
using BLL.Services.Interfaces;
using System.Collections.Generic;
using PL.Models;
using AutoMapper;

namespace BLL.Services.Implementations
{
    public class Search : ISearch
    {
        public IUnitOfWork Database { get; set; }

        public Search(IUnitOfWork unitOfWork)
        {
            Database = unitOfWork;
        }

        public Search()
        {
            Database = new EFUnitOfWork();
        }

        
         List<CategoryDTO> ISearch.SearchCategory(string keyWord)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Category, CategoryDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Category>, List<CategoryDTO>>(Database.Categories.Find(c => c.CategoryName.Contains(keyWord)).ToList());
           
        }

        List<ProductDTO> ISearch.SearchProduct(string keyWord)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Product>, List<ProductDTO>>(Database.Products.Find(p => p.Name.Contains(keyWord) || p.Brand.Contains(keyWord)).ToList());
        }

        List<SupplierDTO> ISearch.SearchSupplier(string keyWord)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Supplier, SupplierDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Supplier>, List<SupplierDTO>>(Database.Suppliers.Find(s => s.FirstName.Contains(keyWord) || s.LastName.Contains(keyWord)).ToList());
        }
    }
}
