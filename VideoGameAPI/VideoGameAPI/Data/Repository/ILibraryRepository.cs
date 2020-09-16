using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGameAPI.Data.Entities;

namespace VideoGameAPI.Data.Repository
{
    public interface ILibraryRepository
    {
        //companies
        IEnumerable<CompanyEntity> GetCompanies(string orderBy);
        CompanyEntity GetCompany(int companyId);
        CompanyEntity CreateCompany(CompanyEntity companyModel);
        bool DeleteCompany(int companyId);
        bool UpdateCompany(CompanyEntity companyModel);

        //videogames 
        VideoGameEntity CreateVideogame(VideoGameEntity videoGame);
        VideoGameEntity GetVideogame(int videogameId);
        IEnumerable<VideoGameEntity> GetVideoGames(int companyId);
        bool UpdateVideogame(VideoGameEntity videoGame);
        bool DeleteVideogame(int videogameId);
    }
}
