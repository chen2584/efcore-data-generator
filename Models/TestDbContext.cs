using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TestEf.Models
{
    public class TestDbContext : DbContext
    {
        public DbSet<Customers> Customers { get; set; }
        public TestDbContext(DbContextOptions options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<Customers>()
                .Property(b => b.Created)
                .HasDefaultValue(DateTime.Now);

            modelBuilder.Entity<Customers>()
                .Property(b => b.LastVisited)
                .HasDefaultValue(DateTime.Now);
            
            modelBuilder.Entity<Customers>()
                .HasAlternateKey(p => p.UniqueId);*/
        }

    }

    public class DateData
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime Created { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime LastVisited { get; set; }
    }

    public class Customers : DateData
    {
        public int Id { get; set; }
        public int UniqueId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        /*[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime Created { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime LastVisited { get; set; }*/
    }
}