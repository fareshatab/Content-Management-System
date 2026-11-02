using CMS.Core.Dtos;
using Core.DTOs;
using Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfraStructure.Services.Advertisement
{
    public interface IAdvertisementService
    {
        Task<ResponseDto> GetAll(Pagination pagination, Query query);
        Task<int> Delete(int id);
        Task<int> Create(CreateAdvertisementDto dto);
        Task<List<UserViewModel>> GetAdvertisementOwners();
        Task<UpdateAdvertisementDto> Get(int id);
        Task<int> Update(UpdateAdvertisementDto dto);
    }
}
