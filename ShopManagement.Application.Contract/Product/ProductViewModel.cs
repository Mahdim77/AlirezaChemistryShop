namespace ShopManagement.Application.Contract.Product
{
    public class ProductViewModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public string ProductCategory { get; set; }

        public long CategoryId { get; set; }

        public string CreationDate { get; set; }

        public string CasNumber { get; set; }

        public string Formula { get; set; }

        public string MeasurementUnit { get; set; }

        public bool IsDeleted { get; set; }

        public bool? IsInStock { get; set; }

    }
}
