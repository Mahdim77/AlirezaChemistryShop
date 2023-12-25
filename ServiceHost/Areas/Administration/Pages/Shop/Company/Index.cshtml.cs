using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contract.Company;
using ShopManagement.Application.Contract.ProductCategory;

namespace ServiceHost.Areas.Administration.Pages.Shop.Company
{
    public class IndexModel : PageModel
    {

        public List<CompanyViewModel> Companies { get; set; }

        private readonly ICompanyApplication _companyApplication;

        public IndexModel(ICompanyApplication companyApplication)
        {
             _companyApplication = companyApplication;
        }

        public async Task OnGet()
        {
            Companies = await _companyApplication.AllCompanies();
        }

        public IActionResult OnGetCreate()
        {
            return  Partial("./Create");
        }

        public async Task<IActionResult> OnPostCreate(CreateCompany command) 
        {
            var result = await _companyApplication.Create(command);
            return new JsonResult(result); 
        }

        public async Task<IActionResult> OnGetEdit(long id)
        {
            var SelectedCompany = await _companyApplication.GetDetails(id);
            return Partial("./Edit",SelectedCompany);
        }

        public async Task<IActionResult> OnPostEdit(EditCompany command)
        {
            var result =  await _companyApplication.Edit(command);
            return new JsonResult(result);
        }
    }
}
