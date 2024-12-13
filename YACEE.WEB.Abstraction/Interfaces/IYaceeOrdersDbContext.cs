using YACEE.WEB.Models;

namespace YACEE.WEB.Abstraction.Interfaces
{
    public interface IYaceeOrdersDbContext
    {
        IQueryable<BasketItem> BasketItems { get; }

        IQueryable<BuyBasketItem> BuyBasketItems { get; }

        IQueryable<Order> Orders { get; }

        IQueryable<OrderBasket> OrderBaskets { get; }
    }
}
