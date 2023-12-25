using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contract.Company;
using ShopManagement.Application.Contract.Product;
using ShopManagement.Application.Contract.ProductCategory;

namespace ServiceHost.Areas.Administration.Pages.Shop.Product
{
    public class CreateModel : PageModel
    {
        public List<SelectListItem> Companies { get; set; }
        public SelectList Categories { get; set; }

        public CreateProduct Command { get; set; }

        private readonly ICompanyApplication _companyApplication;

        private readonly IProductCategoryApplication _productCategoryApplication;

        private readonly IProductApplication _productApplication;

        public CreateModel(ICompanyApplication companyApplication, IProductCategoryApplication productCategoryApplication, IProductApplication productApplication)
        {
            _companyApplication = companyApplication;
            _productCategoryApplication = productCategoryApplication;
            _productApplication = productApplication;
            Companies = new List<SelectListItem>();
        }

        public async Task OnGet()
        {
            var companies = await _companyApplication.GetCompanySelectBoxDtos();
            foreach (var company in companies )
            {
                var selitem = new SelectListItem(company.Name,company.Id.ToString());
                Companies.Add(selitem);
            }

            Categories = new SelectList(await  _productCategoryApplication.GetCategorySelectBox(), "Id", "Name");
        }

        public async Task<IActionResult> OnPost(CreateProduct command)
        {
            await _productApplication.Create(command);
            return RedirectToPage("./Index");
        }
    }
}
