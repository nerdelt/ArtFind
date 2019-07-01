﻿using System.Collections.Generic;
using System.Text;
using artfind.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using artfind.Models;

namespace artfind.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<AppUser>().Ignore(e => e.FullName);
        }

        public DbSet<artfind.Models.Artist> Artist { get; set; }
        public DbSet<artfind.Models.ArtPiece> ArtPiece{ get; set; }

    }
}