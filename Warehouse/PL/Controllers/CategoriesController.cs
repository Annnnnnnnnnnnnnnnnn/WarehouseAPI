using AutoMapper;
using BLL.Services.Implementations;
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
    public class CategoriesController : ControllerBase
    {
        ICategoryService categoryService;

        public CategoriesController(ICategoryService service)
        {
            categoryService = service;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public IEnumerable<CategoryViewModel> Get()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CategoryDTO, CategoryViewModel>()).CreateMapper();
            return mapper.Map<IEnumerable<CategoryDTO>, List<CategoryViewModel>>(categoryService.GetAll());
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public CategoryViewModel Get(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CategoryDTO, CategoryViewModel>()).CreateMapper();
            return mapper.Map<CategoryDTO, CategoryViewModel>(categoryService.Get(id));
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public void Post([FromBody] CategoryViewModel value)
        {
            CategoryDTO category = new CategoryDTO()
            {
                Id = value.Id,
                CategoryName = value.CategoryName
            };
            categoryService.Add(category);

        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CategoryViewModel value)
        {
            CategoryDTO category = new CategoryDTO()
            {
                Id = value.Id,
                CategoryName = value.CategoryName
            };
            categoryService.Update(category, id);
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            categoryService.Remove(id);
        }
    }
}
