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
        public List<formular> GetFormulars()
        {
            using (RoomsContext context = new RoomsContext())

            {                 var formulare_utilizator = (from formular in context.Formular.Where(x => x.StareFormular == 0).ToList()
                                                          select formular).ToList();


                return formulare_utilizator;
            }
        }

        public student GetStudent(int student_id)
        {
            using (RoomsContext context = new RoomsContext())
            {
                var student_form = (from student in context.Student.Where(x => x.id == student_id)
                                    select student).FirstOrDefault();

                return student_form;
            }
        }

    }
}
