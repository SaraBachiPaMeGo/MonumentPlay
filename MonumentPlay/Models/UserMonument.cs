using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MonumentPlay.Models
{
    [Table("user_has_monumento")]
    public class UserMonument 
    {
        [Key]
        [Column("User_idUser")]
        public int IdUsuarioMonu { get; set; }
        [Column("Monumento_idMonumento")]
        public int IdMonumentoUser { get; set; }
    }
}