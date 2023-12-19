using CustomFramework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contract.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;
using CustomFramework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EFCore.Repositories
{
    public class ProductCategoryRepository : GenericRepository<ProductCategory, long>, IProductCategoryRepository
    {
        private readonly ShopContext _shopContext;
        public ProductCategoryRepository(ShopContext shopContext) : base(shopContext)
        {
            _shopContext = shopContext;
        }

        public async Task<EditProductCategory> GetDetails(long id)
        {
            var productCategory = await _shopContext.ProductCategories
            .Select(x => new EditProductCategory
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                ImageAlt = x.ImageAlt,
                ImageTitle = x.ImageTitle,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                Slug = x.Slug,
            }).FirstOrDefaultAsync(x => x.Id == id);

            return productCategory ?? new EditProductCategory();
        }

        public async Task<List<ProductCategoryViewModel>> Search(ProductCategorySearchModel model)
        {
            var query = _shopContext.ProductCategories.Select(x => new ProductCategoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
                CreationDate = x.CreationDate.ToFarsi(),
                Image = x.Image,
            }).AsNoTracking();

            if (!string.IsNullOrWhiteSpace(model.Name))
            {
                query = query.Where(x => x.Name.Contains(model.Name));
            }

            var Categories = await query.OrderByDescending(x => x.Id).ToListAsync();

            return Categories;
        }
    }
}
