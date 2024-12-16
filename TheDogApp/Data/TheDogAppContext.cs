using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TheDogApp;

namespace TheDogApp.Data
{
    public class TheDogAppContext : DbContext
    {
        public TheDogAppContext (DbContextOptions<TheDogAppContext> options)
            : base(options)
        {
        }

        public DbSet<TheDogApp.Dog> Dog { get; set; } = default!;
    }
}
