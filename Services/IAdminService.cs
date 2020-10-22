using Officemancer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Officemancer.Services
{
    public interface IAdminService
    {
        string SetBannerMessage(int userid, string message);
        string UpdateFloor(Floor f);
        string AddFloor(Floor f);
        bool AdminCheck(int userid);
    }
}
