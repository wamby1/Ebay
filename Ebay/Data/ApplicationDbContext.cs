 using Ebay.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ebay.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Artikel> artikels { get; set; }
        public DbSet<ArtikelImage> artikelsImage { get; set; }
        public DbSet<Kommentar> kommentar { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
