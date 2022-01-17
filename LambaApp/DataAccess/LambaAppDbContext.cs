using LambaApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LambaApp.DataAccess
{
    public class LambaAppDbContext:DbContext
    {
        public LambaAppDbContext(DbContextOptions<LambaAppDbContext> options) : base(options)
        {

        }
        public DbSet<Lamba> Lambas{ get; set; }
        public DbSet<Deger> Degerler { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);


        }
    }
}
