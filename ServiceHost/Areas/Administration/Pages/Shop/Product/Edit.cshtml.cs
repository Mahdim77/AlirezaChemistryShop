using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application;
using ShopManagement.Application.Contract.Company;
using ShopManagement.Application.Contract.Product;
using ShopManagement.Application.Contract.ProductCategory;

namespace ServiceHost.Areas.Administration.Pages.Shop.Product
{
    public class EditModel : PageModel
    {
        public EditProduct product { get; set; }

        public SelectList Categories { get; set; }

        public List<SelectListItem> Companies { get; set; }

        private readonly IProductApplication _productApplication;

        private readonly IProductCategoryApplication _productCategoryApp;

        private readonly ICompanyApplication _companyApplication;


        public EditModel(IProductApplication productApplication, IProductCategoryApplication productCategoryApp, ICompanyApplication companyApplication)
        {
            _productApplication = productApplication;
            _productCategoryApp = productCategoryApp;
            _companyApplication = companyApplication;
            Companies = new List<SelectListItem>();
        }

        public async Task OnGet(long id)
        {
            product = await _productApplication.GetDetails(id);
            Categories = new SelectList(await _productCategoryApp.GetCategorySelectBox(), "Id", "Name");
            var companies = await _companyApplication.GetCompanySelectBoxDtos();
            foreach (var company in companies)
            {
                var selitem = new SelectListItem(company.Name, company.Id.ToString());
                Companies.Add(selitem);
            }
        }

        public async Task<IActionResult> OnPost(EditProduct Product)
        {
            await _productApplication.Edit(Product);
            return RedirectToPage("./Index");
        }
    }
}
