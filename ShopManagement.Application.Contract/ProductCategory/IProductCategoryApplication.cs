using CustomFramework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contract.ProductCategory
{
    public interface IProductCategoryApplication
    {
        Task<OperationResult> Create(CreateProductCategory command);

        Task<OperationResult> Edit(EditProductCategory command);

        Task<EditProductCategory> GetDetails(long id);
        
        Task<List<ProductCategoryViewModel>> Search(ProductCategorySearchModel model);

        Task<List<ProductCategorySelectBoxDto>> GetCategorySelectBox();
    }
}
