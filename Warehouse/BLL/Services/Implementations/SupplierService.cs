using DAL;
using Entities;
using BLL.SortEnums;
using BLL.Services.Interfaces;
using System.Collections.Generic;
using PL.Models;
using System.Reflection;
using System.Linq;
using AutoMapper;

namespace BLL.Services.Implementations
{
    public class SupplierService :  ISupplierService
    {
        IUnitOfWork Database { get; set; }

        public SupplierService(IUnitOfWork unitOfWork)
        {
            Database = unitOfWork;
        }

        public SupplierService()
        {
        }

        public void Add(SupplierDTO entity)
        {
            Supplier supplier = new Supplier
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName
            
            };

            Database.Suppliers.Add(supplier);
            Database.Save();
        }

        public SupplierDTO Get(int id)
        {
            var supplier =  Database.Suppliers.Get(id);
            return new SupplierDTO { Id = supplier.Id, FirstName = supplier.FirstName, LastName = supplier.LastName };
        }

        public List<SupplierDTO> GetAllBy(string orderOption)
        {
            PropertyInfo pi = typeof(Supplier).GetProperty(orderOption);
            
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Supplier, SupplierDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Supplier>, List<SupplierDTO>>(Database.Suppliers.GetAll().OrderBy(x => pi.GetValue(x, null)).ToList());
        }

        public List<SupplierDTO> GetAllOrderBy(SupplierSort sort)
        {
            return GetAllBy(sort.ToString());
        }

        public void Remove(int id)
        {
            Database.Suppliers.Remove(id);
        }

        public void Update(SupplierDTO entity, int id)
        {
            Supplier supplier = new Supplier()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName
            };
            Database.Suppliers.Update(supplier, id);
        }

    }
}
