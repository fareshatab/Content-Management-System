using AutoMapper;
using CMS.Core.Dtos;
using CMS.Core.Exceptions;
using CMS.Data.EntityFrameworkCore;
using CMS.Infrastructure.Services;
using Core.DTOs;
using Core.Enums;
using Core.Exceptions;
using Core.ViewModels;
using Data.Models;
using InfraStructure.Services.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfraStructure.Services.Advertisement
{
    public class AdvertisementService : IAdvertisementService
    {
        private readonly CMSDbContext _db;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IFileService _fileService;

        public AdvertisementService(IFileService fileService, CMSDbContext db, IMapper mapper, IUserService userService)
        {
            _db = db;
            _mapper = mapper;
            _fileService = fileService;
            _userService = userService;
        }

        public async Task<ResponseDto> GetAll(Pagination pagination, Query query)
        {
            var queryString = _db.Advertisments.Include(x => x.Owner).Where(x => !x.IsDelete).AsQueryable();

            var dataCount = queryString.Count();
            var skipValue = pagination.GetSkipValue();
            var dataList = await queryString.Skip(skipValue).Take(pagination.PerPage).ToListAsync();
            var advertisements = _mapper.Map<List<AdvertisementViewModel>>(dataList);
            var pages = pagination.GetPages(dataCount);
            var result = new ResponseDto
            {
                data = advertisements,
                meta = new Meta
                {
                    page = pagination.Page,
                    perpage = pagination.PerPage,
                    pages = pages,
                    total = dataCount,
                }
            };
            return result;
        }

        public async Task<int> Delete(int id)
        {
            var advertisement = await _db.Advertisments.SingleOrDefaultAsync(x => x.Id == id && !x.IsDelete);
            if (advertisement == null)
            {
                throw new EntityNotFoundException();
            }
            advertisement.IsDelete = true;
            _db.Advertisments.Update(advertisement);
            await _db.SaveChangesAsync();
            return advertisement.Id;
        }
    

        public async Task<int> Create(CreateAdvertisementDto dto)
        {
            var advertisement = _mapper.Map<Advertisment>(dto);
            if (dto.Image != null)
            {
                advertisement.ImageURL = await _fileService.SaveFile(dto.Image, "Images");
            }
            await _db.Advertisments.AddAsync(advertisement);
            await _db.SaveChangesAsync();
            if (advertisement.OwnerID == null)
            {
                var userId = await _userService.Create(dto.Owner);
                advertisement.OwnerID = userId;

                _db.Advertisments.Update(advertisement);
                await _db.SaveChangesAsync();

            }

            return advertisement.Id;
        }

        public async Task<List<UserViewModel>> GetAdvertisementOwners()
        {
            var users = await _db.Users.Where(x => !x.IsDelete && x.UserType == TypeUser.AdvertisementOwner).ToListAsync();
            return _mapper.Map<List<UserViewModel>>(users);
        }

        public async Task<UpdateAdvertisementDto> Get(int id)
        {
            var advertisement = await _db.Advertisments.SingleOrDefaultAsync(x => x.Id == id && !x.IsDelete);
            if (advertisement == null)
            {
                throw new EntityNotFoundException();
            }
            return _mapper.Map<UpdateAdvertisementDto>(advertisement);
        }
        public async Task<int> Update(UpdateAdvertisementDto dto)
        {

            if (dto.StartDate >= dto.EndDate)
            {
                throw new InvalidDateException();
            }

            var advertisement = await _db.Advertisments.SingleOrDefaultAsync(x => x.Id == dto.Id && !x.IsDelete);
            if (advertisement == null)
            {
                throw new EntityNotFoundException();
            }

            var updatedAdvertisement = _mapper.Map(dto, advertisement);

            if (dto.Image != null)
            {
                updatedAdvertisement.ImageURL = await _fileService.SaveFile(dto.Image, "Images");
            }

            _db.Advertisments.Update(updatedAdvertisement);
            await _db.SaveChangesAsync();

            return advertisement.Id;
        }

    } 
    } 

