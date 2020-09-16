using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGameAPI.Data.Entities;
using VideoGameAPI.Data.Repository;
using VideoGameAPI.Exceptions;
using VideoGameAPI.Models;

namespace VideoGameAPI.Services
{
    public class VidegamesService : IVidegamesService
    {
        private IMapper _mapper;
        private ILibraryRepository _libraryRepository;

        public VidegamesService(IMapper mapper, ILibraryRepository libraryRepository)
        {
            _mapper = mapper;
            _libraryRepository = libraryRepository;
        }

        public VideogameModel CreateVideogame(int CompanyId, VideogameModel videogame)
        {
            validateCompany(CompanyId);
            return _mapper.Map< VideogameModel>(_libraryRepository.CreateVideogame(_mapper.Map<VideoGameEntity>(videogame)));
        }

        public bool DeleteVideogame(int CompanyId, int videogameId)
        {
            GetVidegame(CompanyId, videogameId);
            return _libraryRepository.DeleteVideogame(videogameId);
        }

        public VideogameModel GetVidegame(int CompanyId, int videogameId)
        {
            validateCompany(CompanyId);
            validateVideogame(videogameId);
            return _mapper.Map< VideogameModel>(_libraryRepository.GetVideogame(videogameId));
        }

        public IEnumerable<VideogameModel> GetVidegames(int CompanyId)
        {
            validateCompany(CompanyId);
            return _mapper.Map<IEnumerable<VideogameModel>>(_libraryRepository.GetVideoGames(CompanyId));

        }

        public VideogameModel UpdateVideogame(int companyId, int videogameId, VideogameModel videogame)
        {
            GetVidegame(companyId, videogameId);
            videogame.Id = videogameId;
            return _mapper.Map<VideogameModel>(_libraryRepository.UpdateVideogame(_mapper.Map<VideoGameEntity>(videogame)));
        }

        private void validateCompany(int companyId)
        {
            var company = _libraryRepository.GetCompany(companyId);
            if (company == null)
            {
                throw new NotFoundOperationException($"the company id:{companyId}, does not exist");
            }
        }

        private void validateVideogame(int videogameId)
        {
            var videogame = _libraryRepository.GetVideogame(videogameId);
            if (videogame == null)
            {
                throw new NotFoundOperationException($"the videogame id:{videogameId}, does not exist");
            }
        }
    }
}
