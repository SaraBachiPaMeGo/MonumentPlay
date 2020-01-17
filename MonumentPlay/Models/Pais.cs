using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MonumentPlay.Models
{
    [Table("pais")]
    public class Pais
    {
        [Key]
        [Column("idPais")]
        public int IdPais { get; set; }

        [Column("NombreP")]
        public String NombreP { get; set; }

        [Column("Continente_idContinente")]
        public int Continente_idContinente { get; set; }

    }
}