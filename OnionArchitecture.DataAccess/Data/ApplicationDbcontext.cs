using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnionArchitecture.DataAccess.Entities;
using OnionArchitecture.DataAccess.Entities.Identities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnionArchitecture.DataAccess.Data
{
    public class ApplicationDbContext : DbContext //IdentityDbContext<AspNetUsers>
    {
        public ApplicationDbContext(DbContextOptions option) : base(option) { }
        public DbSet<CustomLog> CustomLogs{ get; set; }
    }
}
//ApplicationDbcontext