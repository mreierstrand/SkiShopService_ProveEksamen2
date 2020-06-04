using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkiShopService.Model
{
    public class SkiContext : DbContext
    {
        public SkiContext(DbContextOptions<SkiContext> options) : base(options)
        {

        }

        public DbSet<SkiContext> SkiContextinMemory { get; set; }

    }
}
