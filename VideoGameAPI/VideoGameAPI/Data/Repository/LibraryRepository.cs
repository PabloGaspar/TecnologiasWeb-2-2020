using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGameAPI.Data.Entities;

namespace VideoGameAPI.Data.Repository
{
    public class LibraryRepository : ILibraryRepository
    {
        private List<CompanyEntity> companies = new List<CompanyEntity>
        {
            new CompanyEntity(){ Id = 1, Name = "FromSoftware", Country ="japan", FundationDate = new DateTime(1993,12,12), CEO = "Miyazaki"},
            new CompanyEntity(){ Id = 2, Name = "Blizzard", Country ="US", FundationDate = new DateTime(1993,12,12), CEO = "None"}
        };


        private List<VideoGameEntity> videogames = new List<VideoGameEntity>
        {
            new VideoGameEntity(){ Id = 1, Name = "Dark Souls", ESRB = "M", Genre = "Action RPG", Price = 44.9m, ReleaseDate = new DateTime(2008, 10,12) },
            new VideoGameEntity(){ Id = 2, Name = "Bloodborne", ESRB = "M", Genre = "Action RPG", Price = 54.9m, ReleaseDate = new DateTime(2014, 12,10) },
            new VideoGameEntity(){ Id = 3, Name = "Warcraft 3", ESRB = "T", Genre = "Strategy", Price = 15.9m, ReleaseDate = new DateTime(2001, 12,10)},
            new VideoGameEntity(){ Id = 4, Name = "starcraft remaster", ESRB = "T", Genre = "Strategy", Price = 10.9m, ReleaseDate = new DateTime(1993,12,10)},
        };

        private LibraryDbContext _dbContext;

        public LibraryRepository(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // companies
        public void CreateCompany(CompanyEntity company)
        {
            _dbContext.Companies.Add(company);
        }

        public bool DeleteCompany(int companyId)
        {
            var companyToDelete = companies.FirstOrDefault(c => c.Id == companyId);
            companies.Remove(companyToDelete);
            return true;
        }

        public async Task<IEnumerable<CompanyEntity>> GetCompaniesAsync(string orderBy, bool showVideogames = false)
        {
            IQueryable<CompanyEntity> query = _dbContext.Companies;
            
            switch (orderBy)
            {
                case "id":
                    query = query.OrderBy(c => c.Id);
                    break;
                case "name":
                    query = query.OrderBy(c => c.Name);
                    break;
                case "fundation-date":
                    query = query.OrderBy(c => c.FundationDate);
                    break;
                case "country":
                    query = query.OrderBy(c => c.Country);
                    break;
                default:
                    query = query.OrderBy(c => c.Id); ;
                    break;
            }
            return await query.ToListAsync();
        }

        public async Task<CompanyEntity> GetCompanyAsync(int companyId, bool showVideogames = false)
        {
            IQueryable<CompanyEntity> query = _dbContext.Companies;
            query = query.AsNoTracking();

            if (showVideogames)
            {
                query = query.Include(c => c.Videogames);
            }

            //tolist()
            //toArray()
            //foreach
            //firstOfDefaul
            //Single
            //Count

            return await query.FirstOrDefaultAsync(c => c.Id == companyId);
        }

        public bool UpdateCompany(CompanyEntity companyModel)
        {
            var companyToUpdate = new CompanyEntity();//GetCompany(companyModel.Id);
            companyToUpdate.CEO = companyModel.CEO ?? companyToUpdate.CEO;
            companyToUpdate.Country = companyModel.Country ?? companyToUpdate.Country;
            companyToUpdate.FundationDate = companyModel.FundationDate ?? companyToUpdate.FundationDate;
            companyToUpdate.Name = companyModel.Name ?? companyToUpdate.Name;
            return true;
        }


        public VideoGameEntity CreateVideogame(VideoGameEntity videoGame)
        {
            int newId;
            var lastVideogame = videogames.OrderByDescending(v => v.Id).FirstOrDefault();
            if (lastVideogame == null)
            {
                newId = 1;
            }
            else
            {
                newId = lastVideogame.Id + 1;
            }
            videoGame.Id = newId;
            videogames.Add(videoGame);
            return videoGame;
        }

        public VideoGameEntity GetVideogame(int videogameId)
        {
            return videogames.FirstOrDefault(v => v.Id == videogameId);
        }

        public IEnumerable<VideoGameEntity> GetVideoGames(int companyId)
        {
            //return videogames.Where(v => v.companyId == companyId);
            return null;
        }

        public bool UpdateVideogame(VideoGameEntity videoGame)
        {
            var videogameToUpdate = GetVideogame(videoGame.Id);
            videogameToUpdate.Name = videoGame.Name ?? videogameToUpdate.Name;
            videogameToUpdate.Price = videoGame.Price?? videogameToUpdate.Price;
            videogameToUpdate.ReleaseDate = videoGame.ReleaseDate ?? videogameToUpdate.ReleaseDate;
            videogameToUpdate.Genre = videoGame.Genre ?? videogameToUpdate.Genre;
            videogameToUpdate.ESRB = videoGame.ESRB ?? videogameToUpdate.ESRB;
            return true;
        }

        public bool DeleteVideogame(int videogameId)
        {
            var videogameToDelete = videogames.SingleOrDefault(v => v.Id == videogameId);
            videogames.Remove(videogameToDelete);
            return true;
        }

        public async Task<bool> SaveChangesAsync()
        {
            var res = await _dbContext.SaveChangesAsync();
            return res > 0;
        }

       
    }
}
