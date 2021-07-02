using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rooms.Entity;

namespace Student
{
    class getCamin
    {
        public List<camin> GetCamin()
        {
            using (RoomsContext context = new RoomsContext())
            {
                var camine = (from camin in context.Camin
                              select camin).ToList();

                return camine;
            }
        }
    }
}
