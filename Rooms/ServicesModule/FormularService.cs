using Rooms.Entity;
using System.Collections.Generic;
using System.Linq;

namespace Rooms.ServicesModule
{
    public class FormularService
    {
        public void UpdateFormular(formular formular)
        {
            using (RoomsContext roomsContext = new RoomsContext())
            {

                var newStare = roomsContext.Formular.Max(x => x.StareFormular);

                var returnedFormular = roomsContext.Formular.Where(x => x.StareFormular == newStare).ToString();


                roomsContext.SaveChanges();
            }
        }       
    }

}
       
