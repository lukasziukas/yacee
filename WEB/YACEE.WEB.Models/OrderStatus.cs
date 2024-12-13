namespace YACEE.WEB.Models
{
    public enum OrderStatus : int
    {
        Processing = 1,
        Confirmed = 2,
        Shipped = 4,
        Delivered = 8
    }
}
