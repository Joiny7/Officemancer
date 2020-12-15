using Microsoft.CodeAnalysis.CSharp;
using Platypus.Dtos;
using Platypus.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Platypus.Services
{
    public class UserService : IUserService
    {
        private readonly PlatypusContext _context;

        public UserService(PlatypusContext context)
        {
            _context = context;
        }

        public string UpdateUserData(UserDataDto dto)
        {
            User u = _context.Users.Where(x => x.UserID == dto.ID).FirstOrDefault();
            MiniLogin ml = _context.Logins.Where(x => x.UserID == dto.ID).FirstOrDefault();

            if (u != null && ml != null)
            {
                u.UserName = dto.UserName;
                u.LastName = dto.LastName;
                u.FirstName = dto.FirstName;
                ml.Password = dto.Password;
                ml.UserName = u.UserName;

                _context.Update(u);
                _context.Update(ml);
                _context.SaveChanges();
                return "Changes updated successfully";
            }
            else
                return "Changes updated failed";
        }

        public List<UserReservation> GetUserReservations(int userId)
        {
            var list = _context.UserReservations.Where(x => x.UserID == userId).ToList();
            return list;
        }        
        
        public UserReservation GetUserReservation(int userReservationId)
        {
            UserReservation ur = _context.UserReservations.Where(x => x.UserReservationID == userReservationId).FirstOrDefault();
            return ur;
        }

        public Warning GetLastestWarning(int userid)
        {
            var companyid = _context.Users.Where(x => x.UserID == userid).Select(y => y.CompanyID).FirstOrDefault();
            var w = _context.Warnings.Where(x => x.CompanyID == companyid).ToList();
            w.OrderBy(x => x.Timestamp);
            return w.FirstOrDefault();
        }

        public List<User> GetUsers(int id)
        {
            var companyid = _context.Users.Where(x => x.UserID == id).Select(y => y.CompanyID).FirstOrDefault();
            var users = _context.Users.Where(x => x.CompanyID == companyid).ToList();
            return users;
        }

        public User GetUser(string username)
        {
            var user = _context.Users.Where(x => x.UserName == username).FirstOrDefault();
            return user;
        }

        public int? Login(string username, string password)
        {
            var User = _context.Logins.Where(x => x.UserName == username && x.Password == password).FirstOrDefault();

            if (User != null)
                return User.UserID;
            else
                return null;
        }

        public CalenderDto GetMonth(int officeid, int month, int? year)
        {
            if (year == null)
                year = DateTime.Today.Year;

            var floors = _context.Floors.Where(x => x.OfficeID == officeid).ToList();
            CalenderDto Cdto = new CalenderDto();
            Cdto.Days = new List<DayDto>();
            DateTime d = new DateTime(year.GetValueOrDefault(), month, 1);
            Cdto.Month = d.ToString("MMMM", CultureInfo.InvariantCulture);

            for (int i = 1; i < DateTime.DaysInMonth(year.GetValueOrDefault(), month); i++)
            {
                var dd = CreateDayDto(officeid, year.GetValueOrDefault(), month, i);
                Cdto.Days.Add(dd);
            }

            return Cdto;
        }

        private DayDto CreateDayDto(int officeid, int year, int month, int day)
        {
            DayDto dd = new DayDto();
            dd.OfficeID = officeid;
            dd.Date = new DateTime(year, month, day);
            dd.MaxCapacity = GetMaxCapacity(officeid);
            dd.CurrentCapacity = GetCurrentCapacity(officeid, dd.Date);
            return dd;
        }

        private int GetMaxCapacity(int officeid)
        {
            return GetOffice(officeid).TotalCapacity;
        }

        private int GetCurrentCapacity(int officeid, DateTime date)
        {
            var resservs = GetReservations(officeid, date, null);
            return resservs.Count;
        }

        public Office GetOffice(int officeid)
        {
            var office = _context.Offices.Where(x => x.OfficeID == officeid).FirstOrDefault();
            var floors = _context.Floors.Where(x => x.OfficeID == officeid).ToList();
            office.Floors = new List<Floor>();
            office.Floors = floors;
            return office;
        }

        public string CreateReservation(Reservation res)
        {
            if (res != null)
            {
                if (res.Date == null)
                    return "Date cannot be null";

                if (res.OfficeID < 1 || res.FloorID < 1 || res.BookerID < 1)
                    return "ID not correct";

                if ((res.UserIds == null || res.UserIds.Count < 1) && !res.UserIds.Contains(res.BookerID))
                {
                    res.UserIds = new List<int>();
                    res.UserIds.Add(res.BookerID);
                }

                if (IsFloorFull(res.OfficeID, res.FloorID, res.UserIds.Count, res.Date))
                    return "Not enough room on this floor for all reservations";

                foreach (int u in res.UserIds)
                {
                    Reservation r = new Reservation
                    {
                        BookerID = u,
                        FloorID = res.FloorID,
                        OfficeID = res.OfficeID,
                        Date = res.Date
                    };

                    _context.Reservations.Add(r);
                    _context.SaveChanges();

                    UserReservation ur = new UserReservation()
                    {
                        ReservationID = r.ReservationID,
                        UserID = u,
                        Timestamp = DateTime.Now
                    };

                    _context.UserReservations.Add(ur);
                    _context.SaveChanges();
                }

                return "Reservation Successfull";
            }
            else
                return "bad model";
        }

        private bool IsFloorFull(int officeid, int floorid, int reservations, DateTime date)
        {
            var floor = _context.Floors.Where(x => x.FloorID == floorid).FirstOrDefault();
            if (floor.Bookable && (floor.MaxCapacity - reservations) > GetReservations(officeid, date, floorid).Count)
                return false;
            else
                return true;
        }

        private List<Reservation> GetReservations(int officeid, DateTime date, int? floorid)
        {
            if (floorid != null)
            {
                var res = _context.Reservations.Where(x => x.OfficeID == officeid && x.Date.Date == date.Date && x.FloorID == floorid).ToList();
                return res;
            }
            else
            {
                var res = _context.Reservations.Where(x => x.OfficeID == officeid && x.Date.Date == date.Date).ToList();
                return res;
            }
        }
        public string UpdateReservation(int reservationId, ReservationDto resDto)
        {

            Reservation reservation = _context.Reservations.FirstOrDefault(r => r.ReservationID == reservationId);
            IQueryable<UserReservation> userReservations = _context.UserReservations.Where(r => r.ReservationID == reservationId);
            //Update reservation
            if (reservation == null)
            {
                return "Reservation with Id " + reservationId.ToString() + " not found to update";
            }
            else
            {
                reservation.FloorID = resDto.FloorID;
                reservation.Date = resDto.Date;

                _context.SaveChanges();

                foreach(int userId in resDto.UserIds)
                {
                    //Check if a new user is added
                    bool ifUserExist = userReservations.Any(item => item.UserID.Equals(userId));
                    if (!ifUserExist)
                    {
                        UserReservation ur = new UserReservation()
                        {
                            ReservationID = reservationId,
                            UserID = userId,
                            Timestamp = DateTime.Now
                        };

                        _context.UserReservations.Add(ur);
                        _context.SaveChanges();
                    }

                }
                    //check if user needs to be deleted
                    List<UserReservation> toBeDeleted = userReservations.Where(userRes => !resDto.UserIds.Any(mancerId => userRes.UserID == mancerId)).ToList();
                    foreach(UserReservation userToDelete in toBeDeleted)
                    {
                        _context.UserReservations.Remove(userToDelete);
                       _context.SaveChanges();
                    }



                return "Reservation with Id " + reservationId.ToString() + " updated";
            }
        }

        public string DeleteReservation(int id)
        {
            var entety = _context.Reservations.FirstOrDefault(res => res.ReservationID == id);
            var userReservations = _context.UserReservations.Where(r => r.ReservationID == id);
            if (entety == null)
            {
                return "Reservation with Id " + id.ToString() + " not found";
            }
            else
            {
                _context.Reservations.Remove(entety);
                _context.SaveChanges();

                foreach (var user in userReservations)
                {
                    _context.UserReservations.Remove(user);
                    _context.SaveChanges();

                }
                return "Reservation with Id " + id.ToString() + " deleted";
            }
        }
    }
}