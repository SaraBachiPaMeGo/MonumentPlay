using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace MonumentPlay.Helpers
{
    public class HelperCifrado
    {
        public static byte[] CifrarPassword(String password, String salt)
        {
            String resultado = password + salt;
            SHA256Managed sha = new SHA256Managed();
            byte[] salida = Encoding.UTF8.GetBytes(resultado);

            for (int i = 1; i <= 20; i++)
            {
                salida = sha.ComputeHash(salida);
            }

            return salida;
        }

        public static String GenerarSalt()
        {
            Random rnd = new Random();
            String salt = "";

            for (int i = 1; i <= 50; i++)
            {
                int aleat = rnd.Next(1, 255);
                char letra =Convert.ToChar(aleat);
                salt += letra;
            }
            return salt;
        }
        public static bool CompararBytes(byte[] array1, byte[] array2)
        {
            if (array1.Length != array2.Length)
            {
                return false;
            }
            //COMPARAMOS LOS BYTES 

            bool iguales = true;

            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i].Equals(array2[i]) == false)
                {
                    iguales = false;
                    break;
                }
            }
            return iguales;
        }

    }
}