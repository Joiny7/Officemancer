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

    }
}