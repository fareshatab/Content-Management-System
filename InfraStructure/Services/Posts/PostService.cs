using AutoMapper;
using CMS.Core.Dtos;
using CMS.Data.EntityFrameworkCore;
using CMS.Infrastructure.Services;
using Core.DTOs;
using Core.Enums;
using Core.Exceptions;
using Core.ViewModels;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfraStructure.Services.Posts
{
    public class PostService : IPostService
    {
        private readonly CMSDbContext _db;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly IFileService _fileService;
        public PostService( IEmailService emailService, IFileService fileService, CMSDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _emailService = emailService;
            _fileService = fileService;
        }

        public async Task<ResponseDto> GetAll(Pagination pagination, Query query)
        {
            var queryString = _db.Posts
                .Include(x => x.Attachments)
                .Include(x => x.Category)
                .Include(x => x.Author)
                .Where(x => !x.IsDelete).AsQueryable();

            var dataCount = queryString.Count();
            var skipValue = pagination.GetSkipValue();
            var dataList = await queryString.Skip(skipValue).Take(pagination.PerPage).ToListAsync();
            var posts = _mapper.Map<List<PostViewModel>>(dataList);
            var pages = pagination.GetPages(dataCount);
            var result = new ResponseDto
            {
                data = posts,
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

        public async Task<int> Create(CreatePostDto dto)
        {
            var post = _mapper.Map<Post>(dto);

            await _db.Posts.AddAsync(post);
            await _db.SaveChangesAsync();

            if (dto.Attachments != null)
            {
                foreach (var a in dto.Attachments)
                {
                    var postAttachment = new Attachment();
                    postAttachment.AttachmentURL = await _fileService.SaveFile(a, "Images");
                    postAttachment.PostId = post.Id;
                    await _db.Attachments.AddAsync(postAttachment);
                    await _db.SaveChangesAsync();
                }
            }

            return post.Id;
        }

        public async Task<int> Update(UpdatePostDto dto)
        {
            var post = await _db.Posts.SingleOrDefaultAsync(x => x.Id == dto.Id && !x.IsDelete);
            if (post == null)
            {
                throw new EntityNotFoundException();
            }

            var updatedPost = _mapper.Map(dto, post);


            _db.Posts.Update(updatedPost);
            await _db.SaveChangesAsync();

            if (dto.Attachments != null)
            {
                foreach (var a in dto.Attachments)
                {
                    var postAttachment = new Attachment();
                    postAttachment.AttachmentURL = await _fileService.SaveFile(a, "Images");
                    postAttachment.PostId = post.Id;
                    await _db.Attachments.AddAsync(postAttachment);
                    await _db.SaveChangesAsync();
                }
            }

            return post.Id;
        }

        public async Task<UpdatePostDto> Get(int id)
        {
            var post = await _db.Posts.Include(x => x.Attachments).SingleOrDefaultAsync(x => x.Id == id && !x.IsDelete);
            if (post == null)
            {
                throw new EntityNotFoundException();
            }

            var dto = _mapper.Map<UpdatePostDto>(post);

            if (post.Attachments != null)
            {
                dto.PostAttachments = _mapper.Map<List<PostAttachmentViewModel>>(post.Attachments);
            }

            return dto;
        }

        public async Task<int> Delete(int id)
        {
            var post = await _db.Posts.SingleOrDefaultAsync(x => x.Id == id && !x.IsDelete);
            if (post == null)
            {
                throw new EntityNotFoundException();
            }
            post.IsDelete = true;
            _db.Posts.Update(post);
            await _db.SaveChangesAsync();
            return post.Id;
        }

        public async Task<List<ContentChangeLogViewModel>> GetLog(int id)
        {
            var changes = await _db.ContentChangeLogs.Where(x => x.ContentId == id && x.Type == ContentTypee.Post).ToListAsync();
            return _mapper.Map<List<ContentChangeLogViewModel>>(changes);
        }
        public async Task<int> UpdateStatus(int id, ContentStatus status)
        {
            var post = await _db.Posts.Include(x => x.Author).SingleOrDefaultAsync(x => x.Id == id && !x.IsDelete);
            if (post == null)
            {
                throw new EntityNotFoundException();
            }

            var changeLog = new ContentChangeLog();
            changeLog.ContentId = post.Id;
            changeLog.Type = ContentTypee.Post;
            changeLog.Old = post.Status;
            changeLog.New = status;
            changeLog.ChangeAt = DateTime.Now;

            await _db.ContentChangeLogs.AddAsync(changeLog);
            await _db.SaveChangesAsync();

            post.Status = status;
            _db.Posts.Update(post);
            await _db.SaveChangesAsync();

       


            await _emailService.Send(post.Author.Email, "UPDATE POST STATUS !", $"YOUR POST NOW IS {status.ToString()}");

            return post.Id;
        }


    }
}
