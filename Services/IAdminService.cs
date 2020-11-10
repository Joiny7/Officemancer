using Platypus.Dtos;
using Platypus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Platypus.Services
{
    public interface IAdminService
    {
        string SetBannerMessage(int userid, string message);
        string UpdateFloor(int floorid, string newName, int newMax, bool newBookable);
        string AddFloor(string name, int officeId, int max, bool bookable);
        bool AdminCheck(int userid);
        List<User> GetUsers(int companyid);
        string AddOffice(string OfficeName, int CompanyID, int TotalCapacity, string BannerMessage);
        string UpdateOffice(int OfficeId, string OfficeName, int TotalCapacity, string BannerMessage);
        int CreateWarning(int CompanyID, string Message, int? OfficeID);
        User CreateUser(UserDto dto);

    }
}
