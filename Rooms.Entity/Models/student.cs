using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rooms.Entity
{
    [Table("student")]
    public class student
    {
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string nume { get; set; }

        [Required]
        [StringLength(50)]
        public string prenume { get; set; }

        public double medie { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string nr_telefon { get; set; }

        [Required]
        [StringLength(50)]
        public string facultate { get; set; }

        public int raspuns { get; set; }

        public virtual ICollection<formular> Formular { get; set; }
    }
}
