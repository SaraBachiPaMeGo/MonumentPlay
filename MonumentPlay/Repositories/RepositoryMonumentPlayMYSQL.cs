using MonumentPlay.Data;
using MonumentPlay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonumentPlay.Repositories
{
    public class RepositoryMonumentPlayMYSQL : IRepositoryMonument
    {
        IContextoMonument context;
        public RepositoryMonumentPlayMYSQL(IContextoMonument context)
        {
            this.context = context;
        }

        public Usuario GetUsuario(String nickName, String pass)
        {
            var consulta = from datos in context.Usuarios
                           where datos.NickName == nickName
                           && datos.Password == pass
                           select datos;

            return consulta.FirstOrDefault();
        }

        public Monumento GetMonumento(int idMon)
        {
            var consulta = from datos in context.Monumentos
                           where datos.IdMonumento == idMon
                           select datos;

            return consulta.FirstOrDefault();
        }

        public List<Monumento> GetMonumentUser(String nickname, String password)
        {
            Usuario user = GetUsuario(nickname, password);

            var consulta = from datos in context.UsuariosMonumentos
                           where datos.IdUser == user.IdUser
                           select datos.IdMonumento;

            Monumento mon = GetMonumento(consulta.FirstOrDefault());
            List<Monumento> monumetos  =  (List<Monumento>)consulta.Select(m => GetMonumento(m));

            return monumetos;
        }

        //public List<> 


        public void InsertarUsuario(int idUser, String nombre, String email, String nickname, String password)
        {
            Usuario user = new Usuario();

            user.IdUser = idUser;
            user.NombreUs = nombre;
            user.Email = email;
            user.NickName = nickname;
            user.Password = password;

            this.context.Usuarios.Add(user);
            this.context.SaveChanges();
        }

        public void ActualizarUsuario(String nombre, String email, String nickname, String password)
        {
            Usuario user = GetUsuario(nickname, password);

            nombre = user.NombreUs;
            email = user.Email;
            nickname = user.NickName;
            password = user.Password;

            this.context.SaveChanges();
        }

    }
}