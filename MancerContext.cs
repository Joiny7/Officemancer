using Microsoft.EntityFrameworkCore;
using Officemancer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Officemancer
{
    public class MancerContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        public MancerContext(DbContextOptions<MancerContext> options) : base(options) { }
    }
}