using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCore.Models
{
    public class ProblemContext : DbContext
    {
        public ProblemContext(DbContextOptions<ProblemContext> options)
           : base(options)
        {
        }

        public DbSet<ProblemItem> ProblemItems { get; set; }
    }
}
