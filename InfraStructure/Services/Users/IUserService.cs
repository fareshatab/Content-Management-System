using CMS.Core.Dtos;
using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfraStructure.Services.Users
{
    public interface IUserService
    {
        Task<String> Create(CreateUserDto dto);
        Task<ResponseDto> GetAll(Pagination pagination, Query query);
        Task<String> Delete(System.String Id);
        Task<UpdateUserDto> GitById(string Id);
        Task<String> Update(UpdateUserDto dto);
    }
}
