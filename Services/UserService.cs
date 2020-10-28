﻿using Officemancer.Dtos;
using Officemancer.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Officemancer.Services
{
    public class UserService : IUserService
    {
        private readonly MancerContext _context;

        public UserService(MancerContext context)
        {
            _context = context;
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

                if ((res.MancerIds == null || res.MancerIds.Count < 1) && !res.MancerIds.Contains(res.BookerID))
                {
                    res.MancerIds = new List<int>();
                    res.MancerIds.Add(res.BookerID);
                }

                if (isFloorFull(res.OfficeID, res.FloorID, res.MancerIds.Count, res.Date))
                    return "Not enough room on this floor for all reservations";

                foreach (int u in res.MancerIds)
                {
                    Reservation r = new Reservation
                    {
                        BookerID = u,
                        FloorID = res.FloorID,
                        OfficeID = res.OfficeID,
                        Date = res.Date,
                        Mancers = res.Mancers
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

        private bool isFloorFull(int officeid, int floorid, int reservations, DateTime date)
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
    }
}