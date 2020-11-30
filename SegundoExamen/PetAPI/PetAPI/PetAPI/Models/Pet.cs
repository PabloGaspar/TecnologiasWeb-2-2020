using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetAPI.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool isAdopted { get; set; }
    }
}
