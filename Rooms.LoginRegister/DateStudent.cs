using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rooms.Entity;
using Rooms;

namespace Rooms.LoginRegister
{
    public class DateStudent
    {
        public utilizator Utilizator;
        public student Valideaza_Date(float medie, string nr_telefon, string facultate,string nume, string prenume)
        {

            using (RoomsContext date_context = new RoomsContext())
            {
                date_context.Student.Add(new student()
                {
                    nume = nume,
                    prenume = prenume,
                    medie = medie,
                    nr_telefon = nr_telefon,
                    facultate = facultate,

                });
                date_context.SaveChanges();
                var newId = date_context.Student.Max(x => x.id);

                var returnedUser = date_context.Student.Where(x => x.id == newId).ToList().FirstOrDefault();
                return returnedUser;
            }
        }
    }
                
}
