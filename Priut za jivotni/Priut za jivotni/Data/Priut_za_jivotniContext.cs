using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Priut_za_jivotni.Models;

namespace Priut_za_jivotni.Data
{
    public class Priut_za_jivotniContext : DbContext
    {
        public Priut_za_jivotniContext (DbContextOptions<Priut_za_jivotniContext> options)
            : base(options)
        {
        }

        public DbSet<Priut_za_jivotni.Models.Dogs> Dogs { get; set; } = default!;

        public DbSet<Priut_za_jivotni.Models.Cats> Cats { get; set; } = default!;
    }
}
