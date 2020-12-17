using AutoMapper;
using BLL.Services.Implementations;
using BLL.Services.Interfaces;
using BLL.SortEnums;
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
    public class ProductsController : ControllerBase
    {
        IProductService productService;

        public ProductsController(IProductService service)
        {
            productService = service;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public IEnumerable<ProductViewModel> Get()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductDTO, ProductViewModel>()).CreateMapper();
            return mapper.Map<IEnumerable<ProductDTO>, List<ProductViewModel>>(productService.GetAllOrderBy(ProductSort.Name));
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public ProductViewModel Get(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductDTO, ProductViewModel>()).CreateMapper();
            return mapper.Map<ProductDTO, ProductViewModel>(productService.Get(id));
        }

        // POST api/<ProductsController>
        [HttpPost]
        public void Post([FromBody] ProductViewModel value)
        {
            ProductDTO product = new ProductDTO()
            {
                Id = value.Id,
                Name = value.Name,
                Brand = value.Brand,
                Cost = value.Cost,
                SupplierId = value.SupplierId,
                CategoryId = value.CategoryId
            };
            productService.Add(product);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ProductViewModel value)
        {
            ProductDTO product = new ProductDTO()
            {
                Id = value.Id,
                Name = value.Name,
                Brand = value.Brand,
                Cost = value.Cost,
                CategoryId = value.CategoryId,
                SupplierId = value.SupplierId
            };
            productService.Update(product, id);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            productService.Remove(id);
        }
    }
}
