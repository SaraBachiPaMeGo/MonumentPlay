using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MonumentPlay.Models
{
    [Table("continente")]
    public class Continente
    {
        [Key]
        [Column("idContinente")]
        public int IdContinente { get; set; }

        [Column("NombreC")]
        public String NombreC { get; set; }
    }
}