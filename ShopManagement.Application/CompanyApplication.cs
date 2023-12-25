using CustomFramework.Application;
using ShopManagement.Application.Contract.Company;
using ShopManagement.Domain.CompanyAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application
{
    public class CompanyApplication : ICompanyApplication
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyApplication(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<List<CompanyViewModel>> AllCompanies()
        {
           return await _companyRepository.AllCompanies();
        }

        public async Task<OperationResult> Create(CreateCompany command)
        {
            var operation = new OperationResult();
            if(await _companyRepository.Exists(x => x.Name == command.Name))
            {
                return operation.Failed(ApplicationMessages.DupplicatedMessage);
            }
            var company = new Company(command.Name,command.Origin,command.Detail);
            await _companyRepository.Create(company);
            await _companyRepository.SaveChange();
            return operation.Succedded();
        }

        public async Task<OperationResult> Edit(EditCompany command)
        {
            var selectedCompany =await _companyRepository.Get(command.Id);
            var operation = new OperationResult();
            if(selectedCompany == null)
            {
                return operation.Failed(ApplicationMessages.NullRecordMessage);
            }


            if (await _companyRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
            {
                return operation.Failed(ApplicationMessages.DupplicatedMessage);
            }

            selectedCompany.Edit(command.Name, command.Origin, command.Detail);
            _companyRepository.Update(selectedCompany);
            await _companyRepository.SaveChange();
            return operation.Succedded();
        }

        public async Task<List<CompanySelectBoxDto>> GetCompanySelectBoxDtos()
        {
            return await _companyRepository.GetCompanySelectBoxDtos();
        }

        public async Task<EditCompany> GetDetails(long id)
        {
            return await _companyRepository.GetDetails(id);
        }
    }
}
