using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfraStructure.Services.Notifications
{
    public interface INotificationService
    {
        Task<bool> SendByFCM(string token, NotificationDto dto);
    }
}
