using CustomFramework.Domain;
using ShopManagement.Application.Contract.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.CompanyAgg
{
    public interface ICompanyRepository : IRepository<Company, long>
    {
        Task<EditCompany> GetDetails(long id);
        Task<List<CompanyViewModel>> AllCompanies();

        Task<List<CompanySelectBoxDto>> GetCompanySelectBoxDtos();
    }
}
