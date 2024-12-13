namespace YACEE.WEB.Models
{
    public class BasketItem
    {
        public Guid BasketItemId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public double? Discount { get; set; }
    }
}
