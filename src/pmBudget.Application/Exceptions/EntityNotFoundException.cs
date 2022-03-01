using System.Globalization;

namespace pmBudget.Application.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string mensagem = "Entidade não encontrada") : base(mensagem) { }

        public EntityNotFoundException(string mensagem, params object[] args) : base(String.Format(CultureInfo.CurrentCulture, mensagem, args)) { }
    }
}
