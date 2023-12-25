using CustomFramework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contract.Company
{
    public interface ICompanyApplication
    {
        Task<OperationResult> Create(CreateCompany command);
        Task<OperationResult> Edit(EditCompany command);
        Task<EditCompany> GetDetails(long id);
        Task<List<CompanyViewModel>> AllCompanies();

        Task<List<CompanySelectBoxDto>> GetCompanySelectBoxDtos();
    }
}
