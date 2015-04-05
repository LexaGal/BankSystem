using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcMovie.Models
{
    public class ClientsDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
    }
}