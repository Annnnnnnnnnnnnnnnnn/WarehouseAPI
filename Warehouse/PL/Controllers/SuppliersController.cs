using AutoMapper;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        ISupplierService supplierService;

        public SuppliersController(ISupplierService service)
        {
            supplierService = service;
        }

        [HttpGet]
        public IEnumerable<SupplierViewModel> Get()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<SupplierDTO, SupplierViewModel>()).CreateMapper();
            return mapper.Map<IEnumerable<SupplierDTO>, List<SupplierViewModel>>(supplierService.GetAllOrderBy(BLL.SortEnums.SupplierSort.LastName));
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public SupplierViewModel Get(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<SupplierDTO, SupplierViewModel>()).CreateMapper();
            return mapper.Map<SupplierDTO, SupplierViewModel>(supplierService.Get(id));
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public void Post([FromBody] SupplierViewModel value)
        {
            SupplierDTO supplier = new SupplierDTO()
            {
                Id = value.Id,
                FirstName = value.FirstName,
                LastName = value.LastName
            };
            supplierService.Add(supplier);

        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] SupplierViewModel value)
        {
            SupplierDTO supplier = new SupplierDTO()
            {
                Id = value.Id,
                FirstName = value.FirstName,
                LastName = value.LastName
            };
            supplierService.Update(supplier, id);
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            supplierService.Remove(id);
        }
    
    }
}
