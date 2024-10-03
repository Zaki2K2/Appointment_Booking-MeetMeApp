using Microsoft.EntityFrameworkCore;
using MeetMeApp.Web.Models.Domain;
using MeetingApp.Models.Domain;

namespace MeetMeApp.Web.Data
{
    public class MeetMeDbContext : DbContext
    {
        public MeetMeDbContext(DbContextOptions<MeetMeDbContext> options) : base(options) { }



        public DbSet<User> Users { get; set; }


        public DbSet<Information> Informations { get; set; }
 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Information>()
                .HasKey(i => i.Info_id); // Ensure primary key is defined

            modelBuilder.Entity<User>()
                .HasKey(u => u.U_id); // Ensure primary key is defined
        }

    }
}
