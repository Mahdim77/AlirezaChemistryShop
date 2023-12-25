using CustomFramework.Application;
using CustomFramework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contract.Company;
using ShopManagement.Domain.CompanyAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EFCore.Repositories
{
    public class CompanyRepository : GenericRepository<Company, long>, ICompanyRepository
    {
        private readonly ShopContext _shopContext;

        public CompanyRepository(ShopContext dbContext) : base(dbContext)
        {
            _shopContext = dbContext;
        }

        public async Task<List<CompanyViewModel>> AllCompanies()
        {
            return await _shopContext.Companies.Select(x => new CompanyViewModel 
            { Id = x.Id,
            CreationDate = x.CreationDate.ToFarsi(),
            Detail = x.Detail,
            Name = x.Name,
            Origin = x.Origin}).ToListAsync();
        }

        public async Task<List<CompanySelectBoxDto>> GetCompanySelectBoxDtos()
        {
            return await _shopContext.Companies.Select(x => new CompanySelectBoxDto 
            { Id = x.Id,
             Name = x.Name}).ToListAsync();
        }

        public async Task<EditCompany> GetDetails(long id)
        {
            var EditCompany = await _shopContext.Companies.Select(x => new EditCompany { 
                Id = x.Id,
            Name = x.Name,
            Origin = x.Origin,
            Detail = x.Detail}).FirstOrDefaultAsync(x => x.Id == id);
            return EditCompany ?? new EditCompany();
        }
    }
}
