using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contract.Product;
using ShopManagement.Application.Contract.ProductCategory;

namespace ServiceHost.Areas.Administration.Pages.Shop.Product
{
    public class IndexModel : PageModel
    {
        public ProductSearchModel SearchModel { get; set; }

        public List<ProductViewModel> Products { get; set; }
        
        public SelectList ProductCategories { get; set; }

        private readonly IProductCategoryApplication _categoryApplication;

        private readonly IProductApplication _productApplication;

        public IndexModel(IProductCategoryApplication categoryApplication, IProductApplication productApplication)
        {

            _categoryApplication = categoryApplication;
            _productApplication = productApplication;
        }

        public async Task OnGet(ProductSearchModel searchModel)
        {
            ProductCategories = new SelectList(await _categoryApplication.GetCategorySelectBox(), "Id", "Name");
            Products = await _productApplication.Search(searchModel);
        }

        public async Task<IActionResult> OnGetMakeUnavailable(long id)
        {
            await _productApplication.MakeUnavailable(id);
           return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnGetMakeAvailable(long id)
        {
            await _productApplication.MakeAvailable(id);
            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnGetRemove(long id)
        {
            await _productApplication.Delete(id);
            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnGetRestore(long id)
        {
            await _productApplication.Restore(id);
            return RedirectToPage("./Index");
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
