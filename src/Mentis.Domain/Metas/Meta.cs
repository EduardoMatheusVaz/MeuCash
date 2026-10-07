using Mentis.Domain.Constantes;
using Mentis.Domain.Contas;
using Mentis.Domain.Usuarios;

namespace Mentis.Domain.Metas
{
    public sealed class Meta : BaseEntity
    {
        public Meta() { }

        public Meta(
            string nome, 
            string descricao, 
            decimal valorMeta, 
            DateTime prazo, 
            Guid usuarioId, 
            Guid contaId)
        {
            Nome = nome;
            Descricao = descricao;
            ValorMeta = valorMeta;
            Prazo = prazo;
            CriadoEm = DateTime.UtcNow;
            UsuarioId = usuarioId;
            ContaId = contaId;
        }

        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal ValorMeta { get; private set; }
        public DateTime Prazo { get; private set; }
        public DateTime CriadoEm { get; private set; }
        public Guid UsuarioId { get; private set; }
        public Guid ContaId { get; private set; }


        public Usuario Usuario { get; private set; }
        public Conta Conta { get; private set; }


        public static Result<Meta> Criar(
            string nome,
            string descricao,
            decimal valorMeta,
            DateTime prazo,
            DateTime criadoEm,
            Guid usuarioId,
            Guid contaId)
        {
            if (valorMeta <= 0) return Result<Meta>.Erro("Valor da meta deve que ser maior que 0!");
            if (prazo <= DateTime.UtcNow) return Result<Meta>.Erro("Prazo da meta deve ser maior que a data atual!");

            var meta = new Meta(
                nome: nome,
                descricao: descricao,
                valorMeta: valorMeta,
                prazo: prazo,
                usuarioId: usuarioId,
                contaId: contaId);
            
            meta.Ativar();

            return Result<Meta>.Sucesso(meta);
        }

        public Result Atualizar(string nome, string descricao, decimal valorMeta, DateTime prazo)
        {
            if (!Ativo) return Result.Error(GenericConstantes.MensagensErros.RegistroInativoAtualizar);
            if (valorMeta <= 0) return Result.Error("Valor da meta deve que ser maior que 0!");
            if (prazo <= DateTime.UtcNow) return Result.Error("Prazo da meta deve ser maior que a data atual!");

            Nome = nome;
            Descricao = descricao;
            ValorMeta = valorMeta;
            Prazo = prazo;

            return Result.Success();
        } 
    }
}
