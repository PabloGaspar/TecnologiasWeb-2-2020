using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGameAPI.Models;

namespace VideoGameAPI.Services
{
    public interface IVidegamesService
    {
        VideogameModel CreateVideogame(int CompanyId, VideogameModel videogame);
        VideogameModel GetVidegame(int CompanyId, int videogameId);
        IEnumerable<VideogameModel> GetVidegames(int CompanyId);
        VideogameModel UpdateVideogame(int companyId, int videogameId, VideogameModel videogame);
        bool DeleteVideogame(int CompanyId, int videogameId);
    }
}
