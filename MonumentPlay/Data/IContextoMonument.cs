using MonumentPlay.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonumentPlay.Data
{
    public interface IContextoMonument
    {
        DbSet<Capital> Capitales { get; set; }
        DbSet<Continente> Continentes { get; set; }
        DbSet<Monumento> Monumentos { get; set; }
        DbSet<Pais> Paises { get; set; }
        DbSet<Usuario> Usuarios { get; set; }
        DbSet<Provincia> Provincias { get; set; }
        DbSet<PuebloCiudad> PueblosCiudades { get; set; }
        DbSet<UserMonument> UsuariosMonumentos { get; set; }
        int SaveChanges();

    }
}

