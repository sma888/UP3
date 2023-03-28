using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeApp.Core
{
    public class Functions
    {
        public class Verificate
        {

            public bool Check(string login, string password)
            {
                using (var db = new TradeEntities())
                {
                    var result = db.User.FirstOrDefault(user => user.Login == login && user.Password == password);

                    if (result != null)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}
