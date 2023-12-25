using CustomFramework.Domain;
using ShopManagement.Application.Contract.Product;

namespace ShopManagement.Domain.ProductAgg
{
    public interface IProductRepository : IRepository<Product,long>
    {
        Task<EditProduct> GetDetails(long id);

        string GetCategorySlug(long categoryId);

        Task<List<ProductViewModel>> Search(ProductSearchModel model);
    }
}
