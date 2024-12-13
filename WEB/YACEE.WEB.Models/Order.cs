namespace YACEE.WEB.Models
{
    public class Order
    {
        public long OrderId { get; set; }

        public long UserId { get; set; }

        public OrderStatus Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public decimal? FiscalDiscount { get; set; }
    }
}
