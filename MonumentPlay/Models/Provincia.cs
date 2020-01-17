using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MonumentPlay.Models
{
    [Table("provincia")]
    public class Provincia
    {
        [Key]
        [Column("idProvincia")]
        public int IdProvincia { get; set; }
        [Column("NombreProv")]
        public String NombreProv { get; set; }
        [Column("Pais_idPais")]
        public int Pais_idPais { get; set; }

        [Column("Continente_idContinente")]
        public int Continente_idContinente { get; set; }

    }
}