﻿using MonumentPlay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonumentPlay.Repositories
{
    public interface IRepositoryMonument 
    {
        Usuario GetUsuario(String nickName, String pass);
        Monumento GetMonumento(int idMon);
        List<UserMonument> GetMonumentUser(String nickname, String password);
        void InsertarUsuario(int idUser, String nombre, String email, String nickname, String password);
        void ActualizarUsuario(String nombre, String email, String nickname, String password);
    }
}