using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contract.ProductCategory;

namespace ServiceHost.Areas.Administration.Pages.Shop.ProductCategory
{
    public class IndexModel : PageModel
    {
        public ProductCategorySearchModel SearchModel { get; set; }

        public List<ProductCategoryViewModel> Categories { get; set; }

        private readonly IProductCategoryApplication _categoryApplication;

        public IndexModel(IProductCategoryApplication categoryApplication)
        {
             _categoryApplication = categoryApplication;
        }

        public async Task OnGet(ProductCategorySearchModel searchModel)
        {
            Categories = await _categoryApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            return  Partial("./Create");
        }

        public async Task<IActionResult> OnPostCreate(CreateProductCategory command) 
        {
            var result = await _categoryApplication.Create(command);
            return new JsonResult(result); 
        }

        public async Task<IActionResult> OnGetEdit(long id)
        {
            var SelectedCategory = await _categoryApplication.GetDetails(id);
            return Partial("./Edit",SelectedCategory);
        }

        public async Task<IActionResult> OnPostEdit(EditProductCategory command)
        {
            var result =  await _categoryApplication.Edit(command);
            return new JsonResult(result);
        }
    }
}
