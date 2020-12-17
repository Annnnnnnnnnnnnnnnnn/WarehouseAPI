using Entities;
using PL.Models;
using System.Collections.Generic;

namespace BLL.Services.Interfaces
{
    public interface ISearch
    {
        List<CategoryDTO> SearchCategory(string keyWord);
        List<ProductDTO> SearchProduct(string keyWord);
        List<SupplierDTO> SearchSupplier(string keyWord);
    }
}