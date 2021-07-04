using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Rooms.Entity.Validation;



namespace Rooms.Entity
{
    public enum Rol_Utilizator
    {
        Administrator ,
        Membru 
    }
    [Table("utilizator")]
    public class utilizator
    {
    
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]       
        public int id { get; set; }

        [StringLength(50)]       
        public string username { get; set; }

        [Required]
        [StringLength(50)]
        public string password { get; set; }
        
        [Required]
        public string email { get; set; }
               
        [Required]
        [StringLength(50)]
        public string firstname { get; set; }

        [Required]
        [StringLength(50)]
        public string lastname { get; set; }

        public virtual student Student { get; set; }

        [Required]
        //[MaxLength(ValidationRules.userMinLength)]
        public Rol_Utilizator  Role { get; set; }


    }
}
