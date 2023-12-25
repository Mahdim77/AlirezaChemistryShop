using CustomFramework.Application;

namespace ShopManagement.Application.Contract.Product
{
    public interface IProductApplication
    {
        Task<OperationResult> Create(CreateProduct command);
        
        Task<OperationResult> Edit(EditProduct command);

        Task<EditProduct> GetDetails(long id);

        Task<List<ProductViewModel>> Search(ProductSearchModel model);

        Task<OperationResult> Delete(long id);

        Task<OperationResult> Restore(long id);

        Task<OperationResult> MakeAvailable(long id);

        Task<OperationResult> MakeUnavailable(long id);
    }
}
