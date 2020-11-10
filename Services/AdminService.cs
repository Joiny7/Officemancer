using Platypus.Dtos;
using Platypus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Platypus.Services
{
    public class AdminService : IAdminService
    {
        private readonly PlatypusContext _context;

        public AdminService(PlatypusContext context)
        {
            _context = context;
        }

        public User CreateUser(UserDto dto)
        {
            var comp = _context.Companies.Where(x => x.CompanyID == dto.CompanyID).FirstOrDefault();

            if (comp == null)
                return null;

            User u = new User
            {
                UserName = dto.UserName,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                CompanyID = dto.CompanyID,
                Admin = dto.Admin
            };

            _context.Users.Add(u);
            _context.SaveChanges();
            return _context.Users.Where(x => x.FirstName == dto.FirstName && x.LastName == dto.LastName).FirstOrDefault();
        }

        public int CreateWarning(int CompanyID, string Message, int? OfficeID)
        {
            Warning w = new Warning
            {
                CompanyID = CompanyID,
                OfficeID = OfficeID,
                Message = Message,
                Timestamp = DateTime.Now
            };

            _context.Warnings.Add(w);
            _context.SaveChanges();
            return w.WarningID;
        }

        public string AddOffice(string OfficeName, int CompanyID, int TotalCapacity, string BannerMessage)
        {
            Office o = new Office()
            {
                OfficeName = OfficeName,
                CompanyID = CompanyID,
                TotalCapacity = TotalCapacity,
                BannerMessage = BannerMessage
            };

            _context.Offices.Add(o);
            _context.SaveChanges();
            return "Office successfully added.";
        }

        public string UpdateOffice(int OfficeId, string OfficeName, int TotalCapacity, string BannerMessage)
        {
            var f2 = _context.Offices.Where(x => x.OfficeID == OfficeId).FirstOrDefault();
            f2.BannerMessage = BannerMessage;
            f2.OfficeName = OfficeName;
            f2.TotalCapacity = TotalCapacity;
            _context.Update(f2);
            _context.SaveChanges();
            return "Office successfully updated.";
        }

        public List<User> GetUsers(int companyid)
        {
            var users = _context.Users.Where(x => x.CompanyID == companyid).ToList();
            return users;
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

        public string UpdateFloor(int floorid, string newName, int newMax, bool newBookable)
        {
            var f2 = _context.Floors.Where(x => x.FloorID == floorid).FirstOrDefault();
            f2.FloorName = newName;
            f2.MaxCapacity = newMax;
            f2.Bookable = newBookable;
            _context.Update(f2);
            _context.SaveChanges();
            return "Floor successfully updated.";
        }

        public string AddFloor(string name, int officeId, int max, bool bookable)
        {
            Floor f = new Floor()
            {
                FloorName = name,
                OfficeID = officeId,
                MaxCapacity = max, 
                Bookable = bookable
            };

            _context.Floors.Add(f);
            _context.SaveChanges();
            return "Floor successfully added.";
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