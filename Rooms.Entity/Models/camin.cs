using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rooms.Entity
{
    [Table("camin")]
    public class camin
    {
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string nume { get; set; }

        [Required]
        [StringLength(50)]
        public string adresa { get; set; }

        public int nr_camere { get; set; }

        public int nr_etaje { get; set; }

        public int nr_paturi { get; set; }

        public virtual ICollection<camera> Camera { get; set; }
        public virtual ICollection<formular> Formular { get; set; }

        public static implicit operator camin(formular v)
        {
            throw new NotImplementedException();
        }
    }
}
