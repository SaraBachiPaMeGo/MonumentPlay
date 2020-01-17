using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MonumentPlay.Models;

namespace MonumentPlay.Data
{
    public class ContextoMonumentMYSQL : DbContext, IContextoMonument
    {
        public ContextoMonumentMYSQL() : base("name=conexionmonumentMYSQL")
        { }

        public DbSet<Capital> Capitales { get ; set ; }
        public DbSet<Continente> Continentes { get; set; }
        public DbSet<Monumento> Monumentos { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<PuebloCiudad> PueblosCiudades { get; set; }
    }
}