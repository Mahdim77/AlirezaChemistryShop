using CustomFramework.Domain;
using ShopManagement.Application.Contract.ProductCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductCategoryAgg
{
    public interface IProductCategoryRepository : IRepository<ProductCategory, long>
    {
        Task<EditProductCategory> GetDetails(long id);

        Task<List<ProductCategoryViewModel>> Search(ProductCategorySearchModel model);

        Task<List<ProductCategorySelectBoxDto>> GetCategorySelectBox();
    }
}
