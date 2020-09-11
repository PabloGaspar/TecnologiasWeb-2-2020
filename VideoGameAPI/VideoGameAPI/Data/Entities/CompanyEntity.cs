using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoGameAPI.Data.Entities
{
    public class CompanyEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public DateTime? FundationDate { get; set; }
        public string CEO { get; set; }
    }
}
