using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGameAPI.Models;
using VideoGameAPI.Services;

namespace VideoGameAPI.Controllers
{
    [Route("api/[controller]")]
    public class CompaniesController : Controller
    {

        private ICompaniesService _companyService;
        
        public CompaniesController(ICompaniesService companyService)
        {
            this._companyService = companyService; 
        }

        //api/companies
        [HttpGet]
        public IEnumerable<CompanyModel> GetCompanies() {
            return _companyService.GetCompanies();
        }

        //api/companies/companiId
        [HttpGet("{companyId:int}")]
        public CompanyModel GetCompany(int companyId)
        {
            return _companyService.GetCompany(companyId);
        }
    }
}
