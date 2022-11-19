namespace ProjetoMuralis.Auxiliares
{
    public interface IEmail
    {
        bool Enviar(string email,string asssunto,string mensagem);
    }
}
