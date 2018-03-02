using FormationVueDotnet.Models;
using Microsoft.EntityFrameworkCore;

namespace FormationVueDotnet.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<Person> Persons { get; set; }
        public DbSet<ContactInfoPro> ContactInfoPros { get; set; }
        public DbSet<ContactInfoPerso> ContactInfoPersos { get; set; }
        public DbSet<Geo> Geos { get; set; }
        public DbSet<Skill> Skills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<ContactInfoPro>().ToTable("ContactInfoPro");
            modelBuilder.Entity<ContactInfoPerso>().ToTable("ContactInfoPerso");
            modelBuilder.Entity<Geo>().ToTable("Geo");
            modelBuilder.Entity<Skill>().ToTable("Skill");
        }
    }
}