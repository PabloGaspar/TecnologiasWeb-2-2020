﻿using AutoMapper;
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
    public class CompaniesService : ICompaniesService
    {
        ILibraryRepository _libraryRepository;
        private IMapper _mapper;

        private HashSet<string> allowedOrderByParameters = new HashSet<string>()
        {
            "id",
            "name",
            "fundation-date",
            "country"
        };

        public CompaniesService(ILibraryRepository libraryRepository, IMapper mapper)
        {
            _libraryRepository = libraryRepository;
            _mapper = mapper;
        }

        public async Task<CompanyModel> CreateCompanyAsync(CompanyModel companyModel)
        {
            var companyEntity = _mapper.Map<CompanyEntity>(companyModel);
            _libraryRepository.CreateCompany(companyEntity);
            var result = await _libraryRepository.SaveChangesAsync();

            if (result)
            {
                return _mapper.Map<CompanyModel>(companyEntity);
            }

            throw new Exception("Database Error");
        }

        public DeleteModel DeleteCompany(int companyId)
        {
            var companyToDelete = new CompanyModel();//GetCompany(companyId);

            var result = _libraryRepository.DeleteCompany(companyId);

            if (result)
            {
                return new DeleteModel()
                {
                    IsSuccess = result,
                    Message = "The company was deleted."
                };
            } else
            {
                return new DeleteModel()
                {
                    IsSuccess = result,
                    Message = "The company was not deleted."
                };
            }
        }

        public async Task<IEnumerable<CompanyModel>> GetCompaniesAsync(string orderBy, bool showVideogames)
        {
            if (!allowedOrderByParameters.Contains(orderBy.ToLower()))
            {
                throw new BadRequestOperationException($"the field: {orderBy} is not supported, please use one of these {string.Join(",", allowedOrderByParameters)}");
            }

            var entityList = await _libraryRepository.GetCompaniesAsync(orderBy, showVideogames);
            var modelList = _mapper.Map<IEnumerable<CompanyModel>>(entityList);
            return modelList;
        }

        public async Task<CompanyModel> GetCompanyAsync(int companyID, bool showVideogames = false)
        {
            var company = await _libraryRepository.GetCompanyAsync(companyID, showVideogames);
            if (company == null)
            {
                throw new NotFoundOperationException($"The company with id:{companyID} does not exists");
            }

            return _mapper.Map<CompanyModel>(company);
        }

        public CompanyModel UpdateCompany(int companyId, CompanyModel companyModel)
        {
            var companyEntity = _mapper.Map<CompanyEntity>(companyModel);
            _libraryRepository.UpdateCompany(companyEntity);
            return companyModel;
        }
    }
}
