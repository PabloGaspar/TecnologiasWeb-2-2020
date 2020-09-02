using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGameAPI.Models;

namespace VideoGameAPI.Services
{
    public interface ICompaniesService
    {
        IEnumerable<CompanyModel> GetCompanies();
        CompanyModel GetCompany(int  companyID);
    }
}

