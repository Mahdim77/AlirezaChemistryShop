using CustomFramework.Domain;
using ShopManagement.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.CompanyAgg
{
    public class Company : EntityBase
    {
        public string Name { get; private set; }
        public string Origin { get; private set; }
        public string Detail { get; private set; }
        public List<ProductCompany> ProductCompanies { get; private set; }

        public Company(string name, string origin, string detail)
        {
            Name = name;
            Origin = origin;
            Detail = detail;
        }
        public void Edit(string name, string origin, string detail)
        {
            Name = name;
            Origin = origin;
            Detail = detail;
        }
    }
}
