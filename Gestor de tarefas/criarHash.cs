using System;
using System.Security.Cryptography;
using System.Text;

namespace Gestor_de_tarefas
{
    internal class criarHash
    {
        public static string GerarHash(string senha)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(senha));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in bytes)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }
    }
}
