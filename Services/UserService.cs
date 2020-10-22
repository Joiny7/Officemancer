using Officemancer.Models;
using System;
using System.Collections.Generic;
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

        public bool Login(string username, string password)
        {
            var User = _context.Logins.Where(x => x.UserName == username && x.Password == password).FirstOrDefault();

            if (User != null)
                return true;
            else
                return false;
        }

        public string CreateReservation(Reservation res)
        {
            if(res != null)
            {
                if (res.Date == null)
                    return "Date cannot be null";

                if (res.OfficeID < 1 || res.FloorID < 1 || res.BookerID < 1)
                    return "ID not correct";

                if (res.Mancers == null || res.Mancers.Count < 1)
                    return "No Mancers in this booking";

                _context.Reservations.Add(res);
                _context.SaveChanges();
                return "Reservation Successfull";
            }
        }
    }
}