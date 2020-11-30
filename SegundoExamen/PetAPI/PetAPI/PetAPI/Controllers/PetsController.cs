using Microsoft.AspNetCore.Mvc;
using PetAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetAPI.Controllers
{
    [Route("api/[controller]")]
    public class PetsController : Controller
    {
        private static List<Pet> _pets = new List<Pet>()
        {
            new Pet(){ Id = 1, Name = "Bruno", isAdopted = true, Type = "Cat"},
            new Pet(){ Id = 2, Name = "Bet", isAdopted = false, Type = "Cat"},
            new Pet(){ Id = 3, Name = "Dino", isAdopted = false, Type = "Dog"},
            new Pet(){ Id = 4, Name = "Snoopy", isAdopted = true, Type = "Dog"},
            new Pet(){ Id = 5, Name = "Tom", isAdopted = true, Type = "Cat"},
        };
        
        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Pets()
        {
            return Ok(_pets);
        }

        [HttpPost]
        public ActionResult<bool> CreatePet([FromBody] Pet pet)
        {
            var nextId = _pets.OrderByDescending(p => p.Id).FirstOrDefault().Id + 1;
            pet.Id = nextId;
            _pets.Add(pet);

            return Created(string.Empty, pet);
        }
    }
}
