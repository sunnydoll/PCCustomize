using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PCCustomize.Models
{
    public class CustomizeDB : DbContext
    {
        public CustomizeDB() : base("name=DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }
        
        public DbSet<Computer> Computers { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Reply> Replies { get; set; }
    }
}