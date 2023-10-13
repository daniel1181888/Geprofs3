using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Geprofs3.Models;

namespace Geprofs3.Data
{
    public class Geprofs3Context : DbContext
    {
        public Geprofs3Context (DbContextOptions<Geprofs3Context> options)
            : base(options)
        {
        }

        public DbSet<Geprofs3.Models.VerlofAanvraag> VerlofAanvraag { get; set; } = default!;
    }
}
