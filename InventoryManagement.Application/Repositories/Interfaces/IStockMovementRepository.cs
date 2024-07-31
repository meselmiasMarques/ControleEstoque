using InventoryManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Repositories.Interfaces
{
    internal interface IStockMovementRepository
    {
        Task AddAsync(StockMovement movement);
        Task<IEnumerable<StockMovement>> GetByProductIdAsync(int productId);
    }
}
