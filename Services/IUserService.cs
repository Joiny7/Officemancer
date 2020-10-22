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
        bool Login(string username, string password);
        CalenderDto GetMonth(int officeid, int month, int? year);
        Office GetOffice(int officeid);
        string CreateReservation(Reservation res);
    }
}
