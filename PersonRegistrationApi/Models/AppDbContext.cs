using System;
using Microsoft.EntityFrameworkCore;
using PersonRegistrationShared;

namespace PersonRegistrationAPI.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<Person>().HasData(new Person
            {
                BirthDate = new DateTime(1990, 4, 20),
                City = "Porto",
                Email = "therock@tmail.com",
                PersonId = 1,
                FirstName = "Dwayne",
                LastName = "Johnson",
                Street = "Aliados 1",
                Zip = "4000",
            });

            modelBuilder.Entity<Person>().HasData(new Person
            {
                BirthDate = new DateTime(1980, 3, 23),
                City = "Porto",
                Email = "john.wick@tmail.com",
                PersonId = 2,
                FirstName = "Keanu",
                LastName = "Reeves",
                Street = "Trindade 2",
                Zip = "4000",
            });
        }
    }
}
