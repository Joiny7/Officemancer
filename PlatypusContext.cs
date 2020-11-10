using Microsoft.EntityFrameworkCore;
using Platypus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Platypus
{
    public class PlatypusContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<MiniLogin> Logins { get; set; }
        public DbSet<UserReservation> UserReservations { get; set; }
        public DbSet<Warning> Warnings { get; set; }

        public PlatypusContext(DbContextOptions<PlatypusContext> options) : base(options) { }
    }
}