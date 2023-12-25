namespace ShopManagement.Application.Contract.Product
{
    public class ProductSearchModel
    {
        public string? Name { get; set; }
        public long CategoryId { get; set; }
        public string? CasNumber { get; set; }
    }
}
