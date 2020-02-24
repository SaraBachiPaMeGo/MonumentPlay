using MonumentPlay.Data;
using MonumentPlay.Helpers;
using MonumentPlay.Models;
using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
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
            byte[] passByte = Encoding.ASCII.GetBytes(pass);

            //Primero cojo el salt y después calculo el hash con el pass y el salt
            //var consulta = from datos in context.Usuarios
            //               where datos.NickName == nickName
            //               && datos.Password == passByte
            //               select datos;

            //Usuario user = consulta.FirstOrDefault();

            byte[] pass = HelperCifrado.CifrarPassword(passByte, User.salt);
            if (user!= null)
            {
                String salt = user.Salt;
                byte[] cifrado = HelperCifrado.CifrarPassword(pass, salt);
                bool resultado =HelperCifrado.CompararBytes(cifrado, user.Password);

                if (resultado == true)
                {
                    return user;
                }
                else
                {
                    return null;
                }
                //https://security.stackexchange.com/questions/120507/should-the-salt-of-a-bcrypt-hashed-password-be-stored-separately
                //string passwordHash = BCrypt.Net.BCrypt.HashPassword(pass);
                //InsertarSalt(pass);
                //bool correctPassword = BCrypt.Net.BCrypt.Verify(storedPassword, passwordHash);
            }
            else
            {
                return null;
            }

        }

        public Monumento GetMonumento(int idMon)
        {
            var consulta = from datos in context.Monumentos
                           where datos.IdMonumento == idMon
                           select datos;

            return consulta.FirstOrDefault();
        }

        public List<UserMonument> GetMonumentUser(String nickname, String password)
        {
            Usuario user = GetUsuario(nickname, password);

            var consulta = from datos in context.UsuariosMonumentos
                           where datos.IdUsuarioMonu == user.IdUser
                           select datos.IdMonumentoUser;

            Monumento mon = GetMonumento(consulta.FirstOrDefault());
            List<UserMonument> monumentos  =  (List<UserMonument>)consulta.Select(m => GetMonumento(m));

            return monumentos;
        }

        public void InsertarUsuario(String nombre, String email, String nickname, String password)
        {
            Usuario user = new Usuario();

            String salt = HelperCifrado.GenerarSalt();

            byte[] pass = HelperCifrado.CifrarPassword(password, salt);
            int? count = (from datos in context.Usuarios
                          select datos.IdUser).Count();

            if (count == 0)
            {
                user.IdUser = 1;
            }
            else 
            { 
                user.IdUser = this.context.Usuarios.Max(z => z.IdUser) + 1;
            }

            user.Salt = salt;
            user.NombreUs = nombre;
            user.Email = email;
            user.NickName = nickname;
            user.Password = pass;

            this.context.Usuarios.Add(user);
            this.context.SaveChanges();
        }

        public void ActualizarUsuario(String nombre, String email, String nickname, String password)
        {
            Usuario user = GetUsuario(nickname, password);

            user.NombreUs =nombre;
            user.Email = email;
            user.NickName = nickname;

            byte[] passByte = Encoding.ASCII.GetBytes(password);
            user.Password= passByte;

            this.context.SaveChanges();
        }

        //public String InsertarSalt(String pass)
        //{
        //    string passwordHash = BCrypt.Net.BCrypt.HashPassword(pass);
        //    return passwordHash;
        //}

    }
}