using CRM.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.Repository
{
    public class CrmDbContext:XDbContext,ICrmDbContext
    {
        public CrmDbContext(DbContextOptions options):base(options)
        {

        }    
        public DbSet<Person> People { get; set; }
        
    }
}
