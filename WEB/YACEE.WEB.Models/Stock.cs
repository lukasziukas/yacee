namespace YACEE.WEB.Models
{
    public class Stock
    {
        public int ProductId { get; set; }

        public int SupplierId { get; set; }

        public int BuyId { get; set; }

        public int Quantity { get; set; }

        public DateTime? Expirity { get; set; }
    }
}
