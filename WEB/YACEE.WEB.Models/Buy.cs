namespace YACEE.WEB.Models
{
    public class Buy
    {
        public int BuyId { get; set; }

        public int ProviderId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public double Vat { get; set; }
    }
}
