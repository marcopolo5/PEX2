using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Rooms;
using Rooms.Entity;

namespace Rooms.LoginRegister
{
    public class Login
    {
        public utilizator Verificare_User(string email, string password)
        {
            using (RoomsContext context = new RoomsContext())
            {
                var verificare = context.Utilizator.Where(utilizator =>
                (utilizator.email == email) && utilizator.password == password).Select(utilizator => utilizator)
                                    .Cast<utilizator>();

                int nr_verificari = verificare.Count();

                if(nr_verificari!=1)
                        { 
                     throw new Exception ("Anyway....");
                }

                return verificare.FirstOrDefault();
            }
        }
    }
}
