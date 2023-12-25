using CustomFramework.Application;
using CustomFramework.Presentation;
using ShopManagement.Application.Contract.Product;
using ShopManagement.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository _productRepository;
        private readonly IFileUploader _uploader;

        public ProductApplication(IProductRepository productRepository, IFileUploader uploader)
        {
            _productRepository = productRepository;
            _uploader = uploader;
        }

        public async Task<OperationResult> Create(CreateProduct command)
        {
            var operation = new OperationResult();
            if(await _productRepository.Exists(x => x.Name == command.Name))
            {
                return operation.Failed(ApplicationMessages.DupplicatedMessage);
            }

            var Companies = new List<ProductCompany>();

            var productCompanies = command.ProductCompanies.Select(companyId => new ProductCompany(productId: 0, companyId: companyId)).ToList();

            var slug = command.Slug.Slugify();
            var categoryslug = _productRepository.GetCategorySlug(command.ProductCategoryId);
            var folder = $"{categoryslug}/{command.Slug}";

            var ImagePath = _uploader.Upload(command.Image, folder, "ProductsImage");
            var product = new Product(command.Name, ImagePath, command.ImageAlt, command.ImageTitle, command.ShortDescription,
                command.Description, command.Keywords, slug, command.MetaDescription, command.CasNumber,
                command.Formula,command.ProductCategoryId, command.MeasurementUnit);

            product.AssignCompanies(productCompanies);
            await _productRepository.Create(product);
            await _productRepository.SaveChange();
            return operation.Succedded();
        }

        public async Task<OperationResult> Delete(long id)
        {
            var operation = new OperationResult();
            var selectedProduct = await _productRepository.Get(id);
            if (selectedProduct == null)
            {
                return operation.Failed(ApplicationMessages.NullRecordMessage);
            }
            selectedProduct.Delete();
            await _productRepository.SaveChange();
            return operation.Succedded();
        }

        public async Task<OperationResult> Edit(EditProduct command)
        {
            var operation = new OperationResult();
            var selectedProduct = await _productRepository.Get(command.Id);
            if (selectedProduct == null)
            {
                return operation.Failed(ApplicationMessages.NullRecordMessage);
            }
            if (await _productRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
            {
                return operation.Failed(ApplicationMessages.DupplicatedMessage);
            }
            var slug = command.Slug.Slugify();
            
            var categoryslug = _productRepository.GetCategorySlug(command.ProductCategoryId);
            var folder = $"{categoryslug}/{command.Slug}";

            var ImagePath = _uploader.Upload(command.Image, folder, "ProductsImage");
            selectedProduct.Edit(command.Name, ImagePath, command.ImageAlt, command.ImageTitle, command.ShortDescription,
                command.Description, command.Keywords, slug, command.MetaDescription, command.CasNumber,
                command.Formula, command.ProductCategoryId, command.MeasurementUnit);
            await _productRepository.SaveChange();
            return operation.Succedded();
        }

        public Task<EditProduct> GetDetails(long id)
        {
            return _productRepository.GetDetails(id);
        }

        public async Task<OperationResult> MakeAvailable(long id)
        {
            var operation = new OperationResult();
            var selectedProduct = await _productRepository.Get(id);
            if (selectedProduct == null)
            {
                return operation.Failed(ApplicationMessages.NullRecordMessage);
            }
            selectedProduct.Available();
            await _productRepository.SaveChange();
            return operation.Succedded();
        }

        public async Task<OperationResult> MakeUnavailable(long id)
        {
            var operation = new OperationResult();
            var selectedProduct = await _productRepository.Get(id);
            if (selectedProduct == null)
            {
                return operation.Failed(ApplicationMessages.NullRecordMessage);
            }
            selectedProduct.NotAvailable();
            await _productRepository.SaveChange();
            return operation.Succedded();
        }

        public async Task<OperationResult> Restore(long id)
        {
            var operation = new OperationResult();
            var selectedProduct = await _productRepository.Get(id);
            if (selectedProduct == null)
            {
                return operation.Failed(ApplicationMessages.NullRecordMessage);
            }
            selectedProduct.Restore();
            await _productRepository.SaveChange();
            return operation.Succedded();
        }

        public Task<List<ProductViewModel>> Search(ProductSearchModel model)
        {
           return _productRepository.Search(model);
        }
    }
}
