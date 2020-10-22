using Officemancer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Officemancer.Services
{
    public class AdminService : IAdminService
    {
        private readonly MancerContext _context;

        public AdminService(MancerContext context)
        {
            _context = context;
        }

        public string SetBannerMessage(int userid, string message)
        {
            var user = _context.Users.Where(x => x.UserID == userid).FirstOrDefault();
            if (user.Admin)
            {
                var compid = _context.Companies.Where(x => x.CompanyID == user.CompanyID).Select(y => y.CompanyID).FirstOrDefault();
                var office = _context.Offices.Where(x => x.CompanyID == compid).FirstOrDefault();
                office.BannerMessage = message;
                _context.Update(office);
                _context.SaveChanges();
                return "Message succesfully set.";
            }
            else
                return "You are not an admin.";
        }

        public string UpdateFloor(Floor f)
        {
            if (f == null)
                return "invalid values.";
            else
            {
                var f2 = _context.Floors.Where(x => x.FloorID == f.FloorID).FirstOrDefault();
                f2 = f;
                _context.Update(f2);
                _context.SaveChanges();
                return "Floor successfully updated.";
            }
        }

        public string AddFloor(Floor f)
        {
            if (f == null)
                return "invalid values.";
            else
            {
                _context.Floors.Add(f);
                _context.SaveChanges();
                return "Fllor successfully added.";
            }
        }

        public bool AdminCheck(int userid)
        {
            var user = _context.Users.Where(x => x.UserID == userid).FirstOrDefault();
            if (user.Admin)
                return true;
            else
                return false;
        }
    }
}