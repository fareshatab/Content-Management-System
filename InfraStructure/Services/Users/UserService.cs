using AutoMapper;
using CMS.Core.Dtos;
using CMS.Data.EntityFrameworkCore;
using CMS.Infrastructure.Services;
using Core.Constants;
using Core.DTOs;
using Core.Exceptions;
using Core.ViewModels;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfraStructure.Services.Users
{
    public class UserService : IUserService
    {
        private readonly CMSDbContext _db;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        private readonly IEmailService _emailService;
        private readonly UserManager<User> _userManager;

        public UserService(
         CMSDbContext db,
         IMapper mapper,
         UserManager<User> userManager,
         IFileService fileService,
         IEmailService emailService)
        {
            _db = db;
            _mapper = mapper;
            _userManager = userManager;
            _fileService = fileService;
            _emailService = emailService;
        }

        public async Task<ResponseDto> GetAll(Pagination pagination, Query query)
        {
            var queryString = _db.Users.Where(x => !x.IsDelete);

            if (!string.IsNullOrWhiteSpace(query?.GeneralSearch))
            {
                queryString = queryString.Where(x =>
                    x.FullName.Contains(query.GeneralSearch) ||
                    x.Email.Contains(query.GeneralSearch));
            }

            var dataCount = await queryString.CountAsync();
            var skipValue = pagination.GetSkipValue();
            var dataList = await queryString
                .OrderBy(x => x.FullName)   // مهم مع Skip/Take
                .Skip(skipValue)
                .Take(pagination.PerPage)
                .ToListAsync();

            var users = _mapper.Map<List<UserViewModel>>(dataList);
            var pages = pagination.GetPages(dataCount);

            return new ResponseDto
            {
                data = users,
                meta = new Meta
                {
                    page = pagination.Page,
                    pages = pages,
                    perpage = pagination.PerPage,
                    total = dataCount
                }
            };
        }
        public async Task<String> Delete(System.String Id) {
            var user = _db.Users.SingleOrDefault(x => x.Id == Id && !x.IsDelete);
            if (user == null) 
            {
                throw new EntityNotFoundException();
            }
            user.IsDelete = true;
            _db.Users.Update(user);
            await _db.SaveChangesAsync();
            return user.Id;
        }
        public async Task<String> Create(CreateUserDto dto) 
        {
            var EmailOrPhoneIsExist = _db.Users.Any(x => !x.IsDelete && (x.Email == dto.Email || x.PhoneNumber == dto.PhoneNumber));
            if (EmailOrPhoneIsExist) 
            {
                throw new DublicationEmailOrPhone();
            }
            var user = _mapper.Map<User>(dto);
            user.UserName = dto.Email;
           
            if (dto.Image != null)
            {
                user.ImgURL =await _fileService.SaveFile(dto.Image , FolderNames.ImagesFolder);
            }     
            var password = GeneratePassword();
            var resule = await _userManager.CreateAsync(user, password);
            if (!resule.Succeeded) 
            {
                throw new EntityNotFoundException();
            }
            await _emailService.Send(user.Email, "New Account", $"User name is : {user.Email} and The PassWord is {password}");
            return user.Id;
        }
        private static string GeneratePassword()
        {
            const string upper = "ABCDEFGHJKLMNPQRSTUVWXYZ";
            const string lower = "abcdefghijkmnopqrstuvwxyz";
            const string digits = "23456789";
            const string special = "!@#$%^&*";
            var all = upper + lower + digits + special;

            var chars = new List<char>
    {
        upper[Random.Shared.Next(upper.Length)],
        lower[Random.Shared.Next(lower.Length)],
        digits[Random.Shared.Next(digits.Length)],
        special[Random.Shared.Next(special.Length)]
    };

            for (int i = chars.Count; i < 12; i++)
                chars.Add(all[Random.Shared.Next(all.Length)]);

            return new string(chars.OrderBy(_ => Random.Shared.Next()).ToArray());
        }
        public async Task<UpdateUserDto> GitById(string Id)
        {
            var user = await _db.Users.SingleOrDefaultAsync(x => x.Id == Id && !x.IsDelete);
            if (user == null)
            {
                throw new EntityNotFoundException();
            }
            return _mapper.Map<UpdateUserDto>(user);
        }
        public async Task<String> Update(UpdateUserDto dto)
        {
            var emailOrPhoneIsExist = _db.Users.Any(x => !x.IsDelete && (x.Email == dto.Email || x.PhoneNumber == dto.PhoneNumber) && x.Id != dto.Id);
            if (emailOrPhoneIsExist)
            {
                throw new DublicationEmailOrPhone();
            }

            var user = await _db.Users.FindAsync(dto.Id);
            var updatedUser = _mapper.Map<UpdateUserDto,User>(dto,user);
            user.UserName = dto.Email;
            _db.Users.Update(updatedUser);
            await _db.SaveChangesAsync();
            return user.Id;
        }
      


    }
}
