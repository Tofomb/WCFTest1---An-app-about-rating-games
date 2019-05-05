using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFTest1.Model;

namespace WCFTest1
{
    public class WCFDBContext : DbContext
    {
        public WCFDBContext():base("WCFTest1DB")
        {

        }
        public DbSet<GameRating> GR { get; set; }
    }
}
