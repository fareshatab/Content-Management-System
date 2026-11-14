using Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfraStructure.Services
{
    public interface IDashboardService
    {
        Task<DashboardViewModel> GetData();
        Task<List<PieChartViewModel>> GetUserTypeChart();
        Task<List<PieChartViewModel>> GetContentTypeChart();
        Task<List<PieChartViewModel>> GetContentByMonthChart();
    }
}
