using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Rooms
{
    [Table("tip")]
    public class tip
    {
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string rol { get; set; }

        public virtual ICollection<utilizator> Utilizator { get; set; }
    }
    
}
