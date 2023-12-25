using CustomFramework.Application;
using CustomFramework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contract.Product;
using ShopManagement.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EFCore.Repositories
{
    public class ProductRepository : GenericRepository<Product, long>, IProductRepository
    {
        private readonly ShopContext _shopContext;

        public ProductRepository(ShopContext shopContext):base(shopContext) 
        {
            _shopContext = shopContext;
        }

        public string GetCategorySlug(long categoryId)
        {
            var slug = _shopContext.ProductCategories.FirstOrDefault(x => x.Id == categoryId)?.Slug;
            return slug ?? string.Empty;
        }

        public async Task<EditProduct> GetDetails(long id)
        {
            var selectedProduct = await _shopContext.Products.Select(x => new EditProduct 
            { Id = x.Id,
             CasNumber = x.CasNumber,
             ShortDescription = x.ShortDescription,
             Slug = x.Slug,
             Description = x.Description,
             Formula = x.Formula,
             ImageAlt = x.ImageAlt,
             ImageTitle = x.ImageTitle,
             Keywords = x.Keywords,
             MeasurementUnit = x.MeasurementUnit,
             Name = x.Name,
             MetaDescription = x.MetaDescription,
             ProductCategoryId = x.ProductCategoryId,
             
            }).FirstOrDefaultAsync(x => x.Id == id);

            return selectedProduct ?? new EditProduct();
        }

        public async Task<List<ProductViewModel>> Search(ProductSearchModel model)
        {
            var query = _shopContext.Products.Select(x => new ProductViewModel
            {
                Id = x.Id,
                CasNumber = x.CasNumber,
                Name = x.Name,
                CreationDate = x.CreationDate.ToFarsi(),
                Formula = x.Formula,
                Image = x.Image,
                CategoryId = x.ProductCategoryId,
                MeasurementUnit = x.MeasurementUnit,
                ProductCategory = x.Category.Name,
                IsInStock = x.IsInStock,
                IsDeleted = x.IsDeleted,

            });

            if (!string.IsNullOrWhiteSpace(model.Name))
            {
                query = query.Where(x => x.Name.Contains(model.Name));
            }
            if (!string.IsNullOrWhiteSpace(model.CasNumber))
            {
                query = query.Where(x => x.CasNumber.Contains(model.CasNumber));
            }
            if (model.CategoryId > 0)
            {
                query = query.Where(x => x.CategoryId == model.CategoryId);
            }
           

            var products = await query.OrderByDescending(x => x.Id).ToListAsync();
            return products;
        }
    }
}
