using Entities;
using BLL.SortEnums;
using System.Collections.Generic;
using PL.Models;

namespace BLL.Services.Interfaces
{
    public interface IProductService : IService<ProductDTO>
    {
        void AddToCategory(int productId, int categoryId);
        void RemoveFromCategory(int productId);
        List<ProductDTO> GetAllOrderBy(ProductSort sort);
    }
}
