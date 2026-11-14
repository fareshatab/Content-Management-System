using CMS.Core.Dtos;
using Core.DTOs;
using Core.Enums;
using Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfraStructure.Services.Posts
{
    public interface IPostService
    {
        Task<ResponseDto> GetAll(Pagination pagination, Query query);
        Task<int> Create(CreatePostDto dto);
        Task<UpdatePostDto> Get(int id);
        Task<int> UpdateStatus(int id, ContentStatus status);
        Task<int> Delete(int id);
        Task<int> Update(UpdatePostDto dto);

        Task<List<ContentChangeLogViewModel>> GetLog(int id);

    }
}
