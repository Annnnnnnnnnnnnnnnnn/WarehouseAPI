using DAL;
using Entities;
using System.Linq;
using BLL.Services.Interfaces;
using System.Collections.Generic;
using PL.Models;
using System.Reflection;
using AutoMapper;

namespace BLL.Services.Implementations
{
    public class CategoryService :  ICategoryService
    {
       public IUnitOfWork Database { get; set; }

        public CategoryService(IUnitOfWork unitOfWork)
        {
            Database = unitOfWork;
        }

        public CategoryService()
        {
        }

        public void Add(CategoryDTO entity)
        {

            Category category = new Category()
            {
                Id = entity.Id,
                CategoryName = entity.CategoryName
             };
            Database.Categories.Add(category);
        }

        public CategoryDTO Get(int id)  
        {
            var entity = Database.Categories.Get(id);

            CategoryDTO category = new CategoryDTO()
            {
                Id = entity.Id,
                CategoryName = entity.CategoryName
                
            };
            return category;

        }

        public List<CategoryDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Category, CategoryDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Category>, List<CategoryDTO>>(Database.Categories.GetAll());
        }

        public List<CategoryDTO> GetAllBy(string orderOption)
        {
            PropertyInfo pi = typeof(Product).GetProperty(orderOption);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Category, CategoryDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Category>, List<CategoryDTO>>(Database.Categories.GetAll().OrderBy(x => pi.GetValue(x, null)).ToList());
        }

        public void Remove(int id)
        {
            Database.Categories.Remove(id);
        }

        public void Update(CategoryDTO entity, int id)
        {
            Category category = new Category()
            {
                Id = entity.Id,
                CategoryName = entity.CategoryName,
                Products = (ICollection<Product>)Database.Products.GetAll().Where(x => x.CategoryId == entity.Id)
            };
            Database.Categories.Update(category, id);
        }
    }
}
