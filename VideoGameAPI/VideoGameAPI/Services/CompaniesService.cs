using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGameAPI.Models;

namespace VideoGameAPI.Services
{
    public class CompaniesService : ICompaniesService
    {
        private CompanyModel[] companies = new CompanyModel[]
            {
                new CompanyModel(){ Id = 1, Name = "FromSoftware", Country ="japan", FundationDate = new DateTime(1993,12,12), CEO = "Miyazaki"},
                new CompanyModel(){ Id = 2, Name = "Blizzard", Country ="US", FundationDate = new DateTime(1993,12,12), CEO = "None"}
            };


        public IEnumerable<CompanyModel> GetCompanies()
        {
            return companies;
        }

        public CompanyModel GetCompany(int companyID)
        {
            return companies.FirstOrDefault(c => c.Id == companyID);
        }
    }
}
