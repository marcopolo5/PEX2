using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Rooms.Entity
{

    public enum Formular_Status
    {
        In_Asteptare,
        Admis,
        Respins,
    }

    [Table("formular")]
    public class formular
    {
        [Key]
        public int id { get; set; }
         
        public int studentID { get; set; }

        public int caminID { get; set; }

        public int cameraID { get; set; }

        public Formular_Status StareFormular { get; set; }

        public virtual camera camera { get; set; }

        //public virtual camin camin { get; set; }

        public virtual student student { get; set; }

    }
}
