using Entities;
using PL.Models;
using System.Collections.Generic;

namespace BLL.Services.Interfaces
{
    public interface ICategoryService : IService<CategoryDTO>
    {
        List<CategoryDTO> GetAll();
    }
}
