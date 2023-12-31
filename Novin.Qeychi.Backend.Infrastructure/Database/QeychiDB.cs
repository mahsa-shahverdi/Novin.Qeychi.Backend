﻿using Microsoft.EntityFrameworkCore;
using Novin.Qeychi.Backend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novin.Qeychi.Backend.Infrastructure.Database
{
    public class QeychiDB : DbContext
    {
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Entrepreneur> Entrepreneurs { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Stylist> Stylists { get; set; }
        public DbSet<BeautySalon> BeautySalons { get; set; }
        public DbSet<ConfirmationTurn> ConfirmationTurns { get; set; }
        public DbSet<ConfirmationWorkspace> ConfirmationWorkspaces { get; set; }
        public DbSet<ConfirmationEmployment> ConfirmationEmployments { get; set; }

        public QeychiDB(DbContextOptions<QeychiDB> options)
            : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Manager>().HasKey(x => x.Id);
            modelBuilder.Entity<Entrepreneur>().HasKey(x => x.Id);
            modelBuilder.Entity<Customer>().HasKey(x => x.Id);
            modelBuilder.Entity<Stylist>().HasKey(x => x.Id);
            modelBuilder.Entity<BeautySalon>().HasKey(x => x.Id);
            modelBuilder.Entity<ConfirmationTurn>().HasKey(x => x.Id);
            modelBuilder.Entity<ConfirmationWorkspace>().HasKey(x => x.Id);
            modelBuilder.Entity<ConfirmationEmployment>().HasKey(x => x.Id);
        }
    }
}
