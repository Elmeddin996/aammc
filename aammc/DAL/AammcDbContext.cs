using aammc.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace aammc.DAL
{
    public class AammcDbContext: IdentityDbContext
    {

        public AammcDbContext(DbContextOptions<AammcDbContext> options) : base(options) { }


        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Transport> Transports { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
		public DbSet<Partner> Partners { get; set; }



    }
}
