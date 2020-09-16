using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoGameAPI.Exceptions;
using VideoGameAPI.Models;
using VideoGameAPI.Services;

namespace VideoGameAPI.Controllers
{
    [Route("api/companies/{companyId:int}/[controller]")]
    public class VideogamesController : ControllerBase
    {
        private IVidegamesService _videogameService;

        public VideogamesController(IVidegamesService videogameService)
        {
            _videogameService = videogameService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<VideogameModel>> GetVideogames(int companyId)
        {
            try
            {
                return  Ok(_videogameService.GetVidegames(companyId));
            }
            catch(NotFoundOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }
        }

        [HttpGet("{videogameId:int}",  Name="GetVideogame")]
        public ActionResult<VideogameModel> GetVideogame(int companyId, int videogameId)
        {
            try
            {
                return Ok(_videogameService.GetVidegame(companyId, videogameId));
            }
            catch (NotFoundOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }
        }

        [HttpPost]
        public ActionResult<VideogameModel> CreateVideogame(int companyId, [FromBody] VideogameModel videogame)
        {
            try
            {
                var videogameCreated = _videogameService.CreateVideogame(companyId, videogame);
                return CreatedAtRoute("GetVideogame",  new { companyId = companyId , videogameId = videogameCreated.Id}, videogameCreated);
            }
            catch (NotFoundOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }
        }

        [HttpPut("{videogameId:int}")]
        public ActionResult<VideogameModel> UpdateVideogame(int companyId, int videogameId, [FromBody] VideogameModel videogame)
        {
            try
            {
                return Ok(_videogameService.UpdateVideogame(companyId, videogameId, videogame));
            }
            catch (NotFoundOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }
        }

        [HttpDelete("{videogameId:int}")]
        public ActionResult<bool> DeleteVideogame(int companyId, int videogameId)
        {
            try
            {
                return Ok(_videogameService.DeleteVideogame(companyId, videogameId));
            }
            catch (NotFoundOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }
        }
    }
}
