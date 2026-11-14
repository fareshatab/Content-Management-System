using CMS.Core.Dtos;
using CMS.Infrastructure.Services.Categories;
using Core.DTOs;
using Core.Enums;
using Infrastructure.Services.Tracks;
using InfraStructure.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Core.Constants;

namespace CMS.Web.Controllers
{
    public class TrackController : Controller
    {

        private readonly ITrackService _trackService;
        private readonly ICategoryService _categoryService;
        private readonly IUserService _userService;

        public TrackController(ITrackService trackService, ICategoryService categoryService, IUserService userService)
        {
            _trackService = trackService;
            _categoryService = categoryService;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetTracksData(Pagination pagination, Query query)
        {
            var result = await _trackService.GetAll(pagination, query);
            return Json(result);
        }


        [HttpGet]
        public async Task<IActionResult> GetLog(int Id)
        {
            var logs = await _trackService.GetLog(Id);
            return View(logs);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewData["categories"] = new SelectList(await _categoryService.GetCategoryList(), "Id", "Name");
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> UpdateStatus(int id, ContentStatus status)
        {
            await _trackService.UpdateStatus(id, status);
            return Ok(Core.Constants.Results.UpdateStatusSuccessResult());
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateTrackDto dto)
        {

            if (ModelState.IsValid)
            {
                await _trackService.Create(dto);
                return Ok(Core.Constants.Results.AddSuccessResult());
            }

            ViewData["categories"] = new SelectList(await _categoryService.GetCategoryList(), "Id", "Name");
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var track = await _trackService.Get(id);
            ViewData["categories"] = new SelectList(await _categoryService.GetCategoryList(), "Id", "Name");
            return View(track);
        }


        [HttpPost]
        public async Task<IActionResult> Update(UpdateTrackDto dto)
        {
            if (ModelState.IsValid)
            {
                await _trackService.Update(dto);
                return Ok(Core.Constants.Results.EditSuccessResult());
            }

            ViewData["categories"] = new SelectList(await _categoryService.GetCategoryList(), "Id", "Name");
            return View(dto);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _trackService.Delete(id);
            return Ok(Core.Constants.Results.DeleteSuccessResult());
        }

    }
}
