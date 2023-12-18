using BaltaIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaltaIO.Data.Context
{
    public class BaltaDbContext : DbContext
    {
        public BaltaDbContext(DbContextOptions options) : base(options) 
        {
            
        }
        public DbSet<IBGE> Cidades { get; set; }
    }
}
