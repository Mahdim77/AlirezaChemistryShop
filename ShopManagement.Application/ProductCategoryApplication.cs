using CustomFramework.Presentation;
using CustomFramework.Application;
using ShopManagement.Application.Contract.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Application
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        private readonly IProductCategoryRepository _categoryRepository;
        private readonly IFileUploader _uploader;

        public ProductCategoryApplication(IProductCategoryRepository categoryRepository, IFileUploader uploader)
        {
            _categoryRepository = categoryRepository;
            _uploader = uploader;
        }

        public async Task<OperationResult> Create(CreateProductCategory command)
        {
            var operation = new OperationResult();
            if(await _categoryRepository.Exists(x => x.Name == command.Name))
            {
                return operation.Failed(ApplicationMessages.DupplicatedMessage);
            }

            var slug = command.Slug.Slugify();
            var ImagePath = _uploader.Upload(command.Image, command.Slug,"ProductsImage");
            var Category = new ProductCategory(command.Name,ImagePath,command.ImageAlt,command.ImageTitle,command.Description,command.MetaDescription,command.Keywords,slug);
            await _categoryRepository.Create(Category);
            await _categoryRepository.SaveChange();
            return operation.Succedded();

        }

        public async Task<OperationResult> Edit(EditProductCategory command)
        {
            var Category = await _categoryRepository.Get(command.Id);
            var operation = new OperationResult();
            if(Category == null)
            {
                return operation.Failed(ApplicationMessages.NullRecordMessage);
            }

            if (await _categoryRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
            {
                return operation.Failed(ApplicationMessages.DupplicatedMessage);
            }

            var slug = command.Slug.Slugify();
            var ImagePath = _uploader.Upload(command.Image, command.Slug, "ProductsImage");
            Category.Edit(command.Name, ImagePath, command.ImageAlt, command.ImageTitle, command.Description, command.MetaDescription, command.Keywords, slug);
             _categoryRepository.Update(Category);
            await _categoryRepository.SaveChange();
            return operation.Succedded();
        }

        public async Task<EditProductCategory> GetDetails(long id)
        {
            return await _categoryRepository.GetDetails(id);
        }

        public async Task<List<ProductCategoryViewModel>> Search(ProductCategorySearchModel model)
        {
            return await _categoryRepository.Search(model);
        }
    }
}
