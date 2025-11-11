using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using test123.Models;


namespace test123.Data
{
    public class test123DbContext : DbContext
    {
        public test123DbContext() : base("PersonConnection") { }
        public DbSet<Person> Personen {  get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>()
                .Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}