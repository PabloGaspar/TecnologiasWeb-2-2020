using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGameAPI.Data.Entities;

namespace VideoGameAPI.Data.Repository
{
    public class LibraryRepository : ILibraryRepository
    {
        private List<CompanyEntity> companies = new List<CompanyEntity>
        {
            new CompanyEntity(){ Id = 1, Name = "FromSoftware", Country ="japan", FundationDate = new DateTime(1993,12,12), CEO = "Miyazaki"},
            new CompanyEntity(){ Id = 2, Name = "Blizzard", Country ="US", FundationDate = new DateTime(1993,12,12), CEO = "None"}
        };

        public CompanyEntity CreateCompany(CompanyEntity company)
        {
            int newId;
            if (companies.Count == 0)
            {
                newId = 1;
            }
            else
            {
                newId = companies.OrderByDescending(c => c.Id).FirstOrDefault().Id + 1;
            }

            company.Id = newId;

            companies.Add(company);
            return company;
        }

        public bool DeleteCompany(int companyId)
        {
            var companyToDelete = companies.FirstOrDefault(c => c.Id == companyId);
            companies.Remove(companyToDelete);
            return true;
        }

        public IEnumerable<CompanyEntity> GetCompanies(string orderBy)
        {
            switch (orderBy)
            {
                case "id":
                    return companies.OrderBy(c => c.Id);
                case "name":
                    return companies.OrderBy(c => c.Name);
                case "fundation-date":
                    return companies.OrderBy(c => c.FundationDate);
                case "country":
                    return companies.OrderBy(c => c.Country);
                default:
                    return companies.OrderBy(c => c.Id); ;
            }
        }

        public CompanyEntity GetCompany(int companyId)
        {
            return companies.FirstOrDefault(c => c.Id == companyId);
        }

        public bool UpdateCompany(CompanyEntity companyModel)
        {
            var companyToUpdate = GetCompany(companyModel.Id);
            companyToUpdate.CEO = companyModel.CEO ?? companyToUpdate.CEO;
            companyToUpdate.Country = companyModel.Country ?? companyToUpdate.Country;
            companyToUpdate.FundationDate = companyModel.FundationDate ?? companyToUpdate.FundationDate;
            companyToUpdate.Name = companyModel.Name ?? companyToUpdate.Name;
            return true;
        }
    }
}
