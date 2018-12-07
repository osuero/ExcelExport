using PIP.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PIP.Data
{
    public class PIPContext: DbContext
    {
        public PIPContext():base("DefaultConnection")
        {

            Database.SetInitializer(new DropCreateDatabaseAlways<DbContext>());
        }

        public DbSet<Category> Category { get;set;}
        public DbSet<DataSheet> DataSheet { get; set; }
        public DbSet<Range> Range { get; set; }
        public DbSet<RegionData> RegionData { get; set; }
        public DbSet<TableInformation> TableInformation { get; set; }
    }

}