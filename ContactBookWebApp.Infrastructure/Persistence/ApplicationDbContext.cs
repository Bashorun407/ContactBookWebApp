using ContactBookWebApp.Domain.Entities;
using ContactBookWebApp.Infrastructure.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBookWebApp.Infrastructure.Persistence
{


    public class ApplicationDbContext: IdentityDbContext<UserEntity>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<UserEntity> UserEntities { get; set; }
    }
}
