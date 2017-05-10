using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ExpenceTracker.Models
{
    public class ExpencesContext:DbContext
    {
        public DbSet<Expences> Expences { get; set; }
    }
}