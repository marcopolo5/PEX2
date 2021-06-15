using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rooms.Entity
{
    [Table("formular")]
    public class formular
    {
        [Key]
        public int id { get; set; }
         
        public int studentID { get; set; }

        public int caminID { get; set; }

        public int cameraID { get; set; }

        public int nr_pat { get; set; }

        public virtual camera camera { get; set; }

        //public virtual camin camin { get; set; }

        public virtual student student { get; set; }

    }
}
