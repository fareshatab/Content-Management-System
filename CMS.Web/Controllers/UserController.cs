using Core.DTOs;
using Core.ViewModels;
using Core.Constants;
using InfraStructure.Services.Users;
using Microsoft.AspNetCore.Mvc;
using CMS.Core.Dtos;

namespace CMS.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) 
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateUserDto dto)
        {
            if (ModelState.IsValid)
            {
                await _userService.Create(dto);
                return Ok(Core.Constants.Results.AddSuccessResult());
            }
            return BadRequest(ModelState);
        }
        [HttpGet]
        public async Task<IActionResult> Update(String Id)
        {
            var user = await _userService.GitById(Id);
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> Update([FromForm] UpdateUserDto dto)
        {
            if (ModelState.IsValid)
            {
               await _userService.Update(dto);
                return Ok(Core.Constants.Results.EditSuccessResult());
            }
            return View(dto);
        }
        public async Task<IActionResult> Delete(String Id)
        {
           await _userService.Delete(Id);
            return Ok(Core.Constants.Results.DeleteSuccessResult());
        }
        public async Task<JsonResult> GetUserData(Pagination pagination , Query query)
        {
            var result = await _userService.GetAll(pagination, query);
            return Json(result);
        }

    }
}
