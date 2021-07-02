using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rooms.Entity;

namespace Rooms
{
    public class AdminFormularService
    {
        public List<formular> GetFormulars(utilizator utilizator)
        {
            using (RoomsContext context = new RoomsContext())
            {// aici E PROBLEMAAAAAAAAAAAAAAAAAAAAAA
             // AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA LA FORM CUM IL IAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
                var formulare_utilizator = (from formular in context.Formular
                                    where formular.id == formular.id
                                    select new formular()
                                    {
                                        id = formular.id,
                                        studentID = formular.studentID,
                                        caminID = formular.cameraID,
                                        nr_pat = formular.nr_pat
                                    }).ToList();
                return formulare_utilizator;
            }
        }

        
    }
}
