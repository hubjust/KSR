using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Database
{
    public partial class DbDataContext : DataContext
    {
        public DbDataContext(IDbConnection connection) : base(connection)
        {
        }

        public System.Data.Linq.Table<FifaPlayer> FifaPlayer
        {
            get
            {
                return GetTable<FifaPlayer>();
            }
        }
    }
}
