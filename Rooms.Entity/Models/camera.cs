using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rooms.Entity
{
    [Table("camera")]
    public class camera
    {
        [Key]
        public int id { get; set; }

        public int nr_camera { get; set; }

        public int nr_paturi { get; set; }

        public int caminID { get; set; }

        public virtual camin camin { get; set; }
        public virtual ICollection<formular> Formular { get; set; }
    }
}
