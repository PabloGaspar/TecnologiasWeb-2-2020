using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGameAPI.Models;

namespace VideoGameAPI.Services
{
    public interface ICompaniesService
    {
        IEnumerable<CompanyModel> GetCompanies(string orderBy);
        CompanyModel GetCompany(int companyId);
        CompanyModel CreateCompany(CompanyModel companyModel);
        DeleteModel DeleteCompany(int companyId);
        CompanyModel UpdateCompany(int companyId, CompanyModel companyModel);
    }
}

