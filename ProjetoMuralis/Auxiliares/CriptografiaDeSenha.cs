using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace ProjetoMuralis.Auxiliares
{
    public static class CriptografiaDeSenha
    { 
        // Cripitografa a senha do usuario antes de adicionalo ao banco
        public static string GerarHash(this string senha)
        {
            //Metodo de criptografia
            var hash = SHA1.Create();
            var encoding = new ASCIIEncoding();
            var array = encoding.GetBytes(senha);

            array = hash.ComputeHash(array);

            var strgSenha= new StringBuilder();
            foreach(var s in array)
            {
                strgSenha.Append(s.ToString("x2"));
            }
            return strgSenha.ToString();
        }
    }
}
