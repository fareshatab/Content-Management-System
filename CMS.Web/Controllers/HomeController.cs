using InfraStructure.Services;
using InfraStructure.Services.Users;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CMS.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IDashboardService _dashboardService;

        public HomeController(IDashboardService dashboardService, IUserService userService) : base(userService)
        {
            _dashboardService = dashboardService;
        }


        public async Task<IActionResult> Index()
        {
            var data = await _dashboardService.GetData();
            return View(data);
        }


        public async Task<IActionResult> GetUserTypeChartData()
        {
            var data = await _dashboardService.GetUserTypeChart();
            return Ok(data);
        }

        public async Task<IActionResult> GetContentTypeChartData()
        {
            var data = await _dashboardService.GetContentTypeChart();
            return Ok(data);
        }

        public async Task<IActionResult> GetContentByMonthChartData()
        {
            var data = await _dashboardService.GetContentByMonthChart();
            return Ok(data);
        }

    }
}