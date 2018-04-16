using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptSharp;
namespace WebApplication.Util
{

    public static class Criptografia
    {
        public static string Codifica(string senha)
        {
            return Crypter.Sha512.Crypt(senha);
        }

        public static bool Compara(string senha, string hash)
        {

            return Crypter.CheckPassword(senha,hash);
        }
    }

}
