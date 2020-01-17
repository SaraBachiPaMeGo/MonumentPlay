using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MonumentPlay.Models
{
    [Table("pueblociudad")]
    public class PuebloCiudad
    {
        [Key]
        [Column("idPuebloCiudad")]
        public int IdPuebloCiudad { get; set; }
        [Column("NombrePu")]
        public String NombrePu { get; set; }
    }
}