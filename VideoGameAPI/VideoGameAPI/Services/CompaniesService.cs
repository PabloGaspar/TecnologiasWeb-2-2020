﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGameAPI.Exceptions;
using VideoGameAPI.Models;

namespace VideoGameAPI.Services
{
    public class CompaniesService : ICompaniesService
    {
        private List<CompanyModel> companies = new List<CompanyModel>
        {
            new CompanyModel(){ Id = 1, Name = "FromSoftware", Country ="japan", FundationDate = new DateTime(1993,12,12), CEO = "Miyazaki"},
            new CompanyModel(){ Id = 2, Name = "Blizzard", Country ="US", FundationDate = new DateTime(1993,12,12), CEO = "None"}
        };

        private HashSet<string> allowedOrderByParameters = new HashSet<string>()
        {
            "id",
            "name",
            "fundation-date",
            "country"
        };

        public CompanyModel CreateCompany(CompanyModel companyModel)
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

            companyModel.Id = newId;

            companies.Add(companyModel);
            return companyModel;
        }

        public DeleteModel DeleteCompany(int companyId)
        {
            var companyToDelete = companies.FirstOrDefault(c => c.Id == companyId);
            if (companyToDelete == null)
            {
                throw new BadRequestOperationException($"The company with id:{companyId} does not exists");
            }
            var result = companies.Remove(companyToDelete);
            return new DeleteModel()
            {
                IsSuccess = true,
                Message = "The company was deleted."
            };
        }

        public IEnumerable<CompanyModel> GetCompanies(string orderBy)
        {
            if (!allowedOrderByParameters.Contains(orderBy.ToLower()))
            {
                throw new BadRequestOperationException($"the field: {orderBy} is not supported, please use one of these {string.Join(",", allowedOrderByParameters)}");
            }

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

        public CompanyModel GetCompany(int companyID)
        {
            return companies.FirstOrDefault(c => c.Id == companyID);
        }
    }
}
