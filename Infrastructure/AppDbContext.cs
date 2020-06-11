using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
   public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)

        {

        }
        public DbSet<Owner> owners { get; set; }
        public DbSet<PortfileItems> PortfileItems { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Owner>().Property(x => x.id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<PortfileItems>().Property(x => x.id).HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Owner>().HasData(
                new Owner { 
                
                id = Guid.NewGuid(),FullName="mohamed ragab ",Avatar="avatar.jpg",profile="asp.net core web developer"
                
                
                }
                
                );

        }
    }
}
