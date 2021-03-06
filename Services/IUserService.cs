﻿using Platypus.Dtos;
using Platypus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Platypus.Services
{
    public interface IUserService
    {
        int? Login(string username, string password);
        CalenderDto GetMonth(int officeid, int month, int? year);
        Office GetOffice(int officeid);
        string CreateReservation(Reservation res);
        List<User> GetUsers(int id);
        User GetUser(string username);
        Warning GetLastestWarning(int userid);
        List<UserReservation> GetUserReservations(int userId);
        UserReservation GetUserReservation(int userReservationId);
        string UpdateReservation(int id, ReservationDto res);
        string DeleteReservation(int id);
        string UpdateUserData(UserDataDto dto);
    }
}
