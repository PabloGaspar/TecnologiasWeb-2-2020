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
        Task<IEnumerable<CompanyEntity>> GetCompaniesAsync(string orderBy, bool showVideogames = false);
        Task<CompanyEntity> GetCompanyAsync(int companyId, bool showVideogames = false);
        void CreateCompany(CompanyEntity companyModel);
        bool DeleteCompany(int companyId);
        bool UpdateCompany(CompanyEntity companyModel);

        //videogames 
        VideoGameEntity CreateVideogame(VideoGameEntity videoGame);
        VideoGameEntity GetVideogame(int videogameId);
        IEnumerable<VideoGameEntity> GetVideoGames(int companyId);
        bool UpdateVideogame(VideoGameEntity videoGame);
        bool DeleteVideogame(int videogameId);

        //save changes
        Task<bool> SaveChangesAsync();
    }
}
