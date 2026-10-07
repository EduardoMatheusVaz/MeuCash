using Mentis.Domain.Constantes;
using Mentis.Domain.Metas;
using Mentis.Domain.Usuarios;
using System.Reflection.Metadata.Ecma335;

namespace Mentis.Domain.Contas
{
    public sealed class Conta : BaseEntity
    {
        public Conta() { }
        
        public Conta(
            string numeroConta, 
            string agencia, 
            string banco, 
            decimal saldo, 
            Guid usuarioId)
        {
            NumeroConta = numeroConta;
            Agencia = agencia;
            Banco = banco;
            Saldo = saldo;
            UsuarioId = usuarioId;
        }

        public string NumeroConta { get; private set; }
        public string Agencia { get; private set; }
        public string Banco { get; private set; }
        public decimal Saldo { get; private set; }
        public Guid UsuarioId { get; private set; }

        public Usuario Usuario { get; private set; }
        public ICollection<Meta> Metas { get; private set; } = [];

        public Result Atualizar(string numeroConta, string agencia, string banco, decimal saldo)
        {
            // Criar e Atualizar precisam passar pela mesma porta de validação externa; 
            // a diferença é que o Criar produz uma nova entidade, enquanto o Atualizar
            // só modifica a existente depois que a nova informação foi validada.

            // A responsabilidade de garantir a integração vamos deixar na camada de Application
            // Pois senão o domínio vai acabar conhecendo Infra e não é o objetivo
            
            if (!Ativo) return Result.Error(GenericConstantes.MensagensErros.RegistroInativoAtualizar);

            NumeroConta = numeroConta;
            Agencia = agencia;
            Banco = banco;
            Saldo = saldo;

            return Result.Success();
        }
    }
}
