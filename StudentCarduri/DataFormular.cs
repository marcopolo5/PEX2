using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rooms.Entity;

namespace StudentCarduri
{
    class DataFormular
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

        public List<camera> GetCamere(int idCamin)
        {
            using (RoomsContext context = new RoomsContext())
            {
                var camere = (from camera in context.Camera
                              where camera.caminID == idCamin
                              select camera).ToList();

                return camere;
            }
        }

        public formular VerificareFormular(int idUser, int idCamin, int idCamera)
        {
            using (RoomsContext context = new RoomsContext())
            {
                var verificare = context.Formular
                    .Where(formular => (formular.caminID == idCamin)
                && formular.cameraID == idCamera && formular.studentID == idUser)
                    .Select(formular => formular)

                    .Cast<formular>();

                int nr_verificari = verificare.Count();

                if (nr_verificari == 0)
                {
                    context.Formular.Add(new formular()
                    {
                        studentID = idUser,
                        caminID = idCamin,
                        cameraID = idCamera,
                        StareFormular = 0
                    });
                    context.SaveChanges();
                    var newId = context.Formular.Max(x => x.id);
                    var returnedFormular = context.Formular.Where(x => x.id == newId).ToList().FirstOrDefault();
                    return returnedFormular;
                }
                else
                {
                    throw new Exception("Ai selectat aceasta varianta");
                }


            }
        }
    }
}
