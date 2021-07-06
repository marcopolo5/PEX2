using Rooms.Entity;
using System.Collections.Generic;
using System.Linq;

namespace Rooms.ServicesModule
{
    public class FormularService
    {
        public void UpdateFormular(formular formular)
        {
            using (RoomsContext context = new RoomsContext())
            {
               formular updateFormular = context.Formular.Where(x => x.id == formular.id).ToList().FirstOrDefault();
                updateFormular.cameraID = formular.studentID;
                updateFormular.caminID = formular.caminID;
                updateFormular.cameraID = formular.cameraID;
                updateFormular.StareFormular = formular.StareFormular;
                context.SaveChanges();
            }
        }       
    }

}
       
