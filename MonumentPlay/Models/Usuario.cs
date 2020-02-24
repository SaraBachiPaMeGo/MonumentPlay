using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MonumentPlay.Models
{
    [Table("user")]
    public class Usuario
    {
        [Key]
        [Column("idUser")]
        public int IdUser { get; set; }
        [Column("NombreUs")]
        public String NombreUs { get; set; }
        [Column("Email")]
        public String Email { get; set; }
        [Column("NickName")]
        public String NickName { get; set; }
        [Column("Password")]
        public byte[] Password { get; set; }

        [Column("Salt")]
        public String Salt { get; set; }

    }
}