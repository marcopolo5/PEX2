using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rooms
{
    [Table("utilizator")]


    public class utilizator
    {

        public enum Roluri_Utilizator
        {
            Administrator,
            Membru        }

        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string username { get; set; }

        [Required]
        [StringLength(50)]
        public string parola { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string email { get; set; }

        public int tipID { get; set; }

        public virtual Rol_Utilizator Rol_Utilizator { get; set; }
    }
}
