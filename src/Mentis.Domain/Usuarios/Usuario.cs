using Mentis.Domain.Constantes;
using Mentis.Domain.Contas;
using Mentis.Domain.Metas;

namespace Mentis.Domain.Usuarios
{
    public sealed class Usuario : BaseEntity
    {
        public Usuario() { }
        
        public Usuario(
            string nome, 
            string username, 
            string email, 
            string telefone, 
            string senha, 
            DateTime criadoEm)
        {
            Nome = nome;
            Username = username;
            Email = email;
            Telefone = telefone;
            Senha = senha;
            CriadoEm = criadoEm;
        }

        public string Nome { get; private set; }
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
        public string Senha { get; private set; }
        public DateTime CriadoEm { get; private set; }

        public ICollection<Conta> Contas { get; private set; }
        public ICollection<Meta> Metas { get; private set; }


        public Result Atualizar(string nome, string username, string email, string telefone, string senha)
        {
            if (!Ativo) return Result.Error(GenericConstantes.MensagensErros.RegistroInativoAtualizar);

            Nome = nome;
            Username = username;
            Email = email;
            Telefone = telefone;
            Senha = senha;

            return Result.Success();
        }
    }
}
