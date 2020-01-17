using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MonumentPlay.Models
{
    [Table("monumento")]
    public class Monumento
    {
        [Key]
        [Column("idMonumento")]
        public int IdMonumento { get; set; }

        [Column("NombreMon")]
        public String NombreMon { get; set; }
        [Column("Descripcion")]
        public String Descripcion { get; set; }
        [Column("Latitud")]
        public String Latitud { get; set; }
        [Column("Longitug")]
        public String Longitud { get; set; }

    }
}