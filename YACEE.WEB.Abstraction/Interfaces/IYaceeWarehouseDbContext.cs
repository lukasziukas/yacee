using YACEE.WEB.Models;

namespace YACEE.WEB.Abstraction.Interfaces
{
    public interface IYaceeWarehouseDbContext
    {
        IQueryable<Buy> Buys { get; }

        IQueryable<Product> Products { get; }

        IQueryable<Stock> Stocks { get; }

        IQueryable<Supplier> Suppliers { get; }
    }
}
