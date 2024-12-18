using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TheDogApp;
using TheDogApp.Components;

namespace TheDogApp.Data
{
    public class TheDogAppContext : DbContext
    {
        public TheDogAppContext (DbContextOptions<TheDogAppContext> options)
            : base(options)
        {
        }

        public DbSet<TheDogApp.Dog> Dog { get; set; } = default!;
        public DbSet<TheDogApp.Components.User> User { get; set; } = default!;
        public DbSet<TheDogApp.SiteUser> SiteUser { get; set; } = default!;
        public DbSet<TheDogApp.Event> Event { get; set; } = default!;
    }
}
