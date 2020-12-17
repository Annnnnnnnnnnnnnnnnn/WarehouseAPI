using Entities;
using BLL.SortEnums;
using System.Collections.Generic;
using PL.Models;

namespace BLL.Services.Interfaces
{
    public interface ISupplierService : IService<SupplierDTO>
    {
        List<SupplierDTO> GetAllOrderBy(SupplierSort sort);
    }
}
