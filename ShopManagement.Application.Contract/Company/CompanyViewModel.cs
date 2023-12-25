using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contract.Company
{
    public class CompanyViewModel
    {
        public long Id { get; set; }

        public string CreationDate { get; set; }
        public string Name { get; set; }
        public string Origin { get; set; }
        public string Detail { get; set; }
    }
}
