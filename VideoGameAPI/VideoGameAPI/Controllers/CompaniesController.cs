using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGameAPI.Exceptions;
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
        public ActionResult<IEnumerable<CompanyModel>> GetCompanies(string orderBy = "Id") {
            try
            {
                return Ok(_companyService.GetCompanies(orderBy));
            }
            catch (BadRequestOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }
        }

        //api/companies/companiId
        [HttpGet("{companyId:int}")]
        public ActionResult<CompanyModel> GetCompany(int companyId)
        {
            try
            {
                return _companyService.GetCompany(companyId);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }
        }

        [HttpPost]
        public ActionResult<CompanyModel> CreateCompanu([FromBody] CompanyModel companyModel)
        {
            try
            {
                var url = HttpContext.Request.Host;
                var newCompany = _companyService.CreateCompany(companyModel);
                return Created($"{url}/api/companies/{newCompany.Id}", newCompany);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }
        }

        [HttpDelete("{companyId:int}")]
        public ActionResult<DeleteModel> Deletecompany(int companyId)
        {
            try
            {
                return Ok(_companyService.DeleteCompany(companyId));
            }
            catch (BadRequestOperationException ex)
            {
                return BadRequest(new DeleteModel() { 
                    IsSuccess = false,
                    Message = ex.Message
                });;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }
        }
    }
}
