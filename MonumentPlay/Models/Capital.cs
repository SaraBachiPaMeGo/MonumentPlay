using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MonumentPlay.Models
{
    [Table("capital")]
    public class Capital
    {
        [Key]
        [Column("idCapital")]
        public int IdCapital { get; set; }

        [Column("NombreCap")]
        public String NombreCap { get; set; }
    }
}