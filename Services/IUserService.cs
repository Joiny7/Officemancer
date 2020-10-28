using Officemancer.Dtos;
using Officemancer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Officemancer.Services
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
    }
}
