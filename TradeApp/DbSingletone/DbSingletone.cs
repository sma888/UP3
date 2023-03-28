using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeApp.DbSingletone
{
    public static class DbSingletone
    {
        public static TradeEntities Db = new TradeEntities();
    }
}
