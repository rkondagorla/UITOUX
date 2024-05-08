﻿using Microsoft.EntityFrameworkCore;
using UITOUX.Web.Service.Models;

namespace UITOUX.Web.Service.DBConfiguration
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Language> languages { get; set; }
    }
}
