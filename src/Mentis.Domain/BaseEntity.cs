using Mentis.Domain.Constantes;

namespace Mentis.Domain
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
            Ativo = true;
        }

        public Guid Id { get; private set; }
        public bool Ativo { get; private set; }
        public string? MotivoInativacao { get; private set; }
        public DateTime? DataInativacao { get; private set; }

        public Result Inativar(string motivoInativacao)
        {
            if (!Ativo)
                return Result.Error(GenericConstantes.MensagensErros.RegistroInativo);

            Ativo = false;
            MotivoInativacao = motivoInativacao;
            DataInativacao = DateTime.Now;

            return Result.Success();
        }

        public Result Ativar()
        {
            if (Ativo)
                return Result.Error(GenericConstantes.MensagensErros.RegistroAtivo);

            Ativo = true;
            MotivoInativacao = string.Empty;
            DataInativacao = null;

            return Result.Success();
        }
    }
}
